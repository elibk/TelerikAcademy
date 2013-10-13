

function Propeller(numberOfFins, spinDirection) {
    var self = this;
    spinDirection = spinDirection || self.spinDirections[0];
    PropulsionUnit.apply(this, arguments);

    self.setNumberOfFins = function setNumberOfFins(numberOfFins) {
        self._numberOfFins = numberOfFins;
    };

    self.getNumberOfFins = function getNumberOfFins() {
        return self._numberOfFins;
    };

    self.setSpinDirection = function getSpinDirection(spinDirection) {
        if (self.spinDirections.indexOf(spinDirection) >= 0) {
            self._spinDirection = spinDirection;
        } else {
            var possibleValues = self.spinDirections.join('" or "');
            throw new Error('Invalid Arrgument for \'spinDirection\'. The only posible values are "' + possibleValues + '".');
        }
    };

    self.getSpinDirection = function getSpinDirection() {
        return self._spinDirection;
    };

    var _spinDirection = self.setSpinDirection(spinDirection);
   var _numberOfFins = self.setNumberOfFins(numberOfFins);
}

Propeller.inherit(PropulsionUnit);

Propeller.prototype.calculateProducedAcceleration = function calculateAccelerationPropellingPropeller() {

    var acceleration = this.getNumberOfFins();
    if (this.getSpinDirection() === "counter-clockwise") {
        acceleration *= -1;
    }

    return acceleration;
};

Propeller.prototype.spinDirections = ["clockwise", "counter-clockwise"];