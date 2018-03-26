using Cinema.DAO;
using Cinema.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinema.BLL
{
    public class UsersService
    {
        private UserDAO userDAO = UserDAO.getInstance();

        public User login(String username, String password) {
            User user = null;
            try
            {
                user = userDAO.getUser(username, MD5Convert.getMd5Hash(password));
                //MessageBox.Show("In DAO" + user.name);
            }
            catch ( Exception exception)
            {   
                throw exception;
            }
            return user;
        }

        public void insertEmployee(String username, String password, String name)
        {
            try
            {
                userDAO.insertEmployee(username, MD5Convert.getMd5Hash(password), name);
            }
            catch (Exception exception) {
                throw exception;
            }
        }
    }

   
}
