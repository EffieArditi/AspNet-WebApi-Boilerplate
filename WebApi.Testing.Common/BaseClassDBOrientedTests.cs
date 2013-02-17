using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Model;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using NUnit.Framework;

namespace WebApi.Testing.Common
{
    [TestFixture]
    public class BaseClassDBOrientedTests
    {
        [TestFixtureSetUp]
        public void Bootstrap()
        {
            StructureMapBootstrapper.Bootstrap();
            CleanDbBeforeTests();
        }

        private static void CleanDbBeforeTests()
        {
            // Validate that we are not runing on the production DB
            Assert.AreNotEqual(ConfigurationHelper.GetCurrentEnvDbConnString(), "YOU WERE JUST TRYING TO DELETE THE PRODUCTION DB!!");

            // Connecting the MongoDb and deleting its entire collections state
            var cnn = new MongoUrl(ConfigurationHelper.GetCurrentEnvDbConnString());

            var server = MongoServer.Create(cnn.ToServerSettings());
            MongoDatabase db = server.GetDatabase(cnn.DatabaseName);

            // deleting users
            MongoCollection userCollection = db.GetCollection(typeof(User).Name);
            var query = Query.NE("Name", "effie");
            userCollection.Remove(query);

            // deleting questions
            MongoCollection questionsCollection = db.GetCollection(typeof(Question).Name);
            questionsCollection.RemoveAll();
        }
    }
}
