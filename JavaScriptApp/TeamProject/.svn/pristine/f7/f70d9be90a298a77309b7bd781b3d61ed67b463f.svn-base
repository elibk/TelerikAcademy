/// <reference path="prototype.js" />
/// <reference path="jquery-2.0.2.js" />
/// <reference path="jquery-ui.js" />
/// <reference path="RecyclingGameNS.js" />
/// <reference path="TrashNS.js" />
/// <reference path="string-extention.js" />

RecyclingGameNS.TrashItems.Trash = Class.create({

    initialize: function initScoreboard(src) {

        this._queryTrash = $j(String.format('<img src="{0}" />', src));
        this.initEvents();
    },

    initEvents: function initEvents() {
        this._queryTrash.draggable({ cursor: "move", revert: true });
    },

    setId: function setId(id) {

        this._queryTrash.attr('id', id);
    },

    getId: function getId() {

        return this._queryTrash.attr('id');
    },

    throwIt: function throwIt(dumpsite) {
        var style = String.format('position: absolute; top:{0}px; left:{1}px;', $j.randomFromTo(50, 300), $j.randomFromTo(100, 500));
        this._queryTrash.attr('style', style)
        this._queryTrash.appendTo(dumpsite);
    },

    dispose: function dispose() {

        this._queryTrash.remove();
    },

    hide: function hide() {

        this._queryTrash.hide();
    },

    show: function show() {

        this._queryTrash.show();
    },

});