window.Application1 = (function (application, ko, $) {
    var ViewModel1 = function () {
        var self = this;
        var persons = [{ name: "dhiraj", id: "1" }, { name: "poonam", id: "2" }, { name: "hero", id: "3" }];
        self.persons = persons;
        self.selectedPerson = ko.observable("");
        self.computedPersons = ko.computed(function () {
            var newPersons = ko.utils.arrayFilter(persons, function (item) {
                if (item.id=="1") {
                    return item;
                }
            }
            );
            return newPersons;
        }, this);
    }
    application.ViewModel = ViewModel1;
    return application;
})(window.Application1 || {}, ko, jQuery);

window.Application1 = (function (application, ko, $) {
    var addmore1 = "addmore";
    application.addmore = addmore1;
    return application;
})(window.Application1 || {}, ko, jQuery);



