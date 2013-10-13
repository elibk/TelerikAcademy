/// <reference path="jquery-2.0.2.js" />
(function ($, window, document, undefined) {
    'use strict';
    $.fn.treeView = function (params) {
       
        if (!params) {
            params = {};
        }

        var nestedLis = $(this).find('li>ul').hide();
        var nestedA = nestedLis.parent().find('>a');
        nestedA.addClass('nested');
        nestedA.on('click', function () {
            $(this).next('ul').toggle(500);
        });
        return $(this);
    }
})(jQuery, window, document);

$(document).ready(function () {
    $('.tree-view').treeView();
});