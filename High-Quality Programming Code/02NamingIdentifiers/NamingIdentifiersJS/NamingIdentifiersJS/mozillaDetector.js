;(function () {

    function isMozilla(usedBrowserName) {
        return usedBrowserName === "Mozilla";
    }

    function alertIsItMozilla(event, arguments) {
        var selectedWindow = window,
            usedBrowserName = selectedWindow.navigator.appCodeName;

        if (isMozilla(usedBrowserName)) {
            alert("Yes");
        } else {
            alert("No");
        }
    }
})();