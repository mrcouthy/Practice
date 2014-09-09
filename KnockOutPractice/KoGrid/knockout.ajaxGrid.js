(function ($, ko) {
    // Private function
    function getColumnsForScaffolding(data) {
        if ((typeof data.length !== 'number') || data.length === 0) {
            return [];
        }
        var columns = [];
        for (var propertyName in data[0]) {
            columns.push({ headerText: propertyName, rowText: propertyName });
        }
        return columns;
    }

    var sortFieldModel = function (field, isAscending) {
        var me = this;
        me.field = field || '';
        me.isAscending = isAscending;
        me.toJson = function () {
            var result = {};
            if (me.field === '') return result;
            result[me.field] = me.isAscending ? "asc" : "desc";
            return result;
        };
    };

    ko.simpleGrid = {
        // Defines a view model class you can use to populate a grid
        viewModel: function (configuration) {

            var self = this;
            self.currentPageIndex = ko.observable(0);
            self.pageSize = configuration.pageSize || 5;
            self.totalPages = ko.observable(0);
            self.url = configuration.url;
            self.sortField = ko.observable();
            self.showSearchBar = configuration.showSearchBar || false;
            self.filters = ko.observable();
            self.itemToDelete = ko.observable();
            self.deleteRecord = function (item) {
                self.itemToDelete(item);
            };

            self.sort = function(field) {
                if (self.sortField() && self.sortField().field === field) {
                    var order = !self.sortField().isAscending;
                    self.sortField(new sortFieldModel(field,order ));
                } 
                else {
                    self.sortField(new sortFieldModel(field, true));
                }

                self.currentPageIndex(0);
            };

            self.searchCriteria = ko.computed(function() {
                var sort = self.sortField() ? self.sortField().toJson() : {};

                var criteria = {
                    pageIndex: self.currentPageIndex() + 1,
                    pageSize: self.pageSize,
                    filters: self.filters(),
                    sort: sort,
                    itemToDelete: self.itemToDelete()
                };

                return criteria;
            }, self);

            self.result = asyncComputed(function () {
                var criteriaJson = JSON.stringify(self.searchCriteria());
                return $.ajax(self.url, { data: criteriaJson, contentType: "application/json;charset=utf-8", type: 'POST' });
            }, self);

            function asyncComputed(evaluator, owner) {
                var result = ko.observable();
                result.records = ko.observableArray();
                result.totalRecords = ko.observable();
                ko.computed(function () {
                    // Get the $.Deferred value, and then set up a callback so that when it's done,
                    // the output is transferred onto our "result" observable
                    evaluator.call(owner).done(function (res) {
                        result.records(res.records);
                        result.totalRecords(res.totalRecords);
                        result(res);
                    });
                });
                return result;
            }

            // If you don't specify columns configuration, we'll use scaffolding
            self.columns = configuration.columns || getColumnsForScaffolding(ko.utils.unwrapObservable(self.result.records()));

            self.maxPageIndex = ko.computed(function () {
                return Math.ceil(self.result.totalRecords() / self.pageSize) - 1;
            }, self);
        }
    };

    // Templates used to render the grid
    var templateEngine = new ko.nativeTemplateEngine();

    templateEngine.addTemplate = function (templateName, templateMarkup) {
        document.write("<script type='text/html' id='" + templateName + "'>" + templateMarkup + "<" + "/script>");
    };

    templateEngine.addTemplate("ko_simpleGrid_search","<div class=\"row\">\
              <div class=\"col-lg-offset-8\">\
                <div class=\"input-group\">\
                  <input type=\"text\" class=\"form-control\" data-bind=\"value:searchCriteria\">\
                  <span class=\"input-group-btn\">\
                    <button class=\"btn btn-default\" type=\"button\" data-bind=\"click: $root.go\">Go!</button>\
                  </span>\
                </div>\
              </div>\
              <br/>\
            </div>");

    templateEngine.addTemplate("ko_simpleGrid_grid", "\
                    <table class=\"ko-grid table\">\
                        <thead>\
                            <tr data-bind=\"foreach: columns\">\
                               <th data-bind=\"text: headerText\"></th>\
                            </tr>\
                        </thead>\
                        <tbody data-bind=\"foreach: result.records\">\
                           <tr data-bind=\"foreach: $parent.columns\">\
                               <td data-bind=\"text: typeof rowText == 'function' ? rowText($parent) : $parent[rowText] \"></td>\
                            </tr>\
                        </tbody>\
                    </table>");

    templateEngine.addTemplate("ko_simpleGrid_pageLinks", "\
                    <div class=\"ko-grid-pageLinks\">\
                        <span>Page:</span>\
                        <!-- ko foreach: ko.utils.range(0, maxPageIndex) -->\
                               <a href=\"#\" data-bind=\"text: $data + 1, click: function() { $root.currentPageIndex($data) }, css: { selected: $data == $root.currentPageIndex() }\">\
                            </a>\
                        <!-- /ko -->\
                    </div>");

    // The "simpleGrid" binding 
    ko.bindingHandlers.simpleGrid = {
        init: function () {
            return { 'controlsDescendantBindings': true };
        },
        // This method is called to initialize the node, and will also be called again if you change what the grid is bound to
        update: function (element, viewModelAccessor, allBindingsAccessor) {
            var viewModel = viewModelAccessor(), allBindings = allBindingsAccessor();

            // Empty the element
            while (element.firstChild)
                ko.removeNode(element.firstChild);

            // Allow the default templates to be overridden
            var gridTemplateName = allBindings.simpleGridTemplate || "ko_simpleGrid_grid",
                pageLinksTemplateName = allBindings.simpleGridPagerTemplate || "ko_simpleGrid_pageLinks";

            if (viewModel.showSearchBar) {
                // Render the search bar
                var searchContainer = element.appendChild(document.createElement("DIV"));
                ko.renderTemplate("ko_simpleGrid_search", viewModel, { templateEngine: templateEngine }, searchContainer, "replaceNode");
            }

            // Render the main grid
            var gridContainer = element.appendChild(document.createElement("DIV"));
            ko.renderTemplate(gridTemplateName, viewModel, { templateEngine: templateEngine }, gridContainer, "replaceNode");

            // Render the page links
            var pageLinksContainer = element.appendChild(document.createElement("DIV"));
            ko.renderTemplate(pageLinksTemplateName, viewModel, { templateEngine: templateEngine }, pageLinksContainer, "replaceNode");
            
            $(element).delegate(".sort", "click", bindSort);
        }
    };

    function bindSort() {
        //retrieve the context
        var sortField = $(this).html();
         ko.contextFor(this).$root.sort(sortField);
        return false;
    }
})(jQuery, ko);