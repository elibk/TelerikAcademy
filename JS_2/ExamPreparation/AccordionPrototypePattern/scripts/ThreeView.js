(function () {
    //'use strict';
    ThreeView = function (param) {
        var self = this;
        self.parent = document.querySelector(param.threeViewParentSelector);
        self.container = document.createElement('div');
        self.container.className = 'three-view';
        self.parent.appendChild(self.container);
        self.subItems = [];
    };

    ThreeView.prototype = {

        initialise: function initThreeView() {

            this.initialiseEvents();
        },

        initialiseEvents: function initialiseEvents() {

            var changeDisplayOnClick = function changeDisplayOnClick(ev) {

                if (!ev) {

                    ev = window.event;
                }

                ev.preventDefault();
                ev.stopPropagation();

                if (!(ev.target instanceof HTMLAnchorElement)) {

                    return;
                }

                
                var selectedLi = ev.target.parentNode;

                var childrenLi = selectedLi.children;
                var i;
                if (childrenLi) {
                    for (i = 0; i < childrenLi.length; i++) {

                        if (childrenLi[i] instanceof HTMLUListElement) {
                            
                            if (childrenLi[i].style.display === 'none') {

                                childrenLi[i].style.display = '';
                            }
                            else {
                                childrenLi[i].style.display = 'none';
                            }
                        }
                    }
                }

                var nextSibling = selectedLi.nextElementSibling;
                while (nextSibling) {

                    var childrenUlOfNextSibling = nextSibling.children;

                    if (childrenUlOfNextSibling) {
                        for (i = 0; i < childrenUlOfNextSibling.length; i++) {

                            if (childrenUlOfNextSibling[i] instanceof HTMLUListElement) {

                                childrenUlOfNextSibling[i].style.display = 'none';
                            }
                        }
                    }

                    nextSibling = nextSibling.nextElementSibling;
                }

                var prevSibling = selectedLi.previousElementSibling;
                while (prevSibling) {

                    var childrenUlOfPrevSibling = prevSibling.children;

                    if (childrenUlOfPrevSibling) {
                        for ( i = 0; i < childrenUlOfPrevSibling.length; i++) {

                            if (childrenUlOfPrevSibling[i] instanceof HTMLUListElement) {

                                childrenUlOfPrevSibling[i].style.display = 'none';
                            }
                        }
                    }
                    prevSibling = prevSibling.previousElementSibling;
                }
                
            };

            attachEventHandler(this.container, 'click', changeDisplayOnClick);
            
        },
        
        addItem: function addItem(title) {

            var newItem = new ThreeViewItem({ title: title });
            this.subItems.push(newItem);

            return newItem;
        },

        render: function render(title) {

            if (this.subItems.length <= 0) {

                return;
            }

            var newHtml = '<ul>';

            for (var i = 0; i < this.subItems.length; i++) {

                newHtml += this.subItems[i].render();
            }

            newHtml += '</ul>';

            this.container.innerHTML = newHtml;
            return this;
        },

        serialize: function serialize() {
            
            var data = [];
            for (var i = 0; i < this.subItems.length; i++) {

                data.push(this.subItems[i].serializeData());
            }

            return data;
        },

        getDeserializedThreeView: function getDeserializedAccordion(parentSelector, state) {

            var threeView = new ThreeView({threeViewParentSelector: parentSelector});
            threeView.initialise();

            for (var i = 0; i < state.length; i++) {
                threeView.subItems.push(deserialize(state[i]));
            }

            return threeView;

            function deserialize(state) {

                var threeViewItem = new ThreeViewItem({title :state.title});

                for (var i = 0; i < state.subItems.length; i++) {

                    threeViewItem.subItems.push(deserialize(state.subItems[i]));
                }

                return threeViewItem;
            }
            
        }
    };

})();