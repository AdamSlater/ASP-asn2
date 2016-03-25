var app = angular.module("client", ["ngResource"]);

app.controller('ctrl', function ($scope) {
    $scope.url = "/forms/register.html";

    $scope.register = function () {
        var username, email, password, confirmpass;
        var url = "http://a2api.adamslatertech.com/api/Account/Register";
        username = $("#username").val();
        email = $("#email").val();
        password = $("#pwd").val();
        confirmpass = $("#cpwd").val();

        var param = {
            Username: username,
            Email: email,
            Password: password,
            ConfirmPassword: confirmpass
        };

        $.ajax({
            url: url,
            type: 'POST',
            contentType: 'application/json;charset=utf-8',
            data: JSON.stringify(param)
        }).done(function (data) {
            console.log(data);
            $("#message").html("<p style='color:green'>Register: SUCCESS</p>");
        }).fail(function (err) {
            console.warn(err);
            $("#message").html("<p style='color:red'>Register: Please try again!</p>");
        });
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
            $("#message").html("<p style='color:green'>Sign In: SUCCESS</p>");
        }).fail(function (err) {
            console.warn(err);
            $("#message").html("<p style='color:red'>Sign In: Please try again!</p>");
        });
    };
});

jQuery(document).ready(function ($) {
    $(".tab").on("click", function () {
        $(this).addClass("active").siblings().removeClass("active");
    });
});

