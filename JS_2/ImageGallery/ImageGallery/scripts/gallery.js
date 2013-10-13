(function () {

    Gallery = function (param) {
        var self = this;
        var galleryParent = document.querySelector(param.galleryParentSelector);
        self.galleryContainer = document.createElement('div');
        self.galleryContainer.className = 'gallery-container';
        galleryParent.appendChild(self.galleryContainer);
        self.setOfImages = [];
        self.setOfAlbums = [];
    };

    Gallery.prototype = {

        initialise: function initThreeView() {

            this.initialiseEvents();
        },

        initialiseEvents: function initialiseEvents() {

            var changeDisplayOfAlbumOnClick = function changeDisplayOnClick(ev) {

                if (!ev) {

                    ev = window.event;
                }

                ev.preventDefault();
                ev.stopPropagation();

                if (!(ev.target instanceof HTMLAnchorElement)) {

                    return;
                }


                var selectedAlbum = ev.target;

                var nextSibling = selectedAlbum.nextElementSibling;
                while (nextSibling) {

                    if (nextSibling instanceof HTMLDivElement) {

                        if (nextSibling.style.display === 'none') {
                            nextSibling.style.display = '';
                        }
                        else {
                            nextSibling.style.display = 'none';
                        }
                    }
                    nextSibling = nextSibling.nextElementSibling;
                }
            };

            var showBigPictureOnClick = function showBigPictureOnClick(ev) {

                if (!ev) {

                    ev = window.event;
                }

                ev.preventDefault();
                ev.stopPropagation();

                if (!(ev.target instanceof HTMLImageElement)) {

                    return;
                }


                var selectedImg = ev.target;

                var parentContainer = selectedImg.parentNode;

                while (parentContainer.className !== 'gallery-container') {
                    parentContainer = parentContainer.parentNode;
                }

                var displayBorder = parentContainer.querySelector('#display-border');
                if (!displayBorder) {
                    var newDisplayBorder = document.createElement('div');
                    newDisplayBorder.id = 'display-border';
                    parentContainer.appendChild(newDisplayBorder);
                    
                    displayBorder = parentContainer.querySelector('#display-border');
                }

                var resizedImg = selectedImg.cloneNode(true);
                var widthOfOriginalImg = selectedImg.width;
                var heightOfOriginalImg = selectedImg.height;
                resizedImg.width = widthOfOriginalImg * 2;
                resizedImg.height = heightOfOriginalImg * 2;
                
                displayBorder.innerHTML = "";

                displayBorder.appendChild(resizedImg);
            };

            attachEventHandler(this.galleryContainer, 'click', changeDisplayOfAlbumOnClick);
            attachEventHandler(this.galleryContainer, 'click', showBigPictureOnClick);
        },

        addImage: function addImage(title, src) {

            title = replaceSpecialSymbol(title);
            var newImage = new ImageItem({ imgTitle: title, imgSrc: src});
            this.setOfImages.push(newImage);

            return newImage;
        },

        addAlbum: function addAlbum(title) {
            title = replaceSpecialSymbol(title);
            var newAlbum = new AlbumItem({ albumTitle: title });
            this.setOfAlbums.push(newAlbum);

            return newAlbum;
        },

        render: function render(title) {

            var newHtml = "";
            var i;
            for (i = 0; i < this.setOfImages.length; i++) {

                newHtml += this.setOfImages[i].render();
            }

            for (i = 0; i < this.setOfAlbums.length; i++) {
                newHtml += this.setOfAlbums[i].render();
            }

            this.galleryContainer.innerHTML = newHtml;
        },

        getImageGalleryData: function getImageGalleryData() {

            var data = { setOfImages: [], setOfAlbums: [] };
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