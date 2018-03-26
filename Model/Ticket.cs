using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Model
{
    class Ticket
    {
        
        private Movie movie { get; set; }
        private int row { get; set; }
        private int col { get; set; }
        private DateTime airDate { get; set; }

        public Ticket(Movie movie, int row, int col, DateTime date)
        {
            this.movie = movie;
            this.row = row;
            this.col = col;
            this.airDate = date;
        }
    }
}
