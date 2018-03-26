using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Model
{
    public class Admin : User
    {
        public Admin(String username, String password, String name, String role) : base(username, password, name, role) { }
    }
}
