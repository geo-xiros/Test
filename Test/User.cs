using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test
{
    class User
    {
        private readonly Role _role;
        private readonly int _nameId;
        public readonly string Username;
        private readonly string _password;

        protected User(int nameId, string name, string password, Role role)
        {
            _nameId = nameId;
            Username = name;
            _password = password;
            _role = role;
        }
        public bool IsPasswordCorrect(string password) { return _password == password; }
        public bool HasAccessTo(Responsibilities responsibility) { return _role[responsibility]; }

    }
}
