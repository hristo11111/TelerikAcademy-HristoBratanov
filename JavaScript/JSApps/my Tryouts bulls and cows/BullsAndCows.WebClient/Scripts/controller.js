/// <reference path="class.js" />
/// <reference path="http-requester.js" />
/// <reference path="jquery-2.0.2.js" />
/// <reference path="persister.js" />
/// <reference path="ui.js" />

var controllers = (function () {
    var rootUrl = "http://localhost:40643/api/";

    var Controller = Class.create({
        init: function () {
            this.persister = persisters.getPersister(rootUrl);
        },

        loadGameUI: function (selector) {
            this.persister.game.open(function (data) {
                var html = ui.openGamesAttachment(data);
                $(selector).append(html);
            });

            this.persister.game.myActive(function (data) {
                var html = ui.myActiveGameAttachment(data);
                $(selector).append(html);
            });
        },

        loadUI: function (selector) {
            if (this.persister.user.isLoggedIn()) {
                var html = ui.loggedHtml;
                $(selector).html(html);
                this.loadGameUI(selector);
            }
            else {
                var html = ui.loginForm;
                $(selector).html(html);
            }
            this.attachUIEventHandlers(selector);
        },

        attachUIEventHandlers: function (selector) {
            var wrapper = $(selector);
            var self = this;

            wrapper.on("click", "#btn-register", 
                function() {
                    var user = {
                        username: $(selector + " #tb-input-username").val(),
                        nickname: $(selector + " #tb-input-nickname").val(),
                        password: $(selector + " #tb-input-password").val()
                    }

                    self.persister.user.register(user, 
                        function() {
                            self.loadUI(selector);
                        });

                    return false;
                });

            wrapper.on("click", "#btn-login",
                function () {
                    var user = {
                        username: $(selector + " #tb-input-username").val(),
                        password: $(selector + " #tb-input-password").val()
                    }

                    self.persister.user.login(user,
                        function () {
                            self.loadUI(selector);
                        });

                    return false;
                });

            wrapper.on("click", "#btn-logout",
                function () {
                    self.persister.user.logout(
                        function () {
                            self.loadUI(selector);
                        });
                });

            wrapper.on("click", "#all-open-games a",
                function () {
                    $("#game-join-inputs").remove();
                    var html =
                        '<div id="game-join-inputs">' +
                            '<label for="tb-join-game-number">Number</label>' +
                            '<input type="text" id="tb-join-game-number"/>' +
                            '<label for="tb-join-game-password">Password</label>' +
                            '<input type="text" id="tb-join-game-password"/>' +
                            '<button id="btn-join">Join</button>' +
                        '</div>'
                    $(this).after(html);
                });

            wrapper.on("click", "#btn-join", 
                function() {
                    
                })

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