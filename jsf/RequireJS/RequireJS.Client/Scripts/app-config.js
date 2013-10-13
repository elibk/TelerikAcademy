/// <reference path="libs/require.js" />
require.config({
	paths: {
	    jquery: "libs/jquery-1.9.1",
		rsvp: "libs/rsvp.min",
		httpRequester: "libs/http-requester",
		mustache: "libs/mustache",
		kendoWeb: "kendo/2013.2.716/kendo.web.min",
		dataPersister: "app/data-persister",
		controls: "app/controls",
		sammy: "libs/sammy-0.7.4",
		"class": "libs/class"

	}
});

require(["jquery", "app/task01", "app/task02", "mustache", "sammy"], function ($, task01, task02, mustache, sammy) {

    $(document).ready(function () {

        var app = sammy("#content", function () {
            this.get("#/", function () {
                var tasksTemplate = mustache.compile(document.getElementById("home-template").innerHTML);
                $('#content').html(tasksTemplate());
            });

            this.get("#/task01", function () {
                console.log("task01");
                task01.action();
            });

            this.get("#/task02", function () {
                console.log("task02");
               
                task02.action();
            });
            this.get("#/marks/:id", function (id) {
                alert("In item with id: " + this.params["id"]);
            });
        });
        app.run("#/");

       //$('#btnTask01').on('click', task01.action);
      
       //// $('#btnTask03').on('click', task03);
    });
    
});