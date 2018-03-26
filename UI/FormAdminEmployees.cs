using Cinema.BLL;
using Cinema.DAO;
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
    public partial class FormAdminEmployees : Form
    {
        UsersService userService;
        public FormAdminEmployees()
        {
            InitializeComponent();
            userService = new UsersService();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            String username = textBoxUsername.Text;
            String password = textBox2Password.Text;
            String name = textBoxName.Text;

            try
            {
                userService.insertEmployee(username, password, name);
            }
            catch (Exception exception) {
                MessageBox.Show(exception.Message);
            }

            MessageBox.Show("Employee inserted into database!");
            textBoxUsername.Text = "";
            textBox2Password.Text = "";
            textBoxName.Text = "";

        }
    }
}
