function task02() {

    controls.getPeople()
              .then(function (students) {

                  var personTemplate = Mustache.compile(document.getElementById("simple-student").innerHTML);
                  var tableView = controls.getTableView(students);

                  var tableViewHtml = tableView.render(personTemplate);

                  document.getElementById("content").innerHTML = tableViewHtml;

                  $('#content').append('<div id="marksDisplayContainer"></div>');


                  $('#content').on('click', 'td', function (ev) {

                      $('#marksDisplayContainer').html((masterTemplate(students[ev.currentTarget.id || 0])));

                  });

                  var masterTemplate = Mustache.compile(document.getElementById("details-student").innerHTML);

                  console.log(students);

              }, function (err) {
                  console.error(err);
              });

}