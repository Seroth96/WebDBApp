function loginUser() {
    if ($("form").valid()) {
        //showLoadingPanel("TRWA LOGOWANIE");
        $.ajax({
            type: "POST",
            url: "/Login/Login",
            data: $("form").serialize(),
            success: function (data) {
                if (!data) window.location.href = "/Home/Index";
                else {
                    hideLoadingPanel();                    
                }
            },
            error: function (xhr) {
                $("#errorPlaceHolder").show();
                $("#errorPlaceHolder").html(xhr.responseText);
                hideLoadingPanel();
            }
        });
    }
};

function registerUser() {
    if ($("form").valid()) {
        //showLoadingPanel("TRWA WYSYŁANIE");
        $.ajax({
            type: "POST",
            url: "/Login/Register",
            data: $("form").serialize(),
            success: function (data) {
                window.location.href = "/Login";
                $("#errorPlaceHolder").hide();
            },
            error: function (xhr) {
                $("#errorPlaceHolder").show();
                $("#errorPlaceHolder").html(xhr.responseText);
               // hideLoadingPanel();
            }
        });
    }
};

function showLoginView() {
    window.location.href = "/Login";
};

function resetPassword() {
    if ($("form").valid()) {
        //showLoadingPanel("TRWA WYSYŁANIE");
        $.ajax({
            type: "POST",
            url: "/Login/ResetPassword",
            data: $("form").serialize(),
            success: function (data) {
                window.location.href = "/Login";
            },
            error: function (xhr) {
            $("#errorPlaceHolder").show();
            $("#errorPlaceHolder").html(xhr.responseText);
           // hideLoadingPanel();
        }
        });
    }
}

function logout() {
        $.ajax({
            type: "GET",
            url: "/Login/Logout",
            success: function () { 
            },
            error: function (xhr) {
            }
        });
    
};