using Softtek.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Softtek.WebApi.Configuration
{
    public class TokenParameters : ITokenParameters
    {
        public string UserName { get; set; }
        public string PasswordAuth { get; set; }
        public string Id { get; set; }
    }
}
