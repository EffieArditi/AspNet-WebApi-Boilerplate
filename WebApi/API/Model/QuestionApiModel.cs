using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Model;

namespace WebApi.API.Model
{
    public class QuestionApiModel
    {
        public string Id { get; set; }
        public string QuestionText { get; set; }
        public bool IsOpenToVotes { get; set; }
        public List<Vote> Votes { get; set; }
    }
}