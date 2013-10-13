function task01() {

    var arrayOfStudents = [
                   new Student("Asen", "Minkov", 18, 5),
                   new Student("Tabita", "Georgieva", 48, 4),
                   new Student("Bobi", "Ivanov", 21, 3),
                   new Student("Svetlin", "Svetoslavov", 16, 6),
                   new Student("Ivaylo", "Kendov", 87, 5)
    ];

    console.log("TASK 01");
    console.log(":-v ");
    console.log("The initial set of students:");
    console.log(":-v ");

    _.each(arrayOfStudents, function (student) {
        console.log(student.toString());
    })

    var studentsWithFirstNameBeforeLast = _.select(arrayOfStudents, function (student) {
        return student.firstName < student.lastName;
    })

    console.log(":-v ");
    console.log("The subset of students whose first name is before its last name alphabetically:");
    console.log(":-v ");

    _.each(studentsWithFirstNameBeforeLast, function (student) {
        console.log(student.toString());
    })

    studentsWithFirstNameBeforeLast = _.sortBy(studentsWithFirstNameBeforeLast, function (student) {
        var fullName = student.fullName()
        return fullName;
    }).reverse();

    console.log(":-v ");
    console.log("The subset of the students in descending order by full name:");
    console.log(":-v ");

    _.each(studentsWithFirstNameBeforeLast, function (student) {
        console.log(student.toString());
    })
}