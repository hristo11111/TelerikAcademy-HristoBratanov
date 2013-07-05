/// <reference path="jquery-2.0.2.js" />
/// <reference path="class.js" />

var httpRequester = (function () {
    getJSON = function (url, success, error) {
        $.ajax({
            url: url,
            type: "GET",
            contentType: "application/json",
            timeout: 5000,
            success: success,
            error: error
        })
    };

    postJSON = function (url, data, success, error) {
        $.ajax({
            url: url,
            type: "POST",
            data: JSON.stringify(data),
            contentType: "application/json",
            timeout: 5000,
            success: success,
            error: error
        })
    }

    return {
        getJSON: getJSON,
        postJSON: postJSON
    }
}());

//var user = {
//    "username": "Dodo",
//    "authCode": "6fa9133efe05348e430bd5a4585b595f0cb6cba3"
//};

//httpRequester.postJSON("http://localhost:40643/api/user/login", user, function () {
//    alert("Sucess");
//},
//function () {
//    alert("Error");
//});

