/// <reference path="../_references.js" />

define(["jquery","class", "kendoWeb"], function ($, Class) {
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
	
	controls.setMultiSelect = function (selectorDropBox) {

	    var tags = [
		{ text: "C#", value: "CSharp" },
		{ text: "JS", value: "JS" },
		{ text: "CSS", value: "CSS" }
	    ];

	    var newitemtext;

	    var multiselect = $("#tags").kendoMultiSelect({
	        change: function () {
	            $('#tags_taglist li span:first-child').each(function () {
	                $(this).text($(this).text().replace(" (Add New)", ""));
	            });
	        },
	        dataBound: function () {
	            if ((newitemtext || this._prev) && newitemtext != this._prev) {
	                newitemtext = this._prev;

	                var dataitems = this.dataSource.data();

	                for (var i = 0; i < dataitems.length; i++) {
	                    var dataItem = dataitems[i];

	                    if (dataItem.value != dataItem.text) {
	                        this.dataSource.remove(dataItem);
	                    }
	                }

	                dataitems = this.dataSource.data();
	                var found = false;
	                for (var i = 0; i < dataitems.length; i++) {
	                    var dataItem = dataitems[i];
	                    if (dataItem.value == newitemtext) {
	                        found = true;
	                    }
	                }

	                if (!found) {
	                    this.dataSource.add({ text: newitemtext + " (Add New)", value: newitemtext });
	                    this.open();
	                }
	            }
	        },
	        dataSource: tags,
	        dataTextField: "text",
	        dataValueField: "value",
	        animation: false
	    });
	}
	controls.initGamesEvents = function (gameOnClickPromise, urlPath, targetSelector) {

	    $('#content').off('click', targetSelector);
	    $('#content').on('click', targetSelector, function (ev) {

	        gameOnClickPromise(ev.currentTarget)
                .then(function (id) {
                    console.log("The promise succses");
                    window.open(urlPath + ':' + id, "_self");
                    $('#content').off('click', targetSelector);
                }, function (err) {
                    console.log(err);
                });
	    });
	}

	return controls;
});