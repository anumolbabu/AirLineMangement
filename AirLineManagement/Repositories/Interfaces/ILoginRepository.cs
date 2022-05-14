using CoreModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Interfaces
{
    public interface ILoginRepository
    {
        bool LogOn(User user);
    }
}
