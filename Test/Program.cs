using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Database db = new Database();

            Console.WriteLine(db.GetUser("admin").HasAccessTo(Responsibilities.AddUser));

            Console.ReadKey();
        }
    }
    class Database
    {
        private Dictionary<string, User> _users;
        public Database()
        {
            _users = new Dictionary<string, User>();

            _users.Add("admin", new AdminUser());
            _users.Add("george", new SimpleUser(1, "george", "1234", new ViewRole()));
            _users.Add("nick", new SimpleUser(2, "nick", "1234", new ViewEditRole()));
            _users.Add("john", new SimpleUser(3, "john", "1234", new ViewEditDeleteRole()));

            foreach (var un in _users)
            {
                Console.WriteLine(un.Value.Username);
                Console.WriteLine(Responsibilities.ViewData + " " + un.Value.HasAccessTo(Responsibilities.ViewData));
                Console.WriteLine(Responsibilities.EditData + " " + un.Value.HasAccessTo(Responsibilities.EditData));
                Console.WriteLine(Responsibilities.DeleteData + " " + un.Value.HasAccessTo(Responsibilities.DeleteData));
            }

        }

        public User GetUser(string username)
        {
            return _users[username];
        }

        public bool Login(string username, string password)
        {
            return (_users.ContainsKey(username) &&
                    _users[username].IsPasswordCorrect(password));
        }

    }
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
    class ViewRole : Role
    {
        public ViewRole() : base(new Responsibilities[] { Responsibilities.ViewData }) { }
    }
    class ViewEditRole : ViewRole
    {
        public ViewEditRole()
            : base()
        {
            _responsibilities = _responsibilities.Concat(new Responsibilities[] { Responsibilities.EditData }).ToArray();
        }
    }
    class ViewEditDeleteRole : ViewEditRole
    {
        public ViewEditDeleteRole()
            : base()
        {
            _responsibilities = _responsibilities.Concat(new Responsibilities[] { Responsibilities.DeleteData }).ToArray();
        }

    }
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
    class SimpleUser : User
    {
        public SimpleUser(int nameId, string name, string password, Role role) : base(nameId, name, password, role) { }
    }
    class AdminUser : SimpleUser
    {
        public AdminUser() : base(0, "admin", "admin", new AdminRole()) { }
    }
}
