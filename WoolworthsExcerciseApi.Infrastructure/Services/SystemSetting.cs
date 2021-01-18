using System;
using System.Collections.Generic;
using System.Text;
using WoolworthsExcercise.Core.Common.Interfaces;

namespace WoolworthsExcercise.Infrastructure.Services
{
    public class SystemSetting : ISystemSetting
    {
        public SystemSetting( string token)
        {
            Token = token;
        }
        public string Token { get; private set; }
    }
}
