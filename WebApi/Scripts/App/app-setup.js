/// <reference path="Models/session-model.js" />
/// <reference path="Models/user-model.js" />
/// <reference path="router.js" />
/// <reference path="../backbone.js" />
/// <reference path="../_references.js" />
/// <reference path="backbone-auth-adapter.js" />

// Creates ths 'App' object if doesn't exist --> equal to if(!myApplication) myApplication = {};
var WebApiApp = WebApiApp || {};

// Kicking it off!
$(function ()
{
    AdaptBackboneSyncForAuthorization();
    
    // load template to cache
    TemplateManager.get("questions-template", function () { });
    TemplateManager.get("login-template", function () { });
    TemplateManager.get("single-question-template", function () { });
    TemplateManager.get("add-question-template", function () { });
    
    WebApiApp.AppRouter = new AppRouter();
    WebApiApp.Session = new WebApiApp.SessionModel();
    Backbone.history.start();
    
});