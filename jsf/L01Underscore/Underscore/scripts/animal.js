var Animal = Class.create({
    init: function (species, kind, numberOfLegs) {
        var possibleNumberOfLegs = [2, 4, 6, 8, 100];

        this.species = species;
        this.kind = kind;

        if (possibleNumberOfLegs.indexOf(numberOfLegs) < 0) {

            throw new Error(
                "Invalid number of legs. The number of legs should be on of the following values :"
                + possibleNumberOfLegs);
        }

        this.numberOfLegs = numberOfLegs;
    },
    toString: function () {
        return this.species + "-> " + this.kind + " number of legs: " + this.numberOfLegs;
    }
});