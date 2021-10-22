using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition; 
namespace Nadhemni
{
    public partial class Job : Form
    {
        private String action;
        private SpeechRec sr = new SpeechRec();
        public Job(string action)
        {

            this.action = action;
            InitializeComponent();
            if (action == "select")
            {
                FillTimeTable();
                continuee.Hide();
                update.Show();
            }
            else
            {
                update.Hide();
                continuee.Show();
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
                    sr.speak("go to family", "test5");
                    depart f = new depart();
                    f.Show();
                    this.Hide();
                    sr.desable();
                    break;
                case "health":
                    sr.speak("go to Health", "test5");
                    healthy h = new healthy();
                    h.Show();
                    this.Hide();
                    sr.desable();
                    break;
                case "job":
                    sr.speak("go to Job", "test5");
                    Job j = new Job("select");
                    j.Show();
                    this.Hide();
                    sr.desable();
                    break;
                case "pets":
                    sr.speak("go to Pets", "test5");
                    Pets p = new Pets();
                    p.Show();
                    this.Hide();
                    sr.desable();
                    break;
                case "beauty":
                    sr.speak("go to Beauty", "test5");
                    Beauty b = new Beauty("select");
                    b.Show();
                    this.Hide();
                    sr.desable();
                    break;
                case "event":
                    sr.speak("go to Event", "test5");
                    events ev = new events();
                    ev.Show();
                    this.Hide();
                    sr.desable();
                    break;
                case "bank":
                    sr.speak("go to Peggy Bank", "test5");
                    Treasury t = new Treasury();
                    t.Show();
                    this.Hide();
                    sr.desable();
                    break;
                case "bills":
                    sr.speak("go to Bills", "test5");
                    Bills bi = new Bills();
                    bi.Show();
                    this.Hide();
                    sr.desable();
                    break;
                default:
                    break;
            }

        }



        private void gunaImageButton6_Click_1(object sender, EventArgs e)
        {
            sr.speak("Hello !", "test5");
            sr.enable();

        }

        private void gunaImageButton7_Click_1(object sender, EventArgs e)
        {
           sr.desable();

        }




        private void Job_Load(object sender, EventArgs e)
        {

        }

        private void continuee_Click(object sender, EventArgs e)
        {
            try
            {
                addTimeTable();
                //update the data base
                sign_in.nadhemniDB.SubmitChanges();
                MessageBox.Show("add done successfully");
                //if everything is alright move to the next form
                this.Hide();
                Beauty d = new Beauty("insert");
                d.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void gunaGradientButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            depart h = new depart();
            h.Show();
        }

        private void Health_Click(object sender, EventArgs e)
        {
            this.Hide();
            heal1 h = new heal1();
            h.Show();
        }
        private void FillTimeTable()
        {
            /*foreach (Control x in TimeTable.Controls)
            {
                if(x.Name.StartsWith("guna"))
                x.Enabled=false;
            }*/

            try
            {
                var lst = from x in sign_in.nadhemniDB.TimeTable
                          where (x.id_user == sign_in.getUserId() && x.Id_Family == null)
                          select x;

                foreach (var item in lst)
                {
                    TimeTable.GetControlFromPosition(item.day, item.StartTime.Hours - 7).Text = item.content;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void gunaGradientButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Job j = new Job("select");
            j.Show();
            FillTimeTable();
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

        private void gunaCircleButton2_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }

        private void TimeTable_Paint(object sender, PaintEventArgs e)
        {

        }

        private void update_Click(object sender, EventArgs e)
        {
        }

        private void addTimeTable()
        {
            //create the object
            TimeTable t = new TimeTable();
            //get the properties event values from the form
            for (int i = 1; i < TimeTable.ColumnCount; i++)
            {
                for (int j = 1; j < TimeTable.RowCount; j++)
                {
                    Control txt = TimeTable.GetControlFromPosition(i, j);
                    if (txt.Text != "")
                    {
                        TimeTable tab = new TimeTable();
                        tab.id_user = sign_in.getUserId();
                        tab.Id_Family = null;
                        tab.day = i;
                        TimeSpan startTime = new TimeSpan(j + 7, 00, 00);
                        tab.StartTime = startTime;
                        TimeSpan endTime = new TimeSpan(j + 8, 00, 00);
                        tab.EndTime = endTime;
                        tab.content = txt.Text;
                        //add the object to the table 
                        sign_in.nadhemniDB.TimeTable.InsertOnSubmit(tab);

                    }
                }
            }
        }

        private void update_Click_1(object sender, EventArgs e)
        {

            try
            {
                //delete the old records
                var lst = from x in sign_in.nadhemniDB.TimeTable
                          where (x.id_user == sign_in.getUserId())
                          select x;
                if (lst != null)
                {
                    foreach (var t in lst)
                    {
                        sign_in.nadhemniDB.TimeTable.DeleteOnSubmit(t);
                    }
                }
                //add the new information
                addTimeTable();
                sign_in.nadhemniDB.SubmitChanges();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MessageBox.Show("update done successfully");
            this.Refresh();

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

