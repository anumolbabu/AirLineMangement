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
        public List<string> LogOn(LoginUserData loggedinuser)
        {
            IEnumerable<User> result = _airLineDBContext.Users.Where(m => m.UserName == loggedinuser.UserName && m.Password == loggedinuser.Password && m.IsDeleted==0);
            List<string> userdata = new List<string>();
            if (result.ToList().Count != 0)
            {
                userdata.Add(result.FirstOrDefault().UserId.ToString());
                userdata.Add(result.FirstOrDefault().UserName.ToString());
                userdata.Add(result.FirstOrDefault().Role.ToString());

            }
            return userdata;
        }

        List<User> ILoginService.FindAll()
        {
            return _airLineDBContext.Users.ToList();
            //return new List<User>
        }
    }
}
