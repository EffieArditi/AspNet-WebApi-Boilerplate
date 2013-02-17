using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AttributeRouting.Web.Http;
using WebApi.Model;
using WebApi.API.FilterAttributes;
using WebApi.API.Model;
using WebApi.Common;
using WebApi.Repository;

namespace WebApi.API
{
    public class QuestionsController : ApiController
    {
        private readonly IQuestionRepository m_questionRepository;

        public QuestionsController(IQuestionRepository questionRepository)
        {
            m_questionRepository = questionRepository;
        }

        [GET("api/questions/"), HttpGet]
        [ApiAuthentication]
        [ApiAuthorization(UserRole.Admin)]
        public IEnumerable<QuestionApiModel> GetAllQuestions()
        {
            return m_questionRepository.GetAll().Select(q => q.ToApiModel());
        }

        [POST("api/questions/"), HttpPost]
        [ApiAuthentication]
        [ApiAuthorization(UserRole.Admin)]
        public QuestionApiModel AddQuestion(QuestionApiModel questionApiModel)
        {
            Question question = new Question()
            {
                Id = questionApiModel.Id,
                QuestionText = questionApiModel.QuestionText,
                IsOpenToVotes = questionApiModel.IsOpenToVotes
            };

            return m_questionRepository.Add(question).ToApiModel();
        }

        [PUT("api/questions/"), HttpPut]
        [ApiAuthentication]
        [ApiAuthorization(UserRole.Admin)]
        public void UpdateQuestion(QuestionApiModel questionApiModel)
        {
            m_questionRepository.UpdateIsOpenToVotes(questionApiModel.Id, questionApiModel.IsOpenToVotes);
        }

        [GET("api/questions/open"), HttpGet]
        public QuestionApiModel GetOpenQuestion()
        {
            Question qustion = m_questionRepository.GetAll().FirstOrDefault(q => q.IsOpenToVotes);
            return qustion != null ? qustion.ToApiModel() : null;
        }

        [POST("api/questions/{id}/vote"), HttpPost]
        public void VoteForQuestion(string id, Vote vote)
        {
            Question question = m_questionRepository.GetById(id);
            if (question == null)
            {
                throw new ApplicationException("Question Id wasn't found");
            }

           m_questionRepository.AddVote(id, vote);
        }
        
    }
}