window.persisters = (function () {

    var username = localStorage.getItem("username");
    var accessToken = localStorage.getItem("accessToken");

    var clearUserData = function () {
        localStorage.removeItem("username");
        localStorage.removeItem("accessToken");
        username = null;
        accessToken = null;
    };

    var saveUserData = function (userData) {
        localStorage.setItem("username", userData.username);
        localStorage.setItem("accessToken", userData.accessToken);
        username = userData.username;
        accessToken = userData.accessToken;
    };

    var DataPersister = Class.create({
        init: function (apiUrl, id) {
            this.apiUrl = apiUrl;
            this.users = new UsersPersister(apiUrl + "users/");
            this.appointments = new AppointmentsPersister(apiUrl + "appointments/");
            this.todos = new TodosPersister(apiUrl + "lists/");
        },
        isUserLoggedIn: function () {
            if (username !== null && accessToken !== null) {
                return true;
            }

            return false;
        },
        getNickname: function () {
            return false
        },
        getSessionKey: function () {
            return false;
        }
    });
	var UsersPersister = Class.create({
		init: function (apiUrl) {
			this.apiUrl = apiUrl;
		},
		login: function (username, password) {
			var user = {
				username: username,
				authCode: CryptoJS.SHA1(password).toString()
			};

			return requester.postJSON("api/auth/token", user)
				.then(function (data) {
				    saveUserData(data);
					return data;
				});
		},
		register: function (username, password, email) {
		    /*{
		        "username" : "Georgi",
                "firstName" : "Georgi",
                "lastName" : "Georgiev",
                "email": "abv@abv.bg",
                "password": "7c4a8d09ca3762af61e59520943dc26494f8941b"
		    }*/
			var user = {
			    username: username,
                email: email,
                authCode: CryptoJS.SHA1(password).toString()
			};

			return requester.postJSON(this.apiUrl + "register", user)
				.then(function (data) {
				    return data;
				});
		},
		logout: function () {
		    if (!accessToken) {
		        console.log("you accessToken is expired");
		    }
		    else {
		        var headers = {
		            "X-accessToken": accessToken
		        };
		        clearUserData();
		        return requester.putJSON(this.apiUrl, headers);
		    }
		},

		getProducts: function () {
		    var headers = {
		        "X-sessionKey": sessionKey
		    };

		    return requester.getJSON(this.apiUrl + "my-products", headers);
        }
	});

	var AppointmentsPersister = Class.create({
	    init: function (apiUrl) {
	        this.apiUrl = apiUrl;
	    },

	    createAppointment: function (subject, description, appointmentDate, duration) {
	        var headers = {
	            "X-accessToken": accessToken
	        };

	        var appointment = {
	            subject: subject,
	            description: description,
	            appointmentDate: appointmentDate,
	            duration: duration
	        }

	        return requester.postJSON(this.apiUrl, appointment, headers);
	    },

	    all: function () {
	        var headers = {
	            "X-accessToken": accessToken
	        };

	        return requester.getJSON(this.apiUrl + "all", headers);
	    },
	});

	var TodosPersister = Class.create({
	    init: function (apiUrl) {
	        this.apiUrl = apiUrl;
	    },

	    all: function () {
	        var headers = {
	            "X-accessToken": accessToken
	        };

	        return requester.getJSON(this.apiUrl, headers);
	    }
	});

	return {
		get: function (apiUrl) {
			return new DataPersister(apiUrl);
		}
	}
}());