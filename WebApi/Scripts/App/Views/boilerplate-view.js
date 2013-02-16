/// <reference path="../../_references.js" />
/// <reference path="../../underscore.js" />
/// <reference path="../template-manager.js" />
/// <reference path="../app-setup.js" />

// Creates ths 'App' object if doesn't exist --> equal to if(!myApplication) myApplication = {};
var WebApiApp = WebApiApp || {};

WebApiApp.VIEW_NAME = Backbone.View.extend({

    el: '#id',
    //tagName: 'div',
    template_name: "template-name",

    initialize: function ()
    {
        _.bindAll(this, "render");
        this.setElement($(this.el));
    },

    events:
    {
        
    },

    render: function ()
    {
        var _this = this;
        TemplateManager.get(this.template_name, function (template)
        {
            var html = _.template(template);
            _this.$el.html(html);
        });

        return this;
    },
});