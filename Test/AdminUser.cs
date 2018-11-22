using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test
{
    class AdminUser : SimpleUser
    {
        public AdminUser() : base(0, "admin", "admin", new AdminRole()) { }
    }
}
