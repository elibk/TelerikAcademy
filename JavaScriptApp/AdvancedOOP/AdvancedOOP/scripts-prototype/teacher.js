var Teacher = Person.extend({

    init: function initTeacher(firstName, secondName, age, speciality) {
        this._super = Object.create(Person);
        this._super.initPerson(firstName, secondName, age);
        this.speciality = speciality;
        return this;

    },

    introduce: function teacherIntroduce() {

        var introduction = this._super.introduce() + String.format("Speciality : {0}.", this.speciality);
        return introduction;
    }
});