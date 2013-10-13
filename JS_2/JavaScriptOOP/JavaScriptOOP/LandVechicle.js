
function LandVehicle(speed, wheelRadius) {
    var self = this;
    Vehicle.apply(this, arguments);

    self.getWheelRadius = function getWheelRadius() {
        return self._wheelRadius;
    };

    self.setWheelRadius = function setWheelRadius(wheelRadius) {
        self._wheelRadius = wheelRadius;
    };

    var _wheelRadius = self.setWheelRadius(wheelRadius);

    self.setPropulsionUnits([
        new Wheel(self.getWheelRadius()),
        new Wheel(self.getWheelRadius()),
        new Wheel(self.getWheelRadius()),
        new Wheel(self.getWheelRadius())
    ]);


}

LandVehicle.inherit(Vehicle);