using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Common;

namespace WebApi.API.PostRequestParams
{
    public class VotePostParam
    {
        public string QuestionId { get; set; }
        public string UserId { get; set; }
        public VoteAnswer Answer { get; set; }
    }
}