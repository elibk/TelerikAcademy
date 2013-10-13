﻿/// <reference path="prototype.js" />
/// <reference path="jquery-2.0.2.js" />
/// <reference path="RecyclingGameNS.js" />
/// <reference path="TrashBinsNS.js" />
/// <reference path="jquery-ui.js" />
/// <reference path="string-extention.js" />

RecyclingGameNS.TrashBins.TrashBin = Class.create({

    initialize: function initTrashBin(src) {
        this._jQueryTrashBin = $j(String.format('<img src="{0}"/>', src));
    },

    initEvents: function initEvents() {

    },

    setInTheField: function setInTheField(field) {
        this._jQueryTrashBin.attr('class', 'trash-bin');
        this._jQueryTrashBin.appendTo(field);
    },

});