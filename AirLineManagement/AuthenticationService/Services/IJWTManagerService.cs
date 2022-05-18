using AdminService.ViewModels;
using CoreModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationService.Services
{
    public interface IJWTManagerService
    {
        Tokens Authenticate(User user);
    }
}
