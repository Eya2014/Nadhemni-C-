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
    
    public partial class water : Form
    {
        int selectedrow;
        int y = 40;
        public void afficher()
        {/*
            var selectquery =
                from a in sign_in.nadhemni.GetTable<DrinkWater>()
                select a.PeriodDrink;
            //dataGridView1.DataSource = selectquery;

            foreach (String D in selectquery)
            {
                Label t1 = new Label();
                t1.Size = new System.Drawing.Size(24, 24);
                t1.Location = new Point(21, y);
                t1.Image = global::Nadhemni.Properties.Resources.off;
                
                Label t = new Label();
                t.Size = new System.Drawing.Size(100, 30);
                t.Location = new Point(45, y);
                y = y + 36;
                t.BackColor = System.Drawing.SystemColors.Control;
                t.Text = "reminder me At  " + D;
                t.TextAlign = ContentAlignment.MiddleCenter;
                t.Font = new Font("Segoe UI", 9.75F, FontStyle.Italic, GraphicsUnit.Point, ((byte)(0)));
                t.TabIndex = 0;
                t.AutoSize = true;
                t.BackColor = System.Drawing.Color.Transparent;
                this.panel5.Controls.Add(t);
                this.panel5.Controls.Add(t1);
                Console.Write("");
            }*/
        }
        private SpeechRec sr = new SpeechRec();
        public water()
        {
            InitializeComponent();
            aide.Hide();
            pk.Hide();
            Ptime.Hide();
            afficher();
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
                    sr.speak("go to family", "test3");
                    depart f = new depart();
                    f.Show();
                    this.Hide();
                    sr.desable();
                    break;
                case "health":
                    sr.speak("go to Health", "test3");
                    healthy h = new healthy();
                    h.Show();
                    this.Hide();
                    sr.desable();
                    break;
                case "job":
                    sr.speak("go to Job", "test3");
                    Job j = new Job("select");
                    j.Show();
                    this.Hide();
                    sr.desable();
                    break;
                case "pets":
                    sr.speak("go to Pets", "test3");
                    Pets p = new Pets();
                    p.Show();
                    this.Hide();
                    sr.desable();
                    break;
                case "beauty":
                    sr.speak("go to Beauty", "test3");
                    Beauty b = new Beauty("select");
                    b.Show();
                    this.Hide();
                    sr.desable();
                    break;
                case "event":
                    sr.speak("go to Event", "test3");
                    events ev = new events();
                    ev.Show();
                    this.Hide();
                    sr.desable();
                    break;
                case "bank":
                    sr.speak("go to Peggy Bank", "test3");
                    Treasury t = new Treasury();
                    t.Show();
                    this.Hide();
                    sr.desable();
                    break;
                case "bills":
                    sr.speak("go to Bills", "test3");
                    Bills bi = new Bills();
                    bi.Show();
                    this.Hide();
                    sr.desable();
                    break;
                default:
                    break;
            }

        }


        private void gunaImageButton10_Click_1(object sender, EventArgs e)
        {
            sr.speak("Hello !", "test3");
            sr.enable();

        }

        private void gunaImageButton1_Click_1(object sender, EventArgs e)
        {
            sr.desable();
        }


        private void water_Load(object sender, EventArgs e)
        {
            var selectquery =
                from a in sign_in.nadhemniDB.GetTable<DrinkWater>()
                select new {a.Id_water, a.PeriodDrink };
            dataGridView1.DataSource = selectquery;
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            
            P2.Show();
        }
        private int Calculer(double n)
        { int nb = 0;
            if (n % 0.2 == 0)
                nb = (int)(n / 0.2);
            else
                nb =(int) (n/0.2) + 1;
            return nb;
      
        }

        
        private void Qeau_SelectedIndexChanged(object sender, EventArgs e)
        {
           /*            
            int Q = 0;
            double quantite = 0;
            int nb;
            switch (Q)
            {
                case 0:
                    quantite = 0.9;
                    this.panel5.Controls.Clear();

                    break;
                case 1:
                    quantite = 1;
                    this.panel5.Controls.Clear();

                    break;
                case 2:
                    quantite = 1.6;
                    this.panel5.Controls.Clear();


                    break;
                case 3:
                    quantite = 1.6;
                    this.panel5.Controls.Clear();

                    break;
                case 4:
                    quantite = 2;
                    this.panel5.Controls.Clear();

                    break;
                case 5:
                    quantite = 2;
                    this.panel5.Controls.Clear();

                    break;
            }

            nb = Calculer(quantite);

            int y = 40;
            int H = 8;
            for (int i = 0; i < nb; i++)
            {
                Label t = new Label();
                t.Size = new System.Drawing.Size(100, 30);
                t.Location = new Point(45, y);
                y = y + 36;
                t.BackColor = System.Drawing.SystemColors.Control;
                t.Text ="" + 0.2 + " L  : AT " + H + ":00";
                t.TextAlign = ContentAlignment.MiddleCenter;
                t.Font = new Font("Segoe UI", 9.75F, FontStyle.Italic, GraphicsUnit.Point, ((byte)(0)));
                t.TabIndex = 0;
                t.AutoSize = true;
                t.BackColor = System.Drawing.Color.Transparent;

                if (quantite == 0.9 || quantite == 1)
                    H = H + 3;
                else if (quantite == 1.6)
                    H = H + 2;
                else
                    H = H + 1;

                this.panel5.Controls.Add(t);

            }*/
        }

        private void gunaGroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void gunaImageButton1_Click(object sender, EventArgs e)
        {
            P2.Show();
        }

        private void P2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaPictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void gunaImageButton10_Click(object sender, EventArgs e)
        {
            
            pk.Hide();
            aide.Show();
        }

        private void aide_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaImageButton11_Click(object sender, EventArgs e)
        {
            
            aide.Hide();
            pk.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pk.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            aide.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            aide.Hide();
        }

        private void gunaButton1_Click_1(object sender, EventArgs e)
        {

        }

        private void gunaButton4_Click(object sender, EventArgs e)
        {
            
            pk.Hide();
            aide.Hide();
            gunaPictureBox2.Show();        
        }

        private void gunaButton1_Click_2(object sender, EventArgs e)
        {
            gunaPictureBox2.Hide();
            pk.Hide();
            aide.Show();
        }

        private void gunaButton3_Click(object sender, EventArgs e)
        {
            gunaPictureBox2.Hide();
            aide.Hide();
            pk.Show();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaCircleButton3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        

        private void gunaButton6_Click(object sender, EventArgs e)
        {
            Ptime.Show();
        }

        private void gunaButton5_Click(object sender, EventArgs e)
        {
            try
            {
                sign_in sign = new sign_in();
                //lst.Add(""+titre.Text    +" : " +date.Value );
                DrinkWater ev = new DrinkWater();
                ev.Id_user = sign_in.getUserId();
                ev.Quantity = Qeau.Text;
                ev.PeriodDrink = time.Text;
                sign_in.nadhemniDB.DrinkWater.InsertOnSubmit(ev);
                sign_in.nadhemniDB.SubmitChanges();
                var selectquery =
                from a in sign_in.nadhemniDB.GetTable<DrinkWater>()
                select new { a.PeriodDrink };
                dataGridView1.DataSource = selectquery;
                /*   Label t1 = new Label();
                   t1.Size = new System.Drawing.Size(24, 24);
                   t1.Location = new Point(21, y);
                   t1.Image = global::Nadhemni.Properties.Resources.off;
                   Label t = new Label();
                   t.Size = new System.Drawing.Size(100, 30);
                   t.Location = new Point(45, y);
                   y = y + 36;
                   t.BackColor = System.Drawing.SystemColors.Control;
                   t.Text = "reminder me At  " + time.Text;
                   t.TextAlign = ContentAlignment.MiddleCenter;
                   t.Font = new Font("Segoe UI", 9.75F, FontStyle.Italic, GraphicsUnit.Point, ((byte)(0)));
                   t.TabIndex = 0;
                   t.AutoSize = true;
                   t.BackColor = System.Drawing.Color.Transparent;
                   this.panel5.Controls.Add(t);
                   this.panel5.Controls.Add(t1);*/
                Ptime.Hide();
                

            }
            catch (Exception ex)
            {
                MessageBox.Show("erreur d'insertion dans events");
            }

        }

        private void gunaImageButton9_Click(object sender, EventArgs e)
        {
          
            this.Hide();
            heal1 h1 = new heal1();
            h1.Show();
        }

        private void gunaButton7_Click(object sender, EventArgs e)
        {
            
            
            try
            {
                selectedrow = dataGridView1.CurrentCell.RowIndex;
                DataGridViewRow row = this.dataGridView1.Rows[selectedrow];
                DrinkWater Me = sign_in.nadhemniDB.DrinkWater.FirstOrDefault(ev1 => ev1.Id_water.Equals(int.Parse(row.Cells[0].Value.ToString())));
                sign_in.nadhemniDB.DrinkWater.DeleteOnSubmit(Me);
                sign_in.nadhemniDB.SubmitChanges();
                var selectquery =
                from a in sign_in.nadhemniDB.GetTable<DrinkWater>()
                select new { a.Id_water,a.PeriodDrink };
                dataGridView1.DataSource = selectquery;
            }
            catch(Exception ex)
            {

            }
          }

        private void gunaGradientButton21_Click(object sender, EventArgs e)
        {
            this.Hide();
            planning h = new planning();
            h.Show();
        }

        private void gunaImageButton11_Click_1(object sender, EventArgs e)
        {
           
        }
    }
}
