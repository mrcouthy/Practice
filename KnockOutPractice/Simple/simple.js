$(function () {
    // Here's my data model
    var ViewModel = function (firstName, lastName, phones) {
        var tesphones = ['abc', 'def', 'ghi'];
        var self = this;
        self.firstName = ko.observable(firstName);
        self.lastName = ko.observable(lastName);
        self.lastName.subscribe(
            function ()
            {
                alert('hi');
            }
            );
        self.fullName = ko.computed(function () {
            return this.firstName() + ' ' + this.lastName();
        }, this);//this is requrired because function does not belong to any object initially

        self.fullName2 = ko.computed(function () {
            return this.lastName() + ' ' + this.firstName();
        }, self);
        //arrya example
        self.phones = ko.observableArray(phones);

        self.phones(tesphones);
        this.newPhone = ko.observable();

        this.addPhone = function () {
            if (this.newPhone() != "") {
                this.phones.push(this.newPhone());// try this with no brackets ie this.newPhone and get mad !
                this.newPhone("");
            }
            //when using observables always access members as as function ie newphone() => value not noewphone => observable
        }

        this.selectedPhone = ko.observable("");

        //more complex select example
       // var dropDown = [{ name: "dhiraj", id: "1", phone: "9841190907" }, { name: "Hero", id: "2", phone: "5536114" }];

    };

   
    ko.applyBindings(new ViewModel('Dhiraj', 'Bajracharya', ['9841190907', '9841228718', '5536114', '123456', '5425654'])); // This makes Knockout get to work
});



