var Person = Class.create({

    init: function initPerson(firstName, lastName, age) {

        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
        return this;
    },

    introduce: function personIntroduce() {

        var introduction = String.format("FirstName : {0} LastName : {1} Age : {2} ", this.firstName, this.lastName, this.age);
        return introduction;
    }
});