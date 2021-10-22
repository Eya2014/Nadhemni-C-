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
    public partial class sign_in : Form
    {
        private static int UserID;
        internal static NadhemniDBDataContext nadhemniDB = new NadhemniDBDataContext();
        
        public static int getUserId()
        {
            return UserID;
        }
        public static void setUserId(int id)
        {
            UserID=id;
        }
        public sign_in()
        {
            InitializeComponent();
            hide_pwd.Hide();

        }

        private void sign_in_Load(object sender, EventArgs e)
        {

        }

        private void login_Click(object sender, EventArgs e)
        {
            Boolean i = true;//cette variable va nous renseigner après si les champs sont tous remplis correctement ou pas
            if (!Verif.verifDigitOrAlpha(login_txt.Text))
            {
                MessageBox.Show("Please enter a valid LOGIN !");
                i = false;
            }
            else if (password_txt.Text=="" || password_txt.Text==" ")
            {
                MessageBox.Show("Please enter a valid PASSWORD !");
                i = false;
            }
            if (i)//on doit vérifier si cet utilisateur est inscrit ou pas
            {
                var user = from x in sign_in.nadhemniDB.Users
                           where x.Login == login_txt.Text && x.Password == password_txt.Text
                           select x;
                Boolean trouve = false;

                foreach (var item in user)
                {
                    trouve = true;
                    UserID = item.Id_user;
                    depart d = new depart();
                    d.Show();
                    this.Hide();

                }
                if (!trouve)
                    MessageBox.Show("This user does not exist ! Please sign up before!");
            }

        }

        private void register_Click(object sender, EventArgs e)
        {
            Register_Form rg = new Register_Form("insert");
            rg.Show();
            this.Hide();
        }

        private void gunaCircleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void login_txtMouseEnter(object sender, EventArgs e)
        {
            this.gunaSeparator1.LineColor = System.Drawing.Color.DarkGray;

        }


         private void login_txtMouseDown(object sender, EventArgs e)
        {
            this.gunaSeparator1.LineColor = System.Drawing.Color.DimGray;
        }

        private void login_txtClick(object sender, EventArgs e)
        {
            this.gunaSeparator1.LineColor = System.Drawing.Color.DimGray;
        }

        private void password_txtMouseDown(object sender, MouseEventArgs e)
        {

            this.gunaSeparator1.LineColor = System.Drawing.Color.DimGray;
        }

        private void password_txtMouseEnter(object sender, EventArgs e)
        {
            this.gunaSeparator1.LineColor = System.Drawing.Color.DarkGray;
        }

        private void password_txtMouseClick(object sender, EventArgs e)
        {
            this.gunaSeparator1.LineColor = System.Drawing.Color.DimGray;
        }

        private void show_pwd_Click(object sender, EventArgs e)
        {
            show_pwd.Hide();
            hide_pwd.Show();
            password_txt.isPassword = false;
        }

        private void hide_pwd_Click(object sender, EventArgs e)
        {
            hide_pwd.Hide();
            show_pwd.Show();
            password_txt.isPassword = true;
        }

        private void remember_me_OnChange(object sender, EventArgs e)
        {

        }
    }
}
