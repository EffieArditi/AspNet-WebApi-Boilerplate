using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoRepository;
using StructureMap.Configuration.DSL;

namespace WebApi.Repository
{
    public class RepositoryIoCRegistry : Registry
    {
        public RepositoryIoCRegistry(string connString)
        {
            For(typeof (IRepository<>)).Use(typeof (MongoRepository<>)).CtorDependency<string>("connectionString").Is(connString);
            For(typeof(IRepositoryManager<>)).Use(typeof(MongoRepositoryManager<>)).CtorDependency<string>("connectionString").Is(connString);

            For<IQuestionRepository>().Use<QuestionRepository>();
            For<IUserRepository>().Use<UserRepository>();
        }
    }
}
