/// <reference path="jquery-2.0.2.js" />

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