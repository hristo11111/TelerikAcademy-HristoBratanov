/// <reference path="class.js" />
/// <reference path="persister.js" />
/// <reference path="jquery-2.0.2.js" />


var controllers = (function () {
    var rootUrl = "http://localhost:40643/api/"

    var Controller = Class.create({
        init: function () {
            this.persister = persisters.getPersister(rootUrl)
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
                    '<button id="btn-login">login</button>' +
                '</form>'
            $(selector).html(loginFormHtml);
        },

        loadGameUI: function (selector) {
            var html =
                '<span id="user-nickname">' +this.persister.nickname() + '</span>' +
                '<button id="btn-logout">Logout</button>' +
                '<br />' +
                'Title: <input type="text" id="tb-create-title"/>' + '<br />' +
                'Password: <input type="text" id="tb-create-pass"/>' + '<br />' +
                'Number: <input type="text" id="tb-create-number"/>' + '<br />' +
                '<button id="btn-create-game">Create</button>' +
                '<h2>Open</h2>' +
                '<div id="open-games-container"></div>' +
                '<h2>Active</h2>' +
                '<div id="active-games-container"></div>'
            $(selector).html(html);

            this.persister.game.open(function (games) {
                var list = "<ul>";

                for (var i = 0; i < games.length; i++) {
                    var game = games[i];

                    list +=
                        '<li data-game-id = "' + game.id + '">' +
                            '<a href="#">' +
                                $("<div />").html(game.title).text() +
                            '</a>' +
                            '<span>' +
                                " by " + game.creatorNickname +
                            '</span>'
                        '</li>';
                }

                list += "</ul>"
                $(selector + " #open-games-container").html(list);
            });

            this.persister.game.myActive(function (games) {
                var list = "<ul>";

                for (var i = 0; i < games.length; i++) {
                    var game = games[i];

                    list +=
                        '<li>' +
                            game.title +
                        '</li>';
                }

                list += "</ul>"
                $(selector + " #active-games-container").html(list);
            });
        },

        attachUIEventHandlers: function (selector) {
            var wrapper = $(selector);
            var self = this;
            wrapper.on("click", "#btn-login", function () {
                var user = {
                    username: $(selector + " #tb-login-username").val(),
                    password: $(selector + " #tb-login-password").val()
                }

                self.persister.user.login(user, function () {
                    debugger;
                    self.loadGameUI(selector);
                }, function () {
                    wrapper.html("oh no");
                });

                return false;
            });

            wrapper.on("click", "#btn-logout", function () {
                self.persister.user.logout(function () {
                    self.loadLoginFormUI(selector);
                });
            });

            wrapper.on("click", "#open-games-container a",
                function () {
                    $("#game-join-inputs").remove();
                    var html =
                        '<div id="game-join-inputs">' +
                            'Number: <input type="text" id="tb-game-number"/>' +
                            'Password: <input type="text" id="tb-game-pass"/>' +
                            '<button id="btn-join-game">Join</button>' +
                        '</div>';
                    $(this).after(html)
                });

            wrapper.on("click", "#btn-join-game",
                function () {
                    var game = {
                        number: $("#tb-game-number").val(),
                        gameId: $(this).parents("li").first().data("game-id")
                    };

                    var password = $("#tb-game-pass").val();

                    if (password) {
                        game.password = password;
                    }

                    self.persister.game.join(game);
                });

            wrapper.on("click", "#btn-create-game",
                function () {
                    var game = {
                        title: $("#tb-create-title").val(),
                        number: $("#tb-create-number").val(),
                    }

                    var password = $("#tb-create-pass").val();

                    if (password) {
                        game.password = password;
                    }

                    self.persister.game.create(game);
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