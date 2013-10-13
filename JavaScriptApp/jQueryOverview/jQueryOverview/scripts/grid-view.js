/// <reference path="prototype.js" />
/// <reference path="jquery-2.0.2.js" />
/// <reference path="string-extention.js" />
/// <reference path="grid-row.js" />

var GridView = Class.create({

    initialize: function initGridView(colsCount) {
        this._gridTable = $('<table> </table>');
        this._header = $('<thead></thead>');
        this._body = $('<tbody></tbody>');
        this._gridTable.append(this._header);
        this._gridTable.append(this._body);
        this.colsCount = colsCount;
        this._hasHeader = false;
        this._hasNestedGridView = false;
    },

    addHeader: function addHeader() {

        if (this._hasHeader) {
            throw new Error("Header has been already added.");
        }
        
        this._hasHeader = true;
        var headerRow = $('<tr></tr>');
       
        var headerCell = $('<th></th>');

        for (var i = 0; i < this.colsCount; i++) {

            if (arguments[i]) {
                headerRow.append(headerCell.clone(true).text(arguments[i]));
            }
            else {
                headerRow.append(headerCell.clone(true).text("N/A"));
            }
        }

        headerRow.appendTo(this._header);
    },

    addRow: function addRow() {
        var newRow = new GridRow(this, this.colsCount);
        newRow.appendTo(this._body);
        return newRow;
    },

    appendTo: function addRow(parent) {
        this._gridTable.appendTo(parent);

        return this;
    }

});