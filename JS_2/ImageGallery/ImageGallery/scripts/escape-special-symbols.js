function replaceSpecialSymbol(text) {

    if (!text) {
        return;
    }

    var newText = text.split('<').join('&lt;');
    newText = newText.split('>').join('&gt;');

    return newText;
}