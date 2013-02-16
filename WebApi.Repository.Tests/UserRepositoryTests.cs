using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Model;
using MongoDB.Bson;
using NUnit.Framework;
using StructureMap;
using WebApi.Testing.Common;

namespace WebApi.Repository.Tests
{
    [TestFixture]
    public class UserRepositoryTests : BaseClassDBOrientedTests
    {
        [Test]
        public void Add()
        {
            User user = new User
            {
                Id = ObjectId.GenerateNewId().ToString(),
                Name = "moses",
                Password = "admin",
                PasswordSalt = "mySalt",
                AccessToken = "myAccessToken"
            };
            IUserRepository repo = ObjectFactory.GetInstance<IUserRepository>();
            User result = repo.Add(user);
            Assert.AreEqual(result.Id, user.Id);
        }

        [Test]
        public void GetByName()
        {
            User user = new User
            {
                Name = "temp",
                Password = "temp"
            };

            IUserRepository repo = ObjectFactory.GetInstance<IUserRepository>();
            User addedUser = repo.Add(user);
            User result = repo.GetByName(user.Name);

            Assert.AreEqual(result.Id, addedUser.Id);
        }
    }
}
