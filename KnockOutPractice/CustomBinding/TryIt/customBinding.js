$(document).ready(function () {
    var viewModel = {
        giftWrap: ko.observable(true)
    };

    ko.bindingHandlers.slideVisible = {
        init: function (element, valueAccessor) { //valueAccessor is actually a function 
            var value = ko.unwrap(valueAccessor()); // Get the current value of the current property we're bound to
            $(element).toggle(value); // jQuery will hide/show the element depending on whether "value" or true or false
        },
        update: function (element, valueAccessor, allBindings) {
            var value = ko.unwrap(valueAccessor());

            // Grab some more data from another binding property
            var duration = allBindings.get('slideDuration') || 400; // 400ms is default duration unless otherwise specified

            // Now manipulate the DOM element using jQuery
            if (value)
                $(element).slideDown(duration);
            else
                $(element).slideUp(duration);
        }
    }

    ko.applyBindings(viewModel);
}
);
