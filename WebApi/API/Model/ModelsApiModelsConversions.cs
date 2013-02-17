using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Model;

namespace WebApi.API.Model
{
    public static class ModelsApiModelsConversions
    {
        #region Question Model
        public static QuestionApiModel ToApiModel(this Question question)
        {
            QuestionApiModel apiModel = new QuestionApiModel()
            {
                Id = question.Id,
                QuestionText = question.QuestionText,
                IsOpenToVotes = question.IsOpenToVotes,
                Votes = question.Votes
            };

            return apiModel;
        }

        #endregion

        #region User Model
        public static UserApiModel ToApiModel(this User user)
        {
            UserApiModel apiModel = new UserApiModel()
            {
                Id = user.Id,
                Name = user.Name,
                AccessToken = user.AccessToken
            };

            return apiModel;
        } 
        #endregion
    }
}