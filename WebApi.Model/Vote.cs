using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoRepository;
using WebApi.Common;

namespace WebApi.Model
{
    public class Vote
    {
        public string UserId { get; set; }
        public VoteAnswer Answer { get; set; }
    }
}
