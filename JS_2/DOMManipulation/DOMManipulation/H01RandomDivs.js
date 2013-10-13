function randomFromInterval(from, to) {
    return Math.floor(Math.random() * (to - from + 1) + from);
}

function generateColor() {
    var red = randomFromInterval(0, 255),
        green = randomFromInterval(0, 255),
        blue = randomFromInterval(0, 255);

    return 'rgb(' + red + ', ' + green + ', ' + blue + ')';
}

function createRandomDivs(divsCount) {
    var numOfDivs = document.getElementById('divsCount').value.toString();
    numOfDivs = parseInt(numOfDivs, 10);
    divsCount = divsCount || numOfDivs || 10;

    //var time = new Date();
    var frag = document.createDocumentFragment();
    var i;
    for (i = 0; i < divsCount; i += 1) {

        // tested in Chrome - for 10000 divs : 
        // createElement -> (956 miliseconds) cloneNode -> (1346 miliseconds)
        var div = document.createElement('div'),
            strong = document.createElement("strong");
        strong.appendChild(document.createTextNode('div'));
        div.appendChild(strong);

        div.className = 'random-div';

        div.style.color = generateColor();

        var width = randomFromInterval(20, 100),
            height = randomFromInterval(20, 100);
        div.style.width = width + 'px';
        div.style.height = height + 'px';

        var positionTop = randomFromInterval(100, 500),
            positionRight = randomFromInterval(25, 90);
        div.style.position = 'absolute';
        div.style.top = positionTop + 'px';
        div.style.right = positionRight + '%';

        div.style.backgroundColor = generateColor();

        var borederWidth = randomFromInterval(1, 20),
            borderRadius = randomFromInterval(0, 50);
        div.style.border = borederWidth + 'px' + ' solid ' + generateColor();
        div.style.borderRadius = borderRadius + 'px';

        frag.appendChild(div);

    }
    document.body.appendChild(frag);
   // console.log(new Date() - time);
}

