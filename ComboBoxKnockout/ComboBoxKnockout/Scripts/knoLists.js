
window.a = {
    SeatReservation: function (name, initalM) {
        var sr = this;
        sr.name = name;
        sr.meal = ko.observable(initalM);
        sr.formattedPrice = ko.computed(function () {
            var price = sr.meal().price;
            return price ? "$" + price.toFixed(2) : "None";
        });
    }
    ,
    myfunct: function ()
    {
        return "abc";
    }
};


$(document).ready(function () {
   

    var availableData = [
                   { colName: "Col1", price: 0 },
                   { colName: "Col2", price: 34.95 },
                   { colName: "Col3", price: 290 }
    ];
    debugger;
    var r = new ReportViewer.ViewModel(availableData);
    ko.applyBindings(r);
});

var ReportViewer = (function () {
    return {
        ViewModel:
            // Overall viewmodel for this screen, along with initial state
            function ReservationsViewModel(data) {
                var self = this;
                // Non-editable catalog data - would come from the server
                self.availableData = data;               
                //ko-------------------------
                // Editable data
                self.seats = ko.observableArray([
                    new window.a.SeatReservation("T1", self.availableData[0])
                ]);
                //computed-------------
                self.Total = ko.computed(function () {
                    var total = 0;
                    for (var i = 0; i < self.seats().length; i++) {
                        total += self.seats()[i].meal().price;
                    }
                    return total;
                }
                );

                //events----------------------------
                self.addSeats = function () {
                    self.seats.push(new window.a.SeatReservation("a", self.availableData[0]));
                }
                self.removeSeat = function (seat) {
                    self.seats.remove(seat);
                }
            }
    };
})();


