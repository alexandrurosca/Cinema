using Cinema.BLL;
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
            ArrayList movies = new ArrayList();

            try
            {
                movies = movieService.getMovies();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            
           // movieService.insertMovie("abc", "aa","bb", new DateTime(999999999999), 400, new DateTime(9999999999999));

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
