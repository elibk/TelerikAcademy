// I noticed the recommendations about dot notation in document.layers['menu1'].visibility for example and warrings about evil eval
// but for this homework I think there is no need to take them into consideration. I also decide to leave the unused parameters like
// off, txt and e.c.
	
; (function () {

    "use strict";

    var appName = navigator.appName;
    var addScroll = false;
    if ((navigator.userAgent.indexOf('MSIE 5') > 0) || (navigator.userAgent.indexOf('MSIE 6')) > 0) {
	    addScroll = true;
    }
    var off = 0;
    var txt = "";
    var positionX = 0;
    var positionY = 0;
    document.onmousemove = mouseMove;
    if (appName === 'Netscape') {
	    document.captureEvents(Event.MOUSEMOVE);
    }
    function mouseMove(evn) {
        if (appName === 'Netscape') {
            positionX = evn.pageX - 5;
            positionY = evn.pageY;
	    } else {
            positionX = event.x - 5;
            positionY = event.y;
	    }

        if (appName === 'Netscape') {
		    if (document.layers['ToolTip'].visibility === 'show') {
			    PopTip();
		    }
	    } else {
		    if (document.all['ToolTip'].style.visibility === 'visible') {
		        PopTip();
		    }
	    }
    }
    var theLayer;
    function PopTip() {
        if (appName === 'Netscape') {
		    theLayer = eval('document.layers[\'ToolTip\']');
		    if ((positionX + 120) > window.innerWidth) {
		        positionX = window.innerWidth - 150;
		    }

		    theLayer.left = positionX + 10;
		    theLayer.top = positionY + 15;
		    theLayer.visibility = 'show';
	    } else {
		    theLayer = eval('document.all[\'ToolTip\']');
		    if (theLayer) {
		        positionX = event.x - 5;
		        positionY = event.y;
			    if (addScroll) {
			        positionX = positionX + document.body.scrollLeft;
			        positionY = positionY + document.body.scrollTop;
			    }
			    if ((positionX + 120) > document.body.clientWidth) {
			        positionX = positionX - 150;
			    }

			    theLayer.style.pixelLeft = positionX + 10;
			    theLayer.style.pixelTop = positionY + 15;
			    theLayer.style.visibility = 'visible';
		    }
	    }
    }

    function HideTip() {
	   var args = HideTip.arguments;
	   if (appName === "Netscape") {
		    document.layers['ToolTip'].visibility = 'hide';
	    } else {
		    document.all['ToolTip'].style.visibility = 'hidden';
	    }
    }

    function HideMenu1() {
        if (appName === 'Netscape') {
		    document.layers['menu1'].visibility = 'hide';
	    } else {
		    document.all['menu1'].style.visibility = 'hidden';
	    }
    }

    function ShowMenu1() {
        if (appName === "Netscape") {
		    theLayer = eval('document.layers[\'menu1\']');
	        theLayer.visibility = 'show';
	    } else {
		    theLayer = eval('document.all[\'menu1\']');
		    theLayer.style.visibility = 'visible';
	    }

    }

    function HideMenu2() {
        if (appName === 'Netscape') {
		    document.layers['menu2'].visibility = 'hide';
	    } else {
		    document.all['menu2'].style.visibility = 'hidden';
	    }
    }

    function ShowMenu2() {
        if (appName === "Netscape") {
		    theLayer = eval('document.layers[\'menu2\']');
		    theLayer.visibility = 'show';
	    } else {
		    theLayer = eval('document.all[\'menu2\']');
		    theLayer.style.visibility = 'visible';
	    }
    } // fostata
})();