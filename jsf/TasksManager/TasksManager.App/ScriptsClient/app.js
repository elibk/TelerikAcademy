/// <reference path="_references.js" />


require.config({
    paths: {
        jquery: "libs/jquery-2.0.3",
        rsvp: "libs/rsvp.min",
        httpRequester: "libs/http-requester",
        dataProvider: "app/dataProvider",
        "class": "libs/class",
        cryptoJs: "libs/sha1",
        underscore: "libs/underscore",
        kendoWeb: "libs/kendo.web.min",
        persisters: "app/data",
        underscore: "libs/underscore"

    }
});

require(["jquery", "app/controller", "kendoWeb"], function ($, controller) {


    var router = new kendo.Router();

    var controllerFactory = controller.get();

    controllerFactory.loadNav();

    router.route("/", function () {

        router.navigate("/home");
    });

    router.route("/home", function () {

        
        controllerFactory.loadHomePage()
        .then(function (data) {
            controllerFactory.loadNav();
        }, function (err) {
            router.navigate("/auth");
            console.log(err);
        });

    });

    router.route("/auth", function () {

        controllerFactory.loadAuthPage()
            .then(function (data) {
                router.navigate("/");
            }, function (err) {
                console.log(err);
                router.navigate("/");
            });

    });

    // TO DO -think of better way
    router.route("/logout", function () {
        controllerFactory.processLogout()
             .then(function (data) {
                 router.navigate("/");
             }, function (err) {
                 router.navigate("/");
             });
    });


    router.route("/appointments", function () {
        controllerFactory.loadAppointmentsPage();
    });



    router.route("/categories/:id", function (id) {
        
        controllerFactory.loadRecipesByCategoryPage(id);
    });

    router.route("/recipe/:id", function (id) {
        controllerFactory.loadSingleRecipePage(id)

    });

    router.route("/appointments/create", function () {
        controllerFactory.loadCreateAppointmentPage();
    });

    router.route("/appointments/upcomming", function () {
        controllerFactory.loadUpcommingAppointments();
    });

    router.route("/appointments/all", function () {
        controllerFactory.loadAllAppointments();
    });

    router.route("/appointments/today", function () {

        controllerFactory.loadTodaysAppointments();
    });


    router.route("/appointments/byDate/:date", function (date) {
        controllerFactory.loadByDateAppointments(date);
    });


    router.route("/appointments/current", function () {
        controllerFactory.loadCurrentAppointments();
    });

    router.route("/todolists", function () {
        controllerFactory.loadToDoListsPage();
    });

    router.route("/todolists/create", function () {
       
        controllerFactory.loadCreateTODOListPage();
    });

    router.route("/todolists/all", function () {

        controllerFactory.loadCreateTODOListPage();
    });

    $(function () {

        controllerFactory.loadNav();

        controllerFactory.renderLayouts();
        router.start("/");
    });
});