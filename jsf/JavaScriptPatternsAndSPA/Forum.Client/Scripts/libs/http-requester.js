/// <reference path="require.js" />
/// <reference path="jquery-2.0.3.js" />
/// <reference path="rsvp.min.js" />

define(["jquery", "rsvp"], function ($) {
    function getJSON(serviceUrl, sessionKey) {
        var promise = new RSVP.Promise(function (resolve, reject) {
            
			jQuery.ajax({
			    url: serviceUrl,
			    headers: { 'X-sessionKey': sessionKey },
				type: "GET",
				dataType: "json",
				success: function (data) {
					resolve(data);
				},
				error: function (err) {
					reject(err);
				}
			});
		});
		return promise;
	}

    function postJSON(serviceUrl, data, sessionKey) {

        var promise = new RSVP.Promise(function (resolve, reject) {
            console.log(JSON.stringify(data));
			jQuery.ajax({
			    url: serviceUrl,
			    headers: { 'X-sessionKey': sessionKey },
				dataType: "json",
				type: "POST",
				contentType: "application/json",
				data: JSON.stringify(data),
				success: function (data) {
					resolve(data);
				},
				error: function (err) {
					reject(err);
				}
			});
		});
		return promise;
	}

    function putJSON(serviceUrl, data, sessionKey) {
	    var promise = new RSVP.Promise(function (resolve, reject) {

	        jQuery.ajax({
	            url: serviceUrl,
	            headers: { 'X-sessionKey': sessionKey },
	            dataType: "json",
	            type: "PUT",
	            contentType: "application/json",
	            data: JSON.stringify(data),
	            success: function (data) {
	                resolve(data);
	            },
	            error: function (err) {
	                
	                reject(err);
	                console.log("ERROR", err);	
	            }
	        });
	    });
	    return promise;
    }

	return {
		getJSON: getJSON,
		postJSON: postJSON,
		putJSON: putJSON
	}
});