using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Model
{
    public class Movie
    {
        public String title { get; set; }
        private String director { get; set; }
        private String distribution { get; set; }
        private DateTime premiereDate { get; set; }
        private int noOfTickets { get; set; }
        private DateTime endDate { get; set; }

        public Movie(String title, String director, String distribution, DateTime premiereDate, int noOfTickets, DateTime endDate) {
            this.title = title;
            this.director = director;
            this.distribution = distribution;
            this.premiereDate = premiereDate;
            this.noOfTickets = noOfTickets;
            this.endDate = endDate;
        }
    }
}
