using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Model
{
    public class Employee : User
    {
        public Employee(String username, String password, String name, String role) : base(username, password, name, role) { }
    }
}
