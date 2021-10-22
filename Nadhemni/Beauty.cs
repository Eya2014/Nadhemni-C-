using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Recognition;
using System.Windows.Forms;

namespace Nadhemni
{
    public partial class Beauty : Form
    {
        private String action;
        private SpeechRec sr = new SpeechRec();
        public Beauty(String action)
        {

            this.action = action;
            InitializeComponent();
            if (action == "select")
            {
                update.Show();
                continuee.Hide();
                TimeTableBeauty.Show();
                selectBeauty();
            }
            else
            {
                update.Hide();
                continuee.Show();
                TimeTableBeauty.Hide();

            }
            sr = new SpeechRec();
            sr.createRec();
            //Register for Speech Recognition Event Notification
            sr.GetRecognitionEngine().SpeechRecognized += SeRec_SpeechRecofnized;
        }





        private void SeRec_SpeechRecofnized(object sender, SpeechRecognizedEventArgs e)
        {//Create a Speech Recognition Event Handler
            switch (e.Result.Text)
            {
                case "family":
                   sr.speak("go to family", "test7");
                    depart f = new depart();
                    f.Show();
                    this.Hide();
                    sr.desable();
                    break;
                case "health":
                    sr.speak("go to Health", "test7");
                    healthy h = new healthy();
                    h.Show();
                    this.Hide();
                    sr.desable();
                    break;
                case "job":
                    sr.speak("go to Job", "test7");
                    Job j = new Job("select");
                    j.Show();
                    this.Hide();
                    sr.desable();
                    break;
                case "pets":
                    sr.speak("go to Pets", "test7");
                    Pets p = new Pets();
                    p.Show();
                    this.Hide();
                    sr.desable();
                    break;
                case "beauty":
                    sr.speak("go to Beauty", "test7");
                    Beauty b = new Beauty("select");
                    b.Show();
                    this.Hide();
                    sr.desable();
                    break;
                case "event":
                    sr.speak("go to Event", "test7");
                    events ev = new events();
                    ev.Show();
                    this.Hide();
                    sr.desable();
                    break;
                case "bank":
                    sr.speak("go to Peggy Bank", "test7");
                    Treasury t = new Treasury();
                    t.Show();
                    this.Hide();
                    sr.desable();
                    break;
                case "bills":
                    sr.speak("go to Bills", "test7");
                    Bills bi = new Bills();
                    bi.Show();
                    this.Hide();
                    sr.desable();
                    break;
                default:
                    break;
            }

        }
        private void gunaImageButton6_Click(object sender, EventArgs e)
        {
            sr.speak("Hello !", "test7");
            sr.enable();
        }

        private void gunaImageButton7_Click(object sender, EventArgs e)
        {
            sr.desable();
        }
















        private void rd_OfCourse_CheckedChanged_2(object sender, EventArgs e)
        {
            if (rd_OfCourse.Checked)
            {
                TimeTableBeauty.Show();
            }

        }
        private void TextLabel(String str, int x, int y)
        {
            //create w label with a specific text and x,y position
            Label l = new Label();
            l.Text = str;
            l.AutoSize = true;
            l.TextAlign = ContentAlignment.MiddleCenter;
            l.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            l.Location = new Point(x, y);
            this.Controls.Add(l);
            TimeTableBeauty.Hide();

        }

        private void rd_HomeMasks_CheckedChanged(object sender, EventArgs e)
        {
            if (rd_HomeMasks.Checked)
            {
                TimeTableBeauty.Hide();
                TextLabel("Me too, I will send you a lot of homemade masks later !", 180, 150);
            }

        }

        private void Beauty_Load_1(object sender, EventArgs e)
        {

        }

        private void gunaGradientButton13_Click(object sender, EventArgs e)
        {
            this.Hide();
            depart h = new depart();
            h.Show();
        }

        private void gunaGradientButton12_Click(object sender, EventArgs e)
        {
            this.Hide();
            heal1 h = new heal1();
            h.Show();
        }

        private void gunaGradientButton11_Click(object sender, EventArgs e)
        {
            this.Hide();
            Job h = new Job("select");
            h.Show();
        }

        private void gunaGradientButton10_Click(object sender, EventArgs e)
        {
            this.Hide();
            Pets h = new Pets();
            h.Show();
        }

        private void gunaGradientButton9_Click(object sender, EventArgs e)
        {
            this.Hide();
            Beauty h = new Beauty("select");
            h.Show();
        }

        private void gunaGradientButton7_Click(object sender, EventArgs e)
        {
            this.Hide();
            events h = new events();
            h.Show();
        }

        private void gunaGradientButton4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Treasury h = new Treasury();
            h.Show();
        }

        private void gunaGradientButton3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Bills h = new Bills();
            h.Show();
        }

        private void gunaImageButton5_Click(object sender, EventArgs e)
        {
            sign_in.setUserId(0);
            sign_in s = new sign_in();
            this.Hide();
            s.Show();
        }
        private void selectBeauty()
        {
            var lst = from x in sign_in.nadhemniDB.BeautyTb
                      where (x.Id_user == sign_in.getUserId())
                      select x;
            if (lst.Count<BeautyTb>() != 0)
            {
                foreach (var bt in lst)
                {
                    if (bt.DayB == label1.Text)
                    {
                        chk_Monday.Checked = true;
                        gunaNumeric1.Value = bt.TimeB.Hours;
                        gunaNumeric8.Value = bt.TimeB.Minutes;
                    }
                    if (bt.DayB == label2.Text)
                    {
                        chk_Tuesday.Checked = true;
                        gunaNumeric2.Value = bt.TimeB.Hours;
                        gunaNumeric9.Value = bt.TimeB.Minutes;

                    }
                    if (bt.DayB == label3.Text)
                    {
                        chk_Wednesday.Checked = true;
                        gunaNumeric3.Value = bt.TimeB.Hours;
                        gunaNumeric10.Value = bt.TimeB.Minutes;
                    }
                    if (bt.DayB == label4.Text)
                    {
                        chk_Thursday.Checked = true;
                        gunaNumeric4.Value = bt.TimeB.Hours;
                        gunaNumeric11.Value = bt.TimeB.Minutes;
                    }
                    if (bt.DayB == label5.Text)
                    {
                        chk_Friday.Checked = true;
                        gunaNumeric5.Value = bt.TimeB.Hours;
                        gunaNumeric12.Value = bt.TimeB.Minutes;
                    }
                    if (bt.DayB == label6.Text)
                    {
                        chk_Saturday.Checked = true;
                        gunaNumeric6.Value = bt.TimeB.Hours;
                        gunaNumeric13.Value = bt.TimeB.Minutes;
                    }
                    if (bt.DayB == label7.Text)
                    {
                        chk_Sunday.Checked = true;
                        gunaNumeric7.Value = bt.TimeB.Hours;
                        gunaNumeric14.Value = bt.TimeB.Minutes;
                    }
                }

            }
            else
            {
                TextLabel("1. Mash one-quarter of an avocado in a small bowl.", 180, 180);
                TextLabel("2.Stir in one tablespoon cocoa powder and one tablespoon honey,\n mashing and mixing well.", 180, 200);
                TextLabel("3.Apply the mask to your clean, dry skin for 10 minutes.", 180, 220);
                TextLabel("4.Wash off with warm water, then moisturize as per usual.", 180, 240);

            }
        }
        private void gunaImageButton2_Click(object sender, EventArgs e)
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

        private void addBeauty()
        {
            //add beauty information to datbase
            try
            {
                if (chk_Monday.Checked)
                {
                    //create the object
                    BeautyTb bt = new BeautyTb();
                    //get the properties values from the form
                    bt.Id_user = sign_in.getUserId();
                    bt.DayB = label1.Text;
                    TimeSpan ts = new TimeSpan(Int32.Parse(gunaNumeric1.Value.ToString()),
                            Int32.Parse(gunaNumeric8.Value.ToString()), 00);
                    bt.TimeB = ts;
                    //add the object to the table 
                    sign_in.nadhemniDB.BeautyTb.InsertOnSubmit(bt);
                }
                if (chk_Tuesday.Checked)
                {
                    //create the object
                    BeautyTb bt = new BeautyTb();
                    //get the properties values from the form
                    bt.Id_user = sign_in.getUserId();
                    bt.DayB = label2.Text;
                    TimeSpan ts = new TimeSpan(Int32.Parse(gunaNumeric2.Value.ToString()),
                            Int32.Parse(gunaNumeric9.Value.ToString()), 00);
                    bt.TimeB = ts;
                    //add the object to the table 
                    sign_in.nadhemniDB.BeautyTb.InsertOnSubmit(bt);
                }
                if (chk_Wednesday.Checked)
                {
                    //create the object
                    BeautyTb bt = new BeautyTb();
                    //get the properties values from the form
                    bt.Id_user = sign_in.getUserId();
                    bt.DayB = label3.Text;
                    TimeSpan ts = new TimeSpan(Int32.Parse(gunaNumeric3.Value.ToString()),
                            Int32.Parse(gunaNumeric10.Value.ToString()), 00);
                    bt.TimeB = ts;
                    //add the object to the table 
                    sign_in.nadhemniDB.BeautyTb.InsertOnSubmit(bt);
                }
                if (chk_Thursday.Checked)
                {
                    //create the object
                    BeautyTb bt = new BeautyTb();
                    //get the properties values from the form
                    bt.Id_user = sign_in.getUserId();
                    bt.DayB = label4.Text;
                    TimeSpan ts = new TimeSpan(Int32.Parse(gunaNumeric4.Value.ToString()),
                            Int32.Parse(gunaNumeric11.Value.ToString()), 00);
                    bt.TimeB = ts;
                    //add the object to the table 
                    sign_in.nadhemniDB.BeautyTb.InsertOnSubmit(bt);
                }
                if (chk_Friday.Checked)
                {
                    //create the object
                    BeautyTb bt = new BeautyTb();
                    //get the properties values from the form
                    bt.Id_user = sign_in.getUserId();
                    bt.DayB = label5.Text;
                    TimeSpan ts = new TimeSpan(Int32.Parse(gunaNumeric5.Value.ToString()),
                            Int32.Parse(gunaNumeric12.Value.ToString()), 00);
                    bt.TimeB = ts;
                    //add the object to the table 
                    sign_in.nadhemniDB.BeautyTb.InsertOnSubmit(bt);
                }
                if (chk_Saturday.Checked)
                {
                    //create the object
                    BeautyTb bt = new BeautyTb();
                    //get the properties values from the form
                    bt.Id_user = sign_in.getUserId();
                    bt.DayB = label6.Text;
                    TimeSpan ts = new TimeSpan(Int32.Parse(gunaNumeric6.Value.ToString()),
                            Int32.Parse(gunaNumeric13.Value.ToString()), 00);
                    bt.TimeB = ts;
                    //add the object to the table 
                    sign_in.nadhemniDB.BeautyTb.InsertOnSubmit(bt);
                }
                if (chk_Sunday.Checked)
                {
                    //create the object
                    BeautyTb bt = new BeautyTb();
                    //get the properties values from the form
                    bt.Id_user = sign_in.getUserId();
                    bt.DayB = label7.Text;
                    TimeSpan ts = new TimeSpan(Int32.Parse(gunaNumeric7.Value.ToString()),
                            Int32.Parse(gunaNumeric14.Value.ToString()), 00);
                    bt.TimeB = ts;
                    //add the object to the table 
                    sign_in.nadhemniDB.BeautyTb.InsertOnSubmit(bt);
                }

                //update the data base
                sign_in.nadhemniDB.SubmitChanges();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }
        private void gunaCircleButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void continuee_Click(object sender, EventArgs e)
        {
            if (rd_OfCourse.Checked)
            {
                addBeauty();
                MessageBox.Show("add done successfully");
            }
            Parents p = new Parents("insert");
            p.Show();
            this.Hide();
        }

        private void update_Click(object sender, EventArgs e)
        {
            try
            {
                //delete the old records
                var lst = from x in sign_in.nadhemniDB.BeautyTb
                          where (x.Id_user == sign_in.getUserId())
                          select x;
                if (lst != null)
                {
                    foreach (var bt in lst)
                    {
                        sign_in.nadhemniDB.BeautyTb.DeleteOnSubmit(bt);
                    }
                }
                if (rd_OfCourse.Checked)
                {
                    //add the new information
                    addBeauty();

                }
                sign_in.nadhemniDB.SubmitChanges();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MessageBox.Show("update done successfully");
            
        }

        private void gunaNumeric9_ValueChanged(object sender, EventArgs e)
        {

        }

        private void gunaGradientButton21_Click(object sender, EventArgs e)
        {
            this.Hide();
            planning h = new planning();
            h.Show();
        }
    }
}
