(function () {

    var canvasBicycle = document.getElementById('bicycle');
    drowBicycle(canvasBicycle);
    var canvasCreepyDude = document.getElementById('creepy-dude');
    drowCreepyDude(canvasCreepyDude);
    var canvasHouse = document.getElementById('house');
    drowHouse(canvasHouse);
    function drowBicycle(canvas) {

        
        var width = canvas.width;
        var height = canvas.height;
        var ctx = canvas.getContext("2d");
        ctx.strokeStyle = "#257184";
        ctx.fillStyle = "#90CAD7";
        ctx.lineWidth = 2.5;

        ctx.beginPath();
        ctx.strokeRect(0, 0, width, height);    
        ctx.arc(62, 160, 60, 0, 2 * Math.PI, false);
        ctx.fill();
        //ctx.stroke();
        ////ctx.beginPath();
        ctx.moveTo(88, 55);
        ctx.lineTo(138, 55);
        //ctx.stroke();
        //ctx.beginPath();
        ctx.moveTo(113, 55);
        ctx.lineTo(164, 156);
        ctx.stroke();


        ctx.beginPath();
        ctx.arc(162, 155, 16, 0, 2 * Math.PI, false);
        //ctx.stroke();
        //ctx.beginPath();
        ctx.moveTo(59, 158);
        ctx.lineTo(131, 82);
        //ctx.stroke();
        //ctx.beginPath();
        ctx.moveTo(59, 158);
        ctx.lineTo(162, 155);
        //ctx.stroke();
        //ctx.beginPath();
        ctx.moveTo(131, 82);
        ctx.lineTo(273, 82);
        //ctx.stroke();
        //ctx.beginPath();
        ctx.moveTo(273, 83);
        ctx.lineTo(162, 155);
        //ctx.stroke();
        //ctx.beginPath();
        ctx.moveTo(151, 142);
        ctx.lineTo(141, 129);
        //ctx.stroke();
        //ctx.beginPath();
        ctx.moveTo(173, 168);
        ctx.lineTo(183, 180);
        ctx.stroke();

        ctx.beginPath();
        ctx.arc(288, 160, 60, 0, 2 * Math.PI, false);
        ctx.fill();
        //ctx.stroke();
        //ctx.beginPath();
        ctx.moveTo(287, 155);
        ctx.lineTo(266, 40);
        //ctx.stroke();
        //ctx.beginPath();
        ctx.moveTo(266, 40);
        ctx.lineTo(219, 55);
        //ctx.stroke();
        //ctx.beginPath();
        ctx.moveTo(266, 40);
        ctx.lineTo(298, 2);
        ctx.stroke();
    }

    function drawEllipseByCenter(ctx, cx, cy, w, h, filled) {
        drawEllipse(ctx, cx - w / 2.0, cy - h / 2.0, w, h, filled);
    }

    function drawEllipse(ctx, x, y, w, h , filled) {
        var kappa = 0.5522848,
            ox = (w / 2) * kappa, // control point offset horizontal
            oy = (h / 2) * kappa, // control point offset vertical
            xe = x + w,           // x-end
            ye = y + h,           // y-end
            xm = x + w / 2,       // x-middle
            ym = y + h / 2;       // y-middle

        ctx.beginPath();
        ctx.moveTo(x, ym);
        ctx.bezierCurveTo(x, ym - oy, xm - ox, y, xm, y);
        ctx.bezierCurveTo(xm + ox, y, xe, ym - oy, xe, ym);
        ctx.bezierCurveTo(xe, ym + oy, xm + ox, ye, xm, ye);
        ctx.bezierCurveTo(xm - ox, ye, x, ym + oy, x, ym);
        
        if (filled) {
            ctx.fill();
        }
        ctx.closePath();
        ctx.stroke();
    }

    function drowCreepyDude(canvas) {

         var width = canvas.width;
         var height = canvas.height;
         var ctx = canvas.getContext("2d");
         ctx.strokeStyle = "#114450";
         ctx.fillStyle = "#90CAD7";
         ctx.lineWidth = 2.5;

         ctx.strokeRect(0, 0, width, height);

         ctx.save();
         ctx.scale(1.12, 1);
         ctx.beginPath();
         ctx.arc(79, 162, 64, 0, 2 * Math.PI, false);
         ctx.fill();
         ctx.stroke();
         ctx.closePath();
         ctx.restore();

         ctx.lineWidth = 2.5;
         ctx.beginPath();
         ctx.moveTo(43, 191);
         ctx.bezierCurveTo(43, 179, 98, 186, 98, 199);
         ctx.bezierCurveTo(98, 209, 43, 203, 43, 191);
         ctx.closePath();
         ctx.stroke();

         //nose
         ctx.beginPath();
         ctx.moveTo(70, 171);
         ctx.lineTo(54, 171);

         ctx.moveTo(55, 170);
         ctx.lineTo(70, 140);
         ctx.stroke();

         ctx.fillStyle = "#114450";
         //eyes
         drawEllipseByCenter(ctx, 70 - 27, 140, 24, 16);
         drawEllipseByCenter(ctx, 70 + 28, 140, 24, 16);

         drawEllipseByCenter(ctx, (70 - 27)- 4, 140, 5, 10, true);
         drawEllipseByCenter(ctx, (70 + 27) - 4, 140, 5, 10, true);

         //hat
         ctx.fillStyle = "#396693";
         ctx.strokeStyle = "#1D1715";
         drawEllipseByCenter(ctx, 82, 106, 159, 29, true);

        // ctx.fillStyle = "#90CAD7";
         ctx.beginPath();
         ctx.moveTo(44, 94);
         ctx.bezierCurveTo(44, 112, 128, 112, 128, 94);
         ctx.fill();
         ctx.stroke();


         ctx.fillRect(44, 16, 83, 78);

         ctx.beginPath();
         ctx.moveTo(44, 94);
         ctx.lineTo(44, 16);

         ctx.moveTo(128, 94);
         ctx.lineTo(128, 16);
         ctx.fill();
         ctx.stroke();


         drawEllipseByCenter(ctx, 86, 16, 83, 29, true);
    }

    function drowHouse(canvas) {

        var width = canvas.width;
        var height = canvas.height;
        var ctx = canvas.getContext("2d");
        ctx.strokeStyle = "#000000";
        ctx.fillStyle = "#975B5B";
        ctx.lineWidth = 2.5;

        ctx.strokeRect(0, 0, width, height);

        ctx.fillRect(2, 162, 289, 215);
        ctx.strokeRect(2, 162, 289, 215);

        //roof
        ctx.beginPath();
        ctx.moveTo(2, 161);
        ctx.lineTo((289 / 2) + 1, 3);
        ctx.lineTo(289 + 2, 161);
        ctx.fill();
        ctx.stroke();

        ctx.fillRect(204, 41, 32, 80);

        ctx.beginPath();
        ctx.moveTo(203, 41);
        ctx.lineTo(203, 122);

        ctx.moveTo(203 + 32, 41);
        ctx.lineTo(203 + 32, 122);
        ctx.stroke();

        drawEllipseByCenter(ctx, 203 + 32 / 2, 42, 32, 8, true);

        // windows
        ctx.fillStyle = "#000000";
        ctx.fillRect(23, 188, 103, 66);
        ctx.fillRect(23 + 103 + 37, 188, 103, 66);

        ctx.fillRect(23 + 103 + 37, 188 + 66 + 26, 103, 66);

        ctx.strokeStyle = "#975B5B";
        ctx.beginPath();
        ctx.moveTo(23, 188 + 66 / 2);
        ctx.lineTo(23 + 103 * 2 + 37, 188 + 66 / 2);
        ctx.stroke();

        ctx.beginPath();
        ctx.moveTo(23 + 103 / 2, 188);
        ctx.lineTo(23 + 103 / 2, 188 + 66);
        ctx.stroke();

        ctx.beginPath();
        ctx.moveTo(23 + 103 + 37 + 103 / 2, 188);
        ctx.lineTo(23 + 103 + 37 + 103 / 2, 188 + 66 * 2 + 26);
        ctx.stroke();

        ctx.beginPath();
        ctx.moveTo(23 + 103 + 37, 188 + 66 + 26 + 66 / 2);
        ctx.lineTo(23 + 103 + 37 + 103, 188 + 66 + 26 + 66 / 2);
        ctx.stroke();

        // door
        ctx.strokeStyle = "#000000";
        ctx.beginPath();
        ctx.moveTo(34, 300);
        ctx.bezierCurveTo(34, 275, 113, 275, 113, 300);
        ctx.stroke();

        ctx.beginPath();
        ctx.moveTo(74, 281);
        ctx.lineTo(74, 162 + 215);
        ctx.moveTo(34, 300);
        ctx.lineTo(34, 162 + 215);
        ctx.moveTo(113, 300);
        ctx.lineTo(113, 162 + 215);
        ctx.stroke();

        ctx.beginPath();
        ctx.arc(74 + 12, 348, 4, 0, 2 * Math.PI, false);
        ctx.stroke();
        ctx.beginPath();
        ctx.arc(74 - 12, 348, 4, 0, 2 * Math.PI, false);
        ctx.stroke();
    }

    
     
}());


