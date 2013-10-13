/// <reference path="../libs/_references.js" />

define(["jquery", "httpRequester", "rsvp", "class", "cryptoJs"], function ($, httpRequester) {

    var username = localStorage.getItem("task-manager-username");
    var sessionKey = localStorage.getItem("task-manager-sessionKey");

    function saveSession(userData) {
        localStorage.setItem("task-manager-username", userData.username);
        localStorage.setItem("task-manager-sessionKey", userData.accessToken);
        username = userData.username;
        sessionKey = userData.sessionKey;
    }

    function clearSession() {
        localStorage.removeItem("task-manager-username");
        localStorage.removeItem("task-manager-sessionKey");
        username = null;
        sessionKey = null;
    }

    var UsersPersister = Class.create({
        init: function (apiUrl) {
            this.apiUrl = apiUrl;
        },
        login: function (username, password, email) {
            var self = this;
            var promise = new RSVP.Promise(function (resolve, reject) {
                var user = {
                    username: username,
                    authCode: CryptoJS.SHA1(username + password).toString(),
                    email: email
                };
                return httpRequester.postJSON(self.apiUrl + "/auth/token", user)
					.then(function (data) {
					    saveSession(data);
					    resolve(data);
					});
            });
            return promise;
        },
        register: function (username, password, email) {
            var self = this;
            var promise = new RSVP.Promise(function (resolve, reject) {
                var hash = CryptoJS.SHA1(username + password).toString();
                var user = {
                    username: username,
                    authCode: hash,
                    email: email
                };
                return httpRequester.postJSON(self.apiUrl +  "/users/register", user)
					.then(function (data) {
					    httpRequester.postJSON(self.apiUrl + "/auth/token", { username: data.username, authCode: hash })
                         .then(function (dataLogin) {
                             saveSession(data);
                             resolve(data);
                         });
					});
            });
            return promise;
        },

        logout: function (username, password) {
            var self = this;
            var promise = new RSVP.Promise(function (resolve, reject) {
                var user = {
                };

                var header = { "X-accessToken": sessionKey };

                return httpRequester.putJSON(self.apiUrl, user, header)
					.then(function (data) {
					    clearSession();
					    resolve(data);
					});
            });
            return promise;
        }
    });

    var AppointmentsPersister = Class.create({
        init: function (apiUrl) {
            this.apiUrl = apiUrl;
        },
        add: function (appoinment) {
            var self = this;
            var header = { "X-accessToken": sessionKey };
            var promise = new RSVP.Promise(function (resolve, reject) {

                return httpRequester.postJSON(self.apiUrl, appoinment, header)
					.then(function (data) {
					    resolve(data);
					});
            });
            return promise;
        },
        all: function () {
            var url = this.apiUrl + "/all";
            var header = { "X-accessToken": sessionKey };
            return httpRequester.getJSON(url, header);
        },

        comming: function () {
            var url = this.apiUrl + "/comming";
            var header = { "X-accessToken": sessionKey };
            return httpRequester.getJSON(url, header);
        },

        byCurrDate: function (date) {
            var url = this.apiUrl + "?date=" + date;
            var header = { "X-accessToken": sessionKey };
            return httpRequester.getJSON(url, header);
        },

        forToday: function () {
            var url = this.apiUrl + "/today";
            var header = { "X-accessToken": sessionKey };
            return httpRequester.getJSON(url, header);
        },

        current: function () {
            var url = this.apiUrl + "/current";
            var header = { "X-accessToken": sessionKey };
            return httpRequester.getJSON(url, header);
        },
    });

    var ToDosPersister = Class.create({
        init: function (apiUrl) {
            this.apiUrl = apiUrl;
        },
        all: function () {
            var url = this.apiUrl + "/lists";
            var header = { "X-accessToken": sessionKey };
            console.log(sessionKey);
            return httpRequester.getJSON(url, header);
        },

        createList: function (data) {
            var url = this.apiUrl + "/lists";
            debugger;
            var header = { "X-accessToken": sessionKey };
            return httpRequester.postJSON(url,  data,header);
        },

        listWithToDo: function (listId) {
            var url = this.apiUrl + "lists/" + listId + "/todos";
            var header = { "X-accessToken": sessionKey };
            return httpRequester.getJSON(url, header);
        },

        createToDoForList: function (listId, data) {
            var url = this.apiUrl + "lists/" + listId + "/todos";
            var header = { "X-accessToken": sessionKey };
            return httpRequester.postJSON(url, header, data);
        },

        changeToDoSatus: function (todoId) {
            var url = this.apiUrl + "todos/" + todoId;
            var header = { "X-accessToken": sessionKey };
            return httpRequester.putJSON(url, header, data);
        },
    });

    var DataPersister = Class.create({
        init: function (apiUrl) {
            this.apiUrl = apiUrl;
            this.users = new UsersPersister(this.apiUrl);
            this.appointments = new AppointmentsPersister(this.apiUrl + "/appointments");
            this.toDos = new ToDosPersister(this.apiUrl);
        },

        isUserLoggedIn: function () {
            return sessionKey && username;
        },
        getCurrentUsername: function () {
            return username;
        }
    });

    return {
        get: function (apiUrl) {
            return new DataPersister(apiUrl);
        }
    };
});