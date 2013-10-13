var toDoList = (function myfunction() {

    'use strict';

    var toDoListsCouter = 0;

    function getNewList(parentSelector) {

        var taskCounter = 0;

        var parent = document.querySelector(parentSelector);
        var toDoList = document.createElement('div');
        toDoList.className = 'TODO-list';
        toDoList.id = 'TODO-list-' + toDoListsCouter;
      
        var taskListItem = document.createElement('li');
        
        var taskCheck = document.createElement('input');
        taskCheck.type = 'checkbox';
        taskCheck.name = 'task-from-todo-list-' + toDoListsCouter;
        
        var taskLabel = document.createElement('label');

        var inputForItem = document.createElement('input');
        inputForItem.id = 'input-for-new-todo-item-' + toDoListsCouter;
        inputForItem.type = 'text';
        
        var labelForInput = document.createElement('label');
        labelForInput.htmlFor = inputForItem.id;
        labelForInput.textContent = 'New task :';

        toDoList.appendChild(labelForInput);
        toDoList.appendChild(inputForItem);

        var button = document.createElement('a');
        button.href = '#';
        var buttonText = document.createTextNode('');
        button.appendChild(buttonText);

        (function generateButtons() {

            var buttonForNewItem = button.cloneNode(true);
            buttonForNewItem.firstChild.textContent = 'Add TODO task';
            buttonForNewItem.addEventListener('click', addItemOnClick, false);
            toDoList.appendChild(buttonForNewItem);

            var buttonForDeleteItems = button.cloneNode(true);
            buttonForDeleteItems.firstChild.textContent = 'Delete checked TODO task';
            buttonForDeleteItems.addEventListener('click', removeItemsOnClick, false);
            toDoList.appendChild(buttonForDeleteItems);

            var buttonForHideItems = button.cloneNode(true);
            buttonForHideItems.firstChild.textContent = 'Hide checked TODO task';
            buttonForHideItems.addEventListener('click', hideItemsOnClick, false);
            toDoList.appendChild(buttonForHideItems);

            var buttonForShowItems = button.cloneNode(true);
            buttonForShowItems.firstChild.textContent = 'Show hidden TODO task';
            buttonForShowItems.addEventListener('click', showItemsOnClick, false);
            toDoList.appendChild(buttonForShowItems);

        })();

        var tasksChecks = [];
        var taskList = document.createElement('ul');
        toDoList.appendChild(taskList);

        parent.appendChild(toDoList);
        toDoListsCouter += 1;

        function addItemOnClick(ev) {

            if (!ev) {
                ev = window.event;
            }

            ev.stopPropagation();
            ev.preventDefault();

            if (!(ev.target instanceof HTMLAnchorElement)) {

                return;
            }

            var taskContent = inputForItem.value;

            if (!taskContent) {

                alert('Name of the new task can not be empty.');
                return;
            }

            var newTask = taskListItem.cloneNode(true);
            var newTaskCheck = taskCheck.cloneNode(true);
            newTaskCheck.id = 'task-' + taskCounter;
            taskCounter += 1;
            var newLabelTask = taskLabel.cloneNode(true);
            newLabelTask.htmlFor = newTaskCheck.id;
            newLabelTask.textContent = taskContent;

            newTask.appendChild(newTaskCheck);
            newTask.appendChild(newLabelTask);

            taskList.appendChild(newTask);
            tasksChecks.push(newTaskCheck);
        }

        function removeItemsOnClick(ev) {

            if (!ev) {
                ev = window.event;
            }

            ev.stopPropagation();
            ev.preventDefault();

            if (!(ev.target instanceof HTMLAnchorElement)) {

                return;
            }

            var isItemFound = false;
            for (var i = 0; i < tasksChecks.length; i += 1) {

                while (tasksChecks[i].checked) {
                    taskList.removeChild(tasksChecks[i].parentNode);
                    isItemFound = true;
                    tasksChecks.splice(i, 1);
                }
            }

            if (!isItemFound) {
                alert('There are no cheked tasks to be removed.');
                return;
            }
        }

        function hideItemsOnClick(ev) {

            if (!ev) {
                ev = window.event;
            }

            ev.stopPropagation();
            ev.preventDefault();

            if (!(ev.target instanceof HTMLAnchorElement)) {

                return;
            }

            var isItemFound = false;
            for (var i = tasksChecks.length - 1; i >= 0; i--) {

                if (tasksChecks[i].checked) {
                    tasksChecks[i].parentNode.style.display = 'none';
                    tasksChecks[i].checked = false;
                    isItemFound = true;
                }
            }

            if (!isItemFound) {
                alert('There are no cheked tasks to be hide.');
                return;
            }
        }

        function showItemsOnClick(ev) {

            if (!ev) {
                ev = window.event;
            }

            ev.stopPropagation();
            ev.preventDefault();

            if (!(ev.target instanceof HTMLAnchorElement)) {

                return;
            }

            var isItemFound = false;
            for (var i = tasksChecks.length - 1; i >= 0; i--) {

                if (tasksChecks[i].parentNode.style.display === 'none') {
                    

                    tasksChecks[i].parentNode.style.display = '';
                    tasksChecks[i].checked = true;
                    isItemFound = true;
                }
            }

            if (!isItemFound) {
                alert('There are no hidden tasks to shown.');
                return;
            }
        }
    }

    return {
        getNewList: getNewList
    };
})();