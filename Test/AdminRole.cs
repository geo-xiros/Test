using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test
{
    class AdminRole : ViewEditDeleteRole
    {
        public AdminRole()
            : base()
        {
            _responsibilities = _responsibilities.Concat(new Responsibilities[]
            { Responsibilities.AddUser,
              Responsibilities.ViewUser,
              Responsibilities.EditUser,
              Responsibilities.DeleteUser,
              Responsibilities.AddRoleToUser
            }).ToArray();
        }
    }
}
