/// <reference path="prototype.js" />
/// <reference path="jquery-2.0.2.js" />
/// <reference path="RecyclingGameNS.js" />
/// <reference path="string-extention.js" />
/// <reference path="TrashBinsNS.js" />
/// <reference path="trash-bin.js" />
/// <reference path="recycling-trash-bin.js" />
/// <reference path="TrashNS.js" />
/// <reference path="trash.js" />
/// <reference path="recycling-trash.js" />
/// <reference path="scoreboard.js" />
/// <reference path="timer.js" />
/// <reference path="recyclingType.js" />


RecyclingGameNS.GameEngine = Class.create({

    initialize: function initGame(scoreboard, timer) {
        this.container = $('#game-container');
        this.dumpsite = $('#dumpsite');

        this.scoreboard = scoreboard;
        this.timer = timer;

        this.initialTrashCount = 5;
        this.stepOfIncreasing = 3;
        this.initailTime = 300;

        this.scoreUpToNow = 0;
        this.currentLevel = 0;
        //this.remainingTrash = 0;

        this.trashBins = [
             new RecyclingGameNS.TrashBins.RecyclingTrashBin('../images/plastic-and-iron-can.png', RecyclingGameNS.recyclingType.plasticAndIron),
             new RecyclingGameNS.TrashBins.RecyclingTrashBin('../images/glass-can.png', RecyclingGameNS.recyclingType.glass),
             new RecyclingGameNS.TrashBins.RecyclingTrashBin('../images/paper-can.png', RecyclingGameNS.recyclingType.paper),
        ];
        
        this._renderTrashBins();
        this.trash = [];
    },

    _renderTrashBins: function renderTrashBins() {
        function initEvBins(ev) {

            var dragetTrashId = ev.dataTransfer.getData("dragged-trash");
            var currentTrash = this.trash[dragetTrashId];
            if (currentTrash.getType() === $(ev.target).attr('type')) {

                currentTrash.dispose();
                this.splice(dragetTrashId, 1)

                if (this.trash.length === 0) {
                    this.scoreUpToNow += this.scoreboard.calculateScore(this.timer.pastTime, this.currentLevel);

                    this.nextLevel();
                }
            }
            else {

                return;
            }
        }


        for (var i = 0; i < this.trashBins.length; i += 1) {
            var newTrashBin = $(String.format('<img src="{0}" type="{1}"/>', this.trashBins[i].src, this.trashBins[i].type));
            newTrashBin.on('drop', initEvBins);
            this.container.append(newTrashBin);
        }
    },

    newGame: function newGame() {
       
        this.scoreUpToNow = 0;
        this.currentLevel = 0;
        this.remainingTrash = 0;
        this._cleanOldTrash();
        this.nextLevel();
    },

    _cleanOldTrash: function cleanOldTrash() {

        for (var i = 0; i < this.trash.length; i++) {
            this.trash[i].dispose();
        }

        this.trash = [];
    },

    _generateTrash: function generateTrash(currentTrashCount) {

        function onDrag(ev) {
           
            ev.dataTransfer.setData("dragged-trash", ev.target.id);
        }
       
        for (var i = 0; i < currentTrashCount; i += 1) {
            var newTrash = new RecyclingGameNS.TrashItems.RecyclingTrash('../images/paper.png', RecyclingGameNS.recyclingType.paper);
            newTrash.setId(i);
            newTrash.initEvent('dragstart', onDrag);
            this.trash.push(newTrash);
            newTrash.throwIt(this.dumpsite);
        }

    },

    nextLevel: function nextLevel() {
        this.currentLevel++;
        var currentTrashCount = this.currentLevel * this.stepOfIncreasing + this.initialTrashCount;
        // time ???
        //ToDo: setTimer
        this._generateTrash(currentTrashCount);
    },

    gameOver: function gameOver() {
       
        var playerName = this.scoreboard.getPlayersName();
        this.scoreboard.saveData(playerName, this.scoreUpToNow);
    },

});