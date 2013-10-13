var shareButtons = (function ($j) {
    this.addFBShareButton = function (selector) {
        $j(selector).on("click", function () {
            var sharer = "https://www.facebook.com/sharer/sharer.php?u=";
            window.open(sharer + location.href, 'sharer', 'width=626,height=436');
        });
    }

    return {
        addFBShareButton: addFBShareButton
    };
})(jQuery);