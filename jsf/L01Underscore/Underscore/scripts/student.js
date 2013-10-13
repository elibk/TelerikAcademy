/// <reference path="../lib/underscore.js" />
/// <reference path="class.js" />

var Student = Class.create({
    init: function (firstName, lastName, age, mark) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
        this.mark = mark;
    },

    fullName: function () {
        return this.firstName + " " + this.lastName;
    },

    toString: function () {
        return this.fullName() + " age of " + this.age + " grade : " + this.grade;
    }
});