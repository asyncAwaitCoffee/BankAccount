function formatCard(stringData, isInput) {
    if (isInput) {
        return stringData.replace(/(\d{4})(\d{1})+$/, "$1 $2");
    }
    return stringData.replace(/(\d{4})(\d{4})(\d{4})(\d{4})/, "$1 $2 $3 $4");
}

function formatValidThru(dateString) {
    return dateString.replace(/\d{2}(\d{2})-(\d{2}).*/, "$2/$1");
}