using Cinema.BLL;
using Cinema.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinema.UI
{
    public partial class FormAdminMovies : Form
    {
        MoviesService movieService = new MoviesService();
        public FormAdminMovies()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int result = 0;

            try
            {
                //movieService.insertMovie(new Movie("Pain", "asdasd", "asdasd", new DateTime(1222222222222), 123, new DateTime(2222222222223333), new DateTime(123123)));
                result =  movieService.numberOfTickets(new Movie("Titanic"), new DateTime(2013, 03, 20));
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }

            MessageBox.Show("Number of tickets: " + result.ToString());

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
