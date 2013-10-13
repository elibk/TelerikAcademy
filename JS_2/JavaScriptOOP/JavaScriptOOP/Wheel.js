/// <reference path="PropulsionUnit.js" />


function Wheel(radius) {
    var self = this;
    PropulsionUnit.apply(this, arguments);

    self.setRadius = function setRadius(radius) {
        self._radius = radius;
    };

    self.getRadius = function getRadius() {
        return self._radius;
    };

    var _radius = self.setRadius(radius) || 0;
}

Wheel.inherit(PropulsionUnit);

Wheel.prototype.calculateProducedAcceleration = function calculateAccelerationWheel() {

    var radius = this.getRadius();
    var acceleration = radius * 2;

    return acceleration;
};