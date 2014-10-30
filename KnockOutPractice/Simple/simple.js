$(function () {
// Here's my data model
var ViewModel = function(firstName,lastName) {
    this.firstName = ko.observable(firstName);
    this.lastName = ko.observable(lastName);
    this.fullName = ko.computed(function () {
        return this.firstName() + this.lastName();
    },this)//this is requrired because function does not belong to any object initially
};

ko.applyBindings(new ViewModel('Dhiraj','Bajracharya')); // This makes Knockout get to work
});



   