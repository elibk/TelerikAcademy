/// <reference path="_references.js" />
 

require.config({
    paths: {
        jquery: "libs/jquery-2.0.3",
        rsvp: "libs/rsvp.min",
        httpRequester: "libs/http-requester",
        mustache: "libs/mustache",
        dataProvider: "app/dataProvider",
        controls: "app/controls",
        "views": "app/views",
        sammy: "libs/sammy-0.7.4",
        "class": "libs/class",
        cryptoJs: "libs/sha1",
        underscore: "libs/underscore",
        kendoWeb: "kendo/2013.2.716/kendo.web.min"
       
    }
});

require(["jquery", "app/controller", "sammy"], function ($, controllerApp, sammy) {
    function onLoadNav(viewControler, dataProvider) {
        if (dataProvider.isUserLoggedIn()) {
            viewControler.renderNav($("#nav-loged-template").html(), { nickname: dataProvider.nickname() });
        }
        else {
            viewControler.renderNav($("#nav-notloged-template").html());
        }
    }
    $(document).ready(function () {
      
        var navSelector = 'header > nav';
        var contentSelector = '#content';
        var url = 'http://localhost:53888/api/';

        //var viewControler = views.get(navSelector, contentSelector);
        //var dataProvider = baseProvider.get(url);
  
        var controller = controllerApp.get(navSelector, contentSelector, url);
        controller.loadNav();
        var app = sammy(contentSelector, function () {
            this.get("#/", function (context) {
                controller.loadHomePage();
            });

            this.get("#/posts", function (context) {
                controller.loadActiveGamesPage();
            });

            this.get("#/createGame", function (context) {

                var that = this;
                controller.loadCreateGamePage()
                    .then(function (data) {

                        that.redirect("#/posts");


                    }, function (err) {
                        console.log(err, "create game");
                    });
            });

            this.get("#/auth", function (context) {
                var that = this;
                controller.loadAuthenticationPage()
                    .then(function (data) {
                        controller.loadNav();
                        that.redirect("#/");
                    }, function (err) {
                        console.log(err, "login");
                    });
            });

            this.get("#/logout", function (context) {
                var that = this;
                controller.logoutUser()
                .then(function (data) {
                    controller.loadNav();
                    that.redirect("#/");
                }, function (err) {
                    console.log("ERROR in app", err);
                });
            });

            this.get("#/posts:id", function (id) {

                controller.loadGameInProgressPage({context: '#content', id:  this.params["id"]});
            
            });
        });
       
        app.run("#/");
    }); 
});