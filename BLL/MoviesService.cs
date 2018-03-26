using Cinema.DAO;
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

        public ArrayList getMovies() {
            ArrayList movies = new ArrayList();
            try
            {
                movies = moviesDAO.getMovies();
            }
            catch (Exception ex) {
                throw ex;
            }

            return movies;
        }

        public void insertMovie(String title, String director, String distribution, DateTime premiereDate, int tickets, DateTime endDate) {
            try
            {
                moviesDAO.insertMovie(title, director, distribution, premiereDate.ToString("yyyy-MM-dd"), tickets.ToString(), endDate.ToString("yyyy-MM-dd"));
            }
            catch (Exception ex) {
                throw ex;
            }
        }
    }
}
