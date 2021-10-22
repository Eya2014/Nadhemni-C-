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
    public partial class Couple : Form
    {
        private String action;
        public Couple(string action)
        {
            InitializeComponent();
            viderErrLabel();
            this.action = action;
        }

        private void Couple_Load(object sender, EventArgs e)
        {

        }
        private Boolean VerifCoupleControl()
        {
            viderErrLabel();
            Boolean verif = true;
            if (! Verif.verifAlpha(txt_Name.Text))
            {
                Err_name.Text = "This name has certain characters that aren't allowed.";
                verif=false;
            }
            if (! Verif.verifDate(gunaDateTimePicker1.Value))
            {
                Err_date1.Text = "This date is not allowed.";
                verif = false;
            }
            if (! Verif.verifDate(gunaDateTimePicker2.Value))
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
            if (VerifCoupleControl())
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
                    ev.Titre = "First Date";
                    ev.Organiser = "me";
                    ev.Country = "upadate this when you choose a specific country";
                    ev.Address = "upadate this when you choose a specific address";
                    ev.Type = "couple event";
                    //get the properties event values from the form
                    f.Id_user = sign_in.getUserId();
                    f.FamilyMember = "partner";
                    f.Name = txt_Name.Text;
                    f.Dbrth = gunaDateTimePicker2.Value.Date;
                    //add the object to the table 
                    sign_in.nadhemniDB.Event.InsertOnSubmit(ev);
                    sign_in.nadhemniDB.Family.InsertOnSubmit(f);
                    //update the data base
                    sign_in.nadhemniDB.SubmitChanges();
                    MessageBox.Show("add done successfully");
                    //if everything is alright move to the next form
                    if (action == "update")
                    {
                        depart d = new depart();
                        d.Show();
                        this.Hide();
                    }
                    else
                    {
                        this.Hide();
                        Parents p = new Parents("insert");
                        p.Show();
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void gunaCircleButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Err_date1_Click(object sender, EventArgs e)
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
    }
}
