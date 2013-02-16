using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using MongoRepository;

namespace WebApi.Model
{
    [BsonIgnoreExtraElements]
    public class Question : Entity
    {
        public string QuestionText { get; set; }
        public bool IsOpenToVotes { get; set; }
        [BsonIgnoreIfNull]
        public List<Vote> Votes { get; set; }
    }
}
