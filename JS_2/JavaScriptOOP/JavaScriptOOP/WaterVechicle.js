/// <reference path="Vehicle.js" />


function WaterVehicle(speed, numberPropellers, numberOfPropellerFins) {
    var self = this;
    Vehicle.apply(this, arguments);

    self.setNumberOfPropellerFins = function setNumberOfPropellerFins(numberOfPropellerFins) {
        self._numberOfPropellerFins = numberOfPropellerFins;
    };

    self.getNumberOfPropellerFins = function getNumberOfPropellerFins() {
        return self._numberOfPropellerFins;
    };

    self.setNumberOfPropellers = function setNumberOfPropellers(numberPropellers) {
        self._numberPropellers = numberPropellers;
    };

    self.getNumberOfPropellers = function getNumberOfPropellers() {
        return self._numberPropellers;
    };


    var propUnits = [];
    
    var _numberPropellers = self.setNumberOfPropellers(numberPropellers);
    var _numberOfPropellerFins = self.setNumberOfPropellerFins(numberOfPropellerFins);
   
    for (var i = 0; i < self.getNumberOfPropellers(); i++) {
        propUnits.push(new Propeller(self.getNumberOfPropellerFins()));
    }
    var _propulsionUnits = propUnits;
    self.setPropulsionUnits(_propulsionUnits);
}

WaterVehicle.inherit(Vehicle);

WaterVehicle.prototype.spinDirectionClockwise = function spinDirectionClockwise() {
    var units = this.getPropulsionUnits();

    var unitsLen = units.length;
    for (var i = 0; i < unitsLen; i += 1) {
        units[i].setSpinDirection("clockwise");
    }
};

WaterVehicle.prototype.spinDirectionCounterClockwise = function spinDirectionClockwise() {
    var units = this.getPropulsionUnits();
    var unitsLen = units.length;
    for (var i = 0; i < unitsLen; i += 1) {
        units[i].setSpinDirection("counter-clockwise");
    }
};