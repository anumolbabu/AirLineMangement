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
        private readonly AirlineDBContext _airLineDBContext;

        public RegistrationService(AirlineDBContext airLineDBContext)
        {
            _airLineDBContext = airLineDBContext;

        }

        public User Register(RegisterUserData registerUser)
        {
            User user = new User();
            user.Email = registerUser.Email;
            user.Password = registerUser.Password;
            user.Name = registerUser.Name;
            user.Gender = registerUser.Gender;
            user.Age = registerUser.Age;
            user.ContactNumber = registerUser.ContactNumber;

            user.Role = 2;
            user.IsActive = 1;
            user.CreatedBy = registerUser.Email;
            user.CreatedDate = System.DateTime.UtcNow;
            user.UpdatedBy = registerUser.Email;
            user.UpdatedDate = System.DateTime.UtcNow;
           
            var UserExist= _airLineDBContext.Users.Any(x => x.Email == user.Email);
              
            if(!UserExist)
            {
                _airLineDBContext.Users.Add(user);
                _airLineDBContext.SaveChanges();
                User currentuser = _airLineDBContext.Users.Where(x => x.Email == user.Email && x.Password == user.Password).FirstOrDefault();
                return currentuser;
            }
            else
            {
                throw new Exception("UserName not available");
            }
               
            
        }
    }
}
