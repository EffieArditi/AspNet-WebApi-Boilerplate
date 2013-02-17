using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Model;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoRepository;

namespace WebApi.Repository
{
    public interface IQuestionRepository
    {
        Question Add(Question surveyQuestion);
        void UpdateIsOpenToVotes(string questionId, bool isOpenToVotes);
        IEnumerable<Question> GetAll();
        Question GetById(string id);
        void AddVote(string questionId, Vote vote);

    }

    public class QuestionRepository : IQuestionRepository
    {
        private readonly IRepository<Question> m_repository; 
        
        public QuestionRepository(IRepository<Question> repository)
        {
            m_repository = repository;
        }

        #region IQuestionRepository Members

        public Question Add(Question surveyQuestion)
        {
            return m_repository.Add(surveyQuestion);
        }

        public void UpdateIsOpenToVotes(string questionId, bool isOpenToVotes)
        {
            var query = Query.EQ("_id", new ObjectId(questionId));
            var update = Update.Set("IsOpenToVotes", isOpenToVotes);
            m_repository.Collection.Update(query, update, UpdateFlags.None, WriteConcern.Acknowledged);

        }

        public void AddVote(string questionId, Vote vote)
        {
            var query = Query.EQ("_id", new ObjectId(questionId));
            var update = Update.PushWrapped("Votes", vote);
            m_repository.Collection.Update(query, update, UpdateFlags.None, WriteConcern.Acknowledged);
        }

        public Question GetById(string id)
        {
            return m_repository.GetById(id);
        }

        public IEnumerable<Question> GetAll()
        {
            return m_repository.All();
        }

        #endregion
    }
}
