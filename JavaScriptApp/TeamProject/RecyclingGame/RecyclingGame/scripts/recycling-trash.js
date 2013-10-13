/// <reference path="prototype.js" />
/// <reference path="jquery-2.0.2.js" />
/// <reference path="RecyclingGameNS.js" />
/// <reference path="TrashNS.js" />
/// <reference path="trash.js" />
/// <reference path="string-extention.js" />

RecyclingGameNS.TrashItems.RecyclingTrash = Class.create(RecyclingGameNS.TrashItems.Trash,{

    initialize: function initScoreboard($super, src, type) {
        $super(src);
        this._queryTrash.attr('type', type);
       
    },

    initEvent: function initEvents(evType, evHandler) {

        this._queryTrash.on(evType, evHandler);
    },

    getType: function getType() {

        return this._queryTrash.attr('type');
    },

});