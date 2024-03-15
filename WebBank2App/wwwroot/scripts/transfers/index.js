document
    .getElementById("transfer-type")
    .addEventListener("change", (ev) => {
        for (const form of document.getElementsByClassName("form-transfer")) {
            form.classList.add("display-none");
        }

        const theForm = document.getElementById(`form-transfer-${ev.target.value}`);
        theForm.classList.remove("display-none");
    })

document
    .getElementById("form-transfer-own")
    .addEventListener("submit", ev => {
        ev.preventDefault();
        const formData = new FormData(ev.target);
        fetch("/api/account/transfer", {
            method: "POST",
            body: formData
        })
            .then(response => response.json())
            .then(data => {
                console.log(data);
                if (data.ok) {
                    console.log("Ok.");
                } else {
                    document
                        .getElementsByClassName("result")[0]
                        .textContent = data.message;
                }
            });
    })

document
    .getElementById("form-transfer-code")
    .addEventListener("submit", ev => {
        ev.preventDefault();
        const formData = new FormData(ev.target);
        fetch("/api/account/transfer", {
            method: "POST",
            body: formData
        })
            .then(response => response.json())
            .then(data => {
                if (data.ok) {
                    console.log("Ok.");
                } else {
                    document
                        .getElementsByClassName("result")[1]
                        .textContent = data.message;
                }
            });
    })

document
    .querySelector("input[name='cardCodeTo']")
    .addEventListener("input", ev => {
        if (ev.inputType == "deleteContentBackward") {
            return;
        }
        ev.target.value = formatCard(ev.target.value, true)
    })