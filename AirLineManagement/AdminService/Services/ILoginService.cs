using AdminService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminService.Services
{
    public interface ILoginService
    {
        bool LogOn(User user);
        List<User> FindAll();
    }
}
