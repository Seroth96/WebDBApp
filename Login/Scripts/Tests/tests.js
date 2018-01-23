function showTest() {
       // alert($("#SelectedTest").val());
        $.ajax({
            type: "POST",
            url: "/Tests/ShowTest",
            data: {
            "id": $("#SelectedTest").val()
            },
            success: function (data) {
                $("#TestContent").html(data);
                $("#errorPlaceHolder").hide();
            },
            error: function (xhr) {
                $("#errorPlaceHolder").show();
                $("#errorPlaceHolder").html(xhr.responseText);                
            }
        });    
};

function getResult() {
    $.ajax({
        type: "POST",
        url: "/Tests/GetResult",
        data: $("form").serialize(),
        success: function (data) {
            //alert(data);
            $("#resultOfTest").text(data);
            $("#errorPlaceHolder").hide();
            $("#resultDiv").show();
        },
        error: function (xhr) {
            $("#errorPlaceHolder").show();
            $("#errorPlaceHolder").html(xhr.responseText);
        }
    });
};