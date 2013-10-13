/// <reference path="jquery-2.0.2.js" />
/// <reference path="string-extention.js" />
/// <reference path="prototype.js" />
var StudentsTable = Class.create({

    initialize: function initStudentsTable(parentSelector) {

        var parent = $(parentSelector);
        this.table = $('<table></table>');
        this.header = $('<thead><tr><th>First Name</th><th>Last Name</th><th>Grade Name</th></tr></thead>');
        this.tableBody = $('<tbody></tbody>');
        this.table.append(this.header);
        this.table.append(this.tableBody);
        parent.append(this.table);
        this.students = [];
    },

    addStudent: function addStudent(newStudent) {

        this.table.append($(String.format("<tr><td>{0}</td><td>{1}</td><td>{2}</td></tr>", newStudent.firstName, newStudent.lastName, newStudent.grade)));
        this.students.push(newStudent);
    }

});