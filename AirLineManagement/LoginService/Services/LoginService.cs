using CoreModels.Models;
using RegisterAndLoginService.Intefaces;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterAndLoginService.Services
{
    public class LoginService : ILoginService
    {
        ILoginRepository _LoginRepository;
        public LoginService(ILoginRepository LoginRepository)
        {
            _LoginRepository = LoginRepository;
        }
        public List<User> FindAll()
        {
            throw new NotImplementedException();
        }

        public bool LogOn(User user)
        {
            return _LoginRepository.LogOn(user);
        }
    }
}
