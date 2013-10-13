/// <reference path="image-item.js" />
var Slider = {

    init: function initSlider(parentSelector) {
       
        this.parent = document.querySelector(parentSelector);

        this.sliderContainer = document.createElement('div');
        this.imgsContajner = this.sliderContainer.cloneNode(true);
        this.enlagedImgContainer = this.sliderContainer.cloneNode(true);
        this.buttonPrev = document.createElement('a');
        this.buttonPrev.href = '#';
        this.buttonNext = this.buttonPrev.cloneNode(true);

        this.buttonPrev.innerHTML = "Previous";
        this.buttonNext.innerHTML = "Next";

        this.sliderContainer.className = "img-slider";
       
        this.sliderContainer.appendChild(this.imgsContajner);
        this.sliderContainer.appendChild(this.buttonPrev);
        this.sliderContainer.appendChild(this.buttonNext);
        this.sliderContainer.appendChild(this.enlagedImgContainer);
        

        this.parent.appendChild(this.sliderContainer);
        this._setOfImages = [];

        this.enlargedImage = null;

        return this;
    },

    initEvents: function initSlider(parentSelector) {
        
        var that = this;

        var moveTrouthTheSliderOnClick = function moveTrouthTheSliderOnClick(ev) {

            if (!ev) {

                ev = window.event;
            }

            if (!(ev.target instanceof HTMLAnchorElement)) {

                return;
            }

            ev.stopPropagation();
            ev.preventDefault();

            var enlargePic;

            if (!that.enlargedImage) {

                that.enlargedImage = that.imgsContajner.firstChild;

                if (!that.enlargedImage) {

                    return;
                }

                enlargePic = that.enlargedImage.cloneNode(true);
            }
            else {
                if (ev.target.innerHTML === "Next") {
                    var nextImg = that.enlargedImage.nextSibling;

                    if (!nextImg) {
                        nextImg = that.imgsContajner.firstChild;
                    }

                    enlargePic = nextImg.cloneNode(true);
                    that.enlargedImage = nextImg;
                } else if (ev.target.innerHTML === "Previous") {
                    var prevImg = that.enlargedImage.previousSibling;

                    if (!prevImg) {
                        prevImg = that.imgsContajner.lastChild;
                    }

                    enlargePic = prevImg.cloneNode(true);
                    that.enlargedImage = prevImg;

                }
            }

            enlargePic.width = enlargePic.width * 2;
            enlargePic.heigth = enlargePic.width * 2;

            that.enlagedImgContainer.innerHTML = "";

            that.enlagedImgContainer.appendChild(enlargePic);
           

        }

        var enlargeImageOnClick = function enlargeImageOnClick(ev) {

            if (!ev) {

                ev = window.event;
            }

            if (!(ev.target instanceof HTMLImageElement)) {

                return;
            }

            ev.stopPropagation();
            ev.preventDefault();
            that.enlargedImage = ev.target;
            var enlargePic = ev.target.cloneNode(true);
            enlargePic.width = enlargePic.width * 2;
            enlargePic.heigth = enlargePic.width * 2;

            that.enlagedImgContainer.innerHTML = "";

            that.enlagedImgContainer.appendChild(enlargePic);

        }

        attachEventHandler(this.imgsContajner, 'click', enlargeImageOnClick);

        attachEventHandler(this.sliderContainer, 'click', moveTrouthTheSliderOnClick);

        return this;
    },


    addImage: function addImage(title, src) {

        var newImage = Object.create(ImageItem).init(title, src);
        this._setOfImages.push(newImage);

        return this;
    },

    render: function render() {

        var newHtml = "";

        for (var i = 0; i < this._setOfImages.length; i++) {

            newHtml += String.format("<img src='{0}' title='{1}' alt='{1}'/>", this._setOfImages[i].src, this._setOfImages[i].title);
        }

        this.imgsContajner.innerHTML = newHtml;

        this.enlagedImgContainer.innerHTML = "";

        return this;
    }
};