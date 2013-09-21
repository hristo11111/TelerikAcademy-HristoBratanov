/// <reference path="../Libs/require.js" />

define(["httpRequester"], function (httpRequester) {
    function getPeople() {
        return httpRequester.getJSON("http://localhost:13448/api/students");
    }

    return {
        people: getPeople
    }
});