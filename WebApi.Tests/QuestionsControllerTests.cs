using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Model;
using Moq;
using NUnit.Framework;
using WebApi.API;
using WebApi.API.Model;
using WebApi.Repository;

namespace WebApi.Tests
{
    [TestFixture]
    public class QuestionsControllerTests
    {
        [Test]
        public void AddQuestion()
        {
            QuestionApiModel questionApiModelToAdd = new QuestionApiModel
            {
                QuestionText = "Test Question",
                IsOpenToVotes = false
            }; 

            Question question = new Question
            {
                QuestionText = "Test Question",
                IsOpenToVotes = false
            };

            var questionRepoMock = new Mock<IQuestionRepository>();
            questionRepoMock.Setup(repo => repo.Add(It.IsAny<Question>())).Returns(question);

            QuestionsController controller = new QuestionsController(questionRepoMock.Object);
            var result = controller.AddQuestion(questionApiModelToAdd);

            Assert.AreEqual(question.QuestionText, result.QuestionText);
            Assert.IsInstanceOf<QuestionApiModel>(result);
        }
    }
}
