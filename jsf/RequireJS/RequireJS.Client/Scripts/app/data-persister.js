/// <reference path="../libs/jquery-2.0.3.js" />
/// <reference path="../libs/require.js" />
/// <reference path="../libs/rsvp.min.js" />

define(["httpRequester"], function (httpRequester) {
	function getStudents() {		
	    return httpRequester.getJSON("http://localhost:49739/api/students");
	}

	function getStudentMarks(studentId) {
	    var str = "http://localhost:49739/api/students/" + studentId + "/marks";
	    return httpRequester.getJSON(str);
        //return httpRequester.getJSON("http://localhost:49739/api/students?studentId=" + id);
       // return httpRequester.getJSON("http://localhost:49739/api/students/" + id);
    }
	return {
	    students: getStudents,
	    studentMarks: getStudentMarks
	}
});