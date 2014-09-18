$(document).ready(function () {
    var viewModel = {
        giftWrap: ko.observable(true)
    };

    ko.bindingHandlers.slideVisible = {
        init: function (element, valueAccessor) {
            var value = ko.unwrap(valueAccessor()); // Get the current value of the current property we're bound to
            $(element).toggle(value); // jQuery will hide/show the element depending on whether "value" or true or false
            console.log(value);
        },
        update: function (element, valueAccessor, allBindings) {
            var value = valueAccessor();
            console.log(value);

            // Next, whether or not the supplied model property is observable, get its current value
            var valueUnwrapped = ko.unwrap(value);
            console.log(valueUnwrapped);
            // Grab some more data from another binding property
            var duration = allBindings.get('slideDuration') || 400; // 400ms is default duration unless otherwise specified

            // Now manipulate the DOM element
            if (valueUnwrapped == true)
                $(element).slideDown(duration); // Make the element visible
            else
                $(element).slideUp(duration);   // Make the element invisible
        }
    }



    ko.applyBindings(viewModel);
}
);
