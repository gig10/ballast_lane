﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDatabase.Core.Services
{
    public interface ITokenService
    {
        string IssueTokenForUser();
    }
}