/// <reference path="../libs/_references.js" />
window.persisters = (function () {
    var username = localStorage.getItem("username");
    var sessionKey = localStorage.getItem("sessionKey");

    function saveUserData(userData) {
        localStorage.setItem("username", userData.UserName);
        localStorage.setItem("sessionKey", userData.SessionKey);
        username = userData.UserName;
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

    function putJSON(serviceUrl, headers, data) {
        var promise = new RSVP.Promise(function (resolve, reject) {
            $.ajax({
                url: serviceUrl,
                type: "PUT",
                headers: headers,
                contentType: "application/json",
                data: JSON.stringify(data),
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
                    sessionKey = data.SessionKey;
                    username = data.UserName;
                    return data.UserName;
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
                    sessionKey = data.SessionKey;
                    username = data.UserName;
                    return data.UserName;
                });
        },

        logout: function () {
            if (!sessionKey) {
                alert("your sessionKey is expired");
            }
            var headers = {
                "X-sessionKey": sessionKey
            }

            clearUserData();
            return putJSON(this.apiUrl + "logout", headers);
        },

        getUser: function () {
            if (!sessionKey) {
                alert("your sessionKey is expired");
            }
            var headers = {
                "X-sessionKey": sessionKey
            }

            return getJSON(this.apiUrl, headers);
        },

        deposit: function (amount) {
            if (!sessionKey) {
                alert("your sessionKey is expired");
            }
            var headers = {
                "X-sessionKey": sessionKey
            }

            var transaction = {
                amount: amount,
                type: "deposit"
            }

            return postJSON(this.apiUrl + "deposit", transaction, headers)
                .then(function (data) {
                    return data;
                });
        },

        withdraw: function (amount) {
            if (!sessionKey) {
                alert("your sessionKey is expired");
            }
            var headers = {
                "X-sessionKey": sessionKey
            }

            var transaction = {
                amount: amount,
                type: "withdraw"
            }

            return postJSON(this.apiUrl + "withdraw", transaction, headers)
                .then(function (data) {
                    return data;
                });
        },

        currentUser: function () {
            return username;
        }
    });

    var TransactionPersister = Class.create({
        init: function (apiUrl) {
            this.apiUrl = apiUrl;
        },

        getTransactions: function () {
            if (!sessionKey) {
                alert("your sessionKey is expired");
            }
            var headers = {
                "X-sessionKey": sessionKey
            }

            return getJSON(this.apiUrl, headers);
        },
    });

    var DataPersister = Class.create({
        init: function (apiUrl) {
            this.apiUrl = apiUrl;
            this.users = new UserPersister(apiUrl + "users/");
            this.transactions = new TransactionPersister(apiUrl + "transactions/");
        }
    });

    return {
        get: function (apiUrl) {
            return new DataPersister(apiUrl);
        }
    }
}());