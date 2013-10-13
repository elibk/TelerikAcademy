/// <reference path="../libs/jquery-2.0.3.js" />
/// <reference path="../libs/require.js" />
/// <reference path="../libs/rsvp.min.js" />
var controls = controls || {};
(function (c) {
	function getPeople() {		
	    return httpRequester.getJSON("http://localhost:56268/api/students");
	}
	
    c.getPeople= getPeople
	
})(controls || {});