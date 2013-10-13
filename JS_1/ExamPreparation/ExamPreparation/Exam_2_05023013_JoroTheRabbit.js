function Solve(args) {

    var terrain = arrayParseInts(args[0].split(', '));
    var terrLen = terrain.length;
    var maxCount = 1;
    var step;
    var count;

    for (step = 1; step < terrLen; step++) {

        count = jump(terrain, terrLen, step);
        if (maxCount < count) {
            maxCount = count;
        }
    }

    return maxCount.toString();
}


function arrayParseInts(array) {

    for (var i = 0; i < array.length; i++) {
        array[i] = parseInt(array[i], 10);
    }

    return array;
}

function clone(arr) {

    var newArray = [];

    for (var i = 0; i < arr.length; i++) {
        newArray.push(arr[i]);
    }

    return newArray;
}



function jump(terrain, terrLen, step) {
    var visitedPosInd = [];
    var isJumpContinie = true;
    var prevPositionVal;
    var tempCount = 1;
    var count = 1;
    var position;
    var startPos;
    var enterPos;

    for (startPos = 0; startPos < terrLen; startPos++) {
        
        isJumpContinie = true;
        enterPos = startPos + step;
        tempCount = 1;
        prevPositionVal = terrain[startPos];
        visitedPosInd.push[startPos];
        while (isJumpContinie) {
            ////Move Forword
            isJumpContinie = true;
            for (position = enterPos; position < terrLen; position += step) {
                
                if (terrain[position] <= prevPositionVal) {
                    isJumpContinie = false;
                    break;
                }
                if (visitedPosInd.indexOf(position) > 0) {
                    isJumpContinie = false;
                    break;
                }

                prevPositionVal = terrain[position];
                visitedPosInd.push[position];
                tempCount++;
            }

            if (isJumpContinie) {
                enterPos = position - terrLen;
                if (prevPositionVal >= terrain[enterPos] || visitedPosInd.indexOf(enterPos) > 0) {
                    isJumpContinie = false;
                }
            }
        }
        

        if (tempCount > count) {
            count = tempCount;
        }
        visitedPosInd = [];
    }

    return count;
}