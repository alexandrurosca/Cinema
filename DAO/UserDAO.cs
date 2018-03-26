using Cinema.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.DAO
{
    class UserDAO
    {
        private static UserDAO _usersDAL = null;
        private String _connectionString = @"Data Source=DESKTOP-GR5F20N\SQLEXPRESS;Initial Catalog=Cinema;Trusted_Connection=Yes;";
        SqlConnection _conn = null;

        private UserDAO()
        {
            try
            {
                _conn = new SqlConnection(_connectionString);
            }
            catch (SqlException e)
            {
                //de facut ceva error handling, afisat mesaj, etc..
                Console.Write("DIn UserDAO" + e.Message);
                _conn = null;
            }
        }

        public static UserDAO getInstance()
        {
            if (_usersDAL == null)
            {
                _usersDAL = new UserDAO();
            }
            return _usersDAL;
        }


        public User getUser(String username, String password)
        {
            User user = null;

            String sql = "SELECT * FROM Users2 WHERE username='" + username + "' AND parola='" + password + "'";
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand(sql, _conn);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
               
                
                if (reader["rol"].ToString().Equals("administrator"))
                {
                    user = new Admin(reader["username"].ToString(), reader["parola"].ToString(), reader["nume"].ToString(), reader["rol"].ToString());
                }
                else if(reader["rol"].ToString().Equals("employee"))
                {
                    user = new Employee(reader["username"].ToString(), reader["parola"].ToString(), reader["nume"].ToString(), reader["rol"].ToString());
                }
                
                _conn.Close();

            }
            catch (SqlException e)
            {
                _conn.Close();
                Console.WriteLine(e.Message);            
                return null;
            }
            return user;
        }

        public void insertEmployee(String username, String password, String name)
        {
            String sql = "INSERT INTO Users2 VALUES ('" + username + "' , '" + password + "' , '" + name + "' , 'employee')" ;
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand(sql, _conn);
                SqlDataReader reader = cmd.ExecuteReader();
                //reader.Read();

                _conn.Close();

            }
            catch (SqlException e)
            {
                _conn.Close();
                Console.WriteLine(e.Message);
            }
        }
    }
}
