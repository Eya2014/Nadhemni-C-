using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic.ApplicationServices;
using System.IO;
using System.Speech.Recognition;
namespace Nadhemni
{

    public partial class Pets : Form
    {
        internal static NadhemniDBDataContext dbnadhemni = new NadhemniDBDataContext();
        internal static sign_in Sign = new sign_in();
        internal static Users userdb = new Users();
        int selectedRow;
        int U_Id =sign_in.getUserId();
        void datafill()
        {
            dataGridView1.DataSource = null;
            var lstTasks = (from x in Pets.dbnadhemni.petreminder
                            select new
                            {
                                Reminder_Id = x.Id,
                                Reminder_Name = x.RemName,
                                Pet_Name = x.Name,
                                Reminder_Date = x.remdate,
                                Notes = x.Notes
                            }
            ).ToList();
            dataGridView1.DataSource = lstTasks;
        }
        private SpeechRec sr = new SpeechRec();
        public Pets()
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
                    sr.speak("go to family", "test4");
                    depart f = new depart();
                    f.Show();
                    this.Hide();
                    sr.desable();
                    break;
                case "health":
                    sr.speak("go to Health", "test4");
                    healthy h = new healthy();
                    h.Show();
                    this.Hide();
                    sr.desable();
                    break;
                case "job":
                    sr.speak("go to Job", "test4");
                    Job j = new Job("select");
                    j.Show();
                    this.Hide();
                    sr.desable();
                    break;
                case "pets":
                    sr.speak("go to Pets","test4");
                    Pets p = new Pets();
                    p.Show();
                    this.Hide();
                    sr.desable();
                    break;
                case "beauty":
                    sr.speak("go to Beauty", "test4");
                    Beauty b = new Beauty("select");
                    b.Show();
                    this.Hide();
                    sr.desable();
                    break;
                case "event":
                    sr.speak("go to Event", "test4");
                    events ev = new events();
                    ev.Show();
                    this.Hide();
                    sr.desable();
                    break;
                case "bank":
                    sr.speak("go to Peggy Bank", "test4");
                    Treasury t = new Treasury();
                    t.Show();
                    this.Hide();
                    sr.desable();
                    break;
                case "bills":
                    sr.speak("go to Bills", "test4");
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
            sr.speak("Hello !", "test4");
            sr.enable();
        }

        private void gunaImageButton7_Click_1(object sender, EventArgs e)
        {
            sr.desable();
        }



