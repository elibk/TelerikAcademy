; (function myfunction() {
    var canvasBox = document.getElementById('box');
    var width = canvasBox.width;
    var height = canvasBox.height;
    var ctx = canvasBox.getContext("2d");
    ctx.strokeStyle = "#257184";
    ctx.fillStyle = "#90CAD7";
    
    var speedGame = 20;
    
    var borderWidth = 5;
    var circleRadius = 6;
    
    var minCircleX = borderWidth + circleRadius;
    var minCircleY = borderWidth + circleRadius;
    var maxCircleX = width - (borderWidth + circleRadius);
    var maxCircleY = height - (borderWidth + circleRadius);
    var circleX = minCircleX;
    var circleY = Math.floor(maxCircleY / 2);
    var directions = { RightDown: 'RightDown', RightUp: 'RightUp', LeftUp: 'LeftUp', LeftDown: 'LeftDown' };
    var circleDirection = directions.RightDown;
    ctx.lineWidth = borderWidth;
    
    var int = setInterval(function () { drow(); }, speedGame);
    
    function drow() {
        ctx.beginPath();
        ctx.fillStyle = "#90CAD7";
        ctx.fillRect(0, 0, width, height);
        ctx.strokeRect(0, 0, width, height);
        ctx.fill();
        ctx.fillStyle = "white";
        ctx.arc(circleX, circleY, circleRadius, 0, 2 * Math.PI, false);
        ctx.fill();

        switch (circleDirection) {
            case directions.RightDown:
                circleX += 1;
                circleY += 1;
                
                if (isOnBorder()) {

                    circleDirection = directions.RightUp;
                }

                break;
            case directions.RightUp:
                circleX += 1;
                circleY -= 1;

                if (isOnBorder()) {

                    circleDirection = directions.LeftUp;
                }

                break;
            case directions.LeftUp:
                circleX -= 1;
                circleY -= 1;

                if (isOnBorder()) {

                    circleDirection = directions.LeftDown;
                }
                break;
            case directions.LeftDown:
                circleX -= 1;
                circleY += 1;

                if (isOnBorder()) {

                    circleDirection = directions.RightDown;
                }
                break;
            default:
                throw new Error('Invalid Direction');
        }

        
    }
  
    function isOnBorder() {

        var check;

        if (circleY >= maxCircleY) {
            check = true;
        }
        else if (circleX >= maxCircleX) {
            circleDirection = directions.LeftUp;
            check = true;
        }
        else if (circleY <= minCircleY) {
            circleDirection = directions.LeftDown;
            check = true;
        }
        else if (circleX <= minCircleX) {
            circleDirection = directions.RightDown;
            check = true;
        }

        return check;
    }
})();