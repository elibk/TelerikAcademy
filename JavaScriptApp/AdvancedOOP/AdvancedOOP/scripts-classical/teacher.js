var Teacher = Class.create({

    init: function initTeacher(firstName, secondName, age, speciality) {

        this._super = new Person(firstName, secondName, age);

        this.speciality = speciality;
        return this;

    },

    introduce: function teacherIntroduce() {

        var introduction = this._super.introduce() + String.format("Speciality : {0}.", this.speciality);
        return introduction;
    }
});

Teacher.inherit(Person);