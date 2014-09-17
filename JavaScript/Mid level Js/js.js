window.onload = function () {
    //createObjects();
    //prototypeTest();
    accessProperties();

}

function createObjects()
{
    //Create objects
    var txt = '{"Name":"RamText","Address":"Patan"}';
    var obj = JSON.parse(txt);
    console.log(obj.Name);

    //using object literal
    var personLiteral = { firstName: "John", lastName: "Doe", age: 50, eyeColor: "blue" };

    //using new keyword
    var personNewKeyWord = new Object();
    personNewKeyWord.firstName = "John";
    personNewKeyWord.lastName = "Doe";
    personNewKeyWord.age = 50;
    personNewKeyWord.eyeColor = "blue";

    //using object constructor
    // 	The constructor function is the prototype for your person objects.
    function person(first, last, age, eyecolor) {
        this.firstName = first;
        this.lastName = last;
        this.age = age;
        this.eyeColor = eyecolor;
    };

    person.Name = "Ram";//will not work
    //You cannot add a new property to a prototype the same way as you add a new property to an existing object, because the prototype is not an existing object.
    person.prototype.Name = "Ram";//works


    var a = new person("John", "Doe", 50, "blue");
    var b = new person("Sally", "Rally", 48, "green");

    //Js objects are mutable (By reference)
    var x = person;
    x.firstName = "Ram";
    console.log(person.firstName);

}

function prototypeTest()
{
    //using object constructor
    // 	The constructor function is the prototype for your person objects.
    function person(first, last, age, eyecolor) {
        this.firstName = first;
        this.lastName = last;
        this.age = age;
        this.eyeColor = eyecolor;
    };

    person.Name = "Ram";//will not work
    var a = new person("John", "Doe", 50, "blue");
    console.log(a.Name);
    //You cannot add a new property to a prototype the same way as you add a new property to an existing object, because the prototype is not an existing object.
    person.prototype.Name = "Ram";//works
    var b = new person("Sally", "Rally", 48, "green");
    console.log(b.Name);

}

function accessProperties()
{
    var txt;
    var person = { fname: "John", lname: "Doe", age: 25 };
    delete person.age;//delete a property 
    for (x in person) {//loop a property
        txt += person[x];
    }
    console.log(txt);
}
