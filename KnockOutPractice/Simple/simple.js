$(function () {
// Here's my data model
    var ViewModel = function (firstName, lastName,phones) {
     var   self = this;
     self.firstName = ko.observable(firstName);
     self.lastName = ko.observable(lastName);
     self.fullName = ko.computed(function () {
        return this.firstName() + ' ' + this.lastName();
    }, this);//this is requrired because function does not belong to any object initially

    self.fullName2 = ko.computed(function () {
        return this.lastName() + ' ' + this.firstName();
    }, self);

    self.phones = ko.observableArray(phones);
   
    this.newPhone = ko.observable();

    this.addPhone = function ()
    {
        if (this.newPhone()!="") {
            this.phones.push(this.newPhone());// try this with no brackets ie this.newPhone and get mad !
            this.newPhone("");
        }
       
        //when using observables always access members as as function ie newphone() => value not noewphone => observable
    }

    this.selectedPhone = ko.observable("");
    
};

    ko.applyBindings(new ViewModel('Dhiraj', 'Bajracharya', ['9841190907'])); // This makes Knockout get to work
});



   