﻿/// <reference path="prototype.js" />
/// <reference path="jquery-2.0.2.js" />
/// <reference path="RecyclingGameNS.js" />
/// <reference path="TrashBinsNS.js" />
/// <reference path="string-extention.js" />

RecyclingGameNS.Timer = Class.create({

    initialize: function initTimer() {
    
        this.pastTime;

        this.interval;
        this.timerContainer =$("#timer");

    },

    initEvents: function initEvents() {

    },

   

    timerRun : function timerRun() {
    this.pastTime -= 1;
    this.timerContainer.val(pastTime);
    if (gameManager.isGameOver()) {
        this.interval = clearInterval(this.interval);
        gameManager.endGame(pastTime);
    }
            

    },

    start: function setTimer(pastTime) {
        this.interval = clearInterval(this.interval);
        this.pastTime = pastTime;
        this.interval = setInterval(function () { this.timerRun(); }, 100);
    },

    pause: function pause() {
        this.interval = clearInterval(this.interval);
    },

    resume: function resume() {
        this.interval = setInterval(function () { this.timerRun(); }, 100);
    }


});