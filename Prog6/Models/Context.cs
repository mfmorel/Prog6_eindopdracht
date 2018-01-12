using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using Domain;
using Prog6.Interfaces;

namespace Prog6.Models
{
    [InheritedExport]
    public class Context : IContext
    {
        private Prog6Entities _context;

        public Context()
        {
            _context = new Prog6Entities();
        }

        public Context(Prog6Entities context)
        {
            _context = context;
        }

        public Prog6Entities GetContext()
        {
            return _context;
        }
    }
}