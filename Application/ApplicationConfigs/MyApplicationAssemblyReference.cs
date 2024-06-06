using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application.ConfigDependencyInjections
{
    internal class MyApplicationAssemblyReference
    {
        internal static readonly Assembly assembly = typeof(MyApplicationAssemblyReference).Assembly;
    }
}
