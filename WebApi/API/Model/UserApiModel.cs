using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.API.Model
{
    public class UserApiModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string  AccessToken { get; set; }
    }
}