function isBiggerThanItsNeighbors(array, index) {

    if (index > 0 && index < array.length - 1) {

        return array[index] > array[index - 1] && array[index] > array[index + 1];
    }
    else if (index === array.length - 1) {

        return array[index] > array[index - 1];
    }
    else if (index === 0) {

        return array[index] > array[index + 1];

    }
    alert('Index Out Of Range Exception. The index was outside the bounds of the array.');

    throw new Error('Index Out Of Range Exception. The index was outside the bounds of the array.');
}

function intParserArray(array) {

    for (var i = 0; i < array.length; i++) {

        array[i] = parseInt(array[i]);
        
    }

    return array;
}