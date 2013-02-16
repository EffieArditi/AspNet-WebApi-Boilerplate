/// <reference path="../../_references.js" />
/// <reference path="../common.js" />
/// <reference path="user-model.js" />

// Creates the 'App' object if doesn't exist --> equal to if(!myApplication) myApplication = {};
var WebApiApp = WebApiApp || {};

WebApiApp.SessionModel = Backbone.Model.extend({

    defaults:
    {
        localStorageUserKey: "LoggedInUser"
    },

    initialize: function ()
    {
        this.load();
    },

    load: function ()
    {
        var user = loadFromStorage(this.get("localStorageUserKey"));
        if (IsObjectNullOrUndefined(user))
        {
            return null;
        }
        
        WebApiApp.LoggedInUser = new WebApiApp.UserModel(user);
        return WebApiApp.LoggedInUser;
    },

    save: function (userModel)
    {
        WebApiApp.LoggedInUser = userModel;
        saveToStorage(this.get("localStorageUserKey"), WebApiApp.LoggedInUser);
    },

    isAuthenticated: function ()
    {
        var userModel = this.load();
        return (!IsObjectNullOrUndefined(userModel) && !IsObjectNullOrUndefined(userModel.get("accessToken")));
    },

    clear: function ()
    {
        removeFromStorage(this.get("localStorageUserKey"));
        WebApiApp.LoggedInUser = null;
    }
});