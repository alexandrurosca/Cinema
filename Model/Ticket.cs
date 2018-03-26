using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Model
{
    class Ticket
    {
        
        public Movie movie { get; set; }
        public  int row { get; set; }
        public int col { get; set; }
        public DateTime airDate { get; set; }

        public Ticket(Movie movie, int row, int col, DateTime date)
        {
            this.movie = movie;
            this.row = row;
            this.col = col;
            this.airDate = date;
        }
    }
}
