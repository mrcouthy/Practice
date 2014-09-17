//Java script objects
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
   
 
}

function testIt()
{
    automaticGlobal = "Automatic global if not declared";
    var thisIsPrivate = "Private";
    return "Name";
}

