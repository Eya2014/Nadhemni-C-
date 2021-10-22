using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;
using PdfSharp.Drawing;
using System.Drawing.Imaging;
using ScreenToPDF;

namespace Nadhemni
{
    public partial class planning : Form
    {
        internal static NadhemniDBDataContext dbnadhemni = new NadhemniDBDataContext();
        private List<String> lst = new List<String>();
        ScreenCapture capScreen = new ScreenCapture();

        /*   private static void SendCompletedCallBack(object sender , AsyncCompletedEventArgs e)
           {
               if (e.Cancelled)
                   MessageBox.Show("Send canceled..");
               else if (e.Error != null)
                   MessageBox.Show("Error !!");
               else
                   MessageBox.Show("Sent Successfilly !!");
           }

           public void sendmail(string mail , string message)
           {
               NetworkCredential login = new NetworkCredential("NadhemniMail","2lfig2 isg");
               SmtpClient client = new SmtpClient("smtp.gmail.com");
               client.Port = 587;
               client.EnableSsl = true;
               client.Credentials = login;
               MailMessage msg = new MailMessage {From = new MailAddress("NadhemniMail"+ "@gmail.com","Nadhemni" , Encoding.UTF8) };
               msg.To.Add(new MailAddress(mail));
               msg.Subject = "Reminder From Nadhemni.";
               msg.Body = message;
               msg.BodyEncoding = Encoding.UTF8;
               msg.IsBodyHtml = true;
               msg.Priority = MailPriority.Normal;
               msg.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
               client.SendCompleted += new SendCompletedEventHandler(SendCompletedCallBack);
                      string userState = "Sending ...";
               client.SendAsync(msg, userState);
           }
           public void fct_mailing()
           {
               String mail,msg;
               try
               {

                   var lstTasks = from x in planning.dbnadhemni.Planning_No

                                  select new
                                  {
                                      id = x.Id_user,
                                      tr = x.Titre,
                                      dt = x.DateEvent
                                  };
                   foreach (var item in lstTasks)
                   {


                       Users user = sign_in.nadhemniDB.Users.Single<Users>(x => x.Id_user == item.id);
                       mail = user.Email;
                       msg = " Helloo "+user.FirstName+" "+user.LastName + "Nadhemni sent this message as a reminder of " + item.tr + " on : " + item.dt;
                       sendmail(mail,msg);
                    }
               }
               catch (Exception e)
               {
                   MessageBox.Show(e.Message + "");
               }

           }*/
        /*  private void countE()
          {
              int i = 0;
              try
              {
                  String sql = "SELECT Titre FROM Planning";
                  SqlCommand comand = new SqlCommand(sql);
                  SqlDataReader reader = comand.ExecuteReader();
                  while (reader.Read())
                  {
                      i++;
                  }
                  MessageBox.Show(i + "");
              }
              catch (Exception e)
              {
                  MessageBox.Show(e + "");
              }

          }
          */
        private SpeechRec sr = new SpeechRec(); 
        public planning()
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
                    sr.speak("go to family", "test2");
                    depart f = new depart();
                    f.Show();
                    this.Hide();
                    sr.desable();
                    break;
                case "health":
                    sr.speak("go to Health", "test2");
                    healthy h = new healthy();
                    h.Show();
                    this.Hide();
                    sr.desable();
                    break;
                case "job":
                    sr.speak("go to Job", "test2");
                    Job j = new Job("select");
                    j.Show();
                    this.Hide();
                    sr.desable();
                    break;
                case "pets":
                    sr.speak("go to Pets", "test2");
                    Pets p = new Pets();
                    p.Show();
                    this.Hide();
                    sr.desable();
                    break;
                case "beauty":
                    sr.speak("go to Beauty", "test2");
                    Beauty b = new Beauty("select");
                    b.Show();
                    this.Hide();
                    sr.desable();
                    break;
                case "event":
                    sr.speak("go to Event", "test2");
                    events ev = new events();
                    ev.Show();
                    this.Hide();
                    sr.desable();
                    break;
                case "bank":
                    sr.speak("go to Peggy Bank", "test2");
                    Treasury t = new Treasury();
                    t.Show();
                    this.Hide();
                    sr.desable();
                    break;
                case "bills":
                    sr.speak("go to Bills", "test2");
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
            sr.speak("Hello !", "test2");
            sr.enable();
        }

        private void gunaImageButton7_Click_1(object sender, EventArgs e)
        {
            sr.desable();
        }






