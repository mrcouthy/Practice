//Java script objects
//"use strict";  
var obj = { name: "John", Age: 12 };

window.onload = function () {
    //Mulitline text
    console.log('test\
 log');
    console.log(typeof "Str");
    console.log(typeof 123);
    console.log(typeof false);
    console.log(typeof [1, 2, 3]);
    console.log(typeof obj);
    console.log(typeof {});
    console.log(typeof { name: "ram" });
    //access
    console.log('Accessing');
    console.log("_______________");

    console.log(obj.name);//same as
    console.log(obj["name"]);

    //Functions
    console.log('Functions');
    console.log("_______________");
    console.log(testIt());
    console.log(automaticGlobal);
   

    console.log("ABCDEF".slice(1, 3));
    console.log("ABCDEF".slice(-4, -1));

    console.log('Arrays');
    console.log("_______________");
    var hello = ["a", "b", "c", "d"];
    console.log(hello.pop());
    console.log(hello);
    console.log(hello.push("1"));
    console.log(hello);
    hello = ["a", "b", "c", "d"];
    console.log(hello.shift());
    console.log(hello);
    console.log(hello.unshift("1"));
    console.log(hello);
    console.log(delete hello[0]);
    console.log(hello);

    var fruits = ["Banana", "Orange", "Apple", "Mango"];
    console.log(fruits);
    fruits.splice(1, 2);//from ,count
    console.log(fruits);

    //sorting
    var points = [40, 100, 1, 5, 25, 10];
    points.sort(function (a, b) { return a - b });

    //regex
    var str = "Visit W3Schools";
    var n = str.search(/w3schools/i);
    var y;
    console.log(y );
    console.log(y || 0);//if y is undefined use 0
}

function testIt()
{
    automaticGlobal = "Automatic global if not declared";
    var thisIsPrivate = "Private";
    return "Name";
}

