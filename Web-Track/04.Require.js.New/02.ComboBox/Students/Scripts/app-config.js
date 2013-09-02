/// <reference path="Scripts/Libs/require.js" />
/// <reference path="Scripts/Libs/jquery-2.0.3.js" />
/// <reference path="Scripts/Libs/mustache.js" />
/// <reference path="Libs/http-requester.js" />
/// <reference path="Scripts/App/data-persister.js" />

require.config({
    paths: {
        jquery: "Libs/jquery-2.0.3",
        rsvp: "Libs/rsvp.min",
        httpRequester: "Libs/http-requester",
        dataPersister: "App/data-persister",
        mustache: "Libs/mustache",
        classCreator: "Libs/class",
        controlls: "App/controlls",
        controllsList: "App/controllsList"
    }
});

require(["jquery", "httpRequester", "dataPersister", "mustache", "controlls", "controllsList"],
    function ($, httpRequester, data, mustache, controlls, controllsList) {
    data.people()
        .then(function (people) {
            var templateString = $("#people-template").html();
            var template = mustache.compile(templateString);

            var listView = controlls.listView(people);
            var listViewHtml = listView.render(template);
            $("#container").append(listViewHtml);
        },
        function (err) {
            console.log(err);
        });

    $("#container").on("change", "select", function () {
        var studentId = $(this).children(":selected").data("id");
        var marks = httpRequester.getJSON("http://localhost:13448/api/students/" + studentId)
            .then(function (marks) {
                var arr = [];
                arr.push(marks);

                var marksTemplateString = $("#marks-template").html();
                var template = mustache.compile(marksTemplateString);

                var listView = controllsList.listView(arr);
                var listViewHtml = listView.render(template);
                //$("#container").hide();
                //$("#students-marks").show();
                $("#students-marks").empty()
                $("#students-marks").append(listViewHtml);
                //$('#students-marks').append("<button id='back'>Back</back>");
            },
        function (err) {
            console.log(err);
        });
        
    });

    //$("#students-marks").on("click", "#back", function () {
    //    $("#students-marks").empty();
    //    $("#students-marks").hide();
    //    $("#container").show();
    //});
});