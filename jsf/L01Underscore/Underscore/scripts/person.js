/// <reference path="class.js" />
var Person =Class.create( {
    init: function (firstName, lastName, age) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
    },
    fullName: function () {
        return this.firstName + " " + this.lastName;
    },
    toString: function () {
        return this.fullName() +" age of " + this.age;
    }
});