/// <reference path="class.js" />
/// <reference path="jquery-2.0.2.js" />

var httpRequester = (function () {
    getJSON = function (url, success, error) {
        $.ajax({
            url: url,
            type: "GET",
            contentType: "application/json",
            timeout: 5000,
            success:success,
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





















//var person = {
//    "username": "Dodo",
//    "authCode": "6fa9133efe05348e430bd5a4585b595f0cb6cba3"
//}

//httpRequester.postJSON("http://localhost:40643/api/user/login", person, function () {
//    alert("Success");
//},
//function () {
//    alert("Error");
//});









































//var httpRequester = (function () {
//    function getJSON(url, success, error) {
//        $.ajax({
//            url: url,
//            type: "GET",
//            timeout: 5000,
//            contentType: "application/json",
//            success: success,
//            error: error
//        });
//    }

//    function postJSON(url, data, success, error) {
//        $.ajax({
//            url: url,
//            type: "POST",
//            timeout: 5000,
//            contentType: "application/json",
//            data: JSON.stringify(data),
//            success: success,
//            error: error
//        })
//    }

//    return {
//        getJSON: getJSON,
//        postJSON: postJSON
//    }
//}());

//var user = {
//    "username": "Dodo",
//    "authCode": "6fa9133efe05348e430bd5a4585b595f0cb6cba3"
//}

//httpRequester.postJSON("http://localhost:40643/api/user/login", user,
//    function () {
//    alert("Success");
//    },
//    function () {
//        alert("Error");
//    }
//);