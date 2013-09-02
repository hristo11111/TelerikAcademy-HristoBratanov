/// <reference path="../libs/_references.js" />
window.persisters = (function () {
    var username = localStorage.getItem("username");
    var sessionKey = localStorage.getItem("sessionKey");

    function saveUserData(userData) {
        localStorage.setItem("username", userData.username);
        localStorage.setItem("sessionKey", userData.sessionKey);
        nickname = userData.nickname;
        sessionKey = userData.sessionKey;
    }

    function clearUserData() {
        localStorage.removeItem("username");
        localStorage.removeItem("sessionKey");
        username = "";
        sessionKey = "";
    }

    function getJSON(requestUrl, headers) {
        var promise = new RSVP.Promise(function (resolve, reject) {
            $.ajax({
                url: requestUrl,
                type: "GET",
                dataType: "json",
                headers: headers,
                success: function (data) {
                    resolve(data);
                },
                error: function (err) {
                    reject(err);
                }
            });
        });
        return promise;
    }

    function postJSON(requestUrl, data, headers) {
        var promise = new RSVP.Promise(function (resolve, reject) {
            $.ajax({
                url: requestUrl,
                type: "POST",
                contentType: "application/json",
                data: JSON.stringify(data),
                dataType: "json",
                headers: headers,
                success: function (data) {
                    resolve(data);
                },
                error: function (err) {
                    reject(err);
                }
            });
        });
        return promise;
    }

    function putJSON(requestUrl, data, headers) {
        var promise = new RSVP.Promise(function (resolve, reject) {
            $.ajax({
                url: requestUrl,
                type: "PUT",
                contentType: "application/json",
                data: JSON.stringify(data),
                dataType: "json",
                headers: headers,
                success: function (data) {
                    resolve(data);
                },
                error: function (err) {
                    reject(err);
                }
            });
        });
        return promise;
    }

    var UserPersister = Class.create({
        init: function (apiUrl) {
            this.apiUrl = apiUrl;
        },

        login: function (username, password) {
            var user = {
                username: username,
                authCode: CryptoJS.SHA1(password).toString()
            }

            return postJSON(this.apiUrl + "login", user)
                .then(function (data) {
                    saveUserData(data);
                    sessionKey = data.sessionKey;
                    username = data.username;
                    return data.username;
                });
        },

        register: function (username, password) {
            var user = {
                username: username,
                authCode: CryptoJS.SHA1(password).toString()
            };

            return postJSON(this.apiUrl + "register", user)
                .then(function (data) {
                    saveUserData(data);
                    sessionKey = data.sessionKey;
                    username = data.username;
                    return data.username;
                });
        },

        logout: function () {
            if (!sessionKey) {
                throw new ("Invalid session key!")
            }
            var headers = {
                "X-sessionKey": sessionKey
            }

            clearUserData();
            return putJSON(this.apiUrl + "logout", headers);
        },

        //????
        currentUser: function () {
            return username;
        }
    });

    var CarsPersister = Class.create({
        init: function (apiUrl) {
            this.apiUrl = apiUrl;
        },

        all: function () {
            return getJSON(this.apiUrl);
        }
    });

    var StoresPersister = Class.create({
    });

    var DataPersister = Class.create({
        init: function (apiUrl) {
            this.apiUrl = apiUrl;
            this.users = new UserPersister(apiUrl + "users/");
            this.cars = new CarsPersister(apiUrl + "cars/");
            this.stores = new StoresPersister(apiUrl + "stores/");
        }
    });

    return {
        get: function (apiUrl) {
            return new DataPersister(apiUrl);
        }
    }
}());