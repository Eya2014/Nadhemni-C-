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
    public partial class depart : Form
    {
        private SpeechRec sr = new SpeechRec();
        public depart()
        {
            InitializeComponent();
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
                    sr.speak("go to family", "test1");
                    depart f = new depart();
                    f.Show();
                    this.Hide();
                    sr.desable();
                    break;
                case "health":
                    sr.speak("go to Health", "test1");
                    healthy h = new healthy();
                    h.Show();
                    this.Hide();
                    sr.desable();
                    break;
                case "job":
                    sr.speak("go to Job", "test1");
                    Job j = new Job("select");
                    j.Show();
                    this.Hide();
                    sr.desable();
                    break;
                case "pets":
                    sr.speak("go to Pets", "test1");
                    Pets p = new Pets();
                    p.Show();
                    this.Hide();
                    sr.desable();
                    break;
                case "beauty":
                    sr.speak("go to Beauty", "test1");
                    Beauty b = new Beauty("select");
                    b.Show();
                    this.Hide();
                    sr.desable();
                    break;
                case "event":
                    sr.speak("go to Event", "test1");
                    events ev = new events();
                    ev.Show();
                    this.Hide();
                    sr.desable();
                    break;
                case "bank":
                    sr.speak("go to Peggy Bank", "test1");
                    Treasury t = new Treasury();
                    t.Show();
                    this.Hide();
                    sr.desable();
                    break;
                case "bills":
                    sr.speak("go to Bills", "test1");
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
            sr.speak("Hello !","test1");
            sr.enable();

        }

        private void gunaImageButton7_Click_1(object sender, EventArgs e)
        {
            sr.desable();

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

        private void Health_Click(object sender, EventArgs e)
        {
            this.Hide();
            heal1 h = new heal1();
            h.Show();
        }

        private void Beauty_Click(object sender, EventArgs e)
        {
            this.Hide();
            Pets h = new Pets();
            h.Show();
        }

        private void events_Click(object sender, EventArgs e)
        {
            this.Hide();
            events h = new events();
            h.Show();
        }

        private void gunaGradientButton8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Bills h = new Bills();
            h.Show();
        }

        private void gunaCircleButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void depart_Load(object sender, EventArgs e)
        {

        }

        private void gunaGradientButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            depart h = new depart();
            h.Show();
        }

        private void Job_Click(object sender, EventArgs e)
        {
            this.Hide();
            Job h = new Job("select");
            h.Show();
        }

        private void beauty_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Beauty h = new Beauty("select");
            h.Show();
        }

        private void gunaGradientButton5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Treasury h = new Treasury();
            h.Show();
        }

        private void gunaImageButton1_Click(object sender, EventArgs e)
        {
            sign_in.setUserId(0);
            sign_in s = new sign_in();
            this.Hide();
            s.Show();
        }

        private void update_user_Click_1(object sender, EventArgs e)
        {
            Register_Form r = new Register_Form("select");
            this.Hide();
            r.Show();
        }




        private void update_kids_Click(object sender, EventArgs e)
        {
            try
            {
                var lst = from x in sign_in.nadhemniDB.Family
                          where (x.Id_user == sign_in.getUserId() && x.FamilyMember == "Kid")
                          select x;
                if (lst.Count() != 0)
                {
                    Kids k = new Kids(lst.Count(), "select");
                    k.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("You don't have kids");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void addkid_Click(object sender, EventArgs e)
        {
            Kids k = new Kids(1, "add");
            k.Show();
            this.Hide();

        }

        private void update_parent_Click(object sender, EventArgs e)
        {
            Parents p = new Parents("select");
            this.Hide();
            p.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            planning p1 = new planning();
            this.Hide();
            p1.Show();
        }

        private void gunaGradientButton2_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure to delete your account ?", "Removal Process..",
                             MessageBoxButtons.YesNo,
                             MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                BeautyTb b = new BeautyTb();
                var bb = from x1 in sign_in.nadhemniDB.BeautyTb
                         where x1.Id_user == sign_in.getUserId()
                         select x1;
                foreach (var item1 in bb)
                    sign_in.nadhemniDB.BeautyTb.DeleteOnSubmit(item1);

                Bill bi = new Bill();
                var bil = from x2 in sign_in.nadhemniDB.Bill
                          where x2.Id_user == sign_in.getUserId()
                          select x2;
                foreach (var item2 in bil)
                    sign_in.nadhemniDB.Bill.DeleteOnSubmit(item2);

               
                DrinkWater u = new DrinkWater();
                var dw = from x3 in sign_in.nadhemniDB.DrinkWater
                         where x3.Id_user == sign_in.getUserId()
                         select x3;
                foreach (var item3 in dw)
                    sign_in.nadhemniDB.DrinkWater.DeleteOnSubmit(item3);

                Drugs drug = new Drugs();
                var dru = from x4 in sign_in.nadhemniDB.Drugs
                          where x4.id_user == sign_in.getUserId()
                          select x4;
                foreach (var item4 in dru)
                    sign_in.nadhemniDB.Drugs.DeleteOnSubmit(item4);

                Event ev = new Event();
                var eve = from x5 in sign_in.nadhemniDB.Event
                          where x5.Id_user == sign_in.getUserId()
                          select x5;
                foreach (var item5 in eve)
                    sign_in.nadhemniDB.Event.DeleteOnSubmit(item5);

                Family fam = new Family();
                var fami = from x6 in sign_in.nadhemniDB.Family
                           where x6.Id_user == sign_in.getUserId()
                           select x6;
                foreach (var item6 in fami)
                    sign_in.nadhemniDB.Family.DeleteOnSubmit(item6);

                RDV rd = new RDV();
                var rdd = from x7 in sign_in.nadhemniDB.RDV
                          where x7.id_user == sign_in.getUserId()
                          select x7;
                foreach (var item7 in rdd)
                    sign_in.nadhemniDB.RDV.DeleteOnSubmit(item7);

                TimeTable time = new TimeTable();
                var timet = from x8 in sign_in.nadhemniDB.TimeTable
                            where x8.id_user == sign_in.getUserId()
                            select x8;
                foreach (var item8 in timet)
                    sign_in.nadhemniDB.TimeTable.DeleteOnSubmit(item8);

                Desire de = new Desire();
                var dee = from x9 in sign_in.nadhemniDB.Desire
                          where x9.Id_user == sign_in.getUserId()
                          select x9;
                foreach (var item9 in dee)
                    sign_in.nadhemniDB.Desire.DeleteOnSubmit(item9);

                Diseases des = new Diseases();
                var dees = from x10 in sign_in.nadhemniDB.Diseases
                          where x10.Id_User == sign_in.getUserId()
                          select x10;
                foreach (var item10 in dees)
                    sign_in.nadhemniDB.Diseases.DeleteOnSubmit(item10);

                Pet p = new Pet();
                var pet = from x11 in sign_in.nadhemniDB.Pet
                           where x11.Id_User == sign_in.getUserId()
                           select x11;
                foreach (var item11 in pet)
                    sign_in.nadhemniDB.Pet.DeleteOnSubmit(item11);

                petreminder pe = new petreminder();
                var petr = from x12 in sign_in.nadhemniDB.petreminder
                          where x12.Id_User == sign_in.getUserId()
                          select x12;
                foreach (var item12 in petr)
                    sign_in.nadhemniDB.petreminder.DeleteOnSubmit(item12);

                Users user = new Users();
                var uu = from x13 in sign_in.nadhemniDB.Users
                         where x13.Id_user == sign_in.getUserId()
                         select x13;
                foreach (var item13 in uu)
                    sign_in.nadhemniDB.Users.DeleteOnSubmit(item13);

                sign_in.nadhemniDB.SubmitChanges();
                MessageBox.Show("We hope we see you again !");
                this.Hide();
                sign_in s = new sign_in();
                s.Show();
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
