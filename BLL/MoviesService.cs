using Cinema.DAO;
using Cinema.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.BLL
{
    class MoviesService
    {
        MoviesDAO moviesDAO = MoviesDAO.getInstance();

        //Movies

        public List<Movie> getMovies() {
            List<Movie> movies = new List<Movie>();
            try
            {
                movies = moviesDAO.getMovies();
            }
            catch (Exception ex) {
                throw ex;
            }

            return movies;
        }

        public void insertMovie(Movie movie) {
            try
            {
                moviesDAO.insertMovie(movie);
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        public void deleteMovie(String title) {
            try
            {
                moviesDAO.deleteMovie(title);
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        //Tickets
        public List<Ticket> getTickets(Movie movie)
        {
            List<Ticket> tickets = new List<Ticket>();
            try
            {
                tickets = moviesDAO.getTickets(movie);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return tickets;
        }

        public void insertTicket(Movie movie, int row, int col, DateTime reserveDate) {
       
            try
            {
                int noOfTickets = moviesDAO.numberOfTickets(movie, reserveDate);

                if (noOfTickets < movie.noOfTickets) {
                    moviesDAO.insertTicket(new Ticket(movie, row, col, reserveDate));    
                }

            }
            catch (Exception ex) {
                throw ex;
            }
        }
    }
}
