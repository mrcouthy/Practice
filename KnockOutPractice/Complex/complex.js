$(function () {
    // Here's my data model
    var ViewModel = function () {
        var self = this;
        var persons = [{ name: "dhiraj", id: "1"  }, { name: "poonam", id: "2"  },
          { name: "hero", id: "3"  }
        ];

        self.persons = persons;
        this.selectedPerson = ko.observable("");
        this.selectedPerson(1);
        var test = "2";
this.selectedPhone = ko.observable("");
        var telephones = [{ name: "dhiraj", id: "1", phone: "9841190907" }, { name: "home", id: "1", phone: "5536114" },
            { name: "poonam", id: "2", phone: "9841228718" }, { name: "home", id: "2", phone: "44151254" },
            { name: "Hero", id: "3", phone: "984166996699" }, { name: "home", id: "3", phone: "5536101" }
        ];
        self.phones = ko.computed(function () {

            var filteredPhones = ko.utils.arrayFilter(telephones, function (item) {
                
                if (item.id == test)
                return item;
            });
            return filteredPhones;
        });
       // self.phones = telephones;
        console.log("hello" +  this.selectedPerson());
        
        //more complex select example
        // var dropDown = [{ name: "dhiraj", id: "1", phone: "9841190907" }, { name: "Hero", id: "2", phone: "5536114" }];

    };


    ko.applyBindings(new ViewModel()); // This makes Knockout get to work
});



