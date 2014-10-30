$(function () {
// Here's my data model
var ViewModel = function(name) {
   this.name = ko.observable(name);
};
 
ko.applyBindings(new ViewModel('Dhiraj')); // This makes Knockout get to work
});



   