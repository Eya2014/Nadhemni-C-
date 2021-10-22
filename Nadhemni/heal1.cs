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
    public partial class heal1 : Form
    {
        sign_in s = new sign_in();
        int selectedrow;
        public heal1()
        {
            InitializeComponent();
            LM.Hide();
            Ln.Hide();
            Lni.Hide();
            
            med.Hide();
            this.FormBorderStyle = FormBorderStyle.None;
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
           
            //member.DataSource= selectquery;


        }
    
            private const int cGrip = 16;      // Grip size
            private const int cCaption = 32;   // Caption bar height;

            protected override void OnPaint(PaintEventArgs e)
            {
                Rectangle rc = new Rectangle(this.ClientSize.Width - cGrip, this.ClientSize.Height - cGrip, cGrip, cGrip);
                ControlPaint.DrawSizeGrip(e.Graphics, this.BackColor, rc);
                rc = new Rectangle(0, 0, this.ClientSize.Width, cCaption);
            }

            protected override void WndProc(ref Message m)
            {
                if (m.Msg == 0x84)
                {  // Trap WM_NCHITTEST
                    Point pos = new Point(m.LParam.ToInt32());
                    pos = this.PointToClient(pos);
                    if (pos.Y < cCaption)
                    {
                        m.Result = (IntPtr)2;  // HTCAPTION
                        return;
                    }
                    if (pos.X >= this.ClientSize.Width - cGrip && pos.Y >= this.ClientSize.Height - cGrip)
                    {
                        m.Result = (IntPtr)17; // HTBOTTOMRIGHT
                        return;
                    }
                }
                base.WndProc(ref m);
            }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            RDV.DataSource = null;
            var selectquery =
                 from a in sign_in.nadhemniDB.GetTable<RDV>()
                 where (a.id_user == sign_in.getUserId())
                 select new { a.Id_RDV, a.Nom_RDV, a.DateRDV, a.Membre ,a.Etat};
            RDV.DataSource = selectquery;
            M.DataSource = null;
            var selectquery1 =
                 from a in sign_in.nadhemniDB.GetTable<Diseases>()
                 where (a.Id_User == sign_in.getUserId())
                 select new { a.Id_Di, a.Name,a.Med, a.time ,a.NameM};
            M.DataSource = selectquery1;
            etat.Enabled = false;
        }


        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaImageButton2_Click(object sender, EventArgs e)
        {

        }

        private void gunaGradientButton4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Job h = new Job("select");
            h.Show();
        }

        private void gunaCircleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gunaGradientButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            depart h = new depart();
            h.Show();
        }

        private void gunaImageButton3_Click(object sender, EventArgs e)
        {
            if(sideMenu.Width== 196)
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

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void gunaRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            med.Show();
        }

        private void gunaRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            med.Hide();
        }

        private void gunaButton6_Click(object sender, EventArgs e)
        {
            Boolean i = true;
          
            if(Verif.verifDeadline(call.Value)==false)
            {
               
                i = false;
            }
            if(i==true)
            { 
                try
            {
                DateTime dt = new DateTime(call.Value.Year,call.Value.Month ,call.Value.Day, int.Parse(cbH.Text), int.Parse(cbM.Text),0);
                sign_in sign = new sign_in();
                //lst.Add(""+titre.Text    +" : " +date.Value );
                RDV rd = new RDV();
                rd.id_user = sign_in.getUserId();
                rd.DateRDV = dt;
                    rd.Etat = "waiting";
                rd.Membre = member.Text;
                    rd.Nom_RDV = txtnom.Text;
                sign_in.nadhemniDB.RDV.InsertOnSubmit(rd);
                sign_in.nadhemniDB.SubmitChanges();
                var selectquery =
                 from a in sign_in.nadhemniDB.GetTable<RDV>()
                 where (a.id_user == sign_in.getUserId())
                 select new { a.Id_RDV, a.Nom_RDV, a.DateRDV, a.Membre, a.Etat };
                RDV.DataSource = selectquery;
                    member.SelectedIndex = -1;
                    etat.SelectedIndex = 0;
                    txtnom.Text = "";
                    idRDV.Text = "";

                }
            catch (Exception ex)
            {
                MessageBox.Show("erreur d'insertion dans RDV");
            }
            }
        }

        private void gunaButton5_Click(object sender, EventArgs e)
        {
            this.Hide();
           healthy h = new healthy();
            h.Show();
        }

        private void gunaButton4_Click(object sender, EventArgs e)
        {
            this.Hide();
            water eau = new water();
            eau.Show();
        }

        private void med_Click(object sender, EventArgs e)
        {

        }

        private void gunaButton7_Click(object sender, EventArgs e)
        {
            //events ev = new events();
            //ev.Show();
            planning p = new planning();
            p.Show();
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

        private void gunaButton8_Click(object sender, EventArgs e)
        {
            int i = 0;
            if (Verif.verifAlpha(txt1.Text)!=true)
            {
                i = 1;
                LM.Show();

            }
            if (Verif.verifAlpha(Txt2.Text) != true)
            {
                i = 1;
                Ln.Show();
            }
            if (Verif.verifAlpha(Txt3.Text) != true)
            {
                i = 1;
                Lni.Show();

            }
            if (i == 1)
            {
                txt1.Text = "";
                Txt2.Text = "";
                Txt3.Text = "";
                i = 0;
            }
           
            try
            {
                sign_in sign = new sign_in();
                //lst.Add(""+titre.Text    +" : " +date.Value );
                Diseases ev = new Diseases();
                ev.Id_User =sign_in.getUserId();
                ev.Name = cbD.Text;
               if(RbYes.Checked)
                {
                    ev.Med = "oui";
                }
               if(RbNo.Checked)
                {
                    ev.Med = "no";
                }
                if (L1.Checked)
                {
                    ev.time = "Morning";
                    ev.NameM = txt1.Text;

                }
                else if (L2.Checked)
                {
                    ev.time = "Noon";
                    ev.NameM = Txt2.Text;
                }
                else if (L3.Checked)
                {
                    ev.time = "Night";
                    ev.NameM = Txt3.Text;
                 }
               

                sign_in.nadhemniDB.Diseases.InsertOnSubmit(ev);
                sign_in.nadhemniDB.SubmitChanges();
                var selectquery =
                 from a in sign_in.nadhemniDB.GetTable<Diseases>()
                 where (a.Id_User == sign_in.getUserId())
                 select new { a.Id_Di, a.Name, a.Med, a.time, a.NameM };
                M.DataSource = selectquery;
                    LM.Hide();
                    Ln.Hide();
                    Lni.Hide();
                    txt1.Text = "";
                    Txt2.Text = "";
                    Txt3.Text = "";

                }
            catch (Exception ex)
            {
                MessageBox.Show("erreur d'insertion dans diseases");
            }
            

        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {

        }

        private void gunaButton3_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Health_Click(object sender, EventArgs e)
        {

        }

        private void Events_Click(object sender, EventArgs e)
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

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void cal_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void gunaButton1_Click_1(object sender, EventArgs e)
        {   

            try
            {
                DateTime dt = new DateTime(call.Value.Year, call.Value.Month, call.Value.Day, int.Parse(cbH.Text), int.Parse(cbM.Text), 0);

                RDV upRDV = sign_in.nadhemniDB.RDV.FirstOrDefault(ev1 => ev1.Id_RDV.Equals(int.Parse(idRDV.Text)));
                upRDV.Id_RDV =int.Parse(idRDV.Text);
                upRDV.Membre = member.Text;
                upRDV.DateRDV=dt;
                upRDV.Etat = etat.Text;
                upRDV.Nom_RDV = txtnom.Text;
                sign_in.nadhemniDB.SubmitChanges();
                var selectquery =
                 from a in sign_in.nadhemniDB.GetTable<RDV>()
                 where (a.id_user == sign_in.getUserId())
                 select new { a.Id_RDV, a.Nom_RDV ,a.DateRDV, a.Membre, a.Etat };
                RDV.DataSource = selectquery;
                etat.Enabled = false;
                member.SelectedIndex = -1;
                etat.SelectedIndex = 0;
                txtnom.Text = "";
                idRDV.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("erreur de modification");
            }
        }

        private void gunaButton2_Click_1(object sender, EventArgs e)
        {
            try
            {
                RDV Drdv = sign_in.nadhemniDB.RDV.FirstOrDefault(ev1 => ev1.Id_RDV.Equals(int.Parse(idRDV.Text)));
                sign_in.nadhemniDB.RDV.DeleteOnSubmit(Drdv);
                sign_in.nadhemniDB.SubmitChanges();
                var selectquery =
                    from a in sign_in.nadhemniDB.GetTable<RDV>()
                    where (a.id_user == sign_in.getUserId())
                    select new { a.Id_RDV, a.Nom_RDV, a.DateRDV, a.Membre, a.Etat };
                RDV.DataSource = selectquery;
                etat.Enabled = false;
                member.SelectedIndex = -1;
                etat.SelectedIndex = 0;
                txtnom.Text = "";
                idRDV.Text = "";

            }
            catch (Exception ex)
            {
                MessageBox.Show("erreur de supprission");
            }
        }

        

        private void RDV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void RDV_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            selectedrow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.RDV.Rows[selectedrow];
                idRDV.Text = row.Cells[0].Value.ToString();
                txtnom.Text = row.Cells[1].Value.ToString();
                member.Text = row.Cells[3].Value.ToString();
                etat.Text= row.Cells[4].Value.ToString();
                etat.Enabled = true;

            }

            }

        private void M_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void M_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.M.Rows[e.RowIndex];
                cbD.Text = row.Cells[1].Value.ToString();
                if(row.Cells["Med"].Value.ToString().Equals("oui"))
                {
                    RbYes.Checked=true;
                }
                if (row.Cells["Med"].Value.ToString().Equals("no"))
                {
                    RbNo.Checked = true;
                }
                if(row.Cells["time"].Value.ToString().Equals("Morning"))
                {
                    L1.Checked = true;
                    txt1.Text=row.Cells["NameM"].Value.ToString();
                    
                    Txt2.Text = "";
                    Txt3.Text = "";
                    L2.Checked = false;
                    L3.Checked = false;
                }
                else if (row.Cells["time"].Value.ToString().Equals("Noon"))
                {
                    Txt2.Text = row.Cells["NameM"].Value.ToString();

                    txt1.Text = "";
                    Txt3.Text = "";
                    L2.Checked = true;
                    L1.Checked = false;
                    L3.Checked = false;
                }
                else if (row.Cells["time"].Value.ToString().Equals("Night"))
                {
                    Txt3.Text = row.Cells["NameM"].Value.ToString();

                    Txt2.Text = "";
                    txt1.Text = "";
                    L3.Checked = true;
                    L1.Checked = false;
                    L2.Checked = false;
                }
            }
        }

        private void gunaButton3_Click_1(object sender, EventArgs e)
        {
            try
            {

                selectedrow = M.CurrentCell.RowIndex;
                DataGridViewRow row = this.M.Rows[selectedrow];


                Diseases upRDV = sign_in.nadhemniDB.Diseases.FirstOrDefault(ev1 => ev1.Id_Di.Equals(int.Parse(row.Cells[0].Value.ToString())));
                upRDV.Name = cbD.Text;
                upRDV.Id_Di = int.Parse(row.Cells[0].Value.ToString());
                if (RbNo.Checked)
                {
                    upRDV.Med = "no";
                }
                else
                {
                        upRDV.Med = "oui";
                    if(L1.Checked)
                    {
                        upRDV.time = L1.Text;
                        upRDV.NameM= txt1.Text;
                    }
                    else if(L2.Checked)
                    {
                        upRDV.time = L2.Text;
                        upRDV.NameM = Txt2.Text;

                    }
                    else if (L3.Checked)
                    {
                        upRDV.time = L3.Text;
                        upRDV.NameM = Txt3.Text;
                    }
                }

                sign_in.nadhemniDB.SubmitChanges();
                var selectquery =
                 from a in sign_in.nadhemniDB.GetTable<Diseases>()
                 where (a.Id_User == sign_in.getUserId())
                 select new { a.Id_Di, a.Name, a.Med, a.time, a.NameM };
                M.DataSource = selectquery;
            }
            catch (Exception ex)
            {
                MessageBox.Show("erreur de modification");
            }
        }

        private void gunaButton7_Click_1(object sender, EventArgs e)
        {
            try
            {
                selectedrow = M.CurrentCell.RowIndex;
            DataGridViewRow row = this.M.Rows[selectedrow];


            Diseases Me = sign_in.nadhemniDB.Diseases.FirstOrDefault(ev1 => ev1.Id_Di.Equals(int.Parse(row.Cells[0].Value.ToString())));
            sign_in.nadhemniDB.Diseases.DeleteOnSubmit(Me);
            sign_in.nadhemniDB.SubmitChanges();
            var selectquery =
                from a in sign_in.nadhemniDB.GetTable<Diseases>()
                where (a.Id_User == sign_in.getUserId())
                select new { a.Id_Di, a.Name, a.Med, a.time, a.NameM };
            M.DataSource = selectquery;
        }
            catch (Exception ex)
            {
                MessageBox.Show("erreur de modification");
            }
}

        private void RMois_CheckedChanged(object sender, EventArgs e)
        {
            RDV.DataSource = null;
            var selectquery =
                 from a in sign_in.nadhemniDB.GetTable<RDV>()
                 where (a.id_user == sign_in.getUserId())
                 select new { a.Id_RDV, a.DateRDV, a.Membre, a.Etat };
            RDV.DataSource = selectquery;
        }

        private void RJour_CheckedChanged_1(object sender, EventArgs e)
        {
                RDV.DataSource = null;
            var selectquery =
                 from a in sign_in.nadhemniDB.GetTable<RDV>()
                 where (a.DateRDV.Date.Equals(DateTime.Today) && (a.id_user == sign_in.getUserId()))
                 select new { a.Id_RDV,a.Nom_RDV, a.DateRDV, a.Membre, a.Etat };
            RDV.DataSource = selectquery;
        }

        private void gunaGradientButton21_Click(object sender, EventArgs e)
        {
            this.Hide();
            planning h = new planning();
            h.Show();
        }

        private void imprimer_Click(object sender, EventArgs e)
        {
            Treasury.exportDataGridViewtoPDF(RDV, "Appointments", "myAppointments");

        }

        private void gunaPictureBox1_Click(object sender, EventArgs e)
        {

            Treasury.exportDataGridViewtoPDF(M, "Drugs", "myDrugs");
        }
    }
    }


