window.onload = function () {
   // defineFunction();
    //console.log(defineFunction.toString());//prints the function
    argumentObjectSample();
   

}

function argumentObjectSample()
{
    var x = findsum(1, 123, 500, 115, 44, 88);
    //Like variabes functions are also Hoisted ie you can call function before declaring it
    function findsum() {
        var i = 0,sum=0;
        for (i = 0; i < arguments.length; i++)
        {
            sum = sum + arguments[i];
        }
        return sum;
    }
    console.log(x);
}

function defineFunction()
{
    //create functions
    function add(a, b) {
        return a + b;
    }

    //annonymous function
    var multiply = function (a, b) { return a * b };

    //function constructor
    var substract = new Function("a", "b", "return a-b");

    console.log(add(1, 2));
    console.log(multiply(1, 2));
    console.log(substract(1, 2));
}


