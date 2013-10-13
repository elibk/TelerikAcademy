(function main() {
    'use strict';
    var SiteController = function (param) {
        var self = this;
        self.param = param;
        self.threeView;
        self.threeViewStates = [];
    };

    SiteController.prototype = {

        initialise: function initialiseSiteControler() {

            this.initialiseThreeView();
        },

        initialiseThreeView: function initThreeView() {

            this.threeView = new ThreeView(this.param);
            this.threeView.initialise();
        },

       

    };

    window.addEventListener('load', function () {
        var siteController = new SiteController({
            threeViewParentSelector: "#wrapper",
        });
        siteController.initialise();

        var webItem = siteController.threeView.addItem("Web");
        webItem.addItem('Web 0.1');
        var webSubItem = webItem.addItem('Web 0.2');
        webSubItem.addItem('web 0.2.0');
        webItem.addItem('Web 0.3');
        var webOtherSubItem = webItem.addItem('Web 0.4');
        webOtherSubItem.addItem('web 0.4.0');
        var desktopItem = siteController.threeView.addItem("Desktop");
        desktopItem.addItem('Desktop 0.1');
        siteController.threeView.render();

        var state = siteController.threeView.serialize(siteController.threeView);
        localStorage.setObject("tracks-accordion", state);
        var serialized = localStorage.getObject("tracks-accordion");
        var copyThreeView = siteController.threeView.getDeserializedThreeView("#wrapper", state);
        copyThreeView.addItem('Networking');
        copyThreeView.render();
    }, false);

})();