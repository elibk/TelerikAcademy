/// <reference path="prototype.js" />
/// <reference path="jquery-2.0.2.js" />

var Slider =Class.create({

    initialize: function initSlider(parentSelector) {
        var parent = $(parentSelector);
        var mainContainer = $('<div id="slider"></div>');
       
        this.slidesContainer = $('<div></div>');

        mainContainer.append(this.slidesContainer);
        parent.append(mainContainer);
        var initilaSlide = $('<p>The slider <em>WELCOME</em></p>');
        this.leftButton = $('<img src="images/leftArrow.png" class="button" />');
        this.rigthButton = $('<img src="images/rightArrow.png" class="button"/>');

        mainContainer.append(this.leftButton);
        mainContainer.append(this.rigthButton);

        this.slidesContainer.append(initilaSlide);
        this.slides = [initilaSlide];
        this.initEvents();
    },

    addSlide: function addSlide(slideSelector) {
        var slide = $(slideSelector).hide();
        this.slides.push(slide);
        this.slidesContainer.append(slide);
    },

    initEvents: function initEv() {

        var that = this;
        var currentElementIndex = 0;
        function changeSlidesViewForword() {
           
            that.slides[currentElementIndex++].hide();
            if (!that.slides[currentElementIndex]) {
                currentElementIndex = 0;
            }
            that.slides[currentElementIndex].fadeIn(2000);
           
        }

        this.rigthButton.on('click', function () {
            that.slides[currentElementIndex++].hide();
            if (!that.slides[currentElementIndex]) {
                currentElementIndex = 0;
            }
            that.slides[currentElementIndex].show();
        });

        this.leftButton.on('click', function () {

            if ( currentElementIndex === 0) {
                return;
            }
            that.slides[currentElementIndex--].hide();
            
            that.slides[currentElementIndex].show();
        });
        setInterval(changeSlidesViewForword, 5000);

    }
});