using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test
{
    public enum Responsibilities { AddUser, ViewUser, EditUser, DeleteUser, AddRoleToUser, ViewData, EditData, DeleteData };

    class Role
    {
        protected Responsibilities[] _responsibilities;
        protected Role(Responsibilities[] responsibilities)
        {
            _responsibilities = responsibilities;
        }

        public bool this[Responsibilities responsibility]
        {
            get
            {
                return _responsibilities.Contains(responsibility);
            }
        }
    }
}
