$(function () {
ko.validation.rules.pattern.message = 'Invalid.';
ko.validation.init({
    registerExtenders: true,
    messagesOnModified: true,
    insertMessages: true,
    parseInputAttributes: true,
    messageTemplate: null
}, true);
var captcha = function(val) {
    return val == 11;
};
var viewModel = {
    captcha: ko.observable().extend({
        // custom validator
        validation: {
            validator: captcha,
            message: 'Please check.'
        }
    }),
    submit: function() {
        if (viewModel.errors().length === 0) {
            alert('Thank you.');
        }
        else {
         //   alert('Please check your submission.');
            viewModel.errors.showAllMessages();
        }
    },   
};
viewModel.errors = ko.validation.group(viewModel);
ko.applyBindings(viewModel);
});



