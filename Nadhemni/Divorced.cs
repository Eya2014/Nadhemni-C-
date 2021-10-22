using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nadhemni
{
    public partial class Divorced : Form
    {
        public Divorced()
        {
            InitializeComponent();
        }

        private void Divorced_Load(object sender, EventArgs e)
        {

        }


        private void continuee_Click(object sender, EventArgs e)
        {

            int nk =int.Parse(NumKids.Value.ToString()) ;
            // if user has kids then show kids interface
            if (nk > 0)
            {
                Kids k = new Kids(nk,"insert");
                k.Show();
            }
            else
            {
                //show 
                Job j = new Job("insert");
                j.Show();
            }
            this.Hide();
        }

        private void gunaGradientButton21_Click(object sender, EventArgs e)
        {
            this.Hide();
            planning h = new planning();
            h.Show();
        }

        private void gunaImageButton1_Click(object sender, EventArgs e)
        {
            sign_in.setUserId(0);
            sign_in s = new sign_in();
            this.Hide();
            s.Show();
        }

        private void gunaCircleButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
