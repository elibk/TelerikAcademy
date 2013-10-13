var imageGalleryRepository = (function repository() {

    function save(key, data) {

        localStorage.setObject(key, data);
    }

    function load(key) {

        return localStorage.getObject(key);
    }

    return {

        save: save,
        load: load

    };

})();