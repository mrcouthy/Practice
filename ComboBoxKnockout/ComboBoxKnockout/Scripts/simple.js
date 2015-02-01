$(function () {
    
    // Here's my data model
    var ViewModel = function (firstName, lastName, phones) {
        var tesphones = ['poire', 'annas', 'bannana','kiwi','avocado'];
        var self = this;
         
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

//Chosen
// Chosenify every multiple select DOM elements with class 'chosen'
        $('#gogo').chosen();
        var MY_SELECT = $($('#gogo').get(0));

        $('#get-order').click(function()
        {
            // Functional
            // var selection = ChosenOrder.getSelectionOrder(MY_SELECT);
            // Object-oriented
            var selection = MY_SELECT.getSelectionOrder();

            $('#order-list').empty();
            $(selection).each(function(i)
            {
                $('#order-list').append("<li>"+selection[i]+"</li>");
            });
        });

        $('#set-order').click(function()
        {
            // Functional
            // ChosenOrder.setSelectionOrder(MY_SELECT, $('#order').val().split(','), true);
            // Object-oriented
            MY_SELECT.setSelectionOrder($('#order').val().split(','), true);
        })

        // $('#get-order').click();
        // $('#set-order').click();
//Chosen End











});



