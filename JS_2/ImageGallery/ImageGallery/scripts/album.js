(function () {

    AlbumItem = function (param) {
        var self = this;
        self.title = param.albumTitle;
        self.setOfImages = [];
        self.setOfAlbums = [];
    };

    AlbumItem.prototype = {

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
                        for (i = 0; i < childrenUlOfPrevSibling.length; i++) {

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

        addImage: function addImage(title, src) {

            title = replaceSpecialSymbol(title);
            var newImage = new ImageItem({ imgTitle: title, imgSrc: src });
            this.setOfImages.push(newImage);

            return newImage;
        },

        addAlbum: function addAlbum(title) {
            title = replaceSpecialSymbol(title);
            var newAlbum = new AlbumItem({ albumTitle: title });
            this.setOfAlbums.push(newAlbum);

            return newAlbum;

        },

        render: function render() {

            var result = '<div class="album"><a href="#">'+ this.title+ '</a>';
            var i;
            for (i = 0; i < this.setOfImages.length; i++) {

                result += this.setOfImages[i].render();
            }

            for (i = 0; i < this.setOfAlbums.length; i++) {
                result += this.setOfAlbums[i].render();
            }

            result += '</div>';
            return result;
        },

        serialize: function serialize() {
            
            var data = {title:this.title, setOfImages: [], setOfAlbums: [] };
            var i;
            for (i = 0; i < this.setOfImages.length; i++) {

                data.setOfImages.push(this.setOfImages[i].serialize());
            }

            for (i = 0; i < this.setOfAlbums.length; i++) {

                data.setOfAlbums.push(this.setOfAlbums[i].serialize());
            }

            return data;
        },

    };

})();