fetchCardData(-1);

document
    .getElementById("cards-drop-list")
    .addEventListener("change", (ev) => { fetchCardData(ev.target.value) })

async function fetchCardData(cardId) {
    await fetch(`/api/account/card/${cardId}`)
        .then(response => response.json())
        .then(data => {
            code.textContent = formatCard(data.card.code, false);
            holder.textContent = data.client.name;
            type.textContent = data.card.type;
            valid.textContent = formatValidThru(data.card.date);
            balance.textContent = data.account.balance;

            while (transfersHistory.firstChild) {
                transfersHistory.removeChild(transfersHistory.firstChild);
            }

            for (const history of data.transfersHistoryFrom) {
                const div = document.createElement("div");
                div.style.color = "red";
                div.textContent = `${history.amount} - ${history.dateTime}`;
                transfersHistory.appendChild(div);
            }

            for (const history of data.transfersHistoryTo) {
                const div = document.createElement("div");
                div.style.color = "green";
                div.textContent = `${history.amount} - ${history.dateTime}`;
                transfersHistory.appendChild(div);
            }            
        });
}