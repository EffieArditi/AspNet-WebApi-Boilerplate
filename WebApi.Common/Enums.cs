using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Common
{
    public enum VoteAnswer
    {
        Yes = 0,
        No = 1,
        DontKnow = 2
    }

    public enum UserRole
    {
        Admin,
        Guest
    }
}