        private void gunaComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void gunaCheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Guna.UI.WinForms.GunaLineTextBox t1 = new Guna.UI.WinForms.GunaLineTextBox();
            t1.Size = new System.Drawing.Size(100, 10);
            t1.Location = new System.Drawing.Point(300,30);
            t1.BackColor = System.Drawing.SystemColors.Control;
            menu.Controls.Add(t1);
        }

        private void gunaComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            Guna.UI.WinForms.GunaLineTextBox t1 = new Guna.UI.WinForms.GunaLineTextBox();
            t1.Size = new System.Drawing.Size(100, 10);
            t1.Location = new System.Drawing.Point(300, 30);
            t1.BackColor = System.Drawing.SystemColors.Control;
            menu.Controls.Add(t1);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void planning_Load(object sender, EventArgs e)
        {
            // TODO: cette ligne de code charge les données dans la table 'nadhemniDataSet1._Planning_No'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            this.planning_NoTableAdapter.Fill(this.nadhemniDataSet1._Planning_No);
            // TODO: cette ligne de code charge les données dans la table 'nadhemniDataSet1._Planning_date'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            this.planning_dateTableAdapter.Fill(this.nadhemniDataSet1._Planning_date);
            // TODO: cette ligne de code charge les données dans la table 'nadhemniDataSet1.Planning'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            //this.planningTableAdapter.Fill(this.nadhemniDataSet1.Planning);
           

            var affected = from a in sign_in.nadhemniDB.GetTable<Planning>()
                           where (a.Id_user == sign_in.getUserId())
                           select new { a.nom, a.DateEvent, a.et };
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = affected;
            button1.Enabled = false;
            button2.Enabled = true;
            button3.Enabled = true;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           /*chart1.Series["date"].XValueMember = "DateEvent";
            chart1.Series["date"].YValueMembers = "Titre ";
            chart1.DataSource = nadhemniDataSet1.Planning;
            chart1.DataBind();*/
            //this.countE();

        }

        private void gunaCircleButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();       
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            var affected = from a in sign_in.nadhemniDB.GetTable<Planning>()
                           where (a.Id_user == sign_in.getUserId())
                           select new { a.nom, a.DateEvent, a.et };
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = affected;
            button1.Enabled = false;
            button2.Enabled = true;
            button3.Enabled = true;

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            var affected = from a in sign_in.nadhemniDB.GetTable<Planning>()
                           where (a.et == "affected"&& a.Id_user == sign_in.getUserId())
                           select new { a.nom, a.DateEvent, a.et };
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = affected;
            button2.Enabled = false;
            button1.Enabled = true;
            button3.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var affected = from a in sign_in.nadhemniDB.GetTable<Planning>()
                           where ( a.et != "affected" && a.Id_user == sign_in.getUserId())
                           select new { a.nom, a.DateEvent, a.et };
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = affected;
            button2.Enabled = true;
            button1.Enabled = true;
            button3.Enabled = false;
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //fct_mailing();
        }

        private void button5_Click(object sender, EventArgs e)
        {
          
          

        }

        private void gunaGradientButton1_Click(object sender, EventArgs e)
        {
            depart d = new depart();
            d.Show();
            this.Hide();
        }

        private void cbCHOIX_SelectedIndexChanged(object sender, EventArgs e)
        {   if(cbCHOIX.SelectedItem== "Jour")
            {
               

            DateTime dt = DateTime.Now;
            var selectquery =
              from a in sign_in.nadhemniDB.GetTable<Planning>()
              where (((a.DateEvent) == dt.Date) && (a.Id_user == sign_in.getUserId()))
              select new { a.nom, a.DateEvent }
           ;
            
            int y = 160;
            foreach (var cn in selectquery)
            {
                Label l = new Label();
                l.Text = cn.nom;
                l.Location = new System.Drawing.Point(550, y);
                l.Size = new System.Drawing.Size(80, 26);
                l.BackColor = System.Drawing.SystemColors.Control;

                TextBox t = new TextBox();
                t.Text = cn.DateEvent + "";
                t.Location = new System.Drawing.Point(640, y);
                t.Size = new System.Drawing.Size(80, 26);
                t.BackColor = System.Drawing.SystemColors.Control;
                y = y + 35;
                this.Controls.Add(l);
                this.Controls.Add(t);
                   
                   
            }
            }
            else
            {
               
                DateTime dt = DateTime.Now;
                var selectquery =
                  from a in sign_in.nadhemniDB.GetTable<Planning>()
                  where (((a.DateEvent.Value.Month) == dt.Date.Month) && (a.Id_user == sign_in.getUserId()))
                  select new { a.nom, a.DateEvent }
               ;
                int x = 650;
                int y = 160;
                foreach (var cn in selectquery)
                {
                    Label l = new Label();
                    l.Text = cn.nom;
                    l.Location = new System.Drawing.Point(730, y);
                    l.Size = new System.Drawing.Size(80, 26);
                    l.BackColor = System.Drawing.SystemColors.Control;

                    TextBox t = new TextBox();
                    t.Text = cn.DateEvent + "";
                    t.Location = new System.Drawing.Point(820, y);
                    t.Size = new System.Drawing.Size(80, 26);
                    t.BackColor = System.Drawing.SystemColors.Control;
                    y = y + 35;
                    this.Controls.Add(l);
                    this.Controls.Add(t);
                  
                }
            }
        }
        private static void SendCompletedCallBack(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
                MessageBox.Show("Send canceled..");
            else if (e.Error != null)
                MessageBox.Show("Error !!");
            else
                MessageBox.Show("Sent Successfully !!");
        }

        public void sendmail(string mail , string message)
        {
            NetworkCredential login = new NetworkCredential("NadhemniMail","2lfig2 isg");
            SmtpClient client = new SmtpClient("smtp.gmail.com");
            client.Port = 587;
            client.EnableSsl = true;
            client.Credentials = login;
            MailMessage msg = new MailMessage {From = new MailAddress("NadhemniMail"+ "@gmail.com","Nadhemni" , Encoding.UTF8) };
            msg.To.Add(new MailAddress(mail));
            msg.Subject = "Reminder From Nadhemni.";
            msg.Body = message;
            msg.BodyEncoding = Encoding.UTF8;
            msg.IsBodyHtml = true;
            msg.Priority = MailPriority.Normal;
            msg.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            client.SendCompleted += new SendCompletedEventHandler(SendCompletedCallBack);
                   string userState = "Sending ...";
            client.SendAsync(msg, userState);
        }
        public void fct_mailing()
        {
            String mail,msg;
            try
            {

                var lstTasks = from x in planning.dbnadhemni.Planning_No

                               select new
                               {
                                   id = x.Id_user,
                                   tr = x.Titre,
                                   dt = x.DateEvent
                               };
                foreach (var item in lstTasks)
                {
                   

                    Users user = sign_in.nadhemniDB.Users.Single<Users>(x => x.Id_user == item.id);
                    mail = user.Email;
                    msg = " Helloo "+user.FirstName+" "+user.LastName + "Nadhemni sent this message as a reminder of " + item.tr + " on : " + item.dt;
                    sendmail(mail,msg);
                 }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + "");
            }

        }
  private void countE()
  {
      int i = 0;
      try
      {
          String sql = "SELECT Titre FROM Planning";
          SqlCommand comand = new SqlCommand(sql);
          SqlDataReader reader = comand.ExecuteReader();
          while (reader.Read())
          {
              i++;
          }
          MessageBox.Show(i + "");
      }
      catch (Exception e)
      {
          MessageBox.Show(e + "");
      }

  }
