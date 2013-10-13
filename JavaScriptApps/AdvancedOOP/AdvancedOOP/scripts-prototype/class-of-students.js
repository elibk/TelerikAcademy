var ClassOfStudents = {

    init: function init(className, classCapacity, formTeacher) {

        this.className = className;
        this._classCapacity = classCapacity;
        this.formTeacher = formTeacher;
        
        this._setOfStudents = [];
       
        return this;
    },

    addStudent: function addStudent(newStudent) {
    
        if (this._setOfStudents.length === this._classCapacity) {
            throw new Error("The class is full. You can not add any more students");
        } 
        this._setOfStudents.push(newStudent);
    },

    toString: function classToString() {

        var that = this;
        var students = (function getSetOfClassesToString() {

            var strigBuilder = [];

            for (var i = 0; i < that._setOfStudents.length; i++) {
                strigBuilder.push('\n');
                strigBuilder.push(that._setOfStudents[i].introduce());

            }

            return strigBuilder.join();
        })();

        var result = String.format("Class Name : {0}  Class Capacity : {1} Form Teacher : {2} \n STUDENTS : {3}",
            this.className, this._classCapacity, this.formTeacher.introduce(), students);

        return result;
    }
};