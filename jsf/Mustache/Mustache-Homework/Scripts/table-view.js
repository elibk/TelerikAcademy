/// <reference path="jquery-2.0.3.js" />
/// <reference path="jquery-2.0.3.js" />
/// <reference path="class.js" />
var controls = controls || {};
(function (c) {
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
		            currCell.id =index;
		            //this.itemsSource[index]['id'] = index;
		            var rowData = this.itemsSource[index++];
		            
		           

		            currCell.innerHTML = template(rowData);
		            currRow.appendChild(currCell)
		            tbl.appendChild(currRow);
		        }
		    }
		    
		  
		    return tbl.outerHTML;
		}
	});

	c.getTableView = function (itemsSource, rows, cols) {
	    return new TableView(itemsSource, rows, cols);
	}
}(controls || {}));