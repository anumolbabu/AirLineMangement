using CoreModels.Models;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly AirLineDBContext _airLineDBContext;

        public LoginRepository(AirLineDBContext airLineDBContext)
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
    }
}
