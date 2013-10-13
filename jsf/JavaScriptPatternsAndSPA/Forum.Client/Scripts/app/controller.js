/// <reference path="../_references.js" />


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

            console.log("posts");
            var that = this;

            this.dataProvider.game.active().then(function (posts) {

                var sortedPosts = _.sortBy(posts, function (post) { return post.title; });

                that.viewControler.renderPage($('#posts-template').html(), { posts: sortedPosts });

                controls.initGamesEvents(function (element) {

                    var promise = new RSVP.Promise(function (resolve, reject) {

                        var id = $(element).data('id') || 0;

                        console.log(id);

                        resolve(id);

                    });
                    return promise;
                }, "#/posts", ".active");
            }, function () {
                console.log();
            });
        },

        loadCreateGamePage: function () {
            var that = this;
            this.viewControler.renderCreatePostPage($('#create-post-template').html());
            var promise = new RSVP.Promise(function (resolve, reject) {

                $('#create-post-button').on('click', function () {
                    var title = $('#create-post-title-input').val();
                    var content = $('#create-post-content-input').val();
                    var tags = $('#tags').val();
                   
                    that.dataProvider.game.create(title, content, tags)
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
            var postId = param.id.substring(1) || 0;
            console.log("posts");
            var that = this;

            this.dataProvider.game.singlePost(postId).then(function (post) {

                that.viewControler.renderPage($('#post-template').html(), post);

                $('#comment-btn').on('click', function () {
                    var comment = $('#comment-txt').val();

                    that.dataProvider.game.comment(postId, comment)
                        .then(function (data) {
                            resolve(data);
                        }, function (err) {
                            $('#error-box').text(err.responseJSON.Message);
                            reject(err);
                        });
                });

            }, function () {
                console.log();
            });
        },
    });

    return {
        get: function (navSelector, contentSelector, url) {
            return new Controller(navSelector, contentSelector, url);
        }
    };
});