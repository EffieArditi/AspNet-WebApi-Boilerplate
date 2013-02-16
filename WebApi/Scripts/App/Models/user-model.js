/// <reference path="../../_references.js" />
/// <reference path="../../underscore.js" />

// Creates ths 'App' object if doesn't exist --> equal to if(!myApplication) myApplication = {};
var WebApiApp = WebApiApp || {};

WebApiApp.UserModel = Backbone.Model.extend({

    urlRoot: function ()
    {
        return WebApiApp.SiteUrl + "api/user/" + this.get("Id");
    },

    defaults:
    {
        id: "",
        name: "",
        password: "",
        accessToken: ""
    },
    
});