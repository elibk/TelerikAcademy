/// <reference path="prototype.js" />
/// <reference path="jquery-2.0.2.js" />
/// <reference path="string-extention.js" />
/// <reference path="grid-view.js" />

var GridRow = Class.create({

    initialize: function initGridView(parentGridView, colsCount) {
        this._gridRow = $('<tr></tr>');
        this.parentGridView = parentGridView;
        this.colsCount = colsCount;
        this._isContentAdded = false;

    },

    addCells: function addRow() {

        if (this._isContentAdded) {

            throw new Error("Content has been already added.");
        }

        this._isContentAdded = true;
        var cell = $('<td></td>');
        for (var i = 0; i < this.colsCount; i++) {

            if (arguments[i]) {
                this._gridRow.append(cell.clone(true).text(arguments[i]));
            }
            else {
                this._gridRow.append(cell.clone(true).text("N/A"));
            }
        }

        return this;
    },

    addGrid: function addGrid(gridViewColsCount) {
        if (this._isContentAdded) {

            throw new Error("Content has been already added.");
        }
        if (this.parentGridView._hasNestedGridView) {

            throw new Error("Nested grid view has been already added.");
        }

        this._isContentAdded = true;
        this.parentGridView._hasNestedGridView = true;
      
        var cellForGrid = $(String.format('<td colspan="{0}"></td>', this.colsCount));
        var newGrid = new GridView(gridViewColsCount);
        newGrid.appendTo(cellForGrid);
        this._gridRow.append(cellForGrid);
        return newGrid;
    },

    appendTo: function addRow(parent) {
        this._gridRow.appendTo(parent);
    }

});