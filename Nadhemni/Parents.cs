using System;
using System.Linq;
using System.Windows.Forms;

namespace Nadhemni
{
    public partial class Parents : Form
    {
        private String action;
        public Parents(String action)
        {
            this.action = action;
            InitializeComponent();
            viderErrLabel();
            if (action == "select")
            {
                update.Show();
                continuee.Hide();
                FillParent();
            }
            else
            {
                update.Hide();
                continuee.Show();
            }
        }

        private void Parents_Load(object sender, EventArgs e)
        {
            dt_Death.Hide();
            ck_lives.Hide();
            In.Hide();
            dt_Death2.Hide();
            ck_lives2.Hide();
            In2.Hide();
        }

        private void gunaRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaRadioButton1.Checked)
            {
                In.Show();
                dt_Death.Show();
                msg.Text = "I'm sorry to know that !";
                ck_lives.Hide();
            }

        }

        private void gunaRadioButton2_CheckedChanged(object sender, EventArgs e)
        {

            if (gunaRadioButton2.Checked)
            {
                dt_Death.Hide();
                In.Hide();
                msg.Text = "May God protect her !";
                ck_lives.Show();
            }
        }

        private void gunaRadioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (gunaRadioButton4.Checked)
            {
                In2.Show();
                dt_Death2.Show();
                msg2.Text = "I'm sorry to know that !";
                ck_lives2.Hide();
            }
        }

        private void gunaRadioButton3_CheckedChanged(object sender, EventArgs e)
        {

            if (gunaRadioButton3.Checked)
            {
                dt_Death2.Hide();
                In2.Hide();
                msg2.Text = "May God protect him !";
                ck_lives2.Show();
            }
        }
        private Boolean VerifParentsControl()
        {
            viderErrLabel();
            Boolean verif = true;
            if (!Verif.verifAlpha(txt_motherName.Text))
            {
                Err_Mname.Text = "This name has certain characters that aren't allowed.";
                verif = false;
            }
            if (!Verif.verifAlpha(txt_fatherName.Text))
            {
                Err_Fname.Text = "This name has certain characters that aren't allowed.";
                verif = false;
            }
            if (!Verif.verifDate(gunaDateTimePicker1.Value))
            {
                Err_dateM.Text = "This date is not allowed.";
                verif = false;
            }
            if (!Verif.verifDate(gunaDateTimePicker2.Value))
            {
                Err_dateF.Text = "This date is not allowed.";
                verif = false;
            }
            if (gunaRadioButton1.Checked == false && gunaRadioButton2.Checked == false)
            {
                Err_rdbt1.Text = "You should select one of the two option";
                verif = false;
            }
            else if (gunaRadioButton1.Checked)
            {
                if (!Verif.verifDate(dt_Death.Value))
                {
                    Err_chk_date1.Text = "This date is not allowed.";
                    verif = false;
                }
            }
            if (gunaRadioButton3.Checked == false && gunaRadioButton4.Checked == false)
            {
                Err_rdbt2.Text = "You should select one of the two option";
                verif = false;
            }
            else if (gunaRadioButton4.Checked)
            {
                if (!Verif.verifDate(dt_Death2.Value))
                {
                    Err_chk_date2.Text = "This date is not allowed.";
                    verif = false;
                }
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
            if (VerifParentsControl())
            {
                try
                {
                    //create the object(mother)
                    Family mother = new Family();
                    //get the properties values from the form
                    mother.Id_user = sign_in.getUserId();
                    mother.FamilyMember = "Mother";
                    mother.Name = txt_motherName.Text;
                    mother.Dbrth = gunaDateTimePicker1.Value.Date;
                    if (gunaRadioButton1.Checked)
                    {
                        mother.Dead = 1;
                    }
                    else
                    {
                        mother.Dead = 0;
                    }
                    if (ck_lives.Checked)
                    {
                        mother.LIvesWithMe = 1;
                    }
                    else
                    {
                        mother.LIvesWithMe = 0;
                    }
                    //add the object to the table
                    sign_in.nadhemniDB.Family.InsertOnSubmit(mother);
                    if (gunaRadioButton1.Checked)
                    {
                        //create the death event
                        Event ev = new Event();
                        //get the properties event values from the form
                        ev.Id_user = sign_in.getUserId();
                        ev.DateEvent = dt_Death.Value.Date;
                        ev.Titre = "mother's death";
                        ev.Organiser = "me";
                        ev.Country = "upadate this when you choose a specific country";
                        ev.Address = "upadate this when you choose a specific address";
                        ev.Type = "Death event";
                        //add the object to the table 
                        sign_in.nadhemniDB.Event.InsertOnSubmit(ev);
                    }
                    //create the object(mother)
                    Family father = new Family();
                    //get the properties values from the form
                    father.Id_user = sign_in.getUserId();
                    father.FamilyMember = "Father";
                    father.Name = txt_fatherName.Text;
                    father.Dbrth = gunaDateTimePicker2.Value.Date;
                    if (gunaRadioButton4.Checked)
                    {
                        father.Dead = 1;
                    }
                    else
                    {
                        father.Dead = 0;
                    }
                    if (ck_lives2.Checked)
                    {
                        father.LIvesWithMe = 1;
                    }
                    else
                    {
                        father.LIvesWithMe = 0;
                    }
                    //add the object to the table
                    sign_in.nadhemniDB.Family.InsertOnSubmit(father);

                    if (gunaRadioButton4.Checked)
                    {
                        //create the death event
                        Event ev = new Event();
                        //get the properties event values from the form
                        ev.Id_user = sign_in.getUserId();
                        ev.DateEvent = dt_Death2.Value.Date;
                        ev.Titre = "father's death";
                        ev.Organiser = "me";
                        ev.Country = "upadate this when you choose a specific country";
                        ev.Address = "upadate this when you choose a specific address";
                        ev.Type = "Death event";
                        //add the object to the table 
                        sign_in.nadhemniDB.Event.InsertOnSubmit(ev);
                    }
                    //update the data base
                    sign_in.nadhemniDB.SubmitChanges();
                    MessageBox.Show("add done successfully");
                    //if everything is alright move to the next form
                    this.Hide();
                    depart d = new depart();
                    d.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void gunaGradientButton1_Click(object sender, EventArgs e)
        {

        }

        private void Health_Click(object sender, EventArgs e)
        {
            this.Hide();
            heal1 h = new heal1();
            h.Show();
        }

        private void Job_Click(object sender, EventArgs e)
        {
            this.Hide();
            Job h = new Job("select");
            h.Show();
        }

        private void Beauty_Click(object sender, EventArgs e)
        {
            this.Hide();
            Pets h = new Pets();
            h.Show();
        }

        private void Events_Click(object sender, EventArgs e)
        {
            this.Hide();
            Beauty h = new Beauty("select");
            h.Show();
        }

        private void gunaGradientButton6_Click(object sender, EventArgs e)
        {
            this.Hide();
            events h = new events();
            h.Show();
        }

        private void gunaGradientButton5_Click(object sender, EventArgs e)
        {


            this.Hide();
            Treasury h = new Treasury();
            h.Show();
        }

        private void gunaGradientButton8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Bills h = new Bills();
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

        private void gunaImageButton3_Click(object sender, EventArgs e)
        {
            if (sideMenu.Width == 196)
            {
                sideMenu.Visible = false;
                sideMenu.Width = 43;
                bunifuTransition1.ShowSync(sideMenu);
                bunifuTransition1.ShowSync(logo);

            }
            else
            {
                sideMenu.Visible = false;
                sideMenu.Width = 196;
                bunifuTransition1.ShowSync(sideMenu);
                bunifuTransition1.ShowSync(logo);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void FillParent()
        {
            try
            {

                //get parent
                Family mother = sign_in.nadhemniDB.Family.First<Family>
                    (x => x.Id_user == sign_in.getUserId() && x.FamilyMember == "Mother");
                Family father = sign_in.nadhemniDB.Family.First<Family>
                    (x => x.Id_user == sign_in.getUserId() && x.FamilyMember == "Father");
                //update user information 
                txt_motherName.Text = mother.Name;
                gunaDateTimePicker1.Value = mother.Dbrth;

                if (mother.Dead == 1)
                {
                    gunaRadioButton1.Checked = true;
                }
                else
                {
                    gunaRadioButton2.Checked = true;
                }
                if (mother.LIvesWithMe == 1)
                {
                    ck_lives.Checked = true;
                }
                else
                {
                    ck_lives.Checked = false;
                }
                txt_fatherName.Text = father.Name;
                gunaDateTimePicker2.Value = father.Dbrth;

                if (father.Dead == 1)
                {
                    gunaRadioButton4.Checked = true;
                }
                else
                {
                    gunaRadioButton3.Checked = true;
                }
                if (father.LIvesWithMe == 1)
                {
                    ck_lives2.Checked = true;
                }
                else
                {
                    ck_lives2.Checked = false;
                }
                //submit changes in database
                sign_in.nadhemniDB.SubmitChanges();
                MessageBox.Show("Update succesful");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void update_Click_1(object sender, EventArgs e)
        {

            try
            {

                //get parent
                Family mother = sign_in.nadhemniDB.Family.First<Family>
                    (x => x.Id_user == sign_in.getUserId() && x.FamilyMember == "Mother");
                Family father = sign_in.nadhemniDB.Family.First<Family>
                    (x => x.Id_user == sign_in.getUserId() && x.FamilyMember == "Father");
                //update user information 
                mother.Name = txt_motherName.Text;
                mother.Dbrth = gunaDateTimePicker1.Value;

                if (gunaRadioButton1.Checked)
                {
                    mother.Dead = 1;
                }
                else
                {
                    mother.Dead = 0;
                }
                if (ck_lives.Checked)
                {
                    mother.LIvesWithMe = 1;
                }
                else
                {
                    mother.LIvesWithMe = 0;
                }
                father.Name = txt_fatherName.Text;
                father.Dbrth = gunaDateTimePicker2.Value;

                if (gunaRadioButton4.Checked)
                {
                    father.Dead = 1;
                }
                else
                {
                    father.Dead = 0;
                }
                if (ck_lives2.Checked)
                {
                    father.LIvesWithMe = 1;
                }
                else
                {
                    father.LIvesWithMe = 0;
                }
                //submit changes in database
                sign_in.nadhemniDB.SubmitChanges();
                MessageBox.Show("Update succesful");
                depart d = new depart();
                this.Hide();
                d.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void gunaGradientButton21_Click(object sender, EventArgs e)
        {
            this.Hide();
            planning h = new planning();
            h.Show();
        }
    }
}

