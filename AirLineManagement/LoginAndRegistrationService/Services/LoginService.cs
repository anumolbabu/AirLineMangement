using CoreModels.Models;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginAndRegistrationService.Services
{
    public class LoginService : ILoginService
    {

        ILoginRepository _LoginRepository;
        public LoginService(ILoginRepository LoginRepository)
        {
            _LoginRepository = LoginRepository;
        }

        public bool LogOn(User user)
        {
            return _LoginRepository.LogOn(user);
        }
    }
}
