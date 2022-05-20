using CoreModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagerService.ViewModels
{
    public class RegisterResponse
    {
        public User User { get; internal set; }
        public Tokens Tokens { get; internal set; }
    }
}
