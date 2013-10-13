﻿(function () {

    if (!localStorage) {

        localStorage.getItem = cookies.readCookie;
        localStorage.setItem = cookies.createLocalCookie;
        localStorage.removeItem = cookies.removeCookie;
        sessionStorage.getItem = cookies.readCookie;
        sessionStorage.setItem = cookies.createSessionCookie;
        sessionStorage.removeItem = cookies.removeCookie;
        
    }

}());


var cookies = (function () {
    if (!String.prototype.startsWith) {
        String.prototype.startsWith = function (str) {
            if (this.length < str.length) {
                return false;
            }
            for (var i = 0; i < str.length; i++) {
                if (this[i] !== str[i]) {
                    return false;
                }
            }
            return true;
        };
    }

    function readCookie(name) {
        var allCookies = document.cookie.split(";");
        for (var i = 0; i < allCookies.length; i++) {
            var cookie = allCookies[i];
            var trailingZeros = 0;
            for (var j = 0; j < cookie.length; j++) {
                if (cookie[j] !== " ") {
                    break;
                }
            }
            cookie = cookie.substring(j);
            if (cookie.startsWith(name + "=")) {
                return cookie;
            }
        }
    }

    function createCookie(name, value, days) {
        var expires;
        if (days) {
            var date = new Date();
            date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
             expires = "; expires=" + date.toGMTString();
        } else  expires = "";
        document.cookie = name + "=" + value + expires + "; path=/";
    }

    function createSessionCookie(name, value) {
        createCookie(name, value);
    }

    function createLocalCookie(name, value) {
        createCookie(name, days, 3650);
    }

    function removeCookie(name) {
        createCookie(name, "", -1);
    }

    return {
        readCookie: readCookie,
        createSessionCookie: createSessionCookie,
        createLocalCookie: createLocalCookie,
        removeCookie: removeCookie
    };
}());