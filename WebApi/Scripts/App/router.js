/// <reference path="Models/session-model.js" />
/// <reference path="app-setup.js" />
/// <reference path="Views/questions-view.js" />
/// <reference path="Views/vote-view.js" />

var AppRouter = Backbone.Router.extend({
    routes: {

        "login": "login",
        "logout": "logout",
        "questions": "questions",
        "vote": "vote",

        // Default route
        '*actions': 'defaultAction'
    },

    defaultAction: function ()
    {
        if (WebApiApp.Session.isAuthenticated())
        {
            this.navigate("questions", { trigger: true });
        }
        else
        {
            this.navigate("vote", { trigger: true });
        }
    },

    login: function ()
    {
        if (!this.loginView)
        {
            this.loginView = new WebApiApp.LoginView();
        }

        this.loginView.render();
    },

    logout: function ()
    {
        $("#buttonLogin").html("Login");
        $("#buttonLogin").attr("href", "#login");
        WebApiApp.Session.clear();
        this.navigate("/", { trigger: true });
    },

    questions: function ()
    {
        $("#buttonLogin").html("Logout");
        $("#buttonLogin").attr("href", "#logout");
        
        if (!this.questionsView)
        {
            this.questionsView = new WebApiApp.QuestionsView();
        }

        this.questionsView.render();
    },
    vote: function ()
    {
        if (!this.voteView)
        {
            this.voteView = new WebApiApp.VoteView();
        }

        this.voteView.render();
    }
});