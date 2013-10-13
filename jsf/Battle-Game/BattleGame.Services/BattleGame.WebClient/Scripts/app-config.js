/// <reference path="app/dataProvider.js" />
/// <reference path="libs/require.js" />
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
        underscore: "libs/underscore"
       
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
        var url = 'http://localhost:22954/api/';

        //var viewControler = views.get(navSelector, contentSelector);
        //var dataProvider = baseProvider.get(url);
  
        var controller = controllerApp.get(navSelector, contentSelector, url);
        controller.loadNav();
        var app = sammy(contentSelector, function () {
            this.get("#/", function (context) {
                controller.loadHomePage();
            });

            this.get("#/activeGames", function (context) {
                controller.loadActiveGamesPage();
            });

            this.get("#/myGames", function (context) {
                controller.loadMyGamesPage();
            });

            this.get("#/createGame", function (context) {

                var that = this;
                controller.loadCreateGamePage()
                    .then(function (data) {
                        that.redirect("#/myGames");
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

            this.get("#/myGames/game:id", function (id) {

                controller.loadGameInProgressPage({context: '#content', id:  this.params["id"]});

            });
            this.get("#/activeGames:id", function (id) {

                var that = this;

                controller.loadJoinGamePage({ context: '#content', id: this.params["id"] })
                    .then(function (data) {
                    that.redirect("#/myGames");
                }, function (err) {
                    console.log("ERROR in app", err);
                });
            });

            this.get("#/myGames/Start:id", function (id) {
                var that = this;

                controller.loadStartGamePage({ context: '#content', id: this.params["id"] }).then(function (data) {
                    // that.redirect("#/myGames/game" + this.params["id"]);
                    that.redirect("#/myGames");
                }, function (err) {
                    console.log("ERROR in app", err);
                });
            });
        });
       
        app.run("#/");
    }); 
});