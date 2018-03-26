using Cinema.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.DAO
{
    class MoviesDAO
    {
        private static MoviesDAO _usersDAL = null;
        private String _connectionString = @"Data Source=DESKTOP-GR5F20N\SQLEXPRESS;Initial Catalog=Cinema;Trusted_Connection=Yes;";
        SqlConnection _conn = null;

        private MoviesDAO()
        {
            try
            {
                _conn = new SqlConnection(_connectionString);
            }
            catch (SqlException e)
            {
                //de facut ceva error handling, afisat mesaj, etc..
                Console.Write(e.Message);
                _conn = null;
            }
        }

        public static MoviesDAO getInstance()
        {
            if (_usersDAL == null)
            {
                _usersDAL = new MoviesDAO();
            }
            return _usersDAL;
        }


        public Movie getMovies(String title)
        {
            Movie u = null;
            String sql = "SELECT * FROM Movie WHERE title='" + title + "'";
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand(sql, _conn);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                u = new Movie(reader["title"].ToString(), reader["director"].ToString(), reader["distribution"].ToString(), DateTime.Parse(reader["premiereDate"].ToString()), int.Parse(reader["noOfTickets"].ToString()), DateTime.Parse(reader["endDate"].ToString()));
                _conn.Close();

            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            return u;
        }

        public ArrayList getTickets(Movie movie)
        {
            Ticket ticket = null;
            ArrayList result = new ArrayList(); 
            String sql = "SELECT * FROM Ticket WHERE movie='" + movie.title + "'";
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand(sql, _conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ticket = new Ticket(movie, int.Parse(reader["row"].ToString()), int.Parse(reader["col"].ToString()), DateTime.Parse(reader["airDate"].ToString()));
                    result.Add(ticket);
                }
                _conn.Close();

            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            return result;
        }

        public ArrayList getMovies()
        {
            Movie movie = null;
            ArrayList result = new ArrayList();

            String sql = "SELECT * FROM Movie";
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand(sql, _conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    movie = new Movie(reader["title"].ToString(), reader["director"].ToString(), reader["distribution"].ToString(), DateTime.Parse(reader["premiereDate"].ToString()), int.Parse(reader["noOfTickets"].ToString()), DateTime.Parse(reader["endDate"].ToString()));
                    result.Add(movie);
                }
                _conn.Close();

            }
            catch (SqlException e)
            {
                _conn.Close();
                Console.WriteLine(e.Message);
                return null;
            }
            return result;
        }

        public void insertMovie(String title, String director, String distribution, String premiereDate, String tickets, String endDate) {
            String sql = "INSERT INTO Movie VALUES ('" + title + "' , '" + director + "' , '" + distribution + "' , '" + premiereDate + "' , '" + tickets + "' , '" + endDate+ "')";
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand(sql, _conn);
                SqlDataReader reader = cmd.ExecuteReader();
                _conn.Close();

            }
            catch (SqlException e)
            {
                _conn.Close();
            }
        }

    }
}
