
function Vehicle(speed, propulsionUnits) {

    var self = this;

    self.setSpeed = function setSpeed(speed) {
        self._speed = speed;
    };

    self.getSpeed = function getSpeed() {
        return self._speed;
    };

    self.setPropulsionUnits = function setPropulsionUnits(propulsionUnits) {
        self._propulsionUnits = propulsionUnits;
    };
    self.getPropulsionUnits = function getPropulsionUnits() {
        return self._propulsionUnits;
    };

    var _speed = self.setSpeed(speed);
    var _propulsionUnits = self.setPropulsionUnits(propulsionUnits) || [];

   
}

Vehicle.prototype.accelerate = function accelerate() {

        var speed = this.getSpeed();
        var propulsionUnits = this.getPropulsionUnits();

        for (var i = 0; i < propulsionUnits.length; i++) {
            speed += propulsionUnits[i].calculateProducedAcceleration();
        }
        this.setSpeed(speed);
};