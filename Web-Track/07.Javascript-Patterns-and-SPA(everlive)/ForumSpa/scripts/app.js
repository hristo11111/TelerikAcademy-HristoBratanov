/// <reference path="app/ui.js" />
/// <reference path="libs/sha1.js" />
/// <reference path="libs/require.js" />
/// <reference path="libs/jquery-2.0.3.js" />
/// <reference path="libs/sha1.js" />
/// <reference path="app/listView.js" />
/// <reference path="app/controlls.js" />
/// <reference path="app/comboBox.js" />

(function () {
    require.config({
        paths: {
            jquery: "libs/jquery-2.0.3",
            mustache: "libs/mustache",
            sammy: "libs/sammy-0.7.4",
            rsvp: "libs/rsvp.min",
            "http-requester": "libs/http-requester",
            listView: "app/listView",
            comboBox: "app/comboBox",
            controlls: "app/controlls"
            ui: "app/ui",
            sha1: "libs/sha1",
        }
    })

    require(["jquery", "sammy", "mustache", "http-requester", "listView", "comboBox", "controlls", "ui", "sha1"],
					function ($, sammy, mustache, request, listView, comboBox, controlls, sha1) {
					    //var nickname = localStorage.getItem("nickname");
					    //var sessionKey = localStorage.getItem("sessionKey");

					    //$(function () {
					    //    var mygames = document.getElementById("my-games");
					    //    if (mygames) {
					    //        mygames.href = "#game/my-active/" + sessionKey;
					    //    }

					    //    var joingames = document.getElementById("join-games");
					    //    if (joingames) {
					    //        joingames.href = "#game/open/" + sessionKey;
					    //    }

					    //    var logoutForm = document.getElementById("logout-form");
					    //    if (logoutForm) {
					    //        logoutForm.setAttribute("action", "#/user/logout/" + sessionKey);
					    //    }
                            
                            //TODO: add the other elements which use sessionKey
					    //});

					    var app = sammy("#main-content", function () {
					        //function saveUserData(userData) {
					        //    localStorage.setItem("nickname", userData.nickname);
					        //    localStorage.setItem("sessionKey", userData.sessionKey);
					        //    nickname = userData.nickname;
					        //    sessionKey = userData.sessionKey;
					        //}

					        //function clearUserData() {
					        //    localStorage.removeItem("nickname");
					        //    localStorage.removeItem("sessionKey");
					        //    nickname = "";
					        //    sessionKey = "";
					        //}

					        //function clearActionHolder() {
					        //    $("#action-holder").empty();
					        //}

					        this.get("#/register-login", function () {
					            if (nickname) {
					                $("#action-holder").append('<p>You are logged!</p>');
					                throw "There is logged user in the system!"
					            }

					            controlls.loadRegisterLoginForm();

					            $("#action-holder").html(ui.registerLoginForm);
					        });

					        //this.get("#/game/join", function () {
					        //    alert("bau");
					        //});

					        this.post("#/user/register", function () {
					            if (nickname) {
					                $("#action-holder").append('<p>You are logged!</p>');
					                throw "There is logged user in the system!"
					            }

					            var username = $("#user-name").val();
					            var nickname = $("#nick-name").val();
					            var password = $("#password").val();

					            var userData = {
					                username: username,
					                nickname: nickname,
					                authCode: CryptoJS.SHA1(username + password).toString()
					            };

					            request.postJSON("api/user/register", userData)
									.then(function (data) {
									    saveUserData(data);
									    alert("User registered and logged successful");
									    clearActionHolder();
									    $("#main-content").prepend(
                                            '<form id="logout-form" action="#/user/logout" method="put">' +
                                                '<input type="submit" value="Logout" />' +
                                            '</form>');
									    var mygames = document.getElementById("my-games");
									    mygames.href = "#game/my-active/" + sessionKey;
									    var joingames = document.getElementById("join-games");
									    joingames.href = "#game/open/" + sessionKey;
									    document.getElementById("logout-form").setAttribute("action", "#/user/logout/" + sessionKey);
									});
					        });

					        this.post("#/user/login", function () {
					            if (nickname) {
					                clearMainContent();
					                $("action-holder").append('<p>You are logged!</p>');
					                throw "There is logged user in the system!"
					            }

					            var username = $("#user-name").val();
					            var password = $("#password").val();

					            var userData = {
					                username: username,
					                authCode: CryptoJS.SHA1(username + password).toString()
					            }

					            request.postJSON("api/user/login", userData)
									.then(function (data) {
									    saveUserData(data);
									    alert("User logged successful");
									    clearActionHolder();
									    $("#main-content").prepend(
                                            '<form id="logout-form" action="#/user/logout" method="put">' +
                                                '<input type="submit" value="Logout" />' +
                                            '</form>');
									    var mygames = document.getElementById("my-games");
									    mygames.href = "#game/my-active/" + sessionKey;
									    var joingames = document.getElementById("join-games");
									    joingames.href = "#game/open/" + sessionKey;
									    document.getElementById("logout-form").setAttribute("action", "#/user/logout/" + sessionKey);
									});
					        });

					        this.put("#/user/logout/:sessionKey", function () {
					            var json = "";
					            request.putJSON("api/user/logout/" + this.params["sessionKey"], json);
					            clearUserData();
					            $("#logout-form").remove();
					            $("#action-holder").html(ui.registerLoginForm)
					        });

					        this.get("#game/my-active/:sessionKey", function () {
					            request.getJSON("api/game/my-active/" + this.params["sessionKey"])
									.then(function (games) {
									    $("#action-holder").html(ui.myGamesUI(sessionKey));
									    var gamesList = $('<ul/>').addClass("games-list");
									    var templateString = $("#game-template").html();
									    var template = mustache.compile(templateString);
									    for (var i in games) {
									        var game = games[i];
									        var templatedGame = template(game);
									        var gameItem =
												$("<li />")
													.addClass("game-item")
														.html(templatedGame);

									        var viewFieldBtn = $('<a href="#/game/field/' + sessionKey + '/' + game.id + '" id="view-field-btn">View field</a>');
									        gameItem.append(viewFieldBtn);
									        gamesList.append(gameItem);
									    }
									    $("#active-games").html(gamesList);
									});
					        });

					        this.get("#game/open/:sessionKey", function () {
					            request.getJSON("api/game/open/" + this.params["sessionKey"])
									.then(function (games) {
									    $("#action-holder").html(ui.joinGamesUI);
									    var gamesForm = $('<form id="open-games-form" method="post"></form>');
									    var gamesList = $('<ul/>').addClass("games-list");
									    var templateString = $("#game-join-template").html();
									    var template = mustache.compile(templateString);
									    for (var i in games) {
									        var game = games[i];
									        var templatedGame = template(game);
									        var gameItem =
												$("<li />")
													.addClass("game-item")
														.html(templatedGame);
									        gamesList.append(gameItem);
									    }
									    gamesForm.append(gamesList);
									    $("#open-games").html(gamesForm);
									    document.getElementById("open-games-form").setAttribute("action", "#/game/join/" + sessionKey);
									});
					        });

					        this.get("#/game/field/:sessionKey/:gameId", function () {
					            request.getJSON("api/game/field/" + this.params["sessionKey"] + "?gameId=" + this.params["gameId"])
									.then(function (fieldItems) {
									    var fieldList = $('<ul/>').addClass("field-list");
									    var templateString = $("#field-template").html();
									    var template = mustache.compile(templateString);
									    var templatedField = template(fieldItems);
									    fieldList.append(templatedField);
									    fieldList.append(ui.fieldUI);
									    $("#action-holder").html(fieldList);
									    var myTable = document.getElementById('field-table');
									    var blueunits = fieldItems.blue.units;
									    var redunits = fieldItems.red.units;
									    for (var i = 0; i < blueunits.length; i++) {
									        var xPosition = blueunits[i].position.x;
									        var yPosition = blueunits[i].position.y;

									        myTable.rows[xPosition].cells[yPosition].innerHTML = "blue";
									    }

									    for (var i = 0; i < redunits.length; i++) {
									        var xPosition = redunits[i].position.x;
									        var yPosition = redunits[i].position.y;

									        myTable.rows[xPosition].cells[yPosition].innerHTML = "red";
									    }
									});
					        });

					        this.post("#/Game/create/:sessionKey", function () {
					            var title = $("#game-title").val();

					            var gameData = {
					                title: title
					            }

					            request.postJSON("api/game/create/" + this.params["sessionKey"], gameData)
									.then(function (data) {

									});
					        });

					        this.post("#/game/join/:sessionKey", function () {
					            var title = $("#game-title").val();

					            var gameId = $(".selected").attr("data-id");

					            var gameData = {
					                id: gameId
					            }

					            request.postJSON("api/game/join/" + this.params["sessionKey"], gameData)
									.then(function (data) {

									});
					        });
					    });

					    app.run("#/");

					    $("header").on("click", "#login-btn", function () {
					        $("#nick-name").hide();
					        $("#register-login-header").html("Login form");
					        document.getElementById("register-login-form").setAttribute("action", "#/user/login");
					    });
					    $("header").on("click", "#register-btn", function () {
					        $("#nick-name").show();
					        $("#register-login-header").html("Register form");
					        document.getElementById("register-login-form").setAttribute("action", "#/user/register");
					    });
					    $("#action-holder").on("click", "input", function () {
					        $(this).addClass("selected");
					    });
					});
}());

