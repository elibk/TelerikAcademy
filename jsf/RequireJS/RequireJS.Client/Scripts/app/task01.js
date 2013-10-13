define(["jquery", "mustache", "dataPersister", "controls", "sammy"], function ($, mustache, data, controls, sammy) {
    function task01() {
        data.students()
            .then(function (students) {

                var personTemplate = mustache.compile(document.getElementById("simple-student").innerHTML);
                var tableView = controls.getTableView(students);

                var tableViewHtml = tableView.render(personTemplate);

                document.getElementById("content").innerHTML = tableViewHtml;
                

                $('#content').on('click', 'td', function (ev) {

                    var element = $(this).children()[0];
                    var id = $(element).data('id') || 0;
                    if (id == 0) {
                        return;
                    }
                    console.log(id);
                    data.studentMarks(id).then(function (marks) {
                        window.open("#/marks"+':'+id,"_self");
                        var marksTemplate = mustache.compile(document.getElementById("marks-template").innerHTML);
                        var obj = {};
                        obj.marks = marks;
                        $('#content').html((marksTemplate(obj)));
                    }, function (err) {
                        console.error(err);
                    });

                });

            }, function (err) {
                console.error(err);
            });
    }

    return {
        action: task01
    }
});