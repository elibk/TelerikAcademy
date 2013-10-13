
    var tags = ["cms", "javascript", "js", "ASP.NET MVC",
        ".net", ".net", "css", "wordpress", "xaml", "js", "http", "web", "asp.net", "asp.net MVC",
        "ASP.NET MVC", "wp", "javascript", "js", "cms", "html", "javascript", "http", "http", "CMS"];
    var uniqueTags = [];
    fillCollectionOfUniqeTags();


    function generateTagClould(minFontSize, maxFontSize) {
        var minFontSizeValue = document.getElementById('minFontSize').value.toString();
        minFontSizeValue = parseFloat(minFontSizeValue);

        var maxFontSizeValue = document.getElementById('maxFontSize').value.toString();
        maxFontSizeValue = parseFloat(maxFontSizeValue);

        minFontSize = minFontSize || minFontSizeValue || 15;
        maxFontSize = maxFontSize || maxFontSizeValue || 45;


        var tagCloud = document.getElementById('tag-clould');
        if (tagCloud !== null) {
            document.body.removeChild(tagCloud);
        }
        calculateTagsFontSize(minFontSize, maxFontSize);
        tagCloud = createTagCloud(minFontSize, maxFontSize);

        document.body.appendChild(tagCloud);
    }

    function addTag(tagName) {

        if (!tryCountTag(tagName)) {
            var newTagObject = { name: tagName, occurence: 1, fontSize: 0, serialNumber: uniqueTags.length};
            uniqueTags.push(newTagObject);
        }
    }

    function fillCollectionOfUniqeTags() {
        var tagsCount = tags.length;
        var i;
        for (i = 0; i < tagsCount; i += 1) { 
            addTag(tags[i]);
        }
    }

    function tryCountTag(tagName) {
        var uniqueTagsLen = uniqueTags.length;

        for (var i = 0; i < uniqueTagsLen; i++) {
            if (uniqueTags[i].name.toLowerCase() === tagName.toLowerCase()) {
            
                uniqueTags[i].occurence += 1;
                return true;
            }
        }

        return false;
    }

    function createTagCloud() {

        var uniqueTagsLen = uniqueTags.length;
    
        var clould = document.createElement('div');
        clould.style.border = '2px solid black';
        clould.style.padding = '5px';
        clould.style.maxWidth = '30%';
        clould.id = 'tag-clould';
        var frag = document.createDocumentFragment();
    
        uniqueTags = uniqueTags.sort(bySerialNumber);
        var i;
        for (i = 0; i < uniqueTagsLen; i++) {
            var tag = document.createElement('strong');
            tag.style.fontSize = uniqueTags[i].fontSize + 'px';
            tag.style.color = generateColor();
            tag.style.display = 'inline-block';
            tag.style.padding = '5px';
            tag.appendChild(document.createTextNode(uniqueTags[i].name));
            frag.appendChild(tag);

        }

        clould.appendChild(frag);

        return clould;
    }


    function calculateFontSizeStep(uniqueTagsLen, minFontSize, maxFontSize) {
        uniqueTagsLen = uniqueTagsLen || uniqueTags.length;
        minFontSize = minFontSize || 15;
        maxFontSize = maxFontSize || 45;

        var step = (maxFontSize - minFontSize) / uniqueTagsLen;
        if (step - Math.floor(step) > 0.45) {
            step = Math.floor(step + 1);
        }
        return Math.floor(step);
    }

    function byOccurence(a, b) {
        return parseInt(a.occurence, 10) - parseInt(b.occurence, 10);
    }

    function bySerialNumber(a, b) {
        return parseInt(a.serialNumber, 10) - parseInt(b.serialNumber, 10);
    }


    function generateColor() {
        var red = randomFromInterval(0, 255),
            green = randomFromInterval(0, 255),
            blue = randomFromInterval(0, 255);

        return 'rgb(' + red + ', ' + green + ', ' + blue + ')';
    }

    function randomFromInterval(from, to) {
        return Math.floor(Math.random() * (to - from + 1) + from);
    }

    function addNewTag(tagName) {
        tagName = tagName || document.getElementById('newTag').value;
        tags.push(tagName);
        addTag(tagName);
    }

    function calculateTagsFontSize(minFontSize, maxFontSize) {

        minFontSize = minFontSize || 15;
        maxFontSize = maxFontSize || 45;

        var uniqueTagsLen = uniqueTags.length;
        uniqueTags = uniqueTags.sort(byOccurence);

        var fontSizeStep = calculateFontSizeStep(uniqueTagsLen, minFontSize, maxFontSize);
        var fontSize = minFontSize;
        var compareName = uniqueTags[0];
        var incrieceStep = 1;
        var i;
        for (i = 0; i < uniqueTagsLen; i++) {
            if (compareName.name !== uniqueTags[i].name) {
                fontSize += fontSizeStep * incrieceStep;
                incrieceStep = 1;
            }
            else {
                incrieceStep += 1;
            }
        
            uniqueTags[i].fontSize = fontSize;
        }
    
        for (i = uniqueTagsLen - 1; incrieceStep > 0; i--) {

            uniqueTags[i].fontSize = maxFontSize;
            incrieceStep -= 1;
        }
    }