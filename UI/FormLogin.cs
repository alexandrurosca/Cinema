using Cinema.BLL;
using Cinema.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinema.UI
{
    public partial class FormLogin : Form
    {   private UsersService usersService;

        public FormLogin()
        {
            InitializeComponent();
            usersService = new UsersService();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            String username = usernameBox.Text;
            String password = passwordBox.Text;
            User user = null;
            try
            {
                user = usersService.login(username, password);
                //MessageBox.Show(user.name);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            
            if (user == null)
            {
                MessageBox.Show("Can't find user in database!");
            }
            else if (user.GetType() == typeof(Admin))
            {
                FormAdmin formAdmin = new FormAdmin();
                formAdmin.Show();
            }
            else {
                FormEmployee formEmployee = new FormEmployee();
                formEmployee.Show();
            }
        }
    }
}
