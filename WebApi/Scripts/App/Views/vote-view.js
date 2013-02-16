/// <reference path="../../_references.js" />
/// <reference path="../../underscore.js" />
/// <reference path="../template-manager.js" />
/// <reference path="../app-setup.js" />
/// <reference path="../Models/question-model.js" />

// Creates ths 'App' object if doesn't exist --> equal to if(!myApplication) myApplication = {};
var WebApiApp = WebApiApp || {};

WebApiApp.VoteView = Backbone.View.extend({

    el: '#main',
    //tagName: 'div',
    template_name: "vote-template",

    initialize: function ()
    {
        _.bindAll(this, "render", "sendAnswerToServer");
        this.setElement($(this.el));

        this.model = new WebApiApp.QuestionModel();
        this.model.bind('change', this.render, this);

        this.model.fetch();
    },

    events:
    {
        "click #btnYes": "clickedYes",
        "click #btnNo": "clickedNo",
        "click #btnDontKnow": "clickedDontKnow"
    },

    render: function ()
    {
        var _this = this;
        TemplateManager.get(this.template_name, function (template)
        {
            var theTemplate = _.template(template);
            _this.$el.html(theTemplate(_this.model));
        });

        return this;
    },

    clickedYes: function ()
    {
        this.sendAnswerToServer(0);
    },

    clickedNo: function ()
    {
        this.sendAnswerToServer(1);
    },

    clickedDontKnow: function ()
    {
        this.sendAnswerToServer(2);
    },

    sendAnswerToServer: function (answer)
    {
        var questionId = $("#hiddenQuestionId").val();
        var vote = { userId: "", answer: answer };

        $.post(WebApiApp.SiteUrl + "api/questions/" + questionId + "/vote", {"userId": "", "answer": answer}, function (response)
        {})
        .success(function (response)
        {
            $("#divQuestionDetails").html("Thanks for your vote");
        })
        .error(function (error)
        {
            console.error(error);
        });
    }
});