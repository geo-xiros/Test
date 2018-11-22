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
    
}
