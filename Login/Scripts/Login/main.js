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

function deleteAccessory() {
    alert($("#SelectedAccesory").val());
        $.ajax({
            type: "POST",
            url: "/Accessory/DeleteAccessory",
            data: {
                "selectedAccesory":$("#SelectedAccesory").val()
        },
            success: function (data) {
                window.location.href = "/Hall";
                $("#errorPlaceHolder").hide();
            },
            error: function (xhr) {
                $("#errorPlaceHolder").show();
                $("#errorPlaceHolder").html(xhr.responseText);
                // hideLoadingPanel();
            }
        });    
}