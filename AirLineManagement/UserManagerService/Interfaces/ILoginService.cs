using CoreModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagerService.ViewModels;

namespace UserManagerService.Interfaces
{
    public interface ILoginService
    {
        List<string> LogOn(LoginUserData user);
        List<User> FindAll();
    }
}
