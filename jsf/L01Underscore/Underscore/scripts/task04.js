/// <reference path="animal.js" />
/// <reference path="../lib/underscore.js" />
function task04() {

    var arrayOfAnimals = [
                   new Animal('mammal', 'dog', 4),
                   new Animal('bird', 'eagle', 2),
                   new Animal('mammal', 'cat', 4),
                   new Animal('mammal', 'bat', 2),
                   new Animal('insect', 'centipede', 100),
                   new Animal('insect', 'fly', 4),
                   new Animal('bird', 'sparrow', 2),
    ];

    var groupedByNumberOfLegsAnimals = _.groupBy(arrayOfAnimals, function (animal) {
        return animal.species;
    })

    console.log("TASK 04");
    _.each(groupedByNumberOfLegsAnimals, function (animalType) {
        console.log(animalType[0].species);

        _.chain(animalType)
            .sortBy(function (animal) {
                return animal.numberOfLegs;
            })
                .each(function (animalObj) {
                    console.log(animalObj.toString());
                });
    })
}