; (function () {

    var allLi = document.getElementsByTagName('li');

    function changeVisabilityOnClick(element) {

        var insideUL = element.getElementsByTagName('ul');

        if (element.style.display === 'none') {
            element.style.display = '';
        }
        else {
            // to make sure that the next time we expand item, subs item won't be visible
            element.style.display = 'none';
            for (var i = 0; i < insideUL.length; i++) {
                insideUL[i].style.display = 'none';
            }
        }

    
    }

    function litenerForClick(event) {
		if(!event){
		event = window.event;
		}
		event = event || window.event;
	
	if(ev.stopPropagation)
	
        if (this === event.target) {
            changeVisabilityOnClick(this.getElementsByTagName('ul')[0]);
        }

    }
    for (var i = 0; i < allLi.length; i++) {
    
        var li = allLi[i].getElementsByTagName('ul')[0];
        // we need to give spceific instructions because browsers tend to inherit some styles properties
        allLi[i].style.listStyle = 'none';
        allLi[i].style.cursor = 'auto';
        if( li !== undefined) {
            li.style.display = 'none';
            li.parentNode.addEventListener('click', litenerForClick);
            li.parentNode.style.cursor = 'pointer';
            li.parentNode.style.listStyleImage = "url('plus.jpg')";
        }
    }
})();