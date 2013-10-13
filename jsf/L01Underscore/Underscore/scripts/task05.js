/// <reference path="../lib/underscore.js" />
/// <reference path="animal.js" />
function task05() {

    var arrayOfAnimals = [
                  new Animal('mammal', 'dog', 4),
                  new Animal('bird', 'eagle', 2),
                  new Animal('mammal', 'cat', 4),
                  new Animal('mammal', 'bat', 2),
                  new Animal('insect', 'centipede', 100),
                  new Animal('insect', 'fly', 4),
                  new Animal('bird', 'sparrow', 2),
    ];

    console.log(":-v ");
    console.log("The initial set of animals:");
    console.log(":-v ");

    var totalLegs = 0;

    _.each(arrayOfAnimals, function (animal) {
        console.log(animal.toString());
        totalLegs += animal.numberOfLegs;
    })

    

    console.log(":-v ");
    console.log("Total legs: ", totalLegs);
    console.log(":-v ");

}