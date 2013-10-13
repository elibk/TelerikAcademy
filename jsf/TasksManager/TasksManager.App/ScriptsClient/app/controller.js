/// <reference path="../libs/_references.js" />
define(["jquery", "app/view-models", "app/views", "persisters", "kendoWeb", "class", "rsvp"], function ($, viewModels, views, persisters) {
    var Controller = Class.create({
        init: function () {
            this.layout = new kendo.Layout('<div id="content"></div>');
            this.navLayout = new kendo.Layout('<nav id="main-nav"></nav>');
            this.persister = persisters.get("api");
            this.viewModelFactory = viewModels.get(this.persister);
            this.viewFactory = views.get("ScriptsClient/partials/");
        },

        renderLayouts: function () {
            this.layout.render($("#app"));
            this.navLayout.render($("#wrapper > header"));
        },

        loadNav: function onLoadNav() {
            var that = this;
           
            if (that.persister.isUserLoggedIn()) {
                this.viewFactory.mainNavView()
                .then(function (viewHtml) {

                    var view = new kendo.View(viewHtml);
                    that.navLayout.showIn("#main-nav", view);


                }, function (err) {
                    console.log();
                });
            }
           
        },

        loadHomePage: function () {

            var that = this;
            var promise = new RSVP.Promise(function (resolve, reject) {

                if (!that.persister.isUserLoggedIn()) {
                    reject("user is not loged in");
                }
                else {
                    that.viewFactory.homePageView()
                    .then(function (viewHtml) {
                        var vm = that.viewModelFactory.buildHomeViewModel()

                        var view = new kendo.View(viewHtml, { model: vm });
                        that.layout.showIn("#content", view);
                        resolve("succsses");
                    }, function (err) {
                        console.log();
                    });
                }
            
            });
            return promise;
        },

        loadAuthPage: function () {

            var that = this;

            var promise = new RSVP.Promise(function (resolve, reject) {

                if (that.persister.isUserLoggedIn()) {
                    reject("user is already logedin");
                }
                else {

                    that.viewFactory.loginForm()
                    .then(function (loginFormHtml) {

                        var vm = that.viewModelFactory.buildLoginFormVM(function () {
                            console.log("callback");
                            resolve("loged");
                        })
                        var view = new kendo.View(loginFormHtml, { model: vm });
                        that.layout.showIn("#content", view);

                    }, function (err) {
                        console.log(err);
                    });
                }
            });
            return promise;
        },

        processLogout: function () {

            return this.persister.users.logout();
        },

        loadAppointmentsPage: function onLoadNav() {
            var that = this;
            this.viewFactory.appointmentsPanelbarView()
                .then(function (viewHtml) {
                    var vm = that.viewModelFactory.buildAppointemtsModel();

                    var view = new kendo.View(viewHtml, { model: vm });
                    that.layout.showIn("#content", view);
                }, function (err) {
                    console.log();
                });
        },

        loadCreateAppointmentPage: function () {
            var that = this;

          
            that.viewFactory.createAppointmentPageView()
            .then(function (viewHtml) {

               var vm = that.viewModelFactory.buildCreateAppoimtmentFormVM()

                var view = new kendo.View(viewHtml, { model: vm });
                that.layout.showIn("#content", view);

              
            }, function (err) {
                console.log(err);
            });
           
        },

        loadCreateTODOListPage: function () {
            var that = this;

            that.viewFactory.createLitsViewPage()
            .then(function (viewHtml) {

                var vm = that.viewModelFactory.buildCreateTODOListFormVM();

                var view = new kendo.View(viewHtml, { model: vm });
                that.layout.showIn("#content", view);


            }, function (err) {
                console.log(err);
            });

        },

        loadAllAppointments: function (categoryId) {
            var self = this;

            this.viewFactory.appointmentsView()
                .then(function (viewHtml) {
                    self.viewModelFactory.getAllAppointmentsViewModel().then(function (vm) {
                        var view = new kendo.View(viewHtml, { model: vm });

                        self.layout.showIn("#content", view);

                    }, function (err) {
                        console.log();
                    });
                });
        },

        loadByDateAppointments: function (date) {
            var self = this;

            this.viewFactory.appointmentsView()
                .then(function (viewHtml) {
                    self.viewModelFactory.getAppointmentsByDateViewModel(date).then(function (vm) {
                        var view = new kendo.View(viewHtml, { model: vm });

                        self.layout.showIn("#content", view);

                    }, function (err) {
                        console.log();
                    });
                });
        },


        loadCurrentAppointments: function () {
            var self = this;

            this.viewFactory.appointmentsView()
                .then(function (viewHtml) {
                    self.viewModelFactory.getAppointmentCurrentViewModel().then(function (vm) {
                        var view = new kendo.View(viewHtml, { model: vm });

                        self.layout.showIn("#content", view);

                    }, function (err) {
                        console.log();
                    });
                });
        },


        loadTodaysAppointments: function () {
            var self = this;

            this.viewFactory.appointmentsView()
                .then(function (viewHtml) {
                    self.viewModelFactory.getTodaysAppointmentsViewModel().then(function (vm) {
                        var view = new kendo.View(viewHtml, { model: vm });

                        self.layout.showIn("#content", view);

                    }, function (err) {
                        console.log();
                    });
                });
        },

        loadUpcommingAppointments: function () {
            var self = this;

            this.viewFactory.appointmentsView()
                .then(function (viewHtml) {
                    self.viewModelFactory.getCommingAppointmentsViewModel().then(function (vm) {
                        var view = new kendo.View(viewHtml, { model: vm });

                        self.layout.showIn("#content", view);

                    }, function (err) {
                        console.log();
                    });
                });
        },


        loadToDoListsPage: function onLoadNav() {
            var that = this;
            this.viewFactory.listsPanelbarView()
                .then(function (viewHtml) {
                    var vm = that.viewModelFactory.buildToDoListsModelMenu();

                    var view = new kendo.View(viewHtml, { model: vm });
                    that.layout.showIn("#content", view);
                }, function (err) {
                    console.log();
                });
        },

    });

    return {
        get: function () {
            return new Controller();
        }
    };
});