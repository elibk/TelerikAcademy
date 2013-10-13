
function onDropThrowGlassTrash(ev) {
    if (!ev) {

        ev = window.event;
    }
    ev.preventDefault();
    var dragedTrashId = ev.dataTransfer.getData("dragged-trash");
    if (dragedTrashId.substring(0, dragedTrashId.indexOf('-')) === 'glass') {
        var dragedTrash = document.getElementById(dragedTrashId);
        var parentTrash = dragedTrash.parentNode;
        parentTrash.removeChild(dragedTrash); 
    }

    var bin = ev.target;
    binId = bin.id.toString();
    binType = binId.substring(0, binId.indexOf('-'));
    binIdWidthoutState = binId.substring(0, binId.lastIndexOf('-'));

    var closedBin = document.getElementById(binIdWidthoutState + '-closed');

    bin.style.display = 'none';
    closedBin.style.display = '';
}

function onDropThrowPaperTrash(ev) {
    if (!ev) {

        ev = window.event;
    }
    ev.preventDefault();
    var dragedTrashId = ev.dataTransfer.getData("dragged-trash");
    if (dragedTrashId.substring(0, dragedTrashId.indexOf('-')) === 'paper') {
        var dragedTrash = document.getElementById(dragedTrashId);
        var parentTrash = dragedTrash.parentNode;
        parentTrash.removeChild(dragedTrash);

        
    }

    var bin = ev.target;
    binId = bin.id.toString();
    binType = binId.substring(0, binId.indexOf('-'));
    binIdWidthoutState = binId.substring(0, binId.lastIndexOf('-'));

    var closedBin = document.getElementById(binIdWidthoutState + '-closed');

    bin.style.display = 'none';
    closedBin.style.display = '';

}

function onDropThrowMetalOrPlasticTrash(ev) {
    if (!ev) {

        ev = window.event;
    }
    ev.preventDefault();
    var dragedTrashId = ev.dataTransfer.getData("dragged-trash");
    if (dragedTrashId.substring(0, dragedTrashId.indexOf('-')) === 'plasticOrMetal') {
        var dragedTrash = document.getElementById(dragedTrashId);
        var parentTrash = dragedTrash.parentNode;
        parentTrash.removeChild(dragedTrash);
    }

    var bin = ev.target;
    binId = bin.id.toString();
    binType = binId.substring(0, binId.indexOf('-'));
    binIdWidthoutState = binId.substring(0, binId.lastIndexOf('-'));

    var closedBin = document.getElementById(binIdWidthoutState + '-closed');

    bin.style.display = 'none';
    closedBin.style.display = '';
  
}

function drag(ev) {
    if (!ev) {

        ev = window.event;
    }
    ev.dataTransfer.setData("dragged-trash", ev.target.id);
}

function closeBin(ev) {
    if (!ev) {

        ev = window.event;
    }
    ev.preventDefault();
    var bin = ev.target;
    binId = bin.id.toString();
    binType = binId.substring(0, binId.indexOf('-'));
    binIdWidthoutState = binId.substring(0, binId.lastIndexOf('-'));
   
    var closedBin = document.getElementById(binIdWidthoutState + '-closed');
   
    bin.style.display = 'none';
    closedBin.style.display = '';
}

function openBin(ev) {
    if (!ev) {

        ev = window.event;
    }
    ev.preventDefault();
    var bin = ev.target;
    binId = bin.id.toString();
    binType = binId.substring(0, binId.indexOf('-'));
    binIdWidthoutState = binId.substring(0, binId.lastIndexOf('-'));

    var binOpen = document.getElementById(binIdWidthoutState + '-open');

    bin.style.display = 'none';
    binOpen.style.display = '';
}

function allowDrop(ev) {
    if (!ev) {

        ev = window.event;
    }
    ev.preventDefault();
}

function onClickNewGame(ev) {
    if (!ev) {

        ev = window.event;
    }

    document.getElementById('resume').style.display = 'none';
    document.getElementById('pause').style.display = 'inline-block';
    gameManager.play();
    
    return false;
}

function onClickPause(ev) {
    if (!ev) {

        ev = window.event;
    }
    document.getElementById('pause').style.display = 'none';
    document.getElementById('resume').style.display = 'inline-block';
    timer.pause();

    return false;
}


function onClickResume(ev) {
    document.getElementById('resume').style.display = 'none';
    document.getElementById('pause').style.display = 'inline-block';
    timer.resume();

    return false;
}