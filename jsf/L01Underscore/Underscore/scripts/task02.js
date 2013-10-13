/// <reference path="student.js" />
function task02() {
    var arrayOfStudents = [
                   new Student("Asen", "Minkov", 18, 5),
                   new Student("Tabita", "Georgieva", 48, 4),
                   new Student("Bobi", "Ivanov", 21, 3),
                   new Student("Svetlin", "Svetoslavov", 16, 6),
                   new Student("Ivaylo", "Kendov", 87, 5)
    ];

    console.log("TASK 02");
    console.log(":-v ");
    console.log("The initial set of students:");
    console.log(":-v ");

    _.each(arrayOfStudents, function (student) {
        console.log(student.toString());
    })

    var studentsInCertainAge = _.select(arrayOfStudents, function (student) {
        return student.age >= 18 && student.age <= 24;
    })

    console.log(":-v ");
    console.log("The subset of students whose age is between 18 and 24:");
    console.log(":-v ");

    _.each(studentsInCertainAge, function (student) {
        console.log(student.toString());
    })
}