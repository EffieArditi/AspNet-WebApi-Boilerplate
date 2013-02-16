/// <reference path="../../_references.js" />
/// <reference path="../../underscore.js" />
/// <reference path="../template-manager.js" />
/// <reference path="../app-setup.js" />
/// <reference path="../Collections/questions-collection.js" />
/// <reference path="../Models/question-model.js" />

// Creates ths 'App' object if doesn't exist --> equal to if(!myApplication) myApplication = {};
var WebApiApp = WebApiApp || {};

WebApiApp.QuestionsView = Backbone.View.extend({

    el: '#main',
    template_name: "questions-template",

    initialize: function ()
    {
        _.bindAll(this, "render", "addOne", "addAll", "addQuestion");
        this.setElement($(this.el));

        this.collection = new WebApiApp.QuestionCollection();
        this.listenTo(this.collection, 'add', this.addOne);
        this.listenTo(this.collection, 'sync', this.addAll);

        this.collection.fetch();
    },

    events:
    {
        "click #btnAddQuestion": "addQuestion",
        "click input[type=checkbox]": "checkboxClicked"
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

    addAll: function ()
    {
        $("#divQuestions").html("");
        _this = this;
        $.each(this.collection.models, function (index, question)
        {
            _this.addOne(question);
        });
    },

    addOne: function (question)
    {
        TemplateManager.get("single-question-template", function (template)
        {
            var theTemplate = _.template(template);
            $("#divQuestions").append(theTemplate(question));
        });
    },

    addQuestion: function ()
    {
        _this = this;
        var newQuestion = new WebApiApp.QuestionModel({ "questionText": $("#txtNewQuestion").val(), "isOpenToVotes": true });
        
        this.collection.sync("create", newQuestion, {
            success: function (response)
            {
                _this.collection.add(new WebApiApp.QuestionModel(response));
            }
        });
    },

    checkboxClicked: function (e)
    {
        var questionId = $(e.currentTarget).attr('data-questionId');
        var isChecked = $(e.currentTarget).is(":checked");
        
        var questionToUpdate = _.find(this.collection.models, function (questionModel) { return questionModel.get("id") == questionId; });
        questionToUpdate.set("isOpenToVotes", isChecked);
        this.collection.sync("update", questionToUpdate);
    }
});