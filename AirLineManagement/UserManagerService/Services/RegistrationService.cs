using CoreModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagerService.Interfaces;
using UserManagerService.ViewModels;

namespace UserManagerService.Services
{
    public class RegistrationService : IRegistrationService
    {
        private readonly AirLineDBContext _airLineDBContext;

        public RegistrationService(AirLineDBContext airLineDBContext)
        {
            _airLineDBContext = airLineDBContext;

        }

        public User Register(LoginUserData loggedinuser)
        {
            User user = new User();
            user.UserName = loggedinuser.UserName;
            user.Email = loggedinuser.Email;
            user.Password = loggedinuser.Password;
            user.IsDeleted = 0;
            user.Role = 2;
            user.CreatedBy = loggedinuser.UserName;
            user.CreatedDate = System.DateTime.UtcNow;
            user.UpdatedBy = loggedinuser.UserName;
            user.UpdatedDate = System.DateTime.UtcNow;
           
            var UserExist= _airLineDBContext.Users.Any(x => x.UserName == user.UserName);
              
            if(!UserExist)
            {
                _airLineDBContext.Users.Add(user);
                _airLineDBContext.SaveChanges();
                User currentuser = _airLineDBContext.Users.Where(x => x.UserName == user.UserName && x.Password == user.Password).FirstOrDefault();
                return currentuser;
            }
            else
            {
                throw new Exception("UserName not available");
            }
               
            
        }
    }
}
