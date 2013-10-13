(function main() {
    //'use strict';
    ThreeViewItem = function (param) {
        var self = this;
        self.title = param.title;
        self.subItems = [];
       

    };

    ThreeViewItem.prototype = {

        addItem : function addItem(title) {
            
            var newItem = new ThreeViewItem({ title: title });
            this.subItems.push(newItem);
            return newItem;
        },

        render: function render() {

            var renderedElement = '<li> <a href="#">' + this.title + '</a>';
            if (this.subItems.length > 0) {

                renderedElement += '<ul style="display:none">';

                for (var i = 0; i < this.subItems.length; i++) {

                    renderedElement += this.subItems[i].render();
                }

                renderedElement += '</ul>';
            }
            
            renderedElement += '</li>';

            return renderedElement;
        },

        serializeData: function serialize() {

            var data = { title: this.title, subItems: [] };

            for (var i = 0; i < this.subItems.length; i++) {

                data.subItems.push(this.subItems[i].serializeData());
            }

            return data;
        },
    };

})();