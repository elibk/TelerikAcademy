function DomModule() {
    
    var buffer = [];
    var bufferCapacity = 100;

    function appendChild(childElement, selector, appendToAllParents) {

        var parents = document.querySelectorAll(selector);
        var i;
        if (appendToAllParents) {
            for (i = 0; i < parents.length; i += 1) {
                parents[i].appendChild(childElement.cloneNode(true));
            }
        } else {
            for (i = 0; i < parents.length; i += 1) {
                parents[i].appendChild(childElement);
                break;
            }
        }

       
    }

    function removeChild(selectorParent, selectorchildElement) {
        var parents = document.querySelectorAll(selectorParent);
        for (var i = 0; i < parents.length; i += 1) {
            var parentChilds = parents[i].querySelectorAll(selectorchildElement);
            for (var j = 0; j < parentChilds.length; j += 1) {
                parents[i].removeChild(parentChilds[j]);
            }
        }
    }


    function addHandler(selector, eventType, eventHandler) {
        var elements = document.querySelectorAll(selector);
        for (var i = 0; i < elements.length; i += 1) {
            elements[i].addEventListener(eventType, eventHandler, false);
        }

    }
        

    function appendToBuffer(selectorParent, childElement) {

        var parentIndex = intedexOfParent(selectorParent);

        if (parentIndex < 0) {
            var parents = document.querySelectorAll(selectorParent);
            if (parents.length > 0) {
                buffer.push({parents: parents,  selector: selectorParent, childrenCount: 1, parentChildren: document.createDocumentFragment() });
                buffer[buffer.length - 1].parentChildren.appendChild(document.createElement(childElement));
            }
            
        }
        else {
            buffer[parentIndex].parentChildren.appendChild(document.createElement(childElement));
            buffer[parentIndex].childrenCount += 1;
            if (buffer[parentIndex].childrenCount >= bufferCapacity) {

                emptyTheBuffer(parentIndex);
            }

        }

        
    }
   
    function emptyTheBuffer(parentIndex) {

        var parents = buffer[parentIndex].parents;
       
        for (var i = 0; i < parents.length; i++) {
            parents[i].appendChild(buffer[parentIndex].parentChildren);
        }
    }

    function intedexOfParent(selectorParent) {

        for (var i = 0; i < buffer.length; i++) {
            
            if (buffer[i].selector === selectorParent) {

                return i;
            }
        }

        return -1;
    }

    return {
        
        appendChild: appendChild,
        removeChild: removeChild,
        addHandler: addHandler,
        appendToBuffer: appendToBuffer
    };
}