﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.Abstraction
{
    public interface ITokenParameters
    {
        string UserName { get; set; }
        string PasswordAuth { get; set; }
        string Id { get; set; }
    }
}
