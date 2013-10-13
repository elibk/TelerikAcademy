(function () {
    //'use strict';

    var controls = (function () {
        

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
            if (!event) {
                event = window.event;
            }
            event = event || window.event;

            event.stopPropagation();

            changeVisabilityOnClick(this.getElementsByTagName('ul')[0]);

        }

        function TreeUlItem(treeViewsULs) {

            function addNode() {
                var i;
                var treeViewsULsLen = treeViewsULs.length;
                var treeViewsLIs = [];
                var li;
                for (i = 0; i < treeViewsULsLen; i++) {
                    li = document.createElement('li');
                    treeViewsULs[i].appendChild(li);
                    treeViewsLIs.push(li);
                }

                return new TreeLiItem(treeViewsLIs);
            }

            return {
                addNode: addNode
            };
        }

        function TreeLiItem(treeViewsLIs) {
            var self = this;
            function content(textContent) {
                var i;
                var treeViewsLIsLen = treeViewsLIs.length;
                var anchor;
                for (i = 0; i < treeViewsLIsLen; i++) {
                    anchor = document.createElement('a');
                    anchor.href = '#';
                    anchor.appendChild(document.createTextNode(textContent));
                    treeViewsLIs[i].appendChild(anchor);
                }

            }

            function addNode() {
               
                var i;
                var treeViewsLIsLen = treeViewsLIs.length;
                var treeViewsSubLIs = [];
                var li;
                var innerUL;
                for (i = 0; i < treeViewsLIsLen; i++) {
                    
                    li = document.createElement('li');
                    innerUL = treeViewsLIs[i].getElementsByTagName('ul');
                   
                    if (!innerUL || innerUL.length === 0) {
                        var ul = document.createElement('ul');
                        ul.style.display = 'none';
                        
                       
                        treeViewsLIs[i].appendChild(ul);
                        ul.parentNode.addEventListener('click', litenerForClick);
                        ul.parentNode.style.listStyleImage = "url('icon_green_dot.png')";

                        ul.appendChild(li);
                        
                    }
                    else {
                        innerUL[0].appendChild(li);
                    }

                    treeViewsSubLIs.push(li);
                }

                return new TreeLiItem(treeViewsSubLIs);
                
            }

            return {
                addNode : addNode,
                content : content
            };

            
        }

        function treeView(parentSelector) {
            
            var parents = document.querySelectorAll(parentSelector);
            var parentsLen = parents.length;
            var i;
            var treeViewsULs = [];
            var ul;
            for (i = 0; i < parentsLen; i++) {
                ul = document.createElement('ul');
                parents[i].appendChild(ul);
                treeViewsULs.push(ul);
            }

            return new TreeUlItem(treeViewsULs);
        }
        return {
            treeView: treeView,
            TreeLiItem: TreeLiItem,
            TreeUlItem: TreeUlItem

        };
    })();

    var treeView = controls.treeView("div.tree-view");

    var html5 = treeView.addNode();
    html5.content("HTML5");

    var jsnode = treeView.addNode();
    jsnode.content("JavaScript");

    var js1subnode = jsnode.addNode();
    js1subnode.content("JavaScript - part 1");

    var js2subnode = jsnode.addNode();
    js2subnode.content("JavaScript - part 2");

    var jsSubSub = js2subnode.addNode();
    jsSubSub.content('Sub sub 2.2');

    var jslibssubnode = jsnode.addNode();
    jslibssubnode.content("JS Libraries");

    var jsframeworksnode = jsnode.addNode();
    jsframeworksnode.content("JS Frameworks and UI");

    var webnode = treeView.addNode();
    webnode.content("Web");

})();