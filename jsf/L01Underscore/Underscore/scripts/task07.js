/// <reference path="person.js" />
/// <reference path="../lib/underscore.js" />
function task07() {
    var arrayOfPeople = [
        new Person("Mincho", "Minkov", 18),
        new Person("Tabita", "Georgieva", 48),
        new Person("Mincho", "Ivanov", 21, 3),
        new Person("Svetlin", "Svetoslavov", 16),
        new Person("Ivaylo", "Kendov", 87),
        new Person("Gincho", "Kendov", 87),
        new Person("Pencho", "Kendov", 87),
    ];

    var mostPopularFirstNameGrouped = 

        _.countBy(arrayOfPeople, function (person) {
           return person.firstName;
        })

    console.log(mostPopularFirstNameGrouped);

    var mostOccurenceFName = _.max(mostPopularFirstNameGrouped, function (person) {
        return  person;
    });

    var mostPopularFirstName = _.invert(mostPopularFirstNameGrouped)[mostOccurenceFName]

   
    console.log("Most common first name -> ", mostPopularFirstName, " -> ", mostOccurenceFName);

    var mostPopularLastNameGrouped =

       _.countBy(arrayOfPeople, function (person) {
           return person.lastName;
       })

    console.log(mostPopularLastNameGrouped);

    var mostOccurenceLName = _.max(mostPopularLastNameGrouped, function (person) {
        return person;
    });

    var mostPopularLastName = _.invert(mostPopularLastNameGrouped)[mostOccurenceLName]


    
    console.log("Most common last name -> ", mostPopularLastName, " -> ", mostOccurenceLName);
}