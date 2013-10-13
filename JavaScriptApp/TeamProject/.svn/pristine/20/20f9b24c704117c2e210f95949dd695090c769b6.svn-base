/// <reference path="jquery-2.0.2.js" />
describe("Score Board", function(){
var scoreboard;
var container = '#highScores';
var topPlayersCount = 5;

beforeEach(function(){
scoreboard = new RecyclingGameNS.Scoreboard(container, topPlayersCount);
});

describe("score board init", function(){
it("Should set correct values",function(){
expect(scoreboard._topPlayersCount).toBe(topPlayersCount);
expect(scoreboard._container).toBe(container);
});
});
})

describe("Game Engine", function(){
var highScoreInstance;
var timerInstance;
var container = '#highScores';
var topPlayersCount = 5;
var curLevel=0;

beforeEach(function(){
highScoreInstance = new RecyclingGameNS.Scoreboard(container, topPlayersCount);
});
beforeEach(function(){
timerInstance = new RecyclingGameNS.Timer();
});
beforeEach(function(){
engine = new RecyclingGameNS.GameEngine(highScoreInstance, timerInstance);
});

describe("Game Engine init", function(){
it("Should set correct values",function(){
expect(engine.scoreboard).toBe(highScoreInstance);
expect(engine.timer).toBe(timerInstance);
});
});

describe("New Game", function(){
it("When New Game button is pressed", function(){
expect(engine.scoreUpToNow).toBe(0);
expect(engine.currentLevel).toBe(0);
});
});

describe("Next Level", function(){
it("When switching levels in game", function(){
engine.nextLevel();
expect(engine.currentLevel).toBe(curLevel+1);
});
});

})

/*
describe("Timer", function(){
var timer;
var tcontainer = '#timer';


beforeEach(function(){
timer = new RecyclingGameNS.Timer();
});

describe("timer init", function(){
it("Should set correct values",function(){
expect(timer.timerContainer).toBe(tcontainer);
});
});
})
*/

/*describe("Recycling Trash Bin", function(){
var trashBin;

 beforeEach(function(){
trashbin = new RecyclingGameNS.TrashBins.RecyclingTrashBin('../images/plastic-and-iron-can.png', RecyclingGameNS.recyclingType.plasticAndIron);
});

})
*/
/*describe("GameEngine", function(){
//var container = $j('#game-container');
//var dumpsite = $j('#dumpsite');

var initialTrashCount = 3;
var stepOfIncreasing = 3;
var initailTime = 300;
var scoreUpToNow = 0;
var currentLevel = 0;
var remainingTrash = 0;
var trashBins;

beforeEach(function(){
trashBins = [
             new RecyclingGameNS.TrashBins.RecyclingTrashBin('../images/plastic-and-iron-can.png', RecyclingGameNS.recyclingType.plasticAndIron),
             new RecyclingGameNS.TrashBins.RecyclingTrashBin('../images/glass-can.png', RecyclingGameNS.recyclingType.glass),
             new RecyclingGameNS.TrashBins.RecyclingTrashBin('../images/paper-can.png', RecyclingGameNS.recyclingType.paper),
        ];
		});
		
		describe("Game Init",function(){
		it("Should set correct values", function(){
		//expect(this.initialTrashCount).toEqual(initialTrashCount);
		expect(trashBins.Length).toBe(3);
		});
		});
		})
*/
//describe("ScoreBoard", function(){
//var scoreboard;
//var timer;

//beforeEach(function(){
//scoreboard = new RecyclingGameNS.Scoreboard('#highScores', 5);
//});
//beforeEach(function(){
//timer = new RecyclingGameNS.Timer();
//});

//describe("InitGame", function(){
//it("Should set correct values", function(){
//expect(this.scoreboard).toBe(scoreboard);
//});
//});
//})