/// <reference path="data.js" />

define(["jquery", "class", "underscore"], function ($) {
    var displayName = "";
    var ViewModels = Class.create({
        init: function (persister) {
            this.persister = persister;
            return this;
        },

        currentUser: function () {
            return displayName;
        },

        buildHomeViewModel: function () {

            var username = this.persister.getCurrentUsername();
            var user = {
                username: username
            }
            var viewModel = {
                user: user
            };

            var userViewModel = new kendo.observable(
                viewModel
            )
            return userViewModel;

        },

        buildAppointemtsModel: function () {

            //var dateNow = new Date();
            //var dateDefault = $.datepicker.formatDate('dd-mm-yyyy', dateNow);


            states = [
                "finished",
                "current",
                "upcomming"
            ];

           
            //var day = (dateToday.getDay() + 1);
            //if (day.length == 1) {
            //    day = 0 + date;
            //}
            //var month = (dateToday.getMonth() + 1);
            //var year = dateToday.getFullYear();

            var viewModel = {
                pickedDate: "03-09-2013",
                states: states,
                state: "",
                message: "",

                getByDate: function () {

                    var pickedDateVal = $("<div />").html(this.get("pickedDate")).text();

                    window.open("#/appointments/byDate" + "/" + pickedDateVal, "_self");
                },

                getByState: function () {

                    var pickedState = $("<div />").html(this.get("state")).text();

                    if (!pickedState) {
                        this.set("message", "The field state is mandatory.");
                        return;
                    }
                  

                    window.open("#/appointments/byState" + "/" + pickedState, "_self");
                },
            };
            var appointmentsViewModel = new kendo.observable(
               viewModel
           )

            return appointmentsViewModel;
        },

        buildLoginFormVM: function (successCallback) {
            var self = this;
            var viewModel = new kendo.observable({
                username: "SampleUsername",
                password: "password",
                passwordRepeated: "password",
                email: "user@mail.bg",
                message: "",
                loginUser: function (e) {
                    return self.persister.users
						.login(this.get("username"), this.get("password"), this.get("email"))
							.then(function (name) {
							    successCallback();
							}, function (err) {
							    this.set("message", err);
							});
                },
                registerUser: function (e) {
                    return self.persister.users
						.register(this.get("username"), this.get("password") , this.get("email"))
							.then(function (name) {
							    successCallback();
							}, function (err) {
							    this.set("message", err);
							});
                }
            });
            return viewModel;
        },

        getAllAppointmentsViewModel: function () {
            var promise = this.persister.appointments.all()
                .then(function (apointments) {

                    var appointmentsViewModel = new kendo.observable(
                       {
                           apointments: apointments
                       }
                    );
                    return appointmentsViewModel;

                }, function (err) {
                    console.log(err);
                });

            return promise;
        },

        getTodaysAppointmentsViewModel: function () {
            var promise = this.persister.appointments.forToday()
                .then(function (apointments) {

                    var appointmentsViewModel = new kendo.observable(
                        {
                            apointments: apointments
                        }
                     );
                    return appointmentsViewModel;

                }, function (err) {
                    console.log(err);
                });

            return promise;
        },

        getCommingAppointmentsViewModel: function () {
            var promise = this.persister.appointments.comming()
                .then(function (apointments) {

                    var appointmentsViewModel = new kendo.observable(
                      {
                          apointments: apointments
                      }
                   );
                    return appointmentsViewModel;

                }, function (err) {
                    console.log(err);
                });

            return promise;
        },

        getAppointmentCurrentViewModel: function (state) {
            var promise = this.persister.appointments.current()
                .then(function (apointments) {

                    var appointmentsViewModel = new kendo.observable(
                       {
                           apointments: apointments
                       }
                    );
                    return appointmentsViewModel;


                }, function (err) {
                    console.log(err);
                });

            return promise;
        },

        getAppointmentsByDateViewModel: function (date) {
            var promise = this.persister.appointments.byCurrDate(date)
                .then(function (apointments) {

                    var appointmentsViewModel = new kendo.observable(
                     {
                         apointments: apointments
                     }
                  );
                    return appointmentsViewModel;


                }, function (err) {
                    console.log(err);
                });

            return promise;
        },

        buildCreateAppoimtmentFormVM: function (successCallback) {
            var self = this;

            var viewModel = {
              subject: "Appoinment title",
              description: "Appointment description goes here...",
              duration: 5,
              pickedDate: "05-09-2013 19:00:00",

              message: "",


              createAppointment: function (e) {
                  var escapedSubject = $("<div />").html(this.get("subject")).text();
                  var escapedDescription = $("<div />").html(this.get("description")).text();

                  var durationVal = this.get("duration");

                    var durationInMinutes = parseInt(durationVal);
                    if (!durationInMinutes && durationInMinutes <= 0) {
                        this.set("message", "Duration can not be less ot equal zero");
                    }

                    if (escapedSubject.lenght == 0) {
                        this.set("message", "Subject can not be empty");
                    }

                    if (escapedDescription.lenght == 0) {
                        this.set("message", "Description can not be empty");
                    }
                        
                    var promiseCreateRecipe =
                    self.persister.appointments
                        .add({
                            subject: escapedSubject,
                            description: escapedDescription,
                            duration: durationInMinutes,
                            appointmentDate: this.get("pickedDate")
                        })
                            .then(function (addedRecipe) {
                                this.set("message", "Appointment created succssesfully.");
                                
                            }, function (err) {
                                this.set("message", err);
                            });

                    this.set("subject", "");
                    this.set("description", "");
                    this.set("duration", "");

                    return promiseCreateRecipe;
                },
             };

            var createAppViewModel = new kendo.observable(viewModel);

            return createAppViewModel;
        },

        buildCreateTODOListFormVM: function (successCallback) {
            var self = this;

            var viewModel = {
                title: "Title",
                currentToDocontent : "Text of the toDo goes here...",
                slectedToDos: [],

                message :"",

                createList: function (e) {
                    var escapedTitle = $("<div />").html(this.get("title")).text()

                    if (escapedTitle.length <= 0) {
                        this.set("message", "List title can not be empty.");
                        return;
                    }

                    var selectedItems = this.get("slectedToDos");

                    var todosText = [];

                    for (var i = 0; i < selectedItems.length; i++) {
                        todosText.push({ text: selectedItems[i].text });
                    }

                    var promiseCreateRecipe =
                    self.persister.toDos.createList
                        ({
                            title: escapedTitle,
                            todos: todosText
                        })
                            .then(function (addedList) {
                                console.log(addedList);
                                //successCallback(addedList.Id);
                            }, function (err) {
                                this.set("message", err);
                            });

                    this.set("title", "");

                    return promiseCreateRecipe;
                },

                addToDo: function (e) {
                    var escapedText = $("<div />").html(this.get("currentToDocontent")).text();

                    if (escapedText.length <= 0) {
                        this.set("message", "ToDo text can not be empty.");
                        return;
                    }

                    var prod = this.get("slectedToDos");
                    prod.push({ "text": escapedText });

                    this.set("slectedToDos", prod);

                    this.set("currentToDocontent", "");

                }

            };

            var createAppViewModel = new kendo.observable(viewModel);

            return createAppViewModel;
        },

        buildToDoListsModelMenu: function () {

            //var dateNow = new Date();
            //var dateDefault = $.datepicker.formatDate('dd-mm-yyyy', dateNow);

            //var day = (dateToday.getDay() + 1);
            //if (day.length == 1) {
            //    day = 0 + date;
            //}
            //var month = (dateToday.getMonth() + 1);
            //var year = dateToday.getFullYear();

            var viewModel = {
               some: ""
            };
            var appointmentsViewModel = new kendo.observable(
               viewModel
           )

            return appointmentsViewModel;
        },
    });

    return {
        get: function (persister) {
            return new ViewModels(persister)
        }
    }
});