
(function () {
    'use strict';

    if (!document.querySelector) {
        document.querySelector = function (selector) {
            return Sizzle(selector)[0];
        };
    }

    if (!document.querySelectorAll) {
        document.querySelectorAll = function (selector) {
            return Sizzle(selector);
        };
    }

    var listItems = document.querySelectorAll("#wrapper #nav .menu li");
    document.write('<br/>Selected items by "#wrapper #nav .menu li" :');
    for (var i = 0; i < listItems.length; i++)
        document.write("<br/>" + "<strong>Item : </strong>" + listItems[i].innerHTML + "<br/>");
})();

