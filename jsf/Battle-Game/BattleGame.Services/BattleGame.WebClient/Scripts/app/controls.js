/// <reference path="jquery-2.0.3.js" />
/// <reference path="class.js" />
define(["jquery","class"], function ($, Class) {
	var controls = controls || {};

	var TableView = Class.create({
	    init: function (itemsSource, rows, cols, caption) {
	        if (!(itemsSource instanceof Array)) {
	            throw "The itemsSource of a TableView must be an array!";
	        }
	        this.itemsSource = itemsSource;
	        this.cols = cols || 4;
	        this.rows = rows || parseInt(itemsSource.length / this.cols) + 1;
	        this.caption = caption || "";
	    },
	    render: function (template) {
	        var tbl = document.createElement("table");
	        var captTbl = document.createElement("caption");
	        $(captTbl).text(this.caption);
	        tbl.appendChild(captTbl);
	        var tblRow = document.createElement("tr");
	        var tblCell = document.createElement("td");
	        var index = 0;

	        for (var row = 0; row < this.rows; row++) {

	            var currRow = tblRow.cloneNode();

	            for (var i = 0; i < this.cols; i++) {


	                var currCell = tblCell.cloneNode();

	                var rowData = this.itemsSource[index];
	                if (!rowData) {
	                    rowData = {};
	                }
	                rowData.posiionY = row;
	                rowData.positionX = i;

	                currCell.innerHTML = template(rowData);
	                currRow.appendChild(currCell)
	                tbl.appendChild(currRow);
	                index++;
	            }
	        }


	        return tbl.outerHTML;
	    }
	});

	controls.getTableView = function (itemsSource, rows, cols) {
	    return new TableView(itemsSource, rows, cols);
	}
	

	controls.initGamesEvents = function (gameOnClickPromise, urlPath, targetSelector) {

	    $('#content').off('click', targetSelector);
	    $('#content').on('click', targetSelector, function (ev) {

	        gameOnClickPromise(ev.currentTarget)
                .then(function (id) {
                    console.log("The promise succses");
                    window.open(urlPath + ':' + id, "_self");
                }, function (err) {
                    console.log(err);
                });
	    });
	}

	return controls;
});