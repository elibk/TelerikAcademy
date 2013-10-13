var School = {

    init: function schoolInit(name, town, classes) {
        this.name = name;
        this.town = town;

        if (!classes) {

            this.classes = [];
        } else {

            this.classes = classes;
        }

        return this;
    },

    getFullReport: function getFullReport() {

        var that = this;
        var classes = (function getSetOfClassesToString() {

            var strigBuilder = [];

            for (var i = 0; i < that.classes.length; i++) {
                strigBuilder.push('\n');
                strigBuilder.push(that.classes[i].toString());

            }

            return strigBuilder.join();
        })();

        var result = String.format("School Name : {0}  Town : {1} \n Classes : {2}", this.name, this.town, classes);

        return result;
    }
};