function movingShapesModule() {

    var elementWidth = '50px',
        elementHeight = '50px',
        borderWidth = '5px',
        elementText = 'div4e';

    var container = document.getElementById("wrapper");
    var circleDivLeftPosition = 1000;
    var circleDivTopPosition = 200;
    var circleDivRadius = 150;
    var rectDivLeftPosition = 50;
    var rectDivTopPosition = 100;
    var maxRectCoordinates = { x: 500, y: 300 };

    var direction = {right : 'right', left: 'left', up : 'up', down : 'down'};

    var circleDivs = [];
    var rectDivs = [];

    setInterval(function () { moveInEllipse(circleDivs); }, 100);
    setInterval(function () { moveInRectangle(rectDivs); }, 100);

    function randomFromInterval(from, to) {
        return Math.floor(Math.random() * (to - from + 1) + from);
    }

    function generateColor() {
        var red = randomFromInterval(0, 255),
            green = randomFromInterval(0, 255),
            blue = randomFromInterval(0, 255);

        return 'rgb(' + red + ', ' + green + ', ' + blue + ')';
    }


    function createDiv() {
        var div = document.createElement('div');
        div.style.backgroundColor = generateColor();
        div.style.width = elementWidth;
        div.style.position = "absolute";
        div.style.height = elementHeight;
        div.style.border = borderWidth + ' solid ' + generateColor();
        div.appendChild(document.createTextNode(elementText));
        div.style.color = generateColor();

        return div;
    }

    function add(movingType) {
        var div = createDiv();
        if (movingType === "rect") {
            
            rectDivs.push({ element: div, coordinates: { x: rectDivLeftPosition, y: rectDivTopPosition }, direction: direction.right });
        }
        else if (movingType === "ellipse") {

            circleDivs.push({ element: div, angle: 0 });
        }
        
        container.appendChild(div);
    }


    function moveInEllipse() {

        var x = 0, y = 0, len = circleDivs.length;
        var i;
        for (i = 0; i < len; i += 1) {
            circleDivs[i].angle += 0.1;
            x = circleDivLeftPosition + circleDivRadius * Math.cos(circleDivs[i].angle);
            y = circleDivTopPosition + circleDivRadius * Math.sin(circleDivs[i].angle);
            circleDivs[i].element.style.position = 'absolute';
            circleDivs[i].element.style.left = x + 'px';
            circleDivs[i].element.style.top = y + 'px';
        }
    }


    function moveInRectangle() {
        var i, len = rectDivs.length;
        for (i = 0; i < len; i += 1) {

            CheckforChangeOfDirection(rectDivs[i]);

            PreformMove(rectDivs[i]);

            rectDivs[i].element.style.left = rectDivs[i].coordinates.x + 'px';
            rectDivs[i].element.style.top = rectDivs[i].coordinates.y + 'px';
        }
    }
  
    function PreformMove(movingElement) {
        if (movingElement.direction === direction.right) {
            movingElement.coordinates.x += 10;
        }
        else if (movingElement.direction === direction.down) {
            movingElement.coordinates.y += 10;
        }
        else if (movingElement.direction === direction.left) {
            movingElement.coordinates.x -= 10;
        }
        else if (movingElement.direction === direction.up) {
            movingElement.coordinates.y -= 10;
        }
    }
  
    function CheckforChangeOfDirection(movingElement) {
        if (movingElement.direction === direction.right && movingElement.coordinates.x >= maxRectCoordinates.x) {
            movingElement.direction = direction.down;
        }
        else if (movingElement.direction === direction.down && movingElement.coordinates.y >= maxRectCoordinates.y) {
            movingElement.direction = direction.left;
        }
        else if (movingElement.direction === direction.left && movingElement.coordinates.x <= rectDivLeftPosition) {
            movingElement.direction = direction.up;
        }
        else if (movingElement.direction === direction.up && movingElement.coordinates.y <= rectDivTopPosition) {
            movingElement.direction = direction.right;
        }
    }

    return {
        add: add
    };

}