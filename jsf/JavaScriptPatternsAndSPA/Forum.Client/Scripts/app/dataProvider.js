/// <reference path="../_references.js" />

define(["jquery", "httpRequester", "class", "cryptoJs", "rsvp"], function ($, httpRequester, Class) {

    var nickname = localStorage.getItem("nickname");
    var sessionKey = localStorage.getItem("sessionKey");

    function saveSession(userData) {
        localStorage.setItem("nickname", userData.displayName);
        localStorage.setItem("sessionKey", userData.sessionKey);
        nickname = userData.displayName;
        sessionKey = userData.sessionKey;
    }

    function clearSession() {
        localStorage.removeItem("nickname");
        localStorage.removeItem("sessionKey");
        nickname = null;
        sessionKey = null;
    }

    var BaseProvider = Class.create({
        init: function (serviceUrl) {
            this.serviceUrl = serviceUrl;
            this.user = new UserProvider(this.serviceUrl);
            this.game = new GameProvider(this.serviceUrl);
        },
        isUserLoggedIn: function () {
            var isLoggedIn = nickname != null && sessionKey != null;
            return isLoggedIn;
        },
        nickname: function () {
            return nickname;
        }
    });
    var UserProvider = Class.create({
        init: function (serviceUrl) {
            this.serviceUrl = serviceUrl + "users/";
        },
        login: function (username, password) {
            var url = this.serviceUrl + "login";
            var userData = {
                username: username,
                authCode: CryptoJS.SHA1(username + password).toString()
            };
            var promise = new RSVP.Promise(function (resolve, reject) {
                httpRequester.postJSON(url, userData).then(function (result) {
                    resolve(result);
                    saveSession(result);
                }, function (error) {
                    reject(error);
                    console.log(error.responseText);
                });
            });

            return promise;
        },
        register: function (username, nickname, password) {
            var url = this.serviceUrl + "register";
            var userData = {
                username: username,
                displayName: nickname,
                authCode: CryptoJS.SHA1(username + password).toString()
            };

            var promise = new RSVP.Promise(function (resolve, reject) {
                httpRequester.postJSON(url, userData).then(function (result) {
                    resolve(result);
                    saveSession(result);
                }, function (error) {
                    reject(error);
                    console.log(error.responseText);
                });
            });

            return promise;


        },
        logout: function (success, error) {
            var url = this.serviceUrl + "logout";
           
            var data = {};

            var promise = new RSVP.Promise(function (resolve, reject) {
                httpRequester.putJSON(url, data, sessionKey).then(function (data) {
                    resolve(data);
                    clearSession();
                }, function (err) {


                    reject(err);
                    console.log("ERROR", err);

                });
            });

            return promise;
        },
        scores: function () {
            return httpRequester.getJSON(this.serviceUrl + "scores/" + sessionKey);
        }
    });
    var GameProvider = Class.create({
        init: function (serviceUrl) {
            this.serviceUrl = serviceUrl;
        },
        create: function (title, content, tags) {

            var url = this.serviceUrl + "posts";
            var data = {
                title: title,
                content: content,
                tags:tags
            };

            return httpRequester.postJSON(url, data, sessionKey);
        },

        comment: function (postId, text) {
           
            var url = this.serviceUrl   + "posts/" + postId.toString() +'/comment';
            var data = {
                id: postId,
                text: text
            };

            return httpRequester.putJSON(url, data, sessionKey);
        },

        active: function () {
            return httpRequester.getJSON(this.serviceUrl + "posts", sessionKey);
        },

        singlePost: function (postId) {
            return httpRequester.getJSON(this.serviceUrl + "post/" + postId, sessionKey);
        },

    });

    return {
        get: function (url) {

            return new BaseProvider(url);
        }
    }
});