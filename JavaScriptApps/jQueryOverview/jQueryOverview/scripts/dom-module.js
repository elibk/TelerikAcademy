/// <reference path="prototype.js" />
/// <reference path="jquery-2.0.2.js" />

var domInsertionModule = Class.create({

    initialize: function initDomModule() {
    },

    addBefore: function addBefore(elementSelector, newElement) {
        var newElement = $(newElement);
        newElement.insertBefore($(elementSelector));
       
    },

    addAfter: function addAfter(elementSelector, newElement) {
        var newElement = $(newElement);
        newElement.insertAfter($(elementSelector));
    },

});