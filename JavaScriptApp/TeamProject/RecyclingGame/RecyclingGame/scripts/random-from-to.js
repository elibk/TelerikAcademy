/// <reference path="jquery-2.0.2.js" />

(function ($j) {
    $j.randomFromTo = function (from, to) {
        return Math.floor(Math.random() * (to - from + 1) + from);
    };
}(jQuery));