using Cinema.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        //Movies

        public Movie getMovie(String title)
        {
            Movie u = null;
            String sql = "SELECT * FROM Movie WHERE title='" + title + "'";
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand(sql, _conn);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                u = new Movie(reader["title"].ToString(), reader["director"].ToString(), reader["distribution"].ToString(), DateTime.Parse(reader["premiereDate"].ToString()), int.Parse(reader["noOfTickets"].ToString()), DateTime.Parse(reader["endDate"].ToString()), DateTime.Parse(reader["dailyHour"].ToString()));
                _conn.Close();

            }
            catch (SqlException e)
            {
                return null;
                throw e;
                
            }
            return u;
        }

        public List<Movie> getMovies()
        {
            Movie movie = null;
            List<Movie> result = new List<Movie>();

            String sql = "SELECT * FROM Movie";
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand(sql, _conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    movie = new Movie(reader["title"].ToString(), reader["director"].ToString(), reader["distribution"].ToString(), DateTime.Parse(reader["premiereDate"].ToString()), int.Parse(reader["noOfTickets"].ToString()), DateTime.Parse(reader["endDate"].ToString()), DateTime.Parse(reader["dailyHour"].ToString()) );
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

        public void insertMovie(Movie movie) {
            String premiereDate = movie.premiereDate.ToString("yyyy-MM-dd hh:mm:ss");
            String endDate = movie.endDate.ToString("yyyy-MM-dd");
            String dailyHour = movie.dailyHour.ToString("hh:mm:ss");

            MessageBox.Show("premiereDate: " + premiereDate + "; endDate:" + endDate);

            String sql = "INSERT INTO Movie VALUES ('" + movie.title + "' , '" + movie.director + "' , '" + movie.distribution + "' , '" + premiereDate + "' , '" + movie.noOfTickets.ToString() + "' , '" + endDate + "' , '"+ dailyHour + "')";
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
                throw e;
            }
        }

        public void deleteMovie(String title) {
            String sql = "DELETE FROM Movie WHERE title='" + title + "'";
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand(sql, _conn);
                SqlDataReader reader = cmd.ExecuteReader();
                _conn.Close();

            }
            catch (SqlException e)
            {
                throw e;
                _conn.Close();
            }

        }

       // public void updateMovie()

        //Tickets
        public List<Ticket> getTickets(Movie movie)
        {
            Ticket ticket = null;
            List<Ticket> result = new List<Ticket>();
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
                _conn.Close();
                return null;
                throw e;
                
            }
            return result;
        }

        public void insertTicket(Ticket ticket) {
            String airDate = ticket.airDate.ToString("yyyy-MM-dd");
            String sql = "INSERT INTO Ticket VALUES ('" + ticket.movie.title + "' , '" + ticket.row.ToString() + "' , '" + ticket.col.ToString() + "' , '" + airDate + "')";
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
                throw e;
            }
        }

        public int numberOfTickets(Movie movie, DateTime reserveDate) {

            int result = 0;
            String airDate = reserveDate.ToString("yyyy-MM-dd");
            String sql = "SELECT COUNT(Ticket.movie) as tickets FROM Ticket WHERE Ticket.movie='" + movie.title + "' " + " AND Ticket.airDate = '" + airDate + "'";
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand(sql, _conn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read()) {
                    result = (int)reader["tickets"];
                }
                _conn.Close();

            }
            catch (SqlException e)
            {
                _conn.Close();
                return 0;
                throw e;

            }
            return result; 
        }
    }
}
