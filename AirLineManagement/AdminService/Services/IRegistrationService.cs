﻿using CoreModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminService.Services
{
    public interface IRegistrationService
    {
        int Register(User user);
    }
}
