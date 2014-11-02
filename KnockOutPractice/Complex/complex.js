$(function () {
    // Here's my data model
    var ViewModel = function (firstName, lastName, phones) {
        var self = this;
        //self.phones = ko.computed(function () {
        //    return phones;
        //});

        self.phones = ko.computed(function () {

            var filteredPhones = ko.utils.arrayFilter(phones, function (item) {
                if(item.length>1)
                return item;
            });

            return filteredPhones;
        });

        this.selectedPhone = ko.observable("");
        //more complex select example
        // var dropDown = [{ name: "dhiraj", id: "1", phone: "9841190907" }, { name: "Hero", id: "2", phone: "5536114" }];

    };


    ko.applyBindings(new ViewModel('Dhiraj', 'Bajracharya', ['9841190907', '9841228718','a','bb'])); // This makes Knockout get to work
});



