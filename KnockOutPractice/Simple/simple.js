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
   
    
};

    ko.applyBindings(new ViewModel('Dhiraj', 'Bajracharya', ['9841190907', '5536114'])); // This makes Knockout get to work
});



   