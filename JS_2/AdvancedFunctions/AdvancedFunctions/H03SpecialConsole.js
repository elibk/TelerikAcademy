(function () {

    var theConsole = document.createElement('div');
    theConsole.id = 'console';
    theConsole.style.wordBreak = 'break-all'; // not supported in Opera
    theConsole.style.overflowY = 'auto';
    theConsole.style.width = '450px';
    theConsole.style.height = '450px';
    theConsole.style.backgroundColor = 'gray';
    document.body.appendChild(theConsole);

    function specialConsole() {
       

        function stringFormat(text, args) {
            //// finding only first match of reg expresion one or more digits in { }.
            var placeholdStartIndex = text.indexOf(text.match(/{\d+}/));
            var placeholdEndIndex;
            var placeholdNum;
            //// while there is match
            while (placeholdStartIndex > 0) {

                placeholdEndIndex = ++placeholdStartIndex; // from placeholStartIndex = ++placeholdPos to placeholEndIndex  to get the length of placeholdIndex
                for (var i = placeholdStartIndex; text.charAt(i) !== '}'; i++) {
                    placeholdEndIndex++;
                }

                placeholdNum = parseInt(text.substring(placeholdStartIndex, placeholdEndIndex),10) + 1;
                if (args[placeholdNum] === undefined) {
                    throw new Error('FormatError: The index of a format item is less than zero, or greater than or equal to the length of the args array.');
                }
                text = text.replace(/{\d+}/, args[placeholdNum]);
                placeholdStartIndex = text.indexOf(text.match(/{\d+}/));
            }

            return text;
        }


        function writeLine(text) {
            if (!text) {
                text = "";
            }
            text = text.toString();
            var innerText = document.createElement('div');
            innerText.style.color = 'white';
            text = stringFormat(text, arguments);
            innerText.appendChild(document.createTextNode(text));
            theConsole.appendChild(innerText);
        }

        function writeError(text) {
            if (!text) {
                text = "";
            }
            var innerText = document.createElement('div');
            innerText.style.color = 'red';
            text = stringFormat(text, arguments);
            innerText.appendChild(document.createTextNode(text));
            theConsole.appendChild(innerText);
        }

        function writeWarrnig(text) {
            if (!text) {
                text = "";
            }
            var innerText = document.createElement('div');
            innerText.style.color = 'yellow';
            text = stringFormat(text, arguments);
            innerText.appendChild(document.createTextNode(text));
            theConsole.appendChild(innerText);
        }

        return {
            writeLine: writeLine,
            writeError: writeError,
            writeWarrnig: writeWarrnig
        };
    }

    var spConsole = new specialConsole();

    spConsole.writeLine("Message: Hello {0}!", "Mikeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee");
    spConsole.writeError("Error: {0}", "Something happened");
    spConsole.writeWarrnig("Warning: {0}", "A warning");
    spConsole.writeLine(56);
    spConsole.writeError("Error: {0}", "Something happened");
    spConsole.writeWarrnig("Warning: {0}", "A warning");
    spConsole.writeLine("Message: Hello {0}!", "Mikeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee");
    spConsole.writeError("Error: {0}", "Something happened");
    spConsole.writeWarrnig("Warning: {0}", "A warning");
    spConsole.writeLine("Message: Hello {0}!", "Mikeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee");
    spConsole.writeError("Error: {0}", "Something happened");
    spConsole.writeWarrnig("Warning: {0}", "A warning");
    spConsole.writeLine("Message: Hello {0}!", "Mikeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee");
    spConsole.writeError("Error: {0}", "Something happened");
    spConsole.writeWarrnig("Warning: {0}", "A warning");
    spConsole.writeLine("Message: Hello {0}!", "Mikeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee");
    spConsole.writeError("Error: {0}", "Something happened");
    spConsole.writeWarrnig("Warning: {0}", "A warning");
    spConsole.writeWarrnig();

}());