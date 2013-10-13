/// <reference path="Vehicle.js" />


function AirVehicle(speed, nozzlePower) {
    var self = this;
    Vehicle.apply(this, arguments);

    self.getNozzlePower = function getNozzlePower() {
        return self._nozzlePower;
    };

    self.setNozzlePower = function setNozzlePower(nozzlePower) {
        self._nozzlePower = nozzlePower;
    };

    var _nozzlePower = self.setNozzlePower(nozzlePower);

    self.setPropulsionUnits([
        new PropellingNozzle(self.getNozzlePower(),"off"),
    ]);
}

AirVehicle.inherit(Vehicle);

AirVehicle.prototype.switchOn = function switchOnAfterburner() {
    var nozzle = this.getPropulsionUnits()[0];
    nozzle.setAfterburnerPowerState("on");
};

AirVehicle.prototype.switchOff = function switchOffAfterburner() {
    var nozzle = this.getPropulsionUnits()[0];
    nozzle.setAfterburnerPowerState("off");
};