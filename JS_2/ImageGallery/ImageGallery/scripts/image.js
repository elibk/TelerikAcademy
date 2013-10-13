(function () {

    ImageItem = function (param) {
        var self = this;
        self.title = param.imgTitle;
        self.src = param.imgSrc;
    };

    ImageItem.prototype = {

        render: function render() {

            return '<div><p>'+ this.title +'</p><img src="' +this.src +'" /></div>';
        },

        serialize: function serialize() {

            var data = { title: this.title, src:this.src };
            return data;
        },
    };

})();