/// <reference path="jquery-2.0.3.js" />
/// <reference path="class.js" />
define(["jquery","class","kendoWeb"], function ($, Class) {
	var controls = controls || {};

	controls.comboBox = function (selector, data, template, onSelect) {

	    var cBox = $(selector).kendoComboBox({
	        filter: "startswith",
	        dataTextField: "firstName",
	        //dataValueField: "firstName",
	        template: template,
	        dataSource: {
	            data: data
	        },

	        select: onSelect
	    }).data("kendoComboBox");

	};


	var TableView = Class.create({
	    init: function (itemsSource, rows, cols) {
	        if (!(itemsSource instanceof Array)) {
	            throw "The itemsSource of a TableView must be an array!";
	        }
	        this.itemsSource = itemsSource;
	        this.cols = cols || 4;
	        this.rows = rows || parseInt(itemsSource.length / this.cols) + 1;

	        console.log(this.cols, this.rows);
	    },
	    render: function (template) {
	        var tbl = document.createElement("table");
	        var tblRow = document.createElement("tr");
	        var tblCell = document.createElement("td");
	        var index = 0;

	        for (var row = 0; row < this.rows; row++) {

	            var currRow = tblRow.cloneNode();

	            for (var i = 0; i < this.cols; i++) {


	                var currCell = tblCell.cloneNode();
	                var rowData = this.itemsSource[index++];



	                currCell.innerHTML = template(rowData);
	                currRow.appendChild(currCell)
	                tbl.appendChild(currRow);
	            }
	        }


	        return tbl.outerHTML;
	    }
	});

	controls.getTableView = function (itemsSource, rows, cols) {
	    return new TableView(itemsSource, rows, cols);
	}
	return controls;
});