using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test
{
    class SimpleUser : User
    {
        public SimpleUser(int nameId, string name, string password, Role role) : base(nameId, name, password, role) { }
    }
}
