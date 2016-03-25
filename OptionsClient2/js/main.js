var app = angular.module("client", ["ngResource"]);

app.controller('ctrl', function ($scope, $location) {
    $scope.url = "/forms/register.html";

    $scope.register = function () {
        var username, email, password, confirmpass;
        var url = "http://a2api.adamslatertech.com/api/Account/Register";
        username = $("#username").val();
        email = $("#email").val();
        password = $("#pwd").val();
        confirmpass = $("#cpwd").val();

        $("#username-error").hide();
        $("#email-error").hide();
        $("#password-error").hide();
        $("#confirmpassword-error").hide();
         
        var param = {
            Username: username,
            Email: email,
            Password: password,
            ConfirmPassword: confirmpass
        };

        var result = validate(param);
        var isValid = true;
        if (result.Username != null) {
            $scope.username_valid = result.Username;
            $("#username-error").show();
            isValid = false;
        }

        if (result.Email != null) {
            isValid = false;
            $("#email-error").show();
            $scope.email_valid = result.Email;
        }

        if (result.Password != null) {
            isValid = false;
            $("#password-error").show();
            $scope.password_valid = result.Password;
        }

        if (result.ConfirmPassword != null) {
            isValid = false;
            $("#confirmpassword-error").show();
            $scope.confirmpassword_valid = result.ConfirmPassword;
        }

        if (!isValid) {
            $location.path("/forms/register.html");
        } else {
            $('#loadingmessage').show();
            $.ajax({
                url: url,
                type: 'POST',
                contentType: 'application/json;charset=utf-8',
                data: JSON.stringify(param)
            }).done(function (data) {
                console.log("success" + data);
                $('#loadingmessage').hide();
                $('#success').show();
                console.log("success");
            }).fail(function (err) {
                console.warn(err);
                $('#loadingmessage').hide();
                $('#fail').show();
                console.log("fail");
            });
        }  
    };

    $scope.signin = function () {
        var username, password;
        username = $("#username").val();
        password = $("#pwd").val();

        var param = {
            grant_type: "password",
            Username: username,
            Password: password
        };

        $.ajax({
            type: 'POST',
            url: 'http://a2api.adamslatertech.com/Token',
            data: param
        }).done(function (data) {
            console.log(data);
            document.cookie = "access_token=" + data["access_token"];
        }).fail(function (err) { console.warn(err); });
    };
});

function validate(param) {
    var id_regex = new RegExp("^(A00[0-9]{6,6})$");
    var email_regex = new RegExp("^\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*$");
    var password_regex = new RegExp("^(?=(.*\\d))(?=(.*\\W)).{7,}")
    console.log(email_regex.exec(param.Email));

    var result = {
        Username: null,
        Email: null,
        Password: null,
        ConfirmPassword: null
    };

    if (id_regex.exec(param.Username) == null) {
        console.log(id_regex.exec("username " + param.Username));
        result.Username = "Empty or Invalid Username, Please use Student Id";
    }
    if (email_regex.exec(param.Email) == null) {
        console.log(email_regex.exec("email " + param.Email));
        result.Email = "Empty or Invalid Email";
    }

    if (password_regex.exec(param.Password) == null && param.Password != null) {
        result.Password = "Password must be 7 characters long, and contain at least one number and one special character.";
    }

    if ((param.Password != param.ConfirmPassword) && param.ConfirmPassword != null) {
        result.ConfirmPassword = "Password did not match";
    }
   
    return result;
}

jQuery(document).ready(function ($) {
    $(".tab").on("click", function () {
        $(this).addClass("active").siblings().removeClass("active");
    });
});