        public Image ByteArrayToImage (Byte[] btin)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                Image ret = Image.FromStream(ms);
                return ret;

            }
        }
     void combo1()
        {
            comboBox1.ValueMember = null;

            var listpet = (from x in dbnadhemni.Pet
                            where x.Id_User == U_Id
                            select new
                            {
                                code = x.Id_User,
                                name = x.Name
                            }
            ).ToList();

            comboBox1.ValueMember = "Name";
            comboBox1.DataSource = listpet;

        }
      
        private void Pets_Load(object sender, EventArgs e)
        {
            // TODO: cette ligne de code charge les données dans la table 'nadhemniDataSet1.petreminder'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            /*  try { this.petreminderTableAdapter.Fill(this.NadhemniDataSet1); }
              catch(Exception ex)
              {

              }*/
            etat.SelectedIndex = 0;
            etat.Enabled = false;
            combo1();
            datafill();
            er1_birthdate.Hide();
            er1_img.Hide();
            er1_name.Hide();
            er1_type.Hide();
            er1_vetoname.Hide();
            er1_vetonumb.Hide();

            er_datereminder.Hide();
            er_namereminder.Hide();
            er_petnamereminder.Hide();
            er_heure.Hide();
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
            sign_in.setUserId(0);
            sign_in s = new sign_in();
            this.Hide();
            s.Show();
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

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

        private void gunaGradientCircleButton1_Click(object sender, EventArgs e)
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

        private void gunaGradientCircleButton2_Click(object sender, EventArgs e)
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

        private void panelHeader_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaCircleButton2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Health_Click(object sender, EventArgs e)
        {
            this.Hide();
            heal1 h = new heal1();
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

        private void Beauty_Click(object sender, EventArgs e)
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

        private void gunaCirclePictureBox1_Click_1(object sender, EventArgs e)
        {
            int i = 0;
            if (remdate.Value.CompareTo(DateTime.Today) <= 0)
            {
                i = 1;
                er_datereminder.Show();
                remdate.Value = DateTime.Now;
                remdate.ForeColor = System.Drawing.Color.Salmon;
            }
            else
            {
                er_datereminder.Hide();
                remdate.ForeColor = System.Drawing.Color.Black;
            }
            if (numh.Text == "" || numm.Text == "")
            {
                i = 1;
                er_heure.Show();
                numh.ForeColor = System.Drawing.Color.Salmon;
                numm.ForeColor = System.Drawing.Color.Salmon;

            }
            else
            {
                er_heure.Hide();
                numh.ForeColor = System.Drawing.Color.Black;
                numm.ForeColor = System.Drawing.Color.Black;

            }

            if (Verif.verifAlpha(PetName.Text) == false)
            {
                i = 1;
                er_petnamereminder.Show();
                PetName.Text = "";
                PetName.ForeColor = System.Drawing.Color.Salmon;
            }
            else
            {
                er_petnamereminder.Hide();
                PetName.ForeColor = System.Drawing.Color.Black;
            }

            if (Verif.verifDigitOrAlpha(remname.Text) == false)
            {
                i = 1;
                er_namereminder.Show();
                remname.Text = "";
                remname.ForeColor = System.Drawing.Color.Salmon;
            }
            else
            {
                er_namereminder.Hide();
                remname.ForeColor = System.Drawing.Color.Black;
            }

            if (i == 0)
            {
                try
                {
                    petreminder p = new petreminder();
                    p.Id_User = sign_in.getUserId();
                    p.RemName = remname.Text;
                    p.Name = PetName.Text;
                    p.Notes = remnote.Text;
                    p.State = "waiting";
                    DateTime dt = new DateTime(remdate.Value.Year, remdate.Value.Month, remdate.Value.Day, int.Parse(numh.Text), int.Parse(numm.Text), 0);
                    p.remdate = dt;
                    DialogResult dialogResult = MessageBox.Show("Sure", "are you sure to Add...", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        Pets.dbnadhemni.petreminder.InsertOnSubmit(p);
                        Pets.dbnadhemni.SubmitChanges();
                        MessageBox.Show("Reminder added with success...");
                        datafill();

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            remname.Text = "";
            PetName.Text = "";
            remnote.Text = "";
            numh.Text = "";
            numm.Text = "";
            etat.SelectedIndex = 0;
            remdate.Value = DateTime.Now;

            etat.SelectedIndex = 0;

        }
        private void AddPet_Click(object sender, EventArgs e)
        {
            int i = 0;

            if (dt_birth.Value.CompareTo(DateTime.Today) >= 0)
            {
                i = 1;
                er1_birthdate.Show();
                dt_birth.Value = DateTime.Now;
                dt_birth.ForeColor = System.Drawing.Color.Salmon;
            }
            else
            {
                er1_birthdate.Hide();
                dt_birth.ForeColor = System.Drawing.Color.Black;
            }
            if (combo_type.Text == "")
            {
                i = 1;
                er1_type.Show();
                combo_type.Text = "";
                combo_type.ForeColor = System.Drawing.Color.Salmon;

            }
            else
            {
                er1_type.Hide();
                combo_type.ForeColor = System.Drawing.Color.Black;

            }

            if (Verif.verifAlpha(txt_name.Text) == false)
            {
                i = 1;
                er1_name.Show();
                txt_name.Text = "";
                txt_name.ForeColor = System.Drawing.Color.Salmon;
            }
            else
            {
                er1_name.Hide();
                txt_name.ForeColor = System.Drawing.Color.Black;
            }

            if (Verif.verifAlpha(txt_veto_name.Text) == false)
            {
                i = 1;
                er1_vetoname.Show();
                txt_veto_name.Text = "";
                txt_veto_name.ForeColor = System.Drawing.Color.Salmon;
            }
            else
            {
                er1_vetoname.Hide();
                txt_veto_name.ForeColor = System.Drawing.Color.Black;
            }
            if (Verif.verifDigit(txt_veto_number.Text) == false)
            {
                i = 1;
                er1_vetonumb.Show();
                txt_veto_number.Text = "";
                txt_veto_number.ForeColor = System.Drawing.Color.Salmon;
            }
            else
            {
                er1_vetonumb.Hide();
                txt_veto_number.ForeColor = System.Drawing.Color.Black;
            }
            bool isNullOrEmpty = img_pet == null || img_pet.Image == null;

            if (isNullOrEmpty)
            {
                i = 1;
                er1_img.Show();
                img_pet.ForeColor = System.Drawing.Color.Salmon;
            }
            else
            {
                er1_img.Hide();
                img_pet.ForeColor = System.Drawing.Color.Black;
            }
            if (i == 0)
            {
                try
                {
                    byte[] file_bite = ImageToByteArray(img_pet.Image);
                    System.Data.Linq.Binary file_binary = new System.Data.Linq.Binary(file_bite);
                    Pet p = new Pet();
                    p.Id_User = sign_in.getUserId();
                    p.type = combo_type.Text;
                    p.Name = txt_name.Text;
                    p.birthday = dt_birth.Value;
                    p.veto_name = txt_veto_name.Text;
                    p.veto_number = txt_veto_number.Text;
                    p.photo = file_binary;
                    DialogResult dialogResult = MessageBox.Show("Sure", "are you sure to Add...", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        Pets.dbnadhemni.Pet.InsertOnSubmit(p);
                        Pets.dbnadhemni.SubmitChanges();
                        MessageBox.Show("Pet added with success...");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                combo1();
                txt_name.Text = "";
                img_pet.Image = null;
                dt_birth.Value = DateTime.Now;
                combo_type.Text = "";
                txt_veto_name.Text = "";
                txt_veto_number.Text = "";
                combo_type.Text = "";
            }


        }

        private void AddPetBox_Click(object sender, EventArgs e)
        {

        }

        private void historyPet_Click_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        String ImgUrl = null;
        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    ImgUrl = ofd.FileName;
                    img_pet.Image = Image.FromFile(ofd.FileName);
                }
            }
        }
        private byte[] ImageToByteArray (System.Drawing.Image imageIn)
        {
            using (MemoryStream ms  = new MemoryStream())
            {

                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                return ms.ToArray();
                   
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
         


        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void UpdatePet_Click(object sender, EventArgs e)
        {
            int i = 0;
            
          
            if (dt_birth.Value.CompareTo(DateTime.Today) >= 0)
            {
                i = 1;
                er1_birthdate.Show();
                dt_birth.Value = DateTime.Now;
                dt_birth.ForeColor = System.Drawing.Color.Salmon;
            }
            else
            {
                er1_birthdate.Hide();
                dt_birth.ForeColor = System.Drawing.Color.Black;
            }
            if (combo_type.Text == "")
            {
                i = 1;
                er1_type.Show();
                combo_type.Text = "";
                combo_type.ForeColor = System.Drawing.Color.Salmon;

            }
            else
            {
                er1_type.Hide();
                combo_type.ForeColor = System.Drawing.Color.Black;

            }

            if (Verif.verifAlpha(txt_name.Text) == false)
            {
                i = 1;
                er1_name.Show();
                txt_name.Text = "";
                txt_name.ForeColor = System.Drawing.Color.Salmon;
            }
            else
            {
                er1_name.Hide();
                txt_name.ForeColor = System.Drawing.Color.Black;
            }

            if (Verif.verifAlpha(txt_veto_name.Text) == false)
            {
                i = 1;
                er1_vetoname.Show();
                txt_veto_name.Text = "";
                txt_veto_name.ForeColor = System.Drawing.Color.Salmon;
            }
            else
            {
                er1_vetoname.Hide();
                txt_veto_name.ForeColor = System.Drawing.Color.Black;
            }
            if (Verif.verifDigit(txt_veto_number.Text) == false)
            {
                i = 1;
                er1_vetonumb.Show();
                txt_veto_number.Text = "";
                txt_veto_number.ForeColor = System.Drawing.Color.Salmon;
            }
            else
            {
                er1_vetonumb.Hide();
                txt_veto_number.ForeColor = System.Drawing.Color.Black;
            }
            bool isNullOrEmpty = img_pet == null || img_pet.Image == null;

            if (isNullOrEmpty)
            {
                i = 1;
                er1_img.Show();
                img_pet.ForeColor = System.Drawing.Color.Salmon;
            }
            else
            {
                er1_img.Hide();
                img_pet.ForeColor = System.Drawing.Color.Black;
            }
            if (i == 0)
            {
                byte[] file_bite = ImageToByteArray(img_pet.Image);

                String pett = comboBox1.Text as String;
                var peet = (from p in dbnadhemni.Pet
                            where p.Name == pett
                            select p).Single();
                try
                {
                    peet.Id_User = U_Id;
                    peet.type = combo_type.Text;
                    peet.Name = txt_name.Text;
                    peet.birthday = dt_birth.Value;
                    peet.veto_name = txt_veto_name.Text;
                    peet.veto_number = txt_veto_number.Text;
                    DialogResult dialogResult = MessageBox.Show("Sure", "are you sure to update...", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        Pets.dbnadhemni.SubmitChanges();
                        MessageBox.Show("Pet Updated with success...");

                        combo1();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void DeletePet_Click(object sender, EventArgs e)
        {
           


            if (comboBox1.Text != null)
            {
                String pett = comboBox1.Text as String;
                var peet = (from p in dbnadhemni.Pet
                            where p.Name == pett
                            select p).Single();
                DialogResult dialogResult = MessageBox.Show("Sure", "are you sure to Delete...", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    dbnadhemni.Pet.DeleteOnSubmit(peet);
                    dbnadhemni.SubmitChanges();
                    MessageBox.Show("Row Deleted Successfully.");
                    combo1();
                    txt_name.Text = "";
                    img_pet.Image = null;
                    dt_birth.Value = DateTime.Now;
                    combo_type.Text = "";
                    txt_veto_name.Text = "";
                    txt_veto_number.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Please select pet's name.");
            }
          
        }
        public Image BinaryToImage(byte[] byteArrayIn)
        {
            using (MemoryStream ms = new MemoryStream(byteArrayIn))
            {
                Image img = Image.FromStream(ms);
                return img;
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           

            if(comboBox1.Text != null)
            {
                String pett = comboBox1.Text as String;
                var peet = (from p in dbnadhemni.Pet
                            where p.Name == pett
                            select p).Single();
                txt_name.Text = peet.Name;
                img_pet.Image = BinaryToImage(peet.photo.ToArray());
                dt_birth.Value = Convert.ToDateTime(peet.birthday);
                combo_type.Text = peet.type;
                txt_veto_name.Text = peet.veto_name;
                txt_veto_number.Text = Convert.ToString( peet.veto_number);
                         }
            else
            {
                MessageBox.Show("Please select pet's name.");
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                try { 
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    ImgUrl = ofd.FileName;
                    img_pet.Image = Image.FromFile(ofd.FileName);
                }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void txt_veto_number_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void gunaCirclePictureBox2_Click_1(object sender, EventArgs e)
        {

            int i = 0;
            if (remdate.Value.CompareTo(DateTime.Today) <= 0)
            {
                i = 1;
                er_datereminder.Show();
                remdate.Value = DateTime.Now;
                remdate.ForeColor = System.Drawing.Color.Salmon;
            }
            else
            {
                er_datereminder.Hide();
                remdate.ForeColor = System.Drawing.Color.Black;
            }

            if (Verif.verifAlpha(PetName.Text) == false)
            {
                i = 1;
                er_petnamereminder.Show();
                PetName.Text = "";
                PetName.ForeColor = System.Drawing.Color.Salmon;
            }
            else
            {
                er_petnamereminder.Hide();
                PetName.ForeColor = System.Drawing.Color.Black;
            }

            if (Verif.verifDigitOrAlpha(remname.Text) == false)
            {
                i = 1;
                er_namereminder.Show();
                remname.Text = "";
                remname.ForeColor = System.Drawing.Color.Salmon;
            }
            else
            {
                er_namereminder.Hide();
                remname.ForeColor = System.Drawing.Color.Black;
            }

            if (i == 0)
            {
                try
                {
                    string firstCellValue = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
                    var p = (from y in dbnadhemni.petreminder
                             where y.Id == int.Parse(firstCellValue)
                             select y).Single();
                    p.Id_User = sign_in.getUserId();
                    p.RemName = remname.Text;
                    p.Name = PetName.Text;
                    p.Notes = remnote.Text;
                    p.State = etat.Text;

                    DateTime dt = new DateTime(remdate.Value.Year, remdate.Value.Month, remdate.Value.Day, int.Parse(numh.Text), int.Parse(numm.Text), 0);
                    p.remdate = dt;
                    DialogResult dialogResult = MessageBox.Show("Sure", "are you sure to Update...", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        Pets.dbnadhemni.SubmitChanges();
                        MessageBox.Show("Reminder Updated with success...");
                        datafill();

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
                var p = (from y in dbnadhemni.petreminder
                         where y.Id == int.Parse(firstCellValue)
                         select y).Single();
                DialogResult dialogResult = MessageBox.Show("Sure", "are you sure to Delete...", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    dbnadhemni.petreminder.DeleteOnSubmit(p);
                    dbnadhemni.SubmitChanges();
                    MessageBox.Show("Row Deleted Successfully.");
                    datafill();
                    remname.Text = "";
                    PetName.Text = "";
                    remnote.Text = "";
                    numh.Text = "";
                    numm.Text = "";
                    remdate.Value = DateTime.Now;
                    etat.SelectedIndex = 0;

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void dataGridView1_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            selectedRow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRow];
                remname.Text =  row.Cells[1].Value.ToString();
                PetName.Text = row.Cells[2].Value.ToString();
                remnote.Text = row.Cells[4].Value.ToString();
                numh.Text = Convert.ToString(Convert.ToDateTime(row.Cells[3].Value).Hour);
                numm.Text = Convert.ToString(Convert.ToDateTime(row.Cells[3].Value).Minute);
                remdate.Value = Convert.ToDateTime(row.Cells[3].Value);
                etat.Enabled = true;
            }
        }

        private void dataGridView1_CellContentClick_3(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void add_Click(object sender, EventArgs e)
        {
            int i = 0;
            if (remdate.Value.CompareTo(DateTime.Today) <= 0)
            {
                i = 1;
                er_datereminder.Show();
                remdate.Value = DateTime.Now;
                remdate.ForeColor = System.Drawing.Color.Salmon;
            }
            else
            {
                er_datereminder.Hide();
                remdate.ForeColor = System.Drawing.Color.Black;
            }
            if (numh.Text == "" || numm.Text == "")
            {
                i = 1;
                er_heure.Show();
                numh.ForeColor = System.Drawing.Color.Salmon;
                numm.ForeColor = System.Drawing.Color.Salmon;

            }
            else
            {
                er_heure.Hide();
                numh.ForeColor = System.Drawing.Color.Black;
                numm.ForeColor = System.Drawing.Color.Black;

            }

            if (Verif.verifAlpha(PetName.Text) == false)
            {
                i = 1;
                er_petnamereminder.Show();
                PetName.Text = "";
                PetName.ForeColor = System.Drawing.Color.Salmon;
            }
            else
            {
                er_petnamereminder.Hide();
                PetName.ForeColor = System.Drawing.Color.Black;
            }

            if (Verif.verifDigitOrAlpha(remname.Text) == false)
            {
                i = 1;
                er_namereminder.Show();
                remname.Text = "";
                remname.ForeColor = System.Drawing.Color.Salmon;
            }
            else
            {
                er_namereminder.Hide();
                remname.ForeColor = System.Drawing.Color.Black;
            }

            if (i == 0)
            {
                try
                {
                    petreminder p = new petreminder();
                    p.Id_User = U_Id;
                    p.RemName = remname.Text;
                    p.Name = PetName.Text;
                    p.Notes = remnote.Text;
                    DateTime dt = new DateTime(remdate.Value.Year, remdate.Value.Month, remdate.Value.Day, int.Parse(numh.Text), int.Parse(numm.Text), 0);
                    p.remdate = dt;
                    DialogResult dialogResult = MessageBox.Show("Sure", "are you sure to Add...", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        Pets.dbnadhemni.petreminder.InsertOnSubmit(p);
                        Pets.dbnadhemni.SubmitChanges();
                        MessageBox.Show("Reminder added with success...");
                        datafill();

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        
        private void btn_save_update_Click(object sender, EventArgs e)
        {
         
          
            int i = 0;

            if (dt_birth.Value.CompareTo(DateTime.Today) >= 0)
            {
                i = 1;
                er1_birthdate.Show();
                dt_birth.Value = DateTime.Now;
                dt_birth.ForeColor = System.Drawing.Color.Salmon;
            }
            else
            {
                er1_birthdate.Hide();
                dt_birth.ForeColor = System.Drawing.Color.Black;
            }
            if (combo_type.Text == "")
            {
                i = 1;
                er1_type.Show();
                combo_type.Text = "";
                combo_type.ForeColor = System.Drawing.Color.Salmon;

            }
            else
            {
                er1_type.Hide();
                combo_type.ForeColor = System.Drawing.Color.Black;

            }

            if (Verif.verifAlpha(txt_name.Text) == false)
            {
                i = 1;
                er1_name.Show();
                txt_name.Text = "";
                txt_name.ForeColor = System.Drawing.Color.Salmon;
            }
            else
            {
                er1_name.Hide();
                txt_name.ForeColor = System.Drawing.Color.Black;
            }

            if (Verif.verifAlpha(txt_veto_name.Text) == false)
            {
                i = 1;
                er1_vetoname.Show();
                txt_veto_name.Text = "";
                txt_veto_name.ForeColor = System.Drawing.Color.Salmon;
            }
            else
            {
                er1_vetoname.Hide();
                txt_veto_name.ForeColor = System.Drawing.Color.Black;
            }
            if (Verif.verifDigit(txt_veto_number.Text) == false)
            {
                i = 1;
                er1_vetonumb.Show();
                txt_veto_number.Text = "";
                txt_veto_number.ForeColor = System.Drawing.Color.Salmon;
            }
            else
            {
                er1_vetonumb.Hide();
                txt_veto_number.ForeColor = System.Drawing.Color.Black;
            }
            bool isNullOrEmpty = img_pet == null || img_pet.Image == null;

            if (isNullOrEmpty)
            {
                i = 1;
                er1_img.Show();
                img_pet.ForeColor = System.Drawing.Color.Salmon;
            }
            else
            {
                er1_img.Hide();
                img_pet.ForeColor = System.Drawing.Color.Black;
            }
            if (i == 0)
            {
                try
                {
                    byte[] file_bite = ImageToByteArray(img_pet.Image);
                    System.Data.Linq.Binary file_binary = new System.Data.Linq.Binary(file_bite);
                    Pet p = new Pet();
                    p.Id_User = U_Id;
                    p.type = combo_type.Text;
                    p.Name = txt_name.Text;
                    p.birthday = dt_birth.Value;
                    p.veto_name = txt_veto_name.Text;
                    p.veto_number = txt_veto_number.Text;
                    p.photo = file_binary;
                    DialogResult dialogResult = MessageBox.Show("Sure", "are you sure to Add...", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        Pets.dbnadhemni.Pet.InsertOnSubmit(p);
                        Pets.dbnadhemni.SubmitChanges();
                        MessageBox.Show("Pet added with success...");
                        combo1();
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

            Treasury.exportDataGridViewtoPDF(dataGridView1, "Pets", "myPets");
        }

        private void etat_SelectedIndexChanged(object sender, EventArgs e)
        {

            etat.Enabled = false;

        }
    }
}
