/// <reference path="dataProvider.js" />
/// <reference path="../libs/underscore.js" />


define(["jquery", "class", "controls", "dataProvider", "views","underscore", "rsvp"], function ($, Class, controls, baseProvider, views) {
    var Controller = Class.create({
        init: function (navSelector, contentSelector, url) {
            this.viewControler = views.get(navSelector, contentSelector);
            this.dataProvider = baseProvider.get(url);
            this.navSelector = navSelector;
            this.contentSelector = contentSelector;
            this.url = url;
        },
        loadNav:  function onLoadNav() {
            if (this.dataProvider.isUserLoggedIn()) {
                this.viewControler.renderNav($("#nav-loged-template").html(), { nickname: this.dataProvider.nickname() });
            }
            else {
                this.viewControler.renderNav($("#nav-notloged-template").html());
            }
        },

        loadHomePage: function () {

            this.viewControler.renderPage($('#greeting-template').html());
        },

        loadActiveGamesPage: function () {

            console.log("activeGames");
            var that = this;

            this.dataProvider.game.active().then(function (activeGames) {

                var sortedGames = _.sortBy(activeGames, function (game) { return game.title; });

                that.viewControler.renderPage($('#active-games-template').html(), { games: sortedGames });

                controls.initGamesEvents(function (element) {

                    var promise = new RSVP.Promise(function (resolve, reject) {

                        var id = $(element).data('id') || 0;

                        console.log(id);

                        resolve(id);

                    });
                    return promise;
                }, "#/activeGames", ".active");
            }, function () {
                console.log();
            });
        },

        loadMyGamesPage: function () {
            console.log("myGames");

            var that = this;
            this.dataProvider.game.myGames().then(function (myGames) {

                var sortedGames = _.sortBy(myGames, function (game) { return game.title; });
                that.viewControler.renderPage($('#my-games-template').html(), { games: sortedGames });

                controls.initGamesEvents(function (element) {

                    var promise = new RSVP.Promise(function (resolve, reject) {

                        var id = $(element).data('id') || 0;

                        console.log(id);

                        resolve(id);

                    });
                    return promise;

                }, "#/myGames/game", ".in-progress");

                controls.initGamesEvents(function (element) {

                    var promise = new RSVP.Promise(function (resolve, reject) {

                        var id = $(element).data('id') || 0;
                        var creator = $(element).data('creator')
                        console.log(id);
                        if (creator.trim() !== that.dataProvider.nickname()) {
                            reject("This game does not belog to this user.");
                        }
                        else {
                            resolve(id);
                        }
                        

                    });
                    return promise;
                }, "#/myGames/Start", ".full");


            }, function (err) {
                console.log(err);
            });

           
        },

        loadCreateGamePage: function () {
            var that = this;
            this.viewControler.renderPage($('#create-game-template').html());
            var promise = new RSVP.Promise(function (resolve, reject) {

                $('#create-game-button').on('click', function () {
                    var title = $('#create-game-title-input').val();
                    var password = $('#create-game-password-input').val();
                    var passwordRepated = $('#create-game-password-repeated-input').val();

                    if (password != passwordRepated) {

                        $('#error-box').text("Passwords are not the same");

                        return false;
                    }

                    that.dataProvider.game.create(title, password)
                        .then(function (data) {
                            resolve(data);
                        }, function (err) {
                            $('#error-box').text(err.responseJSON.Message);
                            reject(err);
                        });
                    });

            });
            return promise;

        },

        loadAuthenticationPage: function () {
            var that = this;
            this.viewControler.renderPage($('#login-register-template').html());

            var promise = new RSVP.Promise(function (resolve, reject) {

                $('#register-button').on('click', function () {
                    var self = this;
                $(this).attr("disabled", "disabled");
                var username = $('#register-username-input').val();
                var nickname = $('#register-nickname-input').val();
                var password = $('#register-password-input').val();
                var passwordRepated = $('#tb-repeat-pass').val();

                if (password != passwordRepated) {

                    $('#error-box').text("Passwords are not the same");
                    $(this).removeAttr("disabled");
                    return false;
                }

                that.dataProvider.user.register(username, nickname, password)
                    .then(function (data) {
                        resolve(data);
                    }, function (err) {
                        $(self).removeAttr("disabled");
                        $('#error-box').text(err.responseJSON.Message);
                        reject(err);
                    });
            });

            $('#login-button').on('click', function () {
                var username = $('#login-username-input').val();
                var password = $('#login-password-input').val();

                that.dataProvider.user.login(username, password)
                    .then(function (data) {

                        resolve(data);

                    }, function (err) {
                        $('#error-box').text(err.responseJSON.Message);
                        reject(err);
                    });
            });

            $('#btn-show-register').on('click', function () {
                $(this).removeClass('current');
                $('#btn-show-login').addClass('current');

                $('#form-register').removeClass('invisible');
                $('#form-login').addClass('invisible');

                $('#error-box').html('');
            });

            $('#btn-show-login').on('click', function () {

                $(this).removeClass('current');
                $('#btn-login-form').addClass('current');

                $('#form-register').addClass('invisible');
                $('#form-login').removeClass('invisible');

                $('#error-box').html('');
            });
            });
            return promise;
        },

        logoutUser: function () {

            var promise = this.dataProvider.user.logout();

            return promise;
        },

        loadGameInProgressPage: function (param) {

            var context = param.context;
            var gameId = param.id.substring(1);

            var gameEl = $(context).find("[data-id='" + gameId + "']");
            var gameNameEl = $(gameEl).children(':nth-child(' + 1 + ')');
            var gameName = $(gameNameEl).text();

            var template = '<span data-y="{{posiionY}}" data-x ="{{positionX}}"/>Empty field</span>';

            this.viewControler.renderField({ gameName: gameName, template: template, context: context, rows: 9, cols: 9 });
        },

        loadJoinGamePage: function (param) {
            var that = this;
            var context = param.context;
            var gameId = param.id.substring(1) || 0;

            var gameEl = $(context).find("[data-id='" + gameId + "']");
            var gameNameEl = $(gameEl).children(':nth-child(' + 1 + ')');
            var gameName = $(gameNameEl).text();

            var btnJoinGame = '<button id="btn-join-game"> Join the game {{gameName}} </button>';

            this.viewControler.renderPage(btnJoinGame, {gameName: gameName});

            var promise = new RSVP.Promise(function (resolve, reject) {

                $('#btn-join-game').on('click', function () {
                    that.dataProvider.game.join(gameId)
                        .then(function (data) {
                            resolve(data);
                        }, function (err) {
                            reject(err);
                        });
                });

            });
            return promise;

        },

        loadStartGamePage: function (param) {
            var that = this;
            var context = param.context;
            var gameId = param.id.substring(1);

            var gameEl = $(context).find("[data-id='" + gameId + "']");
            var gameNameEl = $(gameEl).children(':nth-child(' + 1 + ')');
            var gameName = $(gameNameEl).text();

            var btnJoinGame = '<button id="btn-start-game"> Start the game {{gameName}} </button>';

            this.viewControler.renderPage(btnJoinGame, { gameName: gameName });

            var promise = new RSVP.Promise(function (resolve, reject) {

                $('#btn-start-game').on('click', function () {
                    that.dataProvider.game.start(gameId)
                        .then(function (data) {
                            resolve(data);
                        }, function (err) {
                            reject(err);
                        });
                });

            });
            return promise;
        },
    });

    return {
        get: function (navSelector, contentSelector, url) {
            return new Controller(navSelector, contentSelector, url);
        }
    };
});