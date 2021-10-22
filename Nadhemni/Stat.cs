using PdfSharp.Drawing;
using ScreenToPDF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nadhemni
{
    public partial class Stat : Form
    {
        ScreenCapture capScreen = new ScreenCapture();

        public Stat()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Stat_Load(object sender, EventArgs e)
        {

            int delay = (from a in sign_in.nadhemniDB.GetTable<Planning>()
                         where ((a.et == "delay") && (a.Id_user == sign_in.getUserId()))
                         select new { a.nom, a.DateEvent, a.et }).Count();
            int cancel = (from a in sign_in.nadhemniDB.GetTable<Planning>()
                         where ((a.et == "cancel") && (a.Id_user == sign_in.getUserId()))
                         select new { a.nom, a.DateEvent, a.et }).Count();
            int affecté = (from a in sign_in.nadhemniDB.GetTable<Planning>()
                           where ((a.et == "affected") && (a.Id_user == sign_in.getUserId()))
                           select new { a.nom, a.DateEvent, a.et }).Count();
            int wait = (from a in sign_in.nadhemniDB.GetTable<Planning>()
                           where ((a.et == "waiting") && (a.Id_user == sign_in.getUserId()))
                           select new { a.nom, a.DateEvent, a.et }).Count();

            this.chart1.Series["real"].Points.AddXY("delay", delay);
            this.chart1.Series["real"].Points.AddXY("affected", affecté);
            this.chart1.Series["real"].Points.AddXY("canceled", cancel);
            this.chart1.Series["real"].Points.AddXY("waiting", wait);
            chart1.Series["real"].Points[3].LabelBackColor = Color.White;
            chart1.Series["real"].Points[2].LabelBackColor = Color.White;
            chart1.Series["real"].Points[0].LabelBackColor = Color.White;
            chart1.Series["real"].Points[1].LabelBackColor = Color.White;
            var affected = from a in sign_in.nadhemniDB.GetTable<Planning>()
                           where ((a.et == "affected") && (a.Id_user == sign_in.getUserId()))
                           select new { a.nom, a.DateEvent, a.et };
            int j=0, f=0, m=0, af=0, ma=0, ju=0, jui=0, oa=0, sep=0, oct=0, nov=0, dec=0;
            foreach(var s in affected)
            {
                var month = s.DateEvent.Value.Month;
                switch(month)
                {
                    case 1 :
                        j++; 
                        break;
                    case 2:
                        f++;
                        break;
                    case 3:
                        m++;
                        break;
                    case 4:
                        af++;
                        break;
                    case 5:
                        ma++;
                        break;
                    case 6:
                        ju++;
                        break;
                    case 7:
                        jui++;
                        break;
                    case 8:
                        oa++;
                        break;
                    case 9:
                        sep++;
                        break;
                    case 10:
                        oct++;
                        break;
                    case 11:
                        nov++;
                        break;
                    case 12:
                        dec++;
                        break;
               }
            }
            this.chart2.Series["affected"].Points.AddXY("January ", j);
            this.chart2.Series["affected"].Points.AddXY("February ", f);
            this.chart2.Series["affected"].Points.AddXY("March ", m);
            this.chart2.Series["affected"].Points.AddXY("April ", af);
            this.chart2.Series["affected"].Points.AddXY("May ", ma);
            this.chart2.Series["affected"].Points.AddXY("June ", ju);
            this.chart2.Series["affected"].Points.AddXY("July", jui);
            this.chart2.Series["affected"].Points.AddXY("August", oa);
            this.chart2.Series["affected"].Points.AddXY("September", sep);
            this.chart2.Series["affected"].Points.AddXY("October", oct);
            this.chart2.Series["affected"].Points.AddXY("November ", nov);
            this.chart2.Series["affected"].Points.AddXY("December", dec);
            var canceled = from a in sign_in.nadhemniDB.GetTable<Planning>()
                           where ((a.et == "cancel") && (a.Id_user == sign_in.getUserId()))
                           select new { a.nom, a.DateEvent, a.et };
            int j1 = 0, f1 = 0, m1 = 0, af1 = 0, ma1 = 0, ju1 = 0, jui1 = 0, oa1 = 0, sep1 = 0, oct1 = 0, nov1 = 0, dec1 = 0;
            foreach (var s in canceled)
            {
                var month = s.DateEvent.Value.Month;
                switch (month)
                {
                    case 1:
                        j1++;
                        break;
                    case 2:
                        f1++;
                        break;
                    case 3:
                        m1++;
                        break;
                    case 4:
                        af1++;
                        break;
                    case 5:
                        ma1++;
                        break;
                    case 6:
                        ju1++;
                        break;
                    case 7:
                        jui1++;
                        break;
                    case 8:
                        oa1++;
                        break;
                    case 9:
                        sep1++;
                        break;
                    case 10:
                        oct1++;
                        break;
                    case 11:
                        nov1++;
                        break;
                    case 12:
                        dec1++;
                        break;
                }
            }
            this.chart3.Series["Canceled"].Points.AddXY("January ", j1);
            this.chart3.Series["Canceled"].Points.AddXY("February ", f1);
            this.chart3.Series["Canceled"].Points.AddXY("March ", m1);
            this.chart3.Series["Canceled"].Points.AddXY("April ", af1);
            this.chart3.Series["Canceled"].Points.AddXY("May ", ma1);
            this.chart3.Series["Canceled"].Points.AddXY("June ", ju1);
            this.chart3.Series["Canceled"].Points.AddXY("July", jui1);
            this.chart3.Series["Canceled"].Points.AddXY("August", oa1);
            this.chart3.Series["Canceled"].Points.AddXY("September", sep1);
            this.chart3.Series["Canceled"].Points.AddXY("October", oct1);
            this.chart3.Series["Canceled"].Points.AddXY("November ", nov1);
            this.chart3.Series["Canceled"].Points.AddXY("December", dec1);

            var delayed = from a in sign_in.nadhemniDB.GetTable<Planning>()
                           where ((a.et == "delay") && (a.Id_user == sign_in.getUserId()))
                           select new { a.nom, a.DateEvent, a.et };
            int j12 = 0, f12 = 0, m12 = 0, af12 = 0, ma12 = 0, ju12 = 0, jui12 = 0, oa12 = 0, sep12 = 0, oct12 = 0, nov12 = 0, dec12 = 0;
            foreach (var s in canceled)
            {
                var month = s.DateEvent.Value.Month;
                switch (month)
                {
                    case 1:
                        j12++;
                        break;
                    case 2:
                        f12++;
                        break;
                    case 3:
                        m12++;
                        break;
                    case 4:
                        af12++;
                        break;
                    case 5:
                        ma12++;
                        break;
                    case 6:
                        ju12++;
                        break;
                    case 7:
                        jui12++;
                        break;
                    case 8:
                        oa12++;
                        break;
                    case 9:
                        sep12++;
                        break;
                    case 10:
                        oct12++;
                        break;
                    case 11:
                        nov12++;
                        break;
                    case 12:
                        dec12++;
                        break;
                }
            }
            this.chart4.Series["Delayed"].Points.AddXY("January ", j12);
            this.chart4.Series["Delayed"].Points.AddXY("February ", f12);
            this.chart4.Series["Delayed"].Points.AddXY("March ", m12);
            this.chart4.Series["Delayed"].Points.AddXY("April ", af12);
            this.chart4.Series["Delayed"].Points.AddXY("May ", ma12);
            this.chart4.Series["Delayed"].Points.AddXY("June ", ju12);
            this.chart4.Series["Delayed"].Points.AddXY("July", jui12);
            this.chart4.Series["Delayed"].Points.AddXY("August", oa12);
            this.chart4.Series["Delayed"].Points.AddXY("September", sep12);
            this.chart4.Series["Delayed"].Points.AddXY("October", oct12);
            this.chart4.Series["Delayed"].Points.AddXY("November ", nov12);
            this.chart4.Series["Delayed"].Points.AddXY("December", dec12);

        }

        private void gunaCircleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
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
    }
}
