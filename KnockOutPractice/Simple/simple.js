$(function () {
// Here's my data model
var ViewModel = function() {
   this.name = ko.observable('');
};
 
ko.applyBindings(new ViewModel()); // This makes Knockout get to work
});



   