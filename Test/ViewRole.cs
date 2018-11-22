using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test
{
    class ViewRole : Role
    {
        public ViewRole() : base(new Responsibilities[] { Responsibilities.ViewData }) { }
    }
}
