﻿using AdminService.Models;
using AdminService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminService.Services
{
    public interface IJWTManagerRepository
    {
        Tokens Authenticate(User user);
    }
}
