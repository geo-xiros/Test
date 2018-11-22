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
        public bool Login(string username, string password)
        {
            return (_users.ContainsKey(username) &&
                    _users[username].IsPasswordCorrect(password));
        }

    }
    public enum Responsibilities { ViewData, EditData, DeleteData };
    class Role
    {
        private Responsibilities[] _responsibilities;
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
    class ViewEditRole : Role
    {
        public ViewEditRole() : base(new Responsibilities[] { Responsibilities.ViewData, Responsibilities.EditData }) { }
    }
    class ViewEditDeleteRole : Role
    {
        public ViewEditDeleteRole() : base(new Responsibilities[] { Responsibilities.ViewData, Responsibilities.EditData, Responsibilities.DeleteData }) { }
    }

    class User
    {
        private readonly int _nameId;
        public readonly string Username;
        private readonly string _password;

        protected User(int nameId, string name, string password)
        {
            _nameId = nameId;
            Username = name;
            _password = password;
        }
        public bool IsPasswordCorrect(string password) { return _password == password; }
        public virtual bool HasAccessTo(Responsibilities responsibility) { return true; }

    }
    class SimpleUser : User
    {
        private readonly Role _role;
        public SimpleUser(int nameId, string name, string password, Role role)
            : base(nameId, name, password)
        {
            _role = role;
        }
        public override bool HasAccessTo(Responsibilities responsibility)
        {
            return _role[responsibility];
        }
    }
    class AdminUser : User
    {
        public AdminUser() : base(0, "admin", "admin") { }
    }
}
