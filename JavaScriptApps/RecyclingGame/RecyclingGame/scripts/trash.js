/// <reference path="prototype.js" />
/// <reference path="jquery-2.0.2.js" />
/// <reference path="RecyclingGameNS.js" />
/// <reference path="TrashNS.js" />
/// <reference path="string-extention.js" />

RecyclingGameNS.TrashItems.Trash = Class.create({

    initialize: function initScoreboard(src) {

        this._queryTrash = $(String.format('<img src="{0}" />', src));
        
    },

    initEvents: function initEvents() {

    },

    setId: function setId(id) {

        this._queryTrash.attr('id', id);
    },

    getId: function getId() {

        return this._queryTrash.attr('id');
    },

    throwIt: function throwIt(dumpsite) {

        this._queryTrash.appendTo(dumpsite);
    },

    dispose: function dispose() {

        this._queryTrash.remove();
    },

});