/// <reference path="http-requester.js" />
/// <reference path="class.js" />
/// <reference path="q.js" />
/// <reference path="sha1.js" />

define(["jquery", "httpRequester", "class", "cryptoJs", "rsvp"], function ($, httpRequester, Class) {

    var nickname = localStorage.getItem("nickname");
    var sessionKey = localStorage.getItem("sessionKey");

    function saveSession(userData) {
        localStorage.setItem("nickname", userData.nickname);
        localStorage.setItem("sessionKey", userData.sessionKey);
        nickname = userData.nickname;
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
            this.message = new MessagesProvider(this.serviceUrl);
            this.guess = new GuessProvider(this.serviceUrl);
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
            this.serviceUrl = serviceUrl + "user/";
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
                nickname: nickname,
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
            var url = this.serviceUrl + "logout/" + sessionKey;

            var promise = new RSVP.Promise(function (resolve, reject) {
                httpRequester.putJSON(url).then(function (data) {
                    resolve(data);
                    clearSession();
                }, function (err) {

                    if (err.status === 200) {
                        resolve("Fake error");
                        clearSession();
                    }
                    else {
                        reject(err);
                        console.log("ERROR", err);
                    }

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
            this.serviceUrl = serviceUrl + "game/";
        },
        create: function (title, password) {

            var url = this.serviceUrl + "create/" + sessionKey;
            var data = {
                title: title
            };

            if (password) {
                var hash = CryptoJS.SHA1(password).toString();
                data.password = hash;
            }

            return httpRequester.postJSON(url, data);
        },

        join: function (gameId, password) {
           
            var url = this.serviceUrl + "join/" + sessionKey;
            var data = {
                id: gameId
            };

            if (password) {
                var hash = CryptoJS.SHA1(password).toString();
                data.password = hash;
            }


            return httpRequester.postJSON(url, data);
        },

        start: function (gameId) {
            return httpRequester.putJSON(this.serviceUrl + "/" + gameId + "/start/" + sessionKey);
        },
        active: function () {
            return httpRequester.getJSON(this.serviceUrl + "open/" + sessionKey);
        },
        myGames: function () {
            return httpRequester.getJSON(this.serviceUrl + "my-active/" + sessionKey);
        },
        state: function (gameId) {
            return httpRequester.getJSON(this.serviceUrl + "/" + gameId + "/state/" + sessionKey);
        }
    });

    var GuessProvider = Class.create({
        init: function (serviceUrl) {
            this.serviceUrl = serviceUrl + "guess/";
        },

        make: function (gameId, number) {
            var data = {
                id: gameId
            };
            return httpRequester.postJSON(this.serviceUrl + "make/" + sessionKey, data);
        }

    });

    var MessagesProvider = Class.create({
        init: function (serviceUrl) {
            this.serviceUrl = serviceUrl + "messages/";
        },

        unread: function () {
            return httpRequester.getJSON(this.serviceUrl + "unread/" + sessionKey);
        },

        all: function () {
            return httpRequester.getJSON(this.serviceUrl + "all/" + sessionKey);
        }

    });
    return {
        get: function (url) {
            return new BaseProvider(url);
        }
    };
});