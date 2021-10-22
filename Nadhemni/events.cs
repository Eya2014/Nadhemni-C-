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
    
    public partial class events : Form
    {
        private int nbClick = 0;
        Verif ver = new Verif();

        int selectedrow;
        private SpeechRec sr = new SpeechRec(); 
        public events()
        {
            InitializeComponent();
            Ltitre.Hide();
            LO.Hide();
            LA.Hide();
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
                    sr.speak("go to family", "test9");
                    depart f = new depart();
                    f.Show();
                    this.Hide();
                    sr.desable();
                    break;
                case "health":
                    sr.speak("go to Health", "test9");
                    healthy h = new healthy();
                    h.Show();
                    this.Hide();
                    sr.desable();
                    break;
                case "job":
                    sr.speak("go to Job", "test9");
                    Job j = new Job("select");
                    j.Show();
                    this.Hide();
                    sr.desable();
                    break;
                case "pets":
                    sr.speak("go to Pets", "test9");
                    Pets p = new Pets();
                    p.Show();
                    this.Hide();
                    sr.desable();
                    break;
                case "beauty":
                    sr.speak("go to Beauty", "test9");
                    Beauty b = new Beauty("select");
                    b.Show();
                    this.Hide();
                    sr.desable();
                    break;
                case "event":
                    sr.speak("go to Event", "test9");
                    events ev = new events();
                    ev.Show();
                    this.Hide();
                    sr.desable();
                    break;
                case "bank":
                    sr.speak("go to Peggy Bank", "test9");
                    Treasury t = new Treasury();
                    t.Show();
                    this.Hide();
                    sr.desable();
                    break;
                case "bills":
                    sr.speak("go to Bills", "test9");
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
            sr.speak("Hello !", "test9");
            sr.enable();
        }


        private void gunaImageButton7_Click_1(object sender, EventArgs e)
        {
            sr.desable();
        }




        private void events_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
           var selectquery =
                from a in sign_in.nadhemniDB.GetTable<Event>()
                where (a.Id_user == sign_in.getUserId())
                select new { a.Id_Event ,a.Titre ,a.Organiser ,a.DateEvent,a.Type ,a.Address,a.Country, a.Etat};
            dataGridView1.DataSource = selectquery;
            etat.SelectedIndex = 0;
            etat.Enabled = false;

        }

        private void ev_Click(object sender, EventArgs e)
        {
            nbClick += 1;
            if (nbClick == 1)
            {
                
                    Guna.UI.WinForms.GunaLineTextBox t = new Guna.UI.WinForms.GunaLineTextBox();
                    t.Size = new System.Drawing.Size(335, 10);
                    t.Location = new System.Drawing.Point(1, (ev.Controls.Count + 1) * 20);
                    t.BackColor = System.Drawing.SystemColors.Control;
                    ev.Enabled = false;
                    ev.Controls.Add(t);
                
            }
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            int i = 0;
            if(Verif.verifAlpha(titre.Text) != true)
            {
                Ltitre.Show();
                i = 1;
            }
            
            if (Verif.verifAlpha(org.Text) != true)
            {
                i = 1;
                LO.Show();
            }
            if (Verif.verifAlpha(adr.Text) != true)
            {
                i = 1;
                LA.Show();
            }
           
            if (i==1)
            {
                titre.Text = "";
                org.Text = "";
                CBCountry.Text = "";
                cbtype.Text = "";
                adr.Text = "";
            }
            else
            {
                try
                {

                    
                    //lst.Add(""+titre.Text    +" : " +date.Value );
                    Event ev = new Event();
                    ev.Id_user = sign_in.getUserId();

                    ev.Titre = titre.Text;

                    ev.Organiser = org.Text;
                    ev.DateEvent = date.Value;
                    ev.Country = CBCountry.Text;
                    ev.Address = adr.Text;
                    ev.Type = cbtype.Text;
                    ev.Etat = etat.Text;

                    sign_in.nadhemniDB.Event.InsertOnSubmit(ev);
                    sign_in.nadhemniDB.SubmitChanges();
                    var selectquery =
                     from a in sign_in.nadhemniDB.GetTable<Event>()
                     where (a.Id_user == sign_in.getUserId())
                     select new { a.Id_Event, a.Titre, a.Organiser, a.DateEvent, a.Type, a.Address, a.Country, a.Etat };
                    dataGridView1.DataSource = selectquery;
                    Ltitre.Hide();
                    LO.Hide();
                    LA.Hide();
                    titre.Text = "";
                    org.Text = "";
                    CBCountry.Text = "";
                    cbtype.Text = "";
                    adr.Text = "";
                    idTxt.Text = "";
                    cbtype.SelectedIndex = -1;
                    CBCountry.SelectedIndex = -1;
                }


                catch (Exception ex)
                {
                    MessageBox.Show("erreur d'insertion dans events");
                }

            }
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            int i = 0;
            if (Verif.verifAlpha(titre.Text) != true)
            {
                Ltitre.Show();
                i = 1;
            }

            if (Verif.verifAlpha(org.Text) != true)
            {
                i = 1;
                LO.Show();
            }
            if (Verif.verifAlpha(adr.Text) != true)
            {
                i = 1;
                LA.Show();
            }

            if (i == 1)
            {
                titre.Text = "";
                org.Text = "";
                CBCountry.Text = "";
                cbtype.Text = "";
                adr.Text = "";
            }
            else
            {
                try
                {
                    ev.Enabled = true;
                    Event upevent = sign_in.nadhemniDB.Event.FirstOrDefault(ev1 => ev1.Id_Event.Equals(int.Parse(idTxt.Text)));
                    upevent.Titre = titre.Text;

                    upevent.Organiser = org.Text;
                    upevent.DateEvent = date.Value;
                    upevent.Type = cbtype.Text;
                    upevent.Country = CBCountry.Text;
                    upevent.Address = adr.Text;
                    upevent.Etat = etat.Text;
                    sign_in.nadhemniDB.SubmitChanges();
                    var selectquery =
                        from a in sign_in.nadhemniDB.GetTable<Event>()
                        where (a.Id_user == sign_in.getUserId())
                        select new { a.Id_Event, a.Titre, a.Organiser, a.DateEvent, a.Type, a.Address, a.Country, a.Etat };
                    dataGridView1.DataSource = selectquery;
                    Ltitre.Hide();
                    LO.Hide();
                    LA.Hide();
                    titre.Text = "";
                    org.Text = "";
                    CBCountry.Text = "";
                    cbtype.Text = "";
                    adr.Text = "";
                    idTxt.Text = "";
                    cbtype.SelectedIndex = -1;
                    CBCountry.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("erreur de modification");
                }
            }
          

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

        private void gunaGradientButton6_Click(object sender, EventArgs e)
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

        private void gunaButton3_Click(object sender, EventArgs e)
        {
            try
             {
                 Event Devent = sign_in.nadhemniDB.Event.FirstOrDefault(ev1 => ev1.Id_Event.Equals(int.Parse(idTxt.Text)));
                 sign_in.nadhemniDB.Event.DeleteOnSubmit(Devent);
                 sign_in.nadhemniDB.SubmitChanges();
                 var selectquery =
                     from a in sign_in.nadhemniDB.GetTable<Event>()
                     where (a.Id_user == sign_in.getUserId())
                     select new { a.Id_Event, a.Titre, a.Organiser, a.DateEvent,a.Type, a.Address, a.Country, a.Etat };
                 dataGridView1.DataSource = selectquery;
                etat.Enabled = false;
                titre.Text = "";
                org.Text = "";
                CBCountry.Text = "";
                cbtype.Text = "";
                adr.Text = "";
                idTxt.Text = "";
                cbtype.SelectedIndex = -1;
                CBCountry.SelectedIndex = -1;

            }
             catch(Exception ex)
             {
                 MessageBox.Show("erreur de suppression");
             }
             
            
        }

        private void gunaGradientButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            depart h = new depart();
            h.Show();
        }

        private void Job_Click(object sender, EventArgs e)
        {
            this.Hide();
            Job t = new Job("select");
            t.Show();
           
           
        }

        private void gunaGradientButton1_Click(object sender, EventArgs e)
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedrow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[selectedrow];
                idTxt.Text = row.Cells["id_Event"].Value.ToString();
                titre.Text = row.Cells["Titre"].Value.ToString();
                cbtype.Text = row.Cells["Type"].Value.ToString();
                adr.Text = row.Cells["Address"].Value.ToString();
                CBCountry.Text = row.Cells["Country"].Value.ToString();
                org.Text = row.Cells["Organiser"].Value.ToString();
               // etat.Text = row.Cells["Etat"].Value.ToString();
                etat.Text = dataGridView1[6,selectedrow].Value.ToString();
                etat.Enabled = true;
            }
        }

        private void gunaGradientButton21_Click(object sender, EventArgs e)
        {
            this.Hide();
            planning h = new planning();
            h.Show();
        }
        private void etat_SelectedIndexChanged(object sender, EventArgs e)
        {
            etat.Enabled = false;
        }
        private void imprimer_Click(object sender, EventArgs e)
        {

            Treasury.exportDataGridViewtoPDF(dataGridView1, "Events", "myEvents");
        }
    }
}
