﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_NetFramework.Services.IServices
{
    public interface IUserService
    {
        Task<string> TestStringAsync();
    }
}