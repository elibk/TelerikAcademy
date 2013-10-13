/// <reference path="prototype.js" />
/// <reference path="jquery-2.0.2.js" />
/// <reference path="RecyclingGameNS.js" />
/// <reference path="TrashBinsNS.js" />
/// <reference path="trash-bin.js" />
/// <reference path="string-extention.js" />

RecyclingGameNS.TrashBins.RecyclingTrashBin = Class.create(RecyclingGameNS.TrashBins.TrashBin, {

    initialize: function init($super, src, type) {
        $super(src);
        this._jQueryTrashBin.attr('type', type);
    },

    initEvents: function initEvents($super, gameEngine) {
        var that = this;
        this._jQueryTrashBin.droppable({
            drop: function (event, ui) {
                gameEngine._cleanTrash(ui.draggable[0], that.getType());
                
            },
           
        });
    },

    getType: function getType() {

        return this._jQueryTrashBin.attr('type');
    },

});