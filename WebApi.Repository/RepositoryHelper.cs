using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Model;
using StructureMap;

namespace WebApi.Repository
{
    public class RepositoryHelper
    {
        public static void InitUserData()
        {
            IUserRepository userRepository = ObjectFactory.GetInstance<IUserRepository>();

            User admin = userRepository.GetByName("effie");
            if (admin == null)
            {
                admin = new User
                {
                    Name = "effie",
                    Password = "admin",
                    PasswordSalt = "mySalt",
                    AccessToken = "myAccessToken"
                };

                userRepository.Add(admin);
            }
        }
    }
}
