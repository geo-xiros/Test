using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test
{
    class ViewEditRole : ViewRole
    {
        public ViewEditRole()
            : base()
        {
            _responsibilities = _responsibilities.Concat(new Responsibilities[] { Responsibilities.EditData }).ToArray();
        }
    }
}
