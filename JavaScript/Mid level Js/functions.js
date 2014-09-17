window.onload = function () {
    //create functions
    function add(a,b)
    {
        return a+b;
    }

    //annonymous function
    var multiply = function (a, b) { return a * b };

    //function constructor
    var substract = new Function("a", "b", "return a-b");

    console.log(add(1,2));
    console.log(multiply(1, 2));


    console.log(substract(1, 2));

}
 