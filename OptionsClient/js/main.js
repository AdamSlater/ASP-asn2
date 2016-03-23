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
        }).fail(function (err) { console.warn(err); });
    };

    $scope.signin = function () {
        var username, password;
        username = $("#username").val();
        password = $("#pwd").val();
    };
});

jQuery(document).ready(function ($) {
    $(".tab").on("click", function () {
        $(this).addClass("active").siblings().removeClass("active");
    });
});

