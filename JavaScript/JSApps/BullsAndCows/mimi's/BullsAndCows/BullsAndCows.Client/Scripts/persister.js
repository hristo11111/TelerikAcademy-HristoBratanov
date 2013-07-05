/// <reference path="http-Request.js" />
/// <reference path="class.js" />
///<reference path = "http://crypto-js.googlecode.com/svn/tags/3.1.2/build/rollups/sha1.js" />


var persisters = (function () {

    var nickname = localStorage.getItem("nickname");
    var sessionKey = localStorage.getItem("sessionKey");

    function saveUserData(userData) {
        localStorage.setItem("nickname", userData.nickname);
        localStorage.setItem("sessionKey", userData.sessionKey);
        nickname = userData.nickname;
        sessionKey = userData.sessionKey;

    }

    function clearUserData() {
        localStorage.removeItem("nickname");
        localStorage.removeItem("sessionKey");
        nickname = "";
        sessionKey = "";
    }

    var MainPersister = Class.create({
        init: function (rootUrl) {
            this.rootUrl = rootUrl;
            this.user = new UserPersister(this.rootUrl);
        },
        isUserLoggedIn: function () {
            var isLogged = (nickname != null && sessionKey != null);
            return isLogged;
        }
    });

    var UserPersister = Class.create({
        init: function (rootUrl) {
            //..api/user/
            this.rootUrl = rootUrl + "user/";
        },
        login: function (user, success, error) {
            var url = this.rootUrl + "login";
            var userData = {
                username: user.username,
                authCode: CryptoJS.SHA1(user.username + user.password).toString()
            };
            httpRequester.postJSON(url, userData,
                function (data) {
                    saveUserData(data);
                    success(data);
                },error);
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
            //api/user/logout/sessionKey
            var url = this.rootUrl + "logout/"+ sessionKey;
            httpRequester.getJSON(url, function (data) {
                clearUserData();
                success(data);
            }, error)
        },
        scores: function (success, error) {
        }
    });

    var GamePersister = Class.create({
        init: function () {
        },
        cretate: function () {
        },
        join: function () {
        },
        start: function () {
        },
        myActive: function () {
        },
        open: function () {
        },
        state: function () {
        },
    });

    var GuessPersister = Class.create({
        init: function () {
        },
        make: function () {
        },
    });

    var MessagesPersister = Class.create({
        init: function () {
        },
        unread: function () {
        },
        all: function () {
        },
    });

    return {
        get: function (url) {
            return new MainPersister(url);
        }
    }
    
}());


//var bcPersister =
//    persisters.get()("http://localhost:40643/api/");

//var user = {
//    username: "Krem",
//    nickname: "karamel",
//    password: "kremkaramel"
//}

//bcPersister.user.register(user, function (data) {
//    alert(JSON.stringify(data));
//}, function (err) {
//    alert(JSON.stringify(err));
//});

//bcPersister.user.login(user, success, error);
//bcPersister.game.create(game, success, error);
//bcPersister.messages.all();

