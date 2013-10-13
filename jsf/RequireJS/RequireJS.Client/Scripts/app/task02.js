define(["jquery", "mustache", "dataPersister", "controls"], function ($, mustache, data, controls) {
    function task02() {
                data.students()
               .then(function (people) {

                   var template = mustache.compile(document.getElementById("task02-template").innerHTML);
                   $('#content').html(template());

                   var studentTemplate = '<p data-id="${ data.id }">' +
                           '${ data.firstName } ${ data.lastName } grade: ${ data.grade }' +
                       '</p>';

                   var marksTemplate = mustache.compile(document.getElementById("marks-template").innerHTML);

                   controls.comboBox('#studentsComboBox', people, studentTemplate, function (e) {
                       console.log($(e.item.children()[0]).data("id"));

                       var studentId = $(e.item.children()[0]).data("id") || 0;

                       data.studentMarks(studentId)
                           .then(function (marks) {
                               var obj = {};
                               obj.marks = marks;
                               $('#marksDisplayContainer').html((marksTemplate(obj)));
                           }, function (err) {
                               console.error(err);
                           });
                   });



               }, function (err) {
                   console.error(err);
               });

                return null;
    }

    return {
        action: task02
    }
});