window.onload = function () {
   defineFunction();
   console.log(defineFunction.toString());//prints the function
   argumentObjectSample();//since its global it belongs to window
   console.log( this.myObject.fullName());
    //calling functions
   window.callingFunction("window");
   this.callingFunction("this");
   var myObj;
   var myArray=["Apply"];
   callingFunction.call(myObj, "Function Method");
   callingFunction.apply(myObj, myArray);//takes parameter as array
   console.log(myObj);

}

function callingFunction(name)
{
    console.log(name + " functionwas called");
}

var myObject = {
    firstName: "John",
    lastName: "Doe",
    fullName: function () {
        return this.firstName + " " + this.lastName;
    }
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
    console.log("Sum is " + x);
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


