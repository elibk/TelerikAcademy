/// <reference path="../_references.js" />


define(["jquery", "mustache", "class", "controls"], function ($, mustache, Class, controls) {
    
    var View = Class.create({
        init: function (navSelector, contentSelector) {

            this.navSelector = navSelector;
            this.contentSelector = contentSelector;

        },
        renderNav: function (navTemplate, param) {

            var param = param || {};

            var navTemplateCompiled = mustache.compile(navTemplate);
            $(this.navSelector).html(navTemplateCompiled(param));

        },
        renderPage: function (contentTemplate, param) {
            var param = param || {};

            var template = mustache.compile(contentTemplate);
            $(this.contentSelector).html(template(param));
        },
        renderCreatePostPage: function (contentTemplate, param) {

            this.renderPage(contentTemplate, param);
            var multiSelect = controls.setMultiSelect('#tags');

        },

        renderSinglePostPage: function (contentTemplate, commentsTemplate, param) {
            var param = param || {};

            var template = mustache.compile(contentTemplate);
            $(this.contentSelector).html(template(param));
            var templateComments = mustache.compile(commentsTemplate);
            $(this.contentSelector).append(templateComments(param.comments));
        },
   
    });


    return {
        get: function (navSelector, contentSelector) {
            return new View(navSelector, contentSelector);
        }
    };
});