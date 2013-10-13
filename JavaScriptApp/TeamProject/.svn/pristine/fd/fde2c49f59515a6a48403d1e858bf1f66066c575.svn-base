/// <reference path="prototype.js" />
/// <reference path="jquery-2.0.2.js" />
/// <reference path="RecyclingGameNS.js" />
/// <reference path="TrashBinsNS.js" />
/// <reference path="string-extention.js" />

RecyclingGameNS.Timer = Class.create({

    initialize: function initTimer() {
    
        this.pastTime;

        this.interval;
        this.timerContainer =$j("#timer");

    },

    initEvents: function initEvents() {

    },

   

    timerRun: function timerRun(gameEingineInstance) {
        this.pastTime -= 1;
        this.timerContainer.val(this.pastTime);
        if (this.pastTime <= 0) {
            gameEingineInstance.gameOver();
            this.interval = clearInterval(this.interval);
        }
       
    },

    start: function setTimer(pastTime, gameEingineInstance) {
        var that = this;
        this.interval = clearInterval(this.interval);
        this.pastTime = pastTime;
        this.interval = setInterval(function () { that.timerRun(gameEingineInstance); }, 100);
    },

    pause: function pause() {
        this.interval = clearInterval(this.interval);
    },

    resume: function resume(gameEingineInstance) {
        var that = this;
        this.interval = setInterval(function () { that.timerRun(gameEingineInstance); }, 100);
    }


});