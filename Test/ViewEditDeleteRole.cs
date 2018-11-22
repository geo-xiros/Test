using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test
{
    class ViewEditDeleteRole : ViewEditRole
    {
        public ViewEditDeleteRole()
            : base()
        {
            _responsibilities = _responsibilities.Concat(new Responsibilities[] { Responsibilities.DeleteData }).ToArray();
        }

    }
}
