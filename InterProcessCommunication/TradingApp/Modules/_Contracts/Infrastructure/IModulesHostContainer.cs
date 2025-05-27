﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Infrastructure
{
    public interface IModulesHostContainer
    {
        void RegisterModule(string moduleName);
        IEnumerable<string> GetModules();
    }
}
