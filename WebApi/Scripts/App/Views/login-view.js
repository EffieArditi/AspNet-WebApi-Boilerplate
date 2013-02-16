/// <reference path="../../_references.js" />
/// <reference path="../Models/user-model.js" />
/// <reference path="../../underscore.js" />
/// <reference path="../template-manager.js" />
/// <reference path="../app-setup.js" />
/// <reference path="../Models/user-model.js" />

// Creates ths 'App' object if doesn't exist --> equal to if(!myApplication) myApplication = {};
var WebApiApp = WebApiApp || {};

WebApiApp.LoginView = Backbone.View.extend({

    el: '#main',
    template_name: "login-template",

    initialize: function ()
    {

    },

    events:
    {
        "click #btnLogin": "login"
    },
    // Re-rendering the App just means refreshing the statistics -- the rest
    // of the app doesn't change.
    render: function ()
    {

        //this.$el.html(this.template);
        var that = this;
        TemplateManager.get(this.template_name, function (template)
        {
            var html = _.template(template);
            that.$el.html(html);
        });

        return this;
    },

    login: function ()
    {
        $("#divWrongLogin").hide();
        $.post(WebApiApp.SiteUrl + "api/authenticate", { "name": $("#txtName").val(), "password": $("#txtPassword").val() }, function (user)
        {
            if (user)
            {
                var userModel = new WebApiApp.UserModel(user);
                WebApiApp.Session.save(userModel);
                WebApiApp.AppRouter.navigate("/", { trigger: true });
            }
            else
            {
                alert("Something went wrong, pleae try again");
            }
        })
       .error(function (error)
       {
           if (error.status == "401")
           {
               $("#divWrongLogin").html(JSON.parse(error.responseText).message);
               $("#divWrongLogin").fadeIn(200);
           }
           else
           {
               alert("Error has occured");
           }

           console.error(error);
       });
    }
});