using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Model;
using MongoDB.Bson;
using NUnit.Framework;
using StructureMap;
using WebApi.Common;
using WebApi.Testing.Common;

namespace WebApi.Repository.Tests
{
    [TestFixture]
    public class QuestionRepositoryTests : BaseClassDBOrientedTests
    {
        [Test]
        public void Add()
        {
            Question q = new Question
            {
                Id = ObjectId.GenerateNewId().ToString(),
                QuestionText = "Who's on first ?"
            };

            IQuestionRepository repo = ObjectFactory.GetInstance<IQuestionRepository>();
            Question result = repo.Add(q);

            Assert.AreEqual(q.Id, result.Id);
        }

        [Test]
        public void Update()
        {
            Question q = new Question
            {
                QuestionText = "Who's on first ?",
                IsOpenToVotes = true
            };

            IQuestionRepository repo = ObjectFactory.GetInstance<IQuestionRepository>();
            Question questionFromDb = repo.Add(q);

            questionFromDb.QuestionText = "Who's on second ?";
            repo.UpdateIsOpenToVotes(questionFromDb.Id, false);

            Question result = repo.GetById(questionFromDb.Id);

            Assert.AreEqual(questionFromDb.Id, result.Id);
            Assert.AreEqual(false, result.IsOpenToVotes);
        }

        [Test]
        public void AddVote()
        {
            Question q = new Question
            {
                QuestionText = "What's the question?",
                //Votes = new List<Vote>()
                
            };

            IQuestionRepository repo = ObjectFactory.GetInstance<IQuestionRepository>();
            Question newlyAddedQuestion = repo.Add(q);

            Vote vote = new Vote
            {
                Answer = VoteAnswer.Yes
            };

            repo.AddVote(newlyAddedQuestion.Id, vote);

            Question result = repo.GetById(newlyAddedQuestion.Id);
            Assert.AreEqual(1, result.Votes.Count);
            Assert.AreEqual(VoteAnswer.Yes, result.Votes[0].Answer);
        }
    }
}
