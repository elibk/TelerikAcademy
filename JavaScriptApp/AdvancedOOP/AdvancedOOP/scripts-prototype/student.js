var Student = Person.extend({

    init: function initStudent(firstName, secondName, age, grade) {
        this._super = Object.create(Person);
        this._super.initPerson(firstName, secondName, age);
        this.grade = grade;
        return this;
    },

    introduce: function personIntroduce() {

        var introduction = this._super.introduce() + String.format("Grade : {0}.", this.grade);
        return introduction;
    }
});