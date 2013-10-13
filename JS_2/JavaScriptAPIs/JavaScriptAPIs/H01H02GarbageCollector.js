//// refactored and upgrade view folder 'RecyclingGame'
var container = document.getElementById("wrapper");
var scoreBoard = document.getElementById("scores");
scoreBoard.style.position = 'absolute';
scoreBoard.style.right = '10%';
var openBinImg = document.getElementById('trash-bin-open');
openBinImg.style.position = 'absolute';
openBinImg.style.bottom = '10%';
openBinImg.style.width = '10%';
openBinImg.addEventListener('dragleave', closeBin, false);
openBinImg.addEventListener('drop', onDropThrowTrash);
var closedBinImg = document.getElementById('trash-bin-closed');
closedBinImg.style.position = 'absolute';
closedBinImg.addEventListener('dragenter', openBin);
closedBinImg.style.bottom = '10%';
var initialNumberOfTrash = 10;
var timer = 0;
var countOfTopScores = 5;
var nameOfScores = "RecyclingScores";
newGame();
closeBin();

//localStorage.clear();

var int;

function clock() {
    timer += 1;
    document.getElementById("clock").value = timer;
    checkForEnd();
   
}

function checkForEnd() {
    var trash = document.getElementsByClassName('trash');
    if (trash.length === 0) {
        int = self.clearInterval(int);
      
        updateScores(timer);
    }
}
  
function getPlayerName() {
    var name = prompt("Well done! You menage to throw the whole trash! Please enter your name.", "anonymous");
    if (name === null) {
        name = 'anonymous';
    }
    return name;
}

function updateScores(playerScore) {
    var playerName = getPlayerName();
    var scores = localStorage.getObject(nameOfScores);

    if (!scores) {
        scores = [];
    }

    scores.push({ player: playerName, score: playerScore });

    scores.sort(orderBy);

    if (scores.length > countOfTopScores) {

        scores.pop();
    }

    localStorage.setObject(nameOfScores, scores);
    displayScores();
}

function orderBy(a, b) {
    return (a.score === b.score) ? 0 : (a.score > b.score) ? 1 : -1;
}

function displayScores() {
    var scores = localStorage.getObject(nameOfScores);

    if (!scores || scores.length === 0) {

        document.getElementById("scores").innerHTML = "Be the first to make score";
        return;

    }

    var resultHTML = "<ul>";
    for (var i = 0; i < scores.length; i += 1) {
        resultHTML +=
        '<li>' +
        '<strong>plase</strong>: ' + (i + 1) + '<br/>score :<strong> ' + scores[i].score + "</strong> player: <strong>" + scores[i].player +
        '</strong></li>';
    }
    resultHTML += "</ul>";
    document.getElementById("scores").innerHTML = resultHTML;
}

function closeBin(ev){
    
    openBinImg.style.display = 'none';
    closedBinImg.style.display = '';
}

function openBin(ev) {
    openBinImg.style.display = '';
    closedBinImg.style.display = 'none';
}

function drag(ev) {
    ev.dataTransfer.setData("dragged-trash", ev.target.id);
}

function onDropThrowTrash(ev) {
    ev.preventDefault();
    var dragedTrashId = ev.dataTransfer.getData("dragged-trash");
    var dragedTrash = document.getElementById(dragedTrashId);
    var parentTrash = dragedTrash.parentNode;
    parentTrash.removeChild(dragedTrash);
    closeBin();
}

function allowDrop(ev) {
    ev.preventDefault();
}

function randomFromInterval(from, to) {
    return Math.floor(Math.random() * (to - from + 1) + from);
}

function newGame() {
    timer = 0;
    removeOldTrash();
    addTrash();
    displayScores();
    int = clearInterval(int);
    int = self.setInterval(function () { clock(); }, 100);
}
  
function addTrash() {
    
    var count;
    var trash;
    for (count = 0; count < initialNumberOfTrash; count += 1) {
        trash = document.createElement('img');
        trash.src = 'pics\\trash.jpg';
        trash.id = 'trash-' + count;
        trash.className = 'trash';
        trash.draggable = 'true';
        trash.addEventListener('dragstart', drag);
        trash.style.position = 'absolute';
        trash.style.left = randomFromInterval(20, 90) + '%';
        trash.style.top = randomFromInterval(0, 80) + '%';
        container.appendChild(trash);
    }
}

function removeOldTrash() {

    var trash = document.getElementsByClassName('trash');
    
    var trashLen = trash.length;
    var parent;
    for (var i = trashLen - 1; i >= 0; i -= 1) {
        parent = trash[i].parentNode;
        parent.removeChild(trash[i]);
    }

}
