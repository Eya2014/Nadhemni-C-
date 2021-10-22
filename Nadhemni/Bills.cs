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
    public partial class Bills : Form
    {
        internal static NadhemniDBDataContext dbnadhemni = new NadhemniDBDataContext();
        internal static sign_in Sign = new sign_in();
        internal static Users userdb = new Users();
        int selectedRow;
        int U_Id =sign_in.getUserId();
        void StegSonede()
        {
            var lststeg = (from x in Bills.dbnadhemni.Bill
                           where x.Beneficiary.ToUpper().ToString() =="STEG"
                           select new
                           {
                               stg = x.Amount }

                        ).ToList();
           var steg = lststeg.Sum(x => x.stg);
            var lstsonede = (from y in Bills.dbnadhemni.Bill
                           where y.Beneficiary.ToUpper().ToString() =="SONEDE" 
                           select new
                           {
                               sone = y.Amount
                           }

                       ).ToList();
            var sonede = lstsonede.Sum(y => y.sone);
            var lstsom = (from x in Bills.dbnadhemni.Bill
                           select new
                           {
                               sm = x.Amount
                           }

                      ).ToList();
            var smm = lstsom.Sum(x => x.sm);
            st.Text = "Steg : "+ steg.ToString() + " dt" ;
            sn.Text = "Sonede : " + sonede.ToString() + " dt";
            total.Text = "Total Amount : " + smm.ToString() + " dt";
         
        }
        private SpeechRec sr = new SpeechRec();
        public Bills()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
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
                    sr.speak("go to family", "test8");
                    depart f = new depart();
                    f.Show();
                    this.Hide();
                    sr.desable();
                    break;
                case "health":
                    sr.speak("go to Health", "test8");
                    healthy h = new healthy();
                    h.Show();
                    this.Hide();
                    sr.desable();
                    break;
                case "job":
                    sr.speak("go to Job", "test8");
                    Job j = new Job("select");
                    j.Show();
                    this.Hide();
                    sr.desable();
                    break;
                case "pets":
                    sr.speak("go to Pets", "test8");
                    Pets p = new Pets();
                    p.Show();
                    this.Hide();
                    sr.desable();
                    break;
                case "beauty":
                    sr.speak("go to Beauty", "test8");
                    Beauty b = new Beauty("select");
                    b.Show();
                    this.Hide();
                    sr.desable();
                    break;
                case "event":
                    sr.speak("go to Event", "test8");
                    events ev = new events();
                    ev.Show();
                    this.Hide();
                    sr.desable();
                    break;
                case "bank":
                    sr.speak("go to Peggy Bank", "test8");
                    Treasury t = new Treasury();
                    t.Show();
                    this.Hide();
                    sr.desable(); 
                    break;
                case "bills":
                    sr.speak("go to Bills", "test8");
                    Bills bi = new Bills();
                    bi.Show();
                    this.Hide();
                    sr.desable();
                    break;
                default:;
                    break;
            }

        }

        private void gunaImageButton6_Click(object sender, EventArgs e)
        {
            sr.speak("Hello !", "test8");
            sr.enable();
        }

        
        private void gunaImageButton7_Click_1(object sender, EventArgs e)
        {
            sr.desable();
        }
        void datafill()
        {
            dataGridView1.DataSource = null;
            var lstTasks = (from x in Pets.dbnadhemni.Bill
                            select new
                            {
                                Id_Bill = x.id_Bills,
                                Date_cheque = x.DateC,
                                Type_of_cheque = x.TypeC,
                                Beneficiary = x.Beneficiary,
                                Amount = x.Amount
                                ,
                                State = x.State 
                            }
            ).ToList();
            dataGridView1.DataSource = lstTasks;
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

        }

        private void gunaCircleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gunaGradientButton1_Click(object sender, EventArgs e)
        {

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

        private void gunaImageButton1_Click(object sender, EventArgs e)
        {

        }

        private void gunaCircleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        }

        private void gunaCirclePictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRow];
                dtrem.Value = Convert.ToDateTime(row.Cells[1].Value);
                type.Text = row.Cells[2].Value.ToString();
                txtbenef.Text = row.Cells[3].Value.ToString();
                txtamount.Text = row.Cells[4].Value.ToString();
                etat.Text = row.Cells[5].Value.ToString();
                etat.Enabled = true;
            }
        }

        private void gunaButton7_Click(object sender, EventArgs e)
        {

        }

        private void med_Click(object sender, EventArgs e)
        {

        }

        private void gunaCheckBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void gunaCirclePictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Reminder_Click(object sender, EventArgs e)
        {

        }


        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void gunaLineTextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void gunaCirclePictureBox2_Click(object sender, EventArgs e)
        {

        }



        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void gunaGradientCircleButton3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Are you sure you want to delete your pet's history");
        }
        private void gunaGradientCircleButton4_Click(object sender, EventArgs e)
        {


        }

        private void historyPet_Click(object sender, EventArgs e)
        {

        }

        private void gunaImageRadioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void gunaComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void gunaCheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void gunaCheckBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void panelHeader_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaCircleButton2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gunaImageButton3_Click_1(object sender, EventArgs e)
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Bills_Load(object sender, EventArgs e)
        {
            StegSonede();
            datafill();
            eram.Hide();
            erbn.Hide();
            erdt.Hide();
            erty.Hide();
            etat.SelectedIndex = 0;
            etat.Enabled = false;
        }

        private void logo_Click(object sender, EventArgs e)
        {

        }

        private void gunaImageButton3_Click_2(object sender, EventArgs e)
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

        private void gunaCircleButton2_Click_2(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void gunaGradientButton1_Click_1(object sender, EventArgs e)
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

        private void gunaGradientButton8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Bills h = new Bills();
            h.Show();
        }

        private void gunaCirclePictureBox1_Click_1(object sender, EventArgs e)
        {
            Bill p = new Bill();
            int i = 0;
          
                    if (Verif.verifDeadline(dtrem.Value) == false)
                    {
                        i = 1;
                        erdt.Show();
                        dtrem.Value = DateTime.Now;
                        dtrem.ForeColor = System.Drawing.Color.Salmon;
                    }
                    else
                    {
                    erdt.Hide();
                    dtrem.ForeColor = System.Drawing.Color.Black;
                    }
                    if (type.Text == "")
                            {
                                i = 1;
                                erty.Show();
                                type.Text = "";
                        type.ForeColor = System.Drawing.Color.Salmon;

                    }
                    else
                            {
                                erty.Hide();
                        type.ForeColor = System.Drawing.Color.Black;

                    }
                    if (Verif.verifFloat(txtamount.Text) == false)
                            {
                            i = 1;
                            eram.Show();
                            txtamount.Text = "";
                        txtamount.ForeColor = System.Drawing.Color.Salmon;

                    }
                    else
                            {
                            eram.Hide();
                        txtamount.ForeColor = System.Drawing.Color.Black;

                    }
                    if (Verif.verifDigitOrAlpha(txtbenef.Text) == false)
                    {
                        i = 1;
                        erbn.Show();
                        txtbenef.Text = "";
                        txtbenef.ForeColor = System.Drawing.Color.Salmon;
                    }
                    else
                    {
                        erbn.Hide();
                        txtbenef.ForeColor = System.Drawing.Color.Black;
                    }

            if (i == 0)
            {
                try
                {
                    eram.Hide();
                    erbn.Hide();
                    erdt.Hide();
                    erty.Hide();

                    p.Id_user = U_Id;
                    p.DateC = dtrem.Value;
                    p.TypeC = type.Text;
                    p.Amount = Convert.ToDouble(txtamount.Text);
                    p.Beneficiary = txtbenef.Text;
                    p.State = "waiting";
                    DialogResult dialogResult = MessageBox.Show("Sure", "are you sure to Add...", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        Bills.dbnadhemni.Bill.InsertOnSubmit(p);
                        Bills.dbnadhemni.SubmitChanges();
                        datafill();
                        MessageBox.Show("Bill added with success...");
                        StegSonede();
                        
                        dtrem.Value = DateTime.Now; ;
                        type.Text = "";
                        txtamount.Text = "";
                        txtbenef.Text = "";
                        etat.SelectedIndex = 0;
                      
                    }
                }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            }
        }

        private void gunaCirclePictureBox3_Click(object sender, EventArgs e)
        {
            try
            {
                string firstCellValue = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
                var p = (from y in dbnadhemni.Bill
                         where y.id_Bills == int.Parse(firstCellValue)
                         select y).Single();
                DialogResult dialogResult = MessageBox.Show("Sure", "are you sure to Delete...", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    dbnadhemni.Bill.DeleteOnSubmit(p);
                    dbnadhemni.SubmitChanges();
                    MessageBox.Show("Row Deleted Successfully.");
                    datafill();
                    dtrem.Value = DateTime.Now; ;
                    type.Text = "";
                    txtamount.Text = "";
                    txtbenef.Text = "";
                    StegSonede();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void med_Click_1(object sender, EventArgs e)
        {

        }

        private void gunaCirclePictureBox2_Click_1(object sender, EventArgs e)
        {
            int i = 0;

            if (Verif.verifDeadline(dtrem.Value) == false)
            {
                i = 1;
                erdt.Show();
                dtrem.Value = DateTime.Now;
                dtrem.ForeColor = System.Drawing.Color.Salmon;
            }
            else
            {
                erdt.Hide();
                dtrem.ForeColor = System.Drawing.Color.Black;
            }
            if (type.Text == "")
            {
                i = 1;
                erty.Show();
                type.Text = "";
                type.ForeColor = System.Drawing.Color.Salmon;

            }
            else
            {
                erty.Hide();
                type.ForeColor = System.Drawing.Color.Black;

            }
            if (Verif.verifFloat(txtamount.Text) == false)
            {
                i = 1;
                eram.Show();
                txtamount.Text = "";
                txtamount.ForeColor = System.Drawing.Color.Salmon;

            }
            else
            {
                eram.Hide();
                txtamount.ForeColor = System.Drawing.Color.Black;

            }
            if (Verif.verifDigitOrAlpha(txtbenef.Text) == false)
            {
                i = 1;
                erbn.Show();
                txtbenef.Text = "";
                txtbenef.ForeColor = System.Drawing.Color.Salmon;
            }
            else
            {
                erbn.Hide();
                txtbenef.ForeColor = System.Drawing.Color.Black;
            }

            if (i == 0)
            {
                try
            {
                string firstCellValue = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
                var p = (from y in dbnadhemni.Bill
                         where y.id_Bills == int.Parse(firstCellValue)
                         select y).Single();
                p.Id_user = U_Id;
                p.DateC = dtrem.Value;
                p.TypeC = type.Text;
                p.Amount = Convert.ToDouble(txtamount.Text);
                p.Beneficiary = txtbenef.Text;
                    p.State = etat.Text;
                    DialogResult dialogResult = MessageBox.Show("Sure", "are you sure to Update...", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Bills.dbnadhemni.SubmitChanges();
                    datafill();
                    MessageBox.Show("Bill Updated with success...");
                    StegSonede();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }   
        }

        private void gunaGradientButton21_Click(object sender, EventArgs e)
        {
            this.Hide();
            planning h = new planning();
            h.Show();
        }

        private void gunaImageButton1_Click_1(object sender, EventArgs e)
        {
            sign_in.setUserId(0);
            sign_in s = new sign_in();
            this.Hide();
            s.Show();
        }

        private void imprimer_Click(object sender, EventArgs e)
        {
            Treasury.exportDataGridViewtoPDF(dataGridView1, "Bills", "myBills");
        }

        private void etat_SelectedIndexChanged(object sender, EventArgs e)
        {
            etat.Enabled = false;
        }
    }

}
