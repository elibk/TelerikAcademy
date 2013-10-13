var buttonStart = document.getElementById('start');
var buttonStop = document.getElementById('stop');
changeElementDisplay(buttonStart, 'none');
changeElementDisplay(buttonStop, 'none');

var allDivs;
var angle = 0;
var interval;


function createDivs() {

    stopAnimation();

    var numOfDivs = document.getElementById('divsCount').value.toString();
    createRandomDivs(numOfDivs); // I'm using the script from H01RandomDivs
    allDivs = document.querySelectorAll('.random-div');

}

function animateDivs(divsCount, elementsCollection, angle, radius) {

    divsCount = divsCount || 5;
    elementsCollection = elementsCollection || document.querySelectorAll('div');
    angle = angle || 0;
    radius = radius || 50;

    for (i = 0; i < divsCount; i += 1) {

        elementsCollection[i].style.margin = '350px';
        elementsCollection[i].style.top = Math.cos(angle + 2 * Math.PI / divsCount * i) / radius * 10000 + 'px';
        elementsCollection[i].style.left = Math.sin(angle + 2 * Math.PI / divsCount * i) / radius * 10000 + 'px';
    }

    angle = angle + 0.1;
}

function startAnimation() {

    interval = self.setInterval(function () { animateDivs(allDivs.length, allDivs, angle += 0.1); }, 100);

    changeElementDisplay(buttonStart, 'none');
    changeElementDisplay(buttonStop);
}

function stopAnimation() {
    interval = window.clearInterval(interval);

    changeElementDisplay(buttonStop, 'none');
    changeElementDisplay(buttonStart);
}


function changeElementDisplay(element, dispalyState) {

    dispalyState = dispalyState || '';
    element.style.display = dispalyState;
}


