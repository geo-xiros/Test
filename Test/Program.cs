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
            Console.WriteLine(db.Login("george", "1234"));
            Console.WriteLine(db.Login("admin", "admin"));
            Console.WriteLine(db.Login("nick", "1234"));
            Console.ReadKey();
        }
    }
    class Database
    {
        private Dictionary<string, User> _users;
        private Dictionary<string, Role> _roles;
        public Database()
        {
            _users = new Dictionary<string, User>();
            _roles = new Dictionary<string, Role>();
            _roles.Add("user", new Role("user", true, true, false, false));
            _roles.Add("admin", new Role("admin", true, true, false, false));

            _users.Add("admin", new User(1, "admin", "admin", _roles["admin"]));
            _users.Add("george", new User(2, "george", "1234", _roles["user"]));
        }
        public bool Login(string username, string password)
        {
            return (_users.ContainsKey(username) &&
                    _users[username].IsPasswordCorrect(password));
        }

    }
    class Role
    {
        public readonly string Name;
        public readonly bool EditAccess;
        public readonly bool AddAccess;
        public readonly bool DeleteAccess;
        public readonly bool ViewAccess;
        public Role(string name, bool viewAccess, bool addAccess, bool editAccess, bool deleteAccess)
        {
            Name = name;
            EditAccess = editAccess;
            DeleteAccess = deleteAccess;
            ViewAccess = viewAccess;
            AddAccess = addAccess;
        }

    }
    class User
    {
        private readonly int _nameId;
        public readonly string Name;
        private readonly string _password;
        private readonly Role _role;
        public User(int nameId, string name, string password, Role role)
        {
            _nameId = nameId;
            Name = name;
            _password = password;
            _role = role;
        }
        public bool IsPasswordCorrect(string password)
        {
            return _password == password;
        }
    }
}
