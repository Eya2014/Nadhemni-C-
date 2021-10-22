namespace Nadhemni
{
    partial class sign_in
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(sign_in));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.bunifuDragControl2 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.gunaCircleButton2 = new Guna.UI.WinForms.GunaCircleButton();
            this.bunifuDragControl3 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.panelHeader = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.wlc_back = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.register = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.login_button = new Guna.UI.WinForms.GunaGradientButton();
            this.remember = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.remember_me = new Bunifu.Framework.UI.BunifuCheckbox();
            this.frgpwd = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.password_txt = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.login_txt = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.show_pwd = new Guna.UI.WinForms.GunaCirclePictureBox();
            this.hide_pwd = new Guna.UI.WinForms.GunaCirclePictureBox();
            this.gunaSeparator2 = new Guna.UI.WinForms.GunaSeparator();
            this.gunaSeparator1 = new Guna.UI.WinForms.GunaSeparator();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panelHeader.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.show_pwd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hide_pwd)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "cat.jpg");
            this.imageList1.Images.SetKeyName(1, "dog.jpg");
            this.imageList1.Images.SetKeyName(2, "parrot.jpg");
            this.imageList1.Images.SetKeyName(3, "rabbit.jpg");
            // 
            // bunifuDragControl2
            // 
            this.bunifuDragControl2.Fixed = true;
            this.bunifuDragControl2.Horizontal = true;
            this.bunifuDragControl2.TargetControl = null;
            this.bunifuDragControl2.Vertical = true;
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // gunaCircleButton2
            // 
            this.gunaCircleButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gunaCircleButton2.AnimationHoverSpeed = 0.07F;
            this.gunaCircleButton2.AnimationSpeed = 0.03F;
            this.gunaCircleButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gunaCircleButton2.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gunaCircleButton2.BorderColor = System.Drawing.Color.Black;
            this.gunaCircleButton2.DialogResult = System.Windows.Forms.DialogResult.None;
            this.gunaCircleButton2.FocusedColor = System.Drawing.Color.Empty;
            this.gunaCircleButton2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaCircleButton2.ForeColor = System.Drawing.SystemColors.Window;
            this.gunaCircleButton2.Image = null;
            this.gunaCircleButton2.ImageSize = new System.Drawing.Size(52, 52);
            this.gunaCircleButton2.Location = new System.Drawing.Point(891, 2);
            this.gunaCircleButton2.Name = "gunaCircleButton2";
            this.gunaCircleButton2.OnHoverBaseColor = System.Drawing.Color.DarkGray;
            this.gunaCircleButton2.OnHoverBorderColor = System.Drawing.Color.Black;
            this.gunaCircleButton2.OnHoverForeColor = System.Drawing.Color.White;
            this.gunaCircleButton2.OnHoverImage = null;
            this.gunaCircleButton2.OnPressedColor = System.Drawing.Color.DarkRed;
            this.gunaCircleButton2.Size = new System.Drawing.Size(33, 24);
            this.gunaCircleButton2.TabIndex = 12;
            this.gunaCircleButton2.Text = "X";
            this.gunaCircleButton2.Click += new System.EventHandler(this.gunaCircleButton2_Click);
            // 
            // bunifuDragControl3
            // 
            this.bunifuDragControl3.Fixed = true;
            this.bunifuDragControl3.Horizontal = true;
            this.bunifuDragControl3.TargetControl = this.panelHeader;
            this.bunifuDragControl3.Vertical = true;
            // 
            // panelHeader
            // 
            this.panelHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelHeader.BackColor = System.Drawing.Color.Silver;
            this.panelHeader.Controls.Add(this.gunaCircleButton2);
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(927, 30);
            this.panelHeader.TabIndex = 12;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.bunifuCustomLabel1);
            this.panel1.Controls.Add(this.wlc_back);
            this.panel1.Location = new System.Drawing.Point(40, 42);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(280, 420);
            this.panel1.TabIndex = 14;
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(47, 228);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(219, 17);
            this.bunifuCustomLabel1.TabIndex = 8;
            this.bunifuCustomLabel1.Text = "Make sure your account is secure !";
            this.bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // wlc_back
            // 
            this.wlc_back.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.wlc_back.AutoSize = true;
            this.wlc_back.BackColor = System.Drawing.Color.Transparent;
            this.wlc_back.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wlc_back.Location = new System.Drawing.Point(35, 191);
            this.wlc_back.Name = "wlc_back";
            this.wlc_back.Size = new System.Drawing.Size(242, 37);
            this.wlc_back.TabIndex = 5;
            this.wlc_back.Text = "WELCOME BACK !";
            this.wlc_back.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // register
            // 
            this.register.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.register.AutoSize = true;
            this.register.BackColor = System.Drawing.Color.Transparent;
            this.register.Cursor = System.Windows.Forms.Cursors.Hand;
            this.register.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.register.Location = new System.Drawing.Point(435, 246);
            this.register.Name = "register";
            this.register.Size = new System.Drawing.Size(49, 15);
            this.register.TabIndex = 31;
            this.register.Text = "Register";
            this.register.Click += new System.EventHandler(this.register_Click);
            // 
            // login_button
            // 
            this.login_button.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.login_button.AnimationHoverSpeed = 0.07F;
            this.login_button.AnimationSpeed = 0.03F;
            this.login_button.BackColor = System.Drawing.Color.Transparent;
            this.login_button.BaseColor1 = System.Drawing.Color.SlateBlue;
            this.login_button.BaseColor2 = System.Drawing.Color.Fuchsia;
            this.login_button.BorderColor = System.Drawing.Color.Black;
            this.login_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.login_button.DialogResult = System.Windows.Forms.DialogResult.None;
            this.login_button.FocusedColor = System.Drawing.Color.Empty;
            this.login_button.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.login_button.ForeColor = System.Drawing.Color.White;
            this.login_button.Image = null;
            this.login_button.ImageSize = new System.Drawing.Size(20, 20);
            this.login_button.Location = new System.Drawing.Point(45, 398);
            this.login_button.Name = "login_button";
            this.login_button.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(145)))), ((int)(((byte)(221)))));
            this.login_button.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(85)))), ((int)(((byte)(255)))));
            this.login_button.OnHoverBorderColor = System.Drawing.Color.Black;
            this.login_button.OnHoverForeColor = System.Drawing.Color.White;
            this.login_button.OnHoverImage = null;
            this.login_button.OnPressedColor = System.Drawing.Color.Black;
            this.login_button.Radius = 15;
            this.login_button.Size = new System.Drawing.Size(424, 37);
            this.login_button.TabIndex = 30;
            this.login_button.Text = "LOGIN";
            this.login_button.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.login_button.Click += new System.EventHandler(this.login_Click);
            // 
            // remember
            // 
            this.remember.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.remember.AutoSize = true;
            this.remember.BackColor = System.Drawing.Color.Transparent;
            this.remember.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.remember.Location = new System.Drawing.Point(50, 300);
            this.remember.Name = "remember";
            this.remember.Size = new System.Drawing.Size(106, 20);
            this.remember.TabIndex = 29;
            this.remember.Text = "Remember me ";
            this.remember.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // remember_me
            // 
            this.remember_me.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.remember_me.BackColor = System.Drawing.Color.HotPink;
            this.remember_me.ChechedOffColor = System.Drawing.Color.HotPink;
            this.remember_me.Checked = false;
            this.remember_me.CheckedOnColor = System.Drawing.Color.HotPink;
            this.remember_me.Cursor = System.Windows.Forms.Cursors.Hand;
            this.remember_me.ForeColor = System.Drawing.Color.White;
            this.remember_me.Location = new System.Drawing.Point(32, 300);
            this.remember_me.Name = "remember_me";
            this.remember_me.Size = new System.Drawing.Size(20, 20);
            this.remember_me.TabIndex = 28;
            this.remember_me.OnChange += new System.EventHandler(this.remember_me_OnChange);
            // 
            // frgpwd
            // 
            this.frgpwd.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.frgpwd.AutoSize = true;
            this.frgpwd.BackColor = System.Drawing.Color.Transparent;
            this.frgpwd.Font = new System.Drawing.Font("Segoe UI Semibold", 8.75F, System.Drawing.FontStyle.Bold);
            this.frgpwd.Location = new System.Drawing.Point(29, 248);
            this.frgpwd.Name = "frgpwd";
            this.frgpwd.Size = new System.Drawing.Size(103, 15);
            this.frgpwd.TabIndex = 27;
            this.frgpwd.Text = "Forgot Password ?";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(215)))), ((int)(((byte)(223)))));
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(453, 208);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 34);
            this.pictureBox1.TabIndex = 26;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(215)))), ((int)(((byte)(223)))));
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(452, 147);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(29, 34);
            this.pictureBox2.TabIndex = 25;
            this.pictureBox2.TabStop = false;
            // 
            // password_txt
            // 
            this.password_txt.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.password_txt.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.password_txt.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.password_txt.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.password_txt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(215)))), ((int)(((byte)(223)))));
            this.password_txt.characterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.password_txt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.password_txt.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.password_txt.ForeColor = System.Drawing.Color.Black;
            this.password_txt.HintForeColor = System.Drawing.Color.Gray;
            this.password_txt.HintText = "";
            this.password_txt.isPassword = true;
            this.password_txt.LineFocusedColor = System.Drawing.Color.DimGray;
            this.password_txt.LineIdleColor = System.Drawing.Color.DimGray;
            this.password_txt.LineMouseHoverColor = System.Drawing.Color.DarkGray;
            this.password_txt.LineThickness = 2;
            this.password_txt.Location = new System.Drawing.Point(29, 208);
            this.password_txt.Margin = new System.Windows.Forms.Padding(4);
            this.password_txt.MaxLength = 32767;
            this.password_txt.Name = "password_txt";
            this.password_txt.Size = new System.Drawing.Size(424, 36);
            this.password_txt.TabIndex = 24;
            this.password_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.password_txt.Click += new System.EventHandler(this.password_txtMouseClick);
            this.password_txt.MouseDown += new System.Windows.Forms.MouseEventHandler(this.password_txtMouseDown);
            this.password_txt.MouseEnter += new System.EventHandler(this.password_txtMouseEnter);
            // 
            // login_txt
            // 
            this.login_txt.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.login_txt.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.login_txt.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.login_txt.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.login_txt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(215)))), ((int)(((byte)(223)))));
            this.login_txt.characterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.login_txt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.login_txt.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.login_txt.ForeColor = System.Drawing.Color.Black;
            this.login_txt.HintForeColor = System.Drawing.Color.Gray;
            this.login_txt.HintText = "LOGIN";
            this.login_txt.isPassword = false;
            this.login_txt.LineFocusedColor = System.Drawing.Color.DimGray;
            this.login_txt.LineIdleColor = System.Drawing.Color.DimGray;
            this.login_txt.LineMouseHoverColor = System.Drawing.Color.DarkGray;
            this.login_txt.LineThickness = 2;
            this.login_txt.Location = new System.Drawing.Point(28, 147);
            this.login_txt.Margin = new System.Windows.Forms.Padding(4);
            this.login_txt.MaxLength = 32767;
            this.login_txt.Name = "login_txt";
            this.login_txt.Size = new System.Drawing.Size(424, 36);
            this.login_txt.TabIndex = 23;
            this.login_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.login_txt.Click += new System.EventHandler(this.login_txtClick);
            this.login_txt.MouseEnter += new System.EventHandler(this.login_txtMouseEnter);
            this.login_txt.MouseLeave += new System.EventHandler(this.login_txtMouseDown);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.show_pwd);
            this.panel2.Controls.Add(this.hide_pwd);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.gunaSeparator2);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.gunaSeparator1);
            this.panel2.Controls.Add(this.register);
            this.panel2.Controls.Add(this.login_button);
            this.panel2.Controls.Add(this.remember);
            this.panel2.Controls.Add(this.remember_me);
            this.panel2.Controls.Add(this.frgpwd);
            this.panel2.Controls.Add(this.password_txt);
            this.panel2.Controls.Add(this.login_txt);
            this.panel2.Location = new System.Drawing.Point(371, 29);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(517, 450);
            this.panel2.TabIndex = 15;
            // 
            // show_pwd
            // 
            this.show_pwd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.show_pwd.BackgroundImage = global::Nadhemni.Properties.Resources.eye_20;
            this.show_pwd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.show_pwd.BaseColor = System.Drawing.Color.Transparent;
            this.show_pwd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.show_pwd.Location = new System.Drawing.Point(489, 217);
            this.show_pwd.Name = "show_pwd";
            this.show_pwd.Size = new System.Drawing.Size(20, 20);
            this.show_pwd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.show_pwd.TabIndex = 102;
            this.show_pwd.TabStop = false;
            this.show_pwd.UseTransfarantBackground = false;
            this.show_pwd.Click += new System.EventHandler(this.show_pwd_Click);
            // 
            // hide_pwd
            // 
            this.hide_pwd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hide_pwd.BackgroundImage = global::Nadhemni.Properties.Resources.hide_20;
            this.hide_pwd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.hide_pwd.BaseColor = System.Drawing.Color.Transparent;
            this.hide_pwd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hide_pwd.Location = new System.Drawing.Point(488, 217);
            this.hide_pwd.Name = "hide_pwd";
            this.hide_pwd.Size = new System.Drawing.Size(20, 20);
            this.hide_pwd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.hide_pwd.TabIndex = 101;
            this.hide_pwd.TabStop = false;
            this.hide_pwd.UseTransfarantBackground = false;
            this.hide_pwd.Click += new System.EventHandler(this.hide_pwd_Click);
            // 
            // gunaSeparator2
            // 
            this.gunaSeparator2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.gunaSeparator2.LineColor = System.Drawing.Color.DimGray;
            this.gunaSeparator2.Location = new System.Drawing.Point(453, 238);
            this.gunaSeparator2.Name = "gunaSeparator2";
            this.gunaSeparator2.Size = new System.Drawing.Size(29, 10);
            this.gunaSeparator2.TabIndex = 38;
            this.gunaSeparator2.Thickness = 2;
            // 
            // gunaSeparator1
            // 
            this.gunaSeparator1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.gunaSeparator1.LineColor = System.Drawing.Color.DimGray;
            this.gunaSeparator1.Location = new System.Drawing.Point(452, 177);
            this.gunaSeparator1.Name = "gunaSeparator1";
            this.gunaSeparator1.Size = new System.Drawing.Size(29, 10);
            this.gunaSeparator1.TabIndex = 37;
            this.gunaSeparator1.Thickness = 2;
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = null;
            this.bunifuDragControl1.Vertical = true;
            // 
            // sign_in
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(215)))), ((int)(((byte)(223)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(927, 500);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "sign_in";
            this.Load += new System.EventHandler(this.sign_in_Load);
            this.panelHeader.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.show_pwd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hide_pwd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl2;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel panelHeader;
        private Guna.UI.WinForms.GunaCircleButton gunaCircleButton2;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl3;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel panel1;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private Bunifu.Framework.UI.BunifuCustomLabel wlc_back;
        private System.Windows.Forms.Panel panel2;
        private Bunifu.Framework.UI.BunifuCustomLabel register;
        private Guna.UI.WinForms.GunaGradientButton login_button;
        private Bunifu.Framework.UI.BunifuCustomLabel remember;
        private Bunifu.Framework.UI.BunifuCheckbox remember_me;
        private Bunifu.Framework.UI.BunifuCustomLabel frgpwd;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private Bunifu.Framework.UI.BunifuMaterialTextbox password_txt;
        private Bunifu.Framework.UI.BunifuMaterialTextbox login_txt;
        private Guna.UI.WinForms.GunaSeparator gunaSeparator1;
        private Guna.UI.WinForms.GunaSeparator gunaSeparator2;
        private Guna.UI.WinForms.GunaCirclePictureBox show_pwd;
        private Guna.UI.WinForms.GunaCirclePictureBox hide_pwd;
    }
}