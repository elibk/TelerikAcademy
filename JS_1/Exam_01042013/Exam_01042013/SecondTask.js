function Solve(args) {

    var codinates = args[0].split(' ');
    var rows = parseInt(codinates[0], 10);
    var cols = parseInt(codinates[1], 10);
    codinates = args[1].split(' ');
    var posRow = parseInt(codinates[0], 10);
    var posCol = parseInt(codinates[1], 10);

    var labyrinth = matrix(rows, cols);
    var directions = [];
    var row;
    var col;
    var ind = 2;
    var ch;
    var dirRow;

    for (row = 0; row < rows; row++) {
        dirRow = args[ind++];
        directions[row] = [];
        for (ch = 0; ch < cols; ch++) {
            directions[row].push(dirRow[ch]);
        }

    }

    var sumCells = 0;
    var lenCells = 0;

    var isLost = false;
    

    while (true) {

        sumCells += labyrinth[posRow][posCol];
        labyrinth[posRow][posCol] = -1;
        lenCells++;

        if (directions[posRow][posCol] === 'l') {

            if (posCol === 0) {
                break;
            }

            posCol--;

            if (labyrinth[posRow][posCol] < 0) {
                isLost = true;
                break;
            }
        }
        else if (directions[posRow][posCol] === 'r') {

            if (posCol === cols - 1) {
                break;
            }
            posCol++;

            if (labyrinth[posRow][posCol] < 0) {
                isLost = true;
                break;
            }
        }
        else if (directions[posRow][posCol] === 'u') {

            if (posRow === 0) {
                break;
            }
            posRow--;

            if (labyrinth[posRow][posCol] < 0) {
                isLost = true;
                break;
            }
        }
        else if (directions[posRow][posCol] === 'd') {

            if (posRow === rows - 1) {
                break;
            }
            posRow++;

            if (labyrinth[posRow][posCol] < 0) {
                isLost = true;
                break;
            }
        }

       
    }


    if (isLost) {
        return "lost " + lenCells;
    }
    else {
        return "out " + sumCells;
    }

}


function matrix(rows, cols) {
    var array = [];
    var row;
    var col;    
    var ind = 1;
    for (row = 0; row < rows; row++) {

        array[row] = [];
        for (col = 0; col < cols; col++) {
            array[row][col] = ind++;

        }

    }
    return array;
}