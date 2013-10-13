/// <reference path="../lib/underscore.js" />
/// <reference path="student.js" />
function task03() {
    var arrayOfStudents = [
                   new Student("Asen", "Minkov", 18, 5),
                   new Student("Tabita", "Georgieva", 48, 4),
                   new Student("Bobi", "Ivanov", 21, 3),
                   new Student("Svetlin", "Svetoslavov", 16, 6),
                   new Student("Ivaylo", "Kendov", 87, 5)
    ];

    console.log("TASK 03");
    console.log(":-v ");
    console.log("The initial set of students:");
    console.log(":-v ");

    _.each(arrayOfStudents, function (student) {
        console.log(student.toString());
    })

    var studentWithHighestMark = _.max(arrayOfStudents, function (student) {
        return student.mark;
    });
    console.log(":-v ");
    console.log("The student with the highest mark:");
    console.log(":-v ");

    console.log(studentWithHighestMark.toString());
}