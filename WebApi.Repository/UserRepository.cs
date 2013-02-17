using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Model;
using MongoRepository;

namespace WebApi.Repository
{
    public interface IUserRepository
    {
        User Add(User user);
        User GetById(string id);
        User GetByName(string name);
    }

    public class UserRepository : IUserRepository
    {
        private readonly IRepository<User> m_userRepository;

        public UserRepository(IRepository<User> userRepository)
        {
            m_userRepository = userRepository;
        }

        public User Add(User user)
        {
            return m_userRepository.Add(user);
        }

        public User GetById(string id)
        {
            return m_userRepository.GetById(id);
        }

        public User GetByName(string name)
        {
            return m_userRepository.GetSingle(user => user.Name == name);
        }
    }
}
