var TemplateManager = {

    // Hash of preloaded templates for the app
    templates: {},

    get: function (name, callback) {
        var template = this.templates[name];

        if (template) {
            callback(template);
        }
        else {
            var that = this;
            $.get(WebApiApp.SiteUrl + "Scripts/App/Templates/" + name + ".html", function (fetchedTemplate)
            {
                that.templates[name] = fetchedTemplate;
                callback(fetchedTemplate);
            });
        }
    }

};