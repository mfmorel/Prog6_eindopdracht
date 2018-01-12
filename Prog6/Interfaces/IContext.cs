using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Prog6.Interfaces
{
    [InheritedExport]
    public interface IContext
    {
        Prog6Entities GetContext();
    }
}
