/// <reference path="../../_references.js" />

// Creates ths 'App' object if doesn't exist --> equal to if(!myApplication) myApplication = {};
var WebApiApp = WebApiApp || {};

WebApiApp.QuestionCollection = Backbone.Collection.extend({

    model: WebApiApp.QuestionModel,
    
    url: function ()
    {
        return WebApiApp.SiteUrl + "api/questions";
    },
});