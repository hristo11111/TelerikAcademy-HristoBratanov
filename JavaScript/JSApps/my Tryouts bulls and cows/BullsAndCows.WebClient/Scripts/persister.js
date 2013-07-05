/// <reference path="class.js" />
/// <reference path="http-requester.js" />
/// <reference path="jquery-2.0.2.js" />
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
        nickname = '';
        sessionKey = '';
    }

    var MainPersister = Class.create({
        init: function (rootUrl) {
            this.rootUrl = rootUrl;
            this.user = new UserPersister(this.rootUrl);
            this.game = new GamePersister(this.rootUrl);
        }
    });

    var UserPersister = Class.create({
        init: function (rootUrl) {
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

        logout: function(success, error) {
            var url = this.rootUrl + "logout/" + sessionKey;

            httpRequester.getJSON(url,
                function(data) {
                    clearUserData();
                    success(data);
                }, error);
        },

        isLoggedIn: function () {
            var isLogged = (localStorage.getItem("nickname") != null && localStorage.getItem("sessionKey") != null)
            return isLogged;
        }
    });

    var GamePersister = Class.create({
        init: function (rootUrl) {
            this.rootUrl = rootUrl + "game/"
        },

        open: function (success, error) {
            var url = this.rootUrl + "open/" + sessionKey;

            httpRequester.getJSON(url,success, error);
        },

        myActive: function (success, error) {
            var url = this.rootUrl + "my-active/" + sessionKey;

            httpRequester.getJSON(url, success, error);
        },

    });

    return {
        getPersister: function (url) {
            return new MainPersister(url);
        }
    }
}());