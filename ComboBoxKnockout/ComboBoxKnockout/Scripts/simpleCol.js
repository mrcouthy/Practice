 
$(document).ready(function () {
    $('#gogo').chosen();
    ko.applyBindings(new ReportViewer.ViewModel( ));
});

var ReportViewer = (function () {
    return {
        ViewModel:
            function ReservationsViewModel( ) {
                var self = this;
                self.availableData = [
                   { colName: "Col1" },
                   { colName: "Col2" },
                   { colName: "Col3" }
                ];
            }
    };
})();


