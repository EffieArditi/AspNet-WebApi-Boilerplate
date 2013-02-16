using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AttributeRouting.Web.Http;
using WebApi.Model;
using WebApi.API.Model;
using WebApi.Repository;

namespace WebApi.API.Controllers
{
    public class AuthenticationController : ApiController
    {
        private readonly IUserRepository m_userRepository;

        public AuthenticationController(IUserRepository userRepository)
        {
            m_userRepository = userRepository;
        }

        [POST("api/authenticate"), HttpPost]
        public UserApiModel Authenticate(CredentialsApiModel creds)
        {
            User user = m_userRepository.GetByName(creds.Name);
            if (user == null)
            {
                throw new UnauthorizedAccessException("Incorrect user name or password");
            }

            if (user.Password != creds.Password)
            {
                throw new UnauthorizedAccessException("Incorrect user name or password"); 
            }

            return user.ToApiModel();
        }
    }
}