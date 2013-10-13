/// <reference path="PropulsionUnit.js" />>

function PropellingNozzle(nozzle, afterburnerPowerState) {
    var self = this;
    afterburnerPowerState = afterburnerPowerState || self.afterburnerPowerStates[0];
    PropulsionUnit.apply(this, arguments);

    self.setNozzle = function setNozzle(nozzle) {
        self._nozzle = nozzle;
    };

    self.getNozzle = function getNozzle() {
        return self._nozzle;
    };

    self.setAfterburnerPowerState = function setAfterburnerPowerState(afterburnerPowerState) {
        if (self.afterburnerPowerStates.indexOf(afterburnerPowerState) >= 0) {
            self._afterburnerPowerState = afterburnerPowerState;
        } else {
            var possibleValues = self.afterburnerPowerStates.join('" or "');
            throw new Error('Invalid Arrument for \'afterburnerPowerState\'. The only posible values are "' + possibleValues + '".');
        }
    };

    self.getAfterburnerPowerState = function getAfterburnerPowerState() {
        return self._afterburnerPowerState;
    };

    var _nozzle = self.setNozzle(nozzle);
    var _afterburnerPowerState = self.setAfterburnerPowerState(afterburnerPowerState);
}

PropellingNozzle.inherit(PropulsionUnit);

PropellingNozzle.prototype.calculateProducedAcceleration = function calculateAccelerationPropellingNozzle() {

    var acceleration = this.getNozzle();
    if (this.getAfterburnerPowerState() === "on") {
        acceleration *= 2;
    }

    return acceleration;
};

PropellingNozzle.prototype.afterburnerPowerStates = ["off", "on"];

