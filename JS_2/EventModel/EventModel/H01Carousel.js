var carousel = (function myfunction() {

    'use strict';

    function getCarousel(parentSelector, widthOfCarouselInPX, heightOfCourselInPX) {

        var int = setInterval(function myfunction() { moveRight(); }, 10);

        widthOfCarouselInPX = parseInt(widthOfCarouselInPX, 10);
        heightOfCourselInPX = parseInt(heightOfCourselInPX, 10);
        var imgs = [];
        var img = document.createElement('img');
        img.style.width = '100%';
        img.style.height = '100%';
        img.style.position = 'relative';
       
        var initialRight = 0;
        var initialTop = 0;
        var speedOfMoving = 0;
       
        var parent = document.querySelector(parentSelector);
        var carousel = document.createElement('div');
        carousel.className = 'carousel';
        carousel.style.width = widthOfCarouselInPX + 'px';
        carousel.style.height = heightOfCourselInPX + 'px';
        parent.appendChild(carousel);

        var arrowSize = Math.floor(widthOfCarouselInPX / 10) ;

        var leftArrow = img.cloneNode(true);
        leftArrow.className = 'left-arrow';
        leftArrow.src = "carouselPics/leftArrow.png";
        leftArrow.addEventListener('click', onClickChangeImg, false);

        leftArrow.style.width = arrowSize + 'px';
        leftArrow.style.height = arrowSize + 'px';
        carousel.appendChild(leftArrow);

        var photoWall = document.createElement('div');
        photoWall.className = 'photo-wall';
        photoWall.style.display = 'inline-block';
        var photoWallSize =  widthOfCarouselInPX * 0.7;
        photoWall.style.width = photoWallSize + 'px';
        photoWall.style.height = photoWallSize + 'px';
        photoWall.style.overflow = 'hidden';
        carousel.appendChild(photoWall);
        
        var rightArrow = img.cloneNode(true);
        rightArrow.className = 'right-arrow';
        rightArrow.src = "carouselPics/rightArrow.png";
        rightArrow.addEventListener('click', onClickChangeImg, false);
        rightArrow.style.width = arrowSize + 'px';
        rightArrow.style.height = arrowSize + 'px';
        carousel.appendChild(rightArrow);
        
        function addImg(path) {
             
            var newImg = img.cloneNode(true);
            newImg.src = path;
           
            newImg.style.top = initialTop + 'px';
            
            newImg.style.right = initialRight + 'px';
            imgs.push({ element: newImg, positionRight: initialRight });
            initialRight -= photoWallSize;
            initialTop -= photoWallSize + 5;
            
        }

        function render() {

            while (photoWall.firstChild) {

                photoWall.removeChild(parent.firstChild);
            }

            for (var i = 0; i < imgs.length; i += 1) {

                photoWall.appendChild(imgs[i].element);
            }

        }

        function onClickChangeImg(ev) {

            if (!ev) {

                ev = window.event;
            }

            ev.preventDefault();
            ev.stopPropagation();

            if (!(ev.target instanceof HTMLImageElement)) {

                return;
            }

            if (imgs.length === 0) {

                return;
            }


            if (ev.target.className === rightArrow.className) {

                int = clearInterval(int);
                int = setInterval(function myfunction() { moveRight(); }, 10);
                moveRight();

            } else if (ev.target.className === leftArrow.className) {

                int = clearInterval(int);
                int = setInterval(function myfunction() { moveLeft(); }, 10);
                moveLeft();
            }
        }

        function moveRight() {
            if (speedOfMoving >= (imgs.length * photoWallSize) - photoWallSize) {

                speedOfMoving = 0;
            }
            else {
                speedOfMoving += 1;
            }
            

            for (var i = 0; i < imgs.length; i++) {
                imgs[i].element.style.right = (imgs[i].positionRight + speedOfMoving) + 'px';
            }
        }

        function moveLeft() {

            if (speedOfMoving <= 0) {
                speedOfMoving = imgs.length * photoWallSize - photoWallSize;
            }

            speedOfMoving -= 1;



            for (var j = 0; j < imgs.length; j++) {
                imgs[j].element.style.right = (imgs[j].positionRight + speedOfMoving) + 'px';
            }
        }

        return {
            addImg: addImg,

            render: render
        };

    }

    return {

        getCarousel : getCarousel
        
    };
   
})();