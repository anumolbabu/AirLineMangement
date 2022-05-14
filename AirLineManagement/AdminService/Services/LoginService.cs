using CoreModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminService.Services
{
    public class LoginService : ILoginService
    {
        AirLineDBContext _airLineDBContext;

        public LoginService(AirLineDBContext airLineDBContext)
        {
            _airLineDBContext = airLineDBContext;
        }
        public bool LogOn(User user)
        {
            if (_airLineDBContext.Users.Any(x => x.UserName == user.UserName && x.Password == user.Password))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        List<User> ILoginService.FindAll()
        {
            return _airLineDBContext.Users.ToList();
            //return new List<User>
        }
    }
}
