/// <reference path="class.js" />
/// <reference path="persister.js" />
/// <reference path="jquery-2.0.2.js" />

var controllers = (function () {
    var rootUrl = "http://localhost:40643/api/";

    var Controller = Class.create({
        init: function () {
            this.persister = persisters.get(rootUrl);
        },
        loadUI: function (selector) {
            if (this.persister.isUserLoggedIn()) {
                this.loadGameUI(selector);
            }
            else {
                this.loadLoginFormUI(selector);
            }
            this.attachUIEventHandlers(selector);
        },
        loadLoginFormUI: function (selector) {
            var loginFormHtml =
                '<form>' +
                    '<label for="tb-login-username">Username: </label>' +
                    '<input type="text" id="tb-login-username">' +
                    '<label for="tb-login-password">Password: </label>' +
                    '<input type="text" id="tb-login-password">' +
                    '<button type="text" id="btn-login">login</button>' +
                '</form>';
            $(selector).html(loginFormHtml);

        },
        loadGameUI: function (selector) {
        },
        attachUIEventHandlers: function (selector) {
            var wrapper = $(selector);
            var self = this;
            wrapper.on("click", "#btn-login", function () {
                var user = {
                    username: $(selector + " #tb-login-username").val(),
                    password: $(selector + " #tb-login-password").val()

                };

                self.persister.user.login(user, function () {
                    wrapper.html("yupii")
                }, function () {
                    wrapper.html("oh nooo....");
                });
                return false; //stops the page reloading
            });
            wrapper.on("click", "#btn-register", function () {

            });
        }

    });

    return {
        get: function () {
            return new Controller();
        }
    }

}());

$(function () {
    var controller = controllers.get();
    controller.loadUI("#wrapper");
});