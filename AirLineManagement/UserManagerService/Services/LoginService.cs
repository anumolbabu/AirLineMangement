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
        private readonly AirlineDBContext _airLineDBContext;

        public LoginService(AirlineDBContext airLineDBContext)
        {
            _airLineDBContext = airLineDBContext;
        }
        public List<string> LogOn(LoginUserData loggedinuser)
        {
            IEnumerable<User> result = _airLineDBContext.Users.Where(m => m.Email == loggedinuser.Email && m.Password == loggedinuser.Password && m.IsActive==1);
            List<string> userdata = new List<string>();
            if (result.ToList().Count != 0)
            {
                userdata.Add(result.FirstOrDefault().UserId.ToString());
                userdata.Add(result.FirstOrDefault().Email.ToString());
                userdata.Add(result.FirstOrDefault().Name.ToString());
                userdata.Add(result.FirstOrDefault().Role.ToString());


                //userdata.Add(result.FirstOrDefault().Gender.ToString());
                //userdata.Add(result.FirstOrDefault().Age.ToString());
                //userdata.Add(result.FirstOrDefault().ContactNumber.ToString());

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
