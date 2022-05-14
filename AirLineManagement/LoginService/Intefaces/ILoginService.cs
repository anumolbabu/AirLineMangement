using CoreModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterAndLoginService.Intefaces
{
    public interface ILoginService
    {
        bool LogOn(User user);
        List<User> FindAll();
    }
}
