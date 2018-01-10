function showLoadingPanel() {
    $("#loading").addClass("loading-visible");
}

function hideLoadingPanel() {
    $("#loading").removeClass("loading-visible");
    setLoadingMessage("");
}

function setLoadingMessage(message) {
    $("#loadingMessage").text(message);
}

function showLoadingPanel(message) {
    $("#loading").addClass("loading-visible");
    $("#loadingMessage").text(message);
}
