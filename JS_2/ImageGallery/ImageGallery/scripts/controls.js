//(function main() {
var controls = (function control() {

        function getImageGallery(parentSelector) {

            var newGallery = new Gallery({galleryParentSelector: parentSelector});
            newGallery.initialise();
            return newGallery;
        }

        function buildImageGallery(parentSelector, state) {

            var gallery = new Gallery({ galleryParentSelector: parentSelector });
            gallery.initialise();

            var i;
            for (i = 0; i < state.setOfImages.length; i += 1) {

                gallery.addImage(state.setOfImages[i].title, state.setOfImages[i].src);
            }

            for (i = 0; i < state.setOfAlbums.length; i += 1) {
                gallery.setOfAlbums.push(deserialize(state.setOfAlbums[i]));
            }

            return gallery;

            function deserialize(state) {

                var album = new AlbumItem({ albumTitle: state.title });

                var i;
                for (i = 0; i < state.setOfImages.length; i += 1) {

                    album.addImage(state.setOfImages[i].title, state.setOfImages[i].src);
                }

                for (i = 0; i < state.setOfAlbums.length; i += 1) {
                    album.setOfAlbums.push(deserialize(state.setOfAlbums[i]));
                }

                return album;
            }
        }

        return {

            getImageGallery: getImageGallery,
            buildImageGallery: buildImageGallery
        };
    })();

    //attachEventHandler(window, 'load', function () {       
    //});   
//})();