private void button5_Click_1(object sender, EventArgs e)
{
            fct_mailing();
}

        private void button4_Click_1(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void gunaImageButton1_Click(object sender, EventArgs e)
        {
            sign_in.setUserId(0);
            sign_in s = new sign_in();
            this.Hide();
            s.Show();
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
        private void captureScreen()
        {
            try
            {
                // Call the CaptureAndSave method from the ScreenCapture class 
                // And create a temporary file in desktop
                capScreen.CaptureAndSave(@"C:\Users\hp\Desktop\planning.png", CaptureMode.Window, ImageFormat.Png);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
            }
        }

        private void imprimer_Click(object sender, EventArgs e)
        {// Call your captureScreen() function
            captureScreen();

            // Create new pdf document and page
            PdfSharp.Pdf.PdfDocument doc = new PdfSharp.Pdf.PdfDocument();

            PdfSharp.Pdf.PdfPage oPage = new PdfSharp.Pdf.PdfPage();

            // Add the page to the pdf document and add the captured image to it
            doc.Pages.Add(oPage);
            XGraphics xgr = XGraphics.FromPdfPage(oPage);
            XImage img = XImage.FromFile(@"C:\Users\hp\Desktop\planning.png");
            if (img.PixelWidth > img.PixelHeight)
                oPage.Orientation = PdfSharp.PageOrientation.Landscape;
            else
                oPage.Orientation = PdfSharp.PageOrientation.Portrait;
            xgr.DrawImage(img, 0, 0);

            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = ("PDF File|*.pdf");
            DialogResult btnSave = saveFileDialog.ShowDialog();
            if (btnSave.Equals(DialogResult.OK))
            {
                doc.Save(saveFileDialog.FileName);
                doc.Close();
            }

            // I used the Dispose() function to be able to 
            // save the same form again, in case some values have changed.
            // When I didn't use the function, an GDI+ error occurred.
            img.Dispose();

        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            Stat s = new Stat();
            s.Show();
            
        }

        private void menu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaButton1_Click_1(object sender, EventArgs e)
        {
            var affected = from a in sign_in.nadhemniDB.GetTable<Planning>()
                           where (a.nom == tsearch.Text && a.Id_user == sign_in.getUserId())
                           select new { a.nom, a.DateEvent, a.et };
            foreach(var i in affected)
            {
                tet.Text = i.et;
                tname.Text = i.nom; 
                tdate.Value = Convert.ToDateTime(i.DateEvent);
            }
        }

        private void tsearch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
