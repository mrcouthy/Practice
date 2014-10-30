$(function () {
// Here's my data model
var ViewModel = function() {
    this.firstName = ko.observable('');
    this.lastName = ko.observable('');
};
 
ko.applyBindings(new ViewModel()); // This makes Knockout get to work
});



   