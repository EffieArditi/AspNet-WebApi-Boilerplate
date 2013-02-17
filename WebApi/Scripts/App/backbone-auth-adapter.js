/// <reference path="../_references.js" />
/// <reference path="common.js" />

function AdaptBackboneSyncForAuthorization()
{
    Backbone.old_sync = Backbone.sync;
    Backbone.sync = function (method, model, options)
    {
        var userId = "";
        var accessToken = "";

        if (!IsObjectNullOrUndefined(window.WebApiApp.LoggedInUser))
        {
            userId = window.WebApiApp.LoggedInUser.get("id");
            accessToken = window.WebApiApp.LoggedInUser.get("accessToken");
        }
        
        options = options || {};
        options.beforeSend = function (xhr)
        {
            xhr.setRequestHeader("Api-UserId", userId);
            xhr.setRequestHeader("Api-AuthKey", accessToken);
        };

        options.error = function (error)
        {
            console.log(error);
            if (error.status == "401" || error.status == "403")
            {
                window.WebApiApp.AppRouter.navigate("login", { trigger: true });
            } else
            {
                console.error(error);
            }
        };
        Backbone.old_sync(method, model, options);
    };
}

function RestoreBackboneSync()
{
    Backbone.sync = Backbone.old_sync;
}

var getValue = function (object, prop)
{
    if (!(object && object[prop])) return null;
    return _.isFunction(object[prop]) ? object[prop]() : object[prop];
};