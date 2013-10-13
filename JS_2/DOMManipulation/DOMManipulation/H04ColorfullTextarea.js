
    function changeBackgroundColor(elementForChange) {
        elementForChange = elementForChange || document.getElementById('colorfull-textarea');
        elementForChange.style.backgroundColor = document.getElementById('td-backgriund-color').value;
    }

    function changeFontColor(elementForChange) {
        elementForChange = elementForChange || document.getElementById('colorfull-textarea');
        elementForChange.style.color = document.getElementById('td-font-color').value;
    }

    changeBackgroundColor();
    changeFontColor();