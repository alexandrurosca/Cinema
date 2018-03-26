using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Model
{   
    public class Movie
    {
        private DateTime _dailyHour;

        public DateTime dailyHour
        {
            get { return _dailyHour; }
            set { _dailyHour = value; }
        }

        public String title { get; set; }
        public String director { get; set; }
        public String distribution { get; set; }
        public DateTime premiereDate { get; set; }
        public int noOfTickets { get; set; }

        public DateTime endDate { get; set; }

        public Movie(String title, String director, String distribution, DateTime premiereDate, int noOfTickets,  DateTime endDate, DateTime dailyHour) {
            this.title = title;
            this.director = director;
            this.distribution = distribution;
            this.premiereDate = premiereDate;
            this.noOfTickets = noOfTickets;
            this.endDate = endDate;
            this._dailyHour = dailyHour; 
        }

        public Movie(string title)
        {
            this.title = title;
        }
    }
}
