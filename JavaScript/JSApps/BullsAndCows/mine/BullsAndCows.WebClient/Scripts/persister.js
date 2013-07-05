/// <reference path="class.js" />
/// <reference path="http-requester.js" />
/// <reference path="http://crypto-js.googlecode.com/svn/tags/3.1.2/build/rollups/sha1.js" />

var persisters = (function () {
    var nickname = localStorage.getItem("nickname");
    var sessionKey = localStorage.getItem("sessionKey");

    function saveUserData(userdata) {
        debugger;
        localStorage.setItem("nickname", userdata.nickname);
        localStorage.setItem("sessionKey", userdata.sessionKey);
        nickname = userdata.nickname;
        sessionKey = userdata.sessionKey;
    }

    function clearUserData() {
        localStorage.removeItem("nickname");
        localStorage.removeItem("sessionKey");
        nickname = "";
        sessionKey = "";
    }

    var MainPersiter = Class.create({
        init: function (rootUrl) {
            this.rootUrl = rootUrl;
            this.user = new UserPersister(this.rootUrl);
            this.game = new GamePersister(this.rootUrl);
        },

        isUserLoggedIn: function () {
            debugger;
            var isLogged = (nickname != null && sessionKey != null);
            return isLogged;
        },

        nickname: function () {
            return nickname;
        }

    });

    var UserPersister = Class.create({
        init: function (rootUrl) {
            this.rootUrl = rootUrl + "user/";
        },

        login: function (user, success, error) {
            debugger;
            var url = this.rootUrl + "login";
            var userData = {
                username: user.username,
                authCode: CryptoJS.SHA1(user.username + user.password).toString()
            };

            httpRequester.postJSON(url, userData,
                function (data) {
                    saveUserData(data);
                    success(data);
            }, error);
        },

        register: function (user, success, error) {
            var url = this.rootUrl + "register";
            var userData = {
                username: user.username,
                nickname: user.nickname,
                authCode: CryptoJS.SHA1(user.username + user.password).toString()
            };

            httpRequester.postJSON(url, userData,
                function (data) {
                    saveUserData(data);
                    success(data);
                }, error);
        },

        logout: function (success, error) {
            var url = this.rootUrl + "logout/" + sessionKey;

            httpRequester.getJSON(url, function (data) {
                clearUserData();
                success(data);
            }, error);
        },

        scores: function(success, error) {
        }
    });

    var GamePersister = Class.create({
        init: function (rootUrl) {
            this.rootUrl = rootUrl + "game/";

        },

        create: function (game, success, error) {
			var gameData = {
				title: game.title,
				number: game.number
			};
			if (game.password) {
				gameData.password = CryptoJS.SHA1(game.password).toString();
			}
			var url = this.rootUrl + "create/" + sessionKey;
			httpRequester.postJSON(url, gameData, success, error);
		},

        join: function (game, success, error) {
            var gameData = {
                gameId: game.gameId,
                number: game.number
            };

            if (game.password) {
                gameData.password = CryptoJS.SHA1(game.password).toString();
            }

            var url = this.rootUrl + "join/" + sessionKey;
            httpRequester.postJSON(url, gameData, success, error);
        },

        start: function () {
        },

        myActive: function (success, error) {
            var url = this.rootUrl + "my-active/" + sessionKey;
            httpRequester.getJSON(url, success, error);
        },

        open: function (success, error) {
            var url = this.rootUrl + "open/" + sessionKey;
            httpRequester.getJSON(url, success, error);
        },

        state: function () {
        }
    });

    var GuessPersister = Class.create({
        init: function () {
        },

        make: function () {
        }
    });

    var MessagesPersister = Class.create({
        init: function () {
        },

        unread: function () {
        },

        all: function () {
        }
    });

    return {
        getPersister: function(url) {
            return new MainPersiter(url);
        }
    }

}());

//var bcPersister = persisters.getPersister("http://localhost:40643/api/");

//var user1 = {
//    username: "Joro",
//    password: "joro"
//};

//bcPersister.user.login(user1, function (data) {
//    alert(JSON.stringify(data));
//},
//function (err) {
//    alert(JSON.stringify(err));
//});

//var user2 = {
//    username: "Hristo",
//    nickname: "hristaki",
//    password: "itseto"
//}

//bcPersister.user.register(user2, function (data) {
//    alert(JSON.stringify(data))
//},
//    function (err) {
//        alert(JSON.stringify(err))
//    }
//);

//bcPersister.user.logout(function(data) {
//    alert(JSON.stringify(data))
//},
//    function (err) {
//        alert(JSON.stringify(err))
//    }
//);


// localhost: 40643/api/user/login
// localhost: 40643/api/game/create
// localhost: 40643/api/game/join
// localhost: 40643/api/messages/all