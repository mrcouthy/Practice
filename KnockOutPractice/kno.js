$documnet.ready(function () {
    function AppViewModel() {
        this.firstName = ko.observable("Bdert");
        this.lastName = ko.observable("Bertington");

        this.fullName = ko.computed(function () {
            return this.firstName() + " " + this.lastName();
        }, this);

        this.capitalizeLastName = function () {
            var currentVal = this.lastName();
            this.lastName(currentVal.toUpperCase());
        };
    }

    // Activates knockout.js
    ko.applyBindings(new AppViewModel());
});