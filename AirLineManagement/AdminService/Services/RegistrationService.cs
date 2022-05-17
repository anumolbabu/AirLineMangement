using CoreModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminService.Services
{
    public class RegistrationService : IRegistrationService
    {
        AirLineDBContext _airLineDBContext;

        public RegistrationService(AirLineDBContext airLineDBContext)
        {
            _airLineDBContext = airLineDBContext;

        }
       
        public int Register(User user)
        {
            user.Role = 2;
            user.CreatedBy = "User";
            user.CreatedDate = System.DateTime.UtcNow;
            user.IsDeleted = 0;

            _airLineDBContext.Users.Add(user);
            return _airLineDBContext.SaveChanges();


        }
    }
}
