using CoreModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagerService.Interfaces;
using UserManagerService.ViewModels;

namespace UserManagerService.Services
{
    public class LoginService: ILoginService
    {
        private readonly AirLineDBContext _airLineDBContext;

        public LoginService(AirLineDBContext airLineDBContext)
        {
            _airLineDBContext = airLineDBContext;
        }
        public bool LogOn(LoginViewModel loggedinuser)
        {
            if (_airLineDBContext.Users.Any(x => x.UserName == loggedinuser.UserName && x.Password == loggedinuser.Password))
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
