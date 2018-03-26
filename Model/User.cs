using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Model
{
    public class User
    {
        private String username { get; set; }
        private String password { get; set; }
        public String name { get; set; }

        public String role { get; set; }

        public User(String username, String password, String name, String role) {
            this.username = username;
            this.password = password;
            this.name = name;
            this.role = role;
        }

    }
}
