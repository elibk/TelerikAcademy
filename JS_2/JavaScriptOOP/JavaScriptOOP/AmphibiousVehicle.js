/// <reference path="Vehicle.js" />


function AmphibiousVehicle(speed, numberPropellers, numberOfPropellerFins, wheelRadius) {
    var self = this;
    Vehicle.apply(this, arguments);
    
    self.getLandMode = function getLandMode() {
        return _landMode;
    };

    self.getWaterMode = function getWaterMode() {
        return _waterMode;
    };

    self.mode = "land";

    var _landMode = new LandVehicle(speed, wheelRadius);
    var _waterMode = new WaterVehicle(speed, numberPropellers, numberOfPropellerFins);
    

    self.switchOnLandMode();
     
  
}

AmphibiousVehicle.inherit(Vehicle);

AmphibiousVehicle.prototype.switchOnLandMode = function switchOnLandMode() {
   
    this.mode = "land";
};

AmphibiousVehicle.prototype.switchOnWaterMode = function switchOnWaterMode() {

    this.mode = "water";
};

AmphibiousVehicle.prototype.accelerate = function accelerateAm() {

    var mode;
    if (this.mode === "land") {

       mode = this.getLandMode();
    } else if (this.mode === "water") {

        mode = this.getWaterMode();
    }
    mode.accelerate();
    this.setSpeed(mode.getSpeed());
};