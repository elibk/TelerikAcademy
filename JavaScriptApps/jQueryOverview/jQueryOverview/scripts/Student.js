/// <reference path="prototype.js" />
/// <reference path="jquery-2.0.2.js" />

var Student = Class.create({

    initialize: function initStudent(firstName, lastName, grade) {

        this.firstName = firstName;
        this.lastName = lastName;
        this.grade = grade;
    }

});