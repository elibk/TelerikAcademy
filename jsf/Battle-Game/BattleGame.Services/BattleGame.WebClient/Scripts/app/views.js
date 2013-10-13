/// <reference path="jquery-2.0.3.js" />
/// <reference path="class.js" />
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

        renderField: function (param) {

            var context = $(param.context);
            var rows = param.rows;
            var cols = param.cols;
            var gameName = param.gameName;

            var template = param.template;
            var fieldTemplate = mustache.compile(template);
            var tableView = controls.getTableView([], rows, cols, gameName);
            var tableViewHtml = tableView.render(fieldTemplate);

            context.html(tableViewHtml);
        }
    });


    return {
        get: function (navSelector, contentSelector) {
            return new View(navSelector, contentSelector);
        }
    };
});