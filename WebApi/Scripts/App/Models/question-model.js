/// <reference path="../../_references.js" />
/// <reference path="../../underscore.js" />

// Creates ths 'App' object if doesn't exist --> equal to if(!myApplication) myApplication = {};
var WebApiApp = WebApiApp || {};

WebApiApp.QuestionModel = Backbone.Model.extend({

    urlRoot: function ()
    {
        if (WebApiApp.Session.isAuthenticated())
        {
            return WebApiApp.SiteUrl + "api/questions/";
        }
        
        return WebApiApp.SiteUrl + "api/questions/open";
    },

    defaults:
    {
        id: "",
        questionText: "",
        isOpenToVotes: "",
        votes: ""
    },

});