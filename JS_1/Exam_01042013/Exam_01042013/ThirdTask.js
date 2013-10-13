var variables = {};

function Solve(args) {

   
    variables = {};
    var i;
    var value = 0;
    for (i = 0; i < args.length; i++) {

        value = parseCommand (args[i]);
    }

    return value;
}

function execute() {

}


function parseCommand(command) {
    
    var valStartPos = command.indexOf('[');

    
    var value = command.substring(valStartPos + 1, command.length - 1).split(/[ ,]+/);
    command = command.substring(0, valStartPos).split(/[ ]+/);
    value = arrToIntArr(value);
 
    if (command[2] !== undefined) {
        switch (command[2]) {

            case 'min':
                value = findMin(value);
                break;
            case 'max':
                value = findMax(value);
                break;
            case 'avg':
                value = findAverage(value);
                break;
            case 'sum':
                value = findSum(value);
                break;
            default:

        }
    }
    

    if (command[0] === "def") {
        variables[command[1]] = value;
    }
    else {
        switch (command[0]) {

            case 'min':
                value = findMin(value);
                break;
            case 'max':
                value = findMax(value);
                break;
            case 'avg':
                value = findAverage(value);
                break;
            case 'sum':
                value = findSum(value);
                break;
            default:

        }
    }
   

    
   
    

    return value;

}

function arrToIntArr(arr) {

    var prop;
    var i;
    var number;
    var newArr = [];
    for (i = 0; i < arr.length; i++) {

        if (arr[i] !== '') {

            newArr.push(arr[i]);
        }
    }

    for (i = 0; i < newArr.length; i++) {

        if (hasProperty(variables, newArr[i])) {
            
            for (prop in variables) {

                if (prop === newArr[i]) {

                    newArr[i] = variables[prop];
                }

            }
        }
        else {
            number = parseInt(newArr[i], 10);
            if (isNaN(number)) {
                
            }
            else {
                newArr[i] = parseInt(newArr[i], 10);
            }

            
        }

        
    }

    return newArr;
}



function hasProperty(obj, propName) {
    if (propName in obj) {

        return true;
    }

    return false;
}

function findMin(sequence) {

    

    var min = sequence[0];

    if (Array.isArray(min)) {
         
        min = findMin(min);
    }

    for (i = 1; i < sequence.length; i++) {


        if (Array.isArray(sequence[i])) {

            if (min > findMin(sequence[i])) {
                min = findMin(sequence[i]);
            }
        }

        if (min > sequence[i]) {

            min = sequence[i];
        }

    }
    return min;
}
function findMax(sequence) {

    var max = sequence[0];

    if (Array.isArray(max)) {

        max = findMax(max);
    }
    for (i = 1; i < sequence.length; i++) {

        if (Array.isArray(sequence[i])) {

            if (max < findMax(sequence[i])) {
                max = findMax(sequence[i]);
            }
        }

        if (max < sequence[i]) {
            max = sequence[i];
        }
    }
    return max;
}

function findAverage(sequence) {

    var avg = sequence[0];

    if (Array.isArray(avg)) {

        avg = findAverage(avg);
    }
    for (i = 1; i < sequence.length; i++) {


        if (Array.isArray(sequence[i])) {

            avg += findAverage(sequence[i]);
        }
        else {
            avg += sequence[i];
        }
    }
    return Math.floor(avg / sequence.length);
}

function findSum(sequence) {

    var sum = sequence[0];
    if (Array.isArray(sum)) {

        sum =  findSum(sum);
    }
    else {
        sum = parseInt(sequence[0], 10);
    }
    
    for (i = 1; i < sequence.length; i++) {


        

        if (Array.isArray(sequence[i])) {

            sum += findSum(sequence[i]);
        }
        else {
            sum += parseInt(sequence[i], 10);
        }

    }
    return sum;
}