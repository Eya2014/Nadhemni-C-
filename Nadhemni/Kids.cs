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
    public partial class Kids : Form
    {
        private int nbrKids;//how many kids user have
        private String action;
        public Kids(int nbrKids, String action)
        {
            InitializeComponent();
            this.nbrKids = nbrKids;
            viderErrLabel();
            TimeTable.Hide();
            this.action = action;
            if (action == "select")
            {
                update.Show();
                continuee.Hide();
                FillKid();

            }
            else
            {
                update.Hide();
                continuee.Show();
            }
        }

        private void sideMenu_Paint(object sender, PaintEventArgs e)
        {

        }


        private void cmb_study_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_study.Text == "Not studying")
            {
                TimeTable.Hide();
            }
            else
            {
                TimeTable.Show();
            }

        }
        private Boolean VerifKidsControl()
        {
            viderErrLabel();
            Boolean verif = true;
            if (!Verif.verifAlpha(txt_nameKid.Text))
            {
                Err_name.Text = "This name has certain characters that aren't allowed.";
                verif = false;
            }
            if (!Verif.verifDate(gunaDateTimePicker1.Value))
            {
                Err_date.Text = "This date is not allowed.";
                verif = false;
            }
            return verif;
        }
        private void viderErrLabel()
        {
            foreach (Control x in panel1.Controls)
            {
                if (x.Name.StartsWith("Err"))
                {
                    x.Text = "";
                }
            }
        }

        private void continuee_Click(object sender, EventArgs e)
        {
            if (VerifKidsControl())
            {
                try
                {
                    //create the object (insert kids first)
                    Family f = new Family();
                    //get the properties event values from the form
                    f.Id_user = sign_in.getUserId();
                    f.FamilyMember = "Kid";
                    f.Name = txt_nameKid.Text;
                    f.Dbrth = gunaDateTimePicker1.Value.Date;
                    f.study = cmb_study.Text;
                    //add the object to the table 
                    sign_in.nadhemniDB.Family.InsertOnSubmit(f);
                    sign_in.nadhemniDB.SubmitChanges();
                    if (cmb_study.Text != "Not studying")
                    {

                        //create the object
                        TimeTable t = new TimeTable();
                        //get the properties event values from the form
                        for (int i = 1; i < TimeTable.ColumnCount; i++)
                        {
                            for (int k = 1; k < TimeTable.RowCount; k++)
                            {
                                Control txt = TimeTable.GetControlFromPosition(i, k);
                                if (txt.Text != "")
                                {
                                    TimeTable tab = new TimeTable();
                                    tab.id_user = sign_in.getUserId();
                                    //get the last kid added to the collection 
                                    var lst = from x in sign_in.nadhemniDB.Family
                                              where (x.Id_user == sign_in.getUserId())
                                              select x;
                                    if (lst.Count()==0)
                                        tab.Id_Family = 1;
                                    else
                                        tab.Id_Family  = lst.ToArray().Last().id_Family ;
                                        
                                    tab.day = i;
                                    TimeSpan startTime = new TimeSpan(k + 7, 00, 00);
                                    tab.StartTime = startTime;
                                    TimeSpan endTime = new TimeSpan(k + 8, 00, 00);
                                    tab.EndTime = endTime;
                                    tab.content = txt.Text;
                                    //add the object to the table 
                                    sign_in.nadhemniDB.TimeTable.InsertOnSubmit(tab);
                                }
                            }
                        }

                    }
                    //update the data base
                    sign_in.nadhemniDB.SubmitChanges();
                    MessageBox.Show("add done successfully");
                    //if everything is alright move to the next form
                    if (action != "insert")
                    {
                        depart d = new depart();
                        this.Hide();
                        d.Show();
                    }
                    else
                    {

                        //check if user have another kid
                        if (this.nbrKids > 1)
                        {
                            Kids k = new Kids(nbrKids - 1, "insert");
                            k.Show();
                            this.Hide();
                        }
                        else
                        {
                            Job j = new Job("insert");
                            j.Show();
                            this.Hide();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void gunaDateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void FillTimeTable(int id)
        {
            /*foreach (Control x in TimeTable.Controls)
            {
                if(x.Name.StartsWith("guna"))
                x.Enabled=false;
            }*/

            try
            {
                var lst = from x in sign_in.nadhemniDB.TimeTable
                          where (x.id_user == sign_in.getUserId() && x.Id_Family == id)
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

        private void FillKid()
        {
            var lst = from x in sign_in.nadhemniDB.Family
                      where (x.Id_user == sign_in.getUserId() && x.FamilyMember == "Kid")
                      select x;
            Family kid = lst.Skip(nbrKids - 1).FirstOrDefault();
            txt_nameKid.Text = kid.Name;
            gunaDateTimePicker1.Value = kid.Dbrth;
            cmb_study.Text = kid.study;
            if (cmb_study.Text != "Not studying")
            {
                FillTimeTable(kid.id_Family);
                TimeTable.Show();
            }
        }
        private void update_Click_1(object sender, EventArgs e)
        {
            try
            {

                var lst = from x in sign_in.nadhemniDB.Family
                          where (x.Id_user == sign_in.getUserId() && x.FamilyMember == "Kid")
                          select x;
                Family kid = lst.Skip(nbrKids - 1).FirstOrDefault();
                kid.Name = txt_nameKid.Text;
                kid.Dbrth = gunaDateTimePicker1.Value;
                kid.study = cmb_study.Text;
                if (cmb_study.Text != "Not studying")
                {
                    //delete the old records
                    var lst1 = from x in sign_in.nadhemniDB.TimeTable
                               where (x.id_user == kid.id_Family)
                               select x;
                    if (lst1 != null)
                    {
                        foreach (var k in lst1)
                        {
                            sign_in.nadhemniDB.TimeTable.DeleteOnSubmit(k);
                        }
                    }

                    //create the object
                    TimeTable t = new TimeTable();
                    //get the properties event values from the form
                    for (int i = 1; i < TimeTable.ColumnCount; i++)
                    {
                        for (int k = 1; k < TimeTable.RowCount; k++)
                        {
                            Control txt = TimeTable.GetControlFromPosition(i, k);
                            if (txt.Text != "")
                            {
                                TimeTable tab = new TimeTable();
                                tab.id_user = sign_in.getUserId();
                                tab.Id_Family = kid.id_Family;
                                tab.day = i;
                                TimeSpan startTime = new TimeSpan(k + 7, 00, 00);
                                tab.StartTime = startTime;
                                TimeSpan endTime = new TimeSpan(k + 8, 00, 00);
                                tab.EndTime = endTime;
                                tab.content = txt.Text;
                                //add the object to the table 
                                sign_in.nadhemniDB.TimeTable.InsertOnSubmit(tab);
                            }
                        }
                    }

                }
                sign_in.nadhemniDB.SubmitChanges();
                //if everything is alright move to the next form
                //check if user have another kid
                if (this.nbrKids > 1)
                {
                    Kids k = new Kids(nbrKids - 1, "select");
                    k.Show();
                    this.Hide();
                }
                else
                {
                    depart j = new depart();
                    j.Show();
                    this.Hide();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        private void gunaCircleButton2_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }
    }
}
