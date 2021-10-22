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
    public partial class Married : Form
    {
        private String action;
        public Married(String action)
        {
            InitializeComponent();
            viderErrLabel();

            this.action = action;
        }

        private Boolean VerifMarriedControl()
        {
            viderErrLabel();
            Boolean verif = true;
            if (!Verif.verifAlpha(txt_name.Text))
            {
                Err_name.Text = "This name has certain characters that aren't allowed.";
                verif = false;
            }
            if (! Verif.verifDate(gunaDateTimePicker1.Value))
            {
                Err_date1.Text = "This date is not allowed.";
                verif = false;
            }
            if (!Verif.verifDate(gunaDateTimePicker2.Value))
            {
                Err_date2.Text = "This date is not allowed.";
                verif = false;
            }
            return verif;
        }
        private void viderErrLabel()
        {
            foreach (Control x in panel1.Controls)
            {
                if (x.Name.StartsWith("Err"))
                {
                    x.Text = "";
                }
            }
        }
        private void continuee_Click(object sender, EventArgs e)
        {
            if (VerifMarriedControl())
            {
                try
                {
                    //create instance of sign in class to get the user id
                    sign_in si = new sign_in();
                    //create the object
                    Event ev = new Event();
                    Family f = new Family();
                    //get the properties event values from the form
                    ev.Id_user = sign_in.getUserId();
                    ev.DateEvent = gunaDateTimePicker1.Value.Date;
                    ev.Titre = "Wedding date";
                    ev.Organiser = "me";
                    ev.Country = "upadate this when you choose a specific country";
                    ev.Address = "upadate this when you choose a specific address";
                    ev.Type = "Wedding date event";
                    //get the properties event values from the form
                    f.Id_user = sign_in.getUserId();
                    f.FamilyMember = "partner";
                    f.Name = txt_name.Text;
                    f.Dbrth = gunaDateTimePicker2.Value.Date;
                    //add the object to the table 
                    sign_in.nadhemniDB.Event.InsertOnSubmit(ev);
                    sign_in.nadhemniDB.Family.InsertOnSubmit(f);
                    //update the data base
                    sign_in.nadhemniDB.SubmitChanges();
                    MessageBox.Show("add done successfully");
                    //if everything is alright move to the next form
                    int nk = int.Parse(NumKids.Value.ToString());
                    // if user has kids then show kids interface
                    if (nk > 0)
                    {
                        Kids k = new Kids(nk, "insert");
                        k.Show();
                    }
                    else if(action == "update")
                    {
                        depart d = new depart();
                        this.Hide();
                        d.Show();
                    }
                    else
                    {

                        //show job 
                        Job j = new Job("insert");
                        j.Show();

                    }
                    // close current form
                    this.Hide();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void Married_Load(object sender, EventArgs e)
        {

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
