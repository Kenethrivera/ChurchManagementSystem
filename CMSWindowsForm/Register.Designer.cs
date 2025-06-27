namespace CMSWindowsForm
{
    partial class Register
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Register));
            lbl_Header = new Label();
            lbl_FirstName = new Label();
            lbl_LastName = new Label();
            lbl_Age = new Label();
            lbl_EmailAdd = new Label();
            lbl_MinistryName = new Label();
            lbl_Position = new Label();
            lbl_Username = new Label();
            lbl_Password = new Label();
            tbx_FirstName = new TextBox();
            tbx_LastName = new TextBox();
            tbx_Age = new TextBox();
            tbx_EmailAddress = new TextBox();
            tbx_Username = new TextBox();
            tbx_Password = new TextBox();
            cmb_MinistryName = new ComboBox();
            btn_Register = new Button();
            cmb_Position = new ComboBox();
            label1 = new Label();
            tbx_ReenterPassword = new TextBox();
            lbl_Status = new Label();
            btn_Back = new Button();
            SuspendLayout();
            // 
            // lbl_Header
            // 
            lbl_Header.AutoSize = true;
            lbl_Header.BackColor = Color.Transparent;
            lbl_Header.Font = new Font("Georgia", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_Header.ForeColor = Color.Black;
            lbl_Header.Location = new Point(10, 9);
            lbl_Header.Name = "lbl_Header";
            lbl_Header.Size = new Size(154, 38);
            lbl_Header.TabIndex = 0;
            lbl_Header.Text = "Register";
            // 
            // lbl_FirstName
            // 
            lbl_FirstName.AutoSize = true;
            lbl_FirstName.BackColor = Color.Transparent;
            lbl_FirstName.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_FirstName.ForeColor = Color.Black;
            lbl_FirstName.Location = new Point(90, 69);
            lbl_FirstName.Name = "lbl_FirstName";
            lbl_FirstName.Size = new Size(93, 18);
            lbl_FirstName.TabIndex = 1;
            lbl_FirstName.Text = "First Name:";
            // 
            // lbl_LastName
            // 
            lbl_LastName.AutoSize = true;
            lbl_LastName.BackColor = Color.Transparent;
            lbl_LastName.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_LastName.ForeColor = Color.Black;
            lbl_LastName.Location = new Point(93, 99);
            lbl_LastName.Name = "lbl_LastName";
            lbl_LastName.Size = new Size(90, 18);
            lbl_LastName.TabIndex = 2;
            lbl_LastName.Text = "Last Name:";
            // 
            // lbl_Age
            // 
            lbl_Age.AutoSize = true;
            lbl_Age.BackColor = Color.Transparent;
            lbl_Age.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_Age.ForeColor = Color.Black;
            lbl_Age.Location = new Point(143, 135);
            lbl_Age.Name = "lbl_Age";
            lbl_Age.Size = new Size(40, 18);
            lbl_Age.TabIndex = 3;
            lbl_Age.Text = "Age:";
            // 
            // lbl_EmailAdd
            // 
            lbl_EmailAdd.AutoSize = true;
            lbl_EmailAdd.BackColor = Color.Transparent;
            lbl_EmailAdd.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_EmailAdd.ForeColor = Color.Black;
            lbl_EmailAdd.Location = new Point(68, 167);
            lbl_EmailAdd.Name = "lbl_EmailAdd";
            lbl_EmailAdd.Size = new Size(115, 18);
            lbl_EmailAdd.TabIndex = 4;
            lbl_EmailAdd.Text = "Email Address:";
            // 
            // lbl_MinistryName
            // 
            lbl_MinistryName.AutoSize = true;
            lbl_MinistryName.BackColor = Color.Transparent;
            lbl_MinistryName.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_MinistryName.ForeColor = Color.Black;
            lbl_MinistryName.Location = new Point(68, 202);
            lbl_MinistryName.Name = "lbl_MinistryName";
            lbl_MinistryName.Size = new Size(120, 18);
            lbl_MinistryName.TabIndex = 5;
            lbl_MinistryName.Text = "MinistryName: ";
            // 
            // lbl_Position
            // 
            lbl_Position.AutoSize = true;
            lbl_Position.BackColor = Color.Transparent;
            lbl_Position.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_Position.ForeColor = Color.Black;
            lbl_Position.Location = new Point(114, 231);
            lbl_Position.Name = "lbl_Position";
            lbl_Position.Size = new Size(69, 18);
            lbl_Position.TabIndex = 6;
            lbl_Position.Text = "Position:";
            // 
            // lbl_Username
            // 
            lbl_Username.AutoSize = true;
            lbl_Username.BackColor = Color.Transparent;
            lbl_Username.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_Username.ForeColor = Color.Black;
            lbl_Username.Location = new Point(97, 265);
            lbl_Username.Name = "lbl_Username";
            lbl_Username.Size = new Size(86, 18);
            lbl_Username.TabIndex = 7;
            lbl_Username.Text = "Username:";
            // 
            // lbl_Password
            // 
            lbl_Password.AutoSize = true;
            lbl_Password.BackColor = Color.Transparent;
            lbl_Password.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_Password.ForeColor = Color.Black;
            lbl_Password.Location = new Point(102, 304);
            lbl_Password.Name = "lbl_Password";
            lbl_Password.Size = new Size(85, 18);
            lbl_Password.TabIndex = 8;
            lbl_Password.Text = "Password: ";
            // 
            // tbx_FirstName
            // 
            tbx_FirstName.BackColor = SystemColors.Window;
            tbx_FirstName.Location = new Point(189, 64);
            tbx_FirstName.Name = "tbx_FirstName";
            tbx_FirstName.Size = new Size(373, 23);
            tbx_FirstName.TabIndex = 9;
            // 
            // tbx_LastName
            // 
            tbx_LastName.Location = new Point(189, 94);
            tbx_LastName.Name = "tbx_LastName";
            tbx_LastName.Size = new Size(373, 23);
            tbx_LastName.TabIndex = 10;
            // 
            // tbx_Age
            // 
            tbx_Age.Location = new Point(189, 130);
            tbx_Age.Name = "tbx_Age";
            tbx_Age.Size = new Size(373, 23);
            tbx_Age.TabIndex = 11;
            // 
            // tbx_EmailAddress
            // 
            tbx_EmailAddress.Location = new Point(189, 162);
            tbx_EmailAddress.Name = "tbx_EmailAddress";
            tbx_EmailAddress.Size = new Size(373, 23);
            tbx_EmailAddress.TabIndex = 12;
            // 
            // tbx_Username
            // 
            tbx_Username.Location = new Point(189, 262);
            tbx_Username.Name = "tbx_Username";
            tbx_Username.Size = new Size(373, 23);
            tbx_Username.TabIndex = 13;
            // 
            // tbx_Password
            // 
            tbx_Password.Location = new Point(190, 301);
            tbx_Password.Name = "tbx_Password";
            tbx_Password.Size = new Size(372, 23);
            tbx_Password.TabIndex = 14;
            tbx_Password.UseSystemPasswordChar = true;
            // 
            // cmb_MinistryName
            // 
            cmb_MinistryName.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_MinistryName.FormattingEnabled = true;
            cmb_MinistryName.Items.AddRange(new object[] { "Discipleship Ministry", "Prayer Ministry", "Worship Ministry", "Christian Education" });
            cmb_MinistryName.Location = new Point(189, 197);
            cmb_MinistryName.Name = "cmb_MinistryName";
            cmb_MinistryName.Size = new Size(373, 23);
            cmb_MinistryName.TabIndex = 15;
            // 
            // btn_Register
            // 
            btn_Register.BackColor = Color.Transparent;
            btn_Register.BackgroundImage = Properties.Resources.registerBg;
            btn_Register.FlatAppearance.BorderColor = Color.FromArgb(0, 0, 0, 0);
            btn_Register.Font = new Font("Georgia", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_Register.ForeColor = Color.Black;
            btn_Register.Location = new Point(254, 382);
            btn_Register.Name = "btn_Register";
            btn_Register.Size = new Size(247, 47);
            btn_Register.TabIndex = 17;
            btn_Register.Text = "Register";
            btn_Register.UseVisualStyleBackColor = false;
            btn_Register.Click += btn_Register_Click;
            // 
            // cmb_Position
            // 
            cmb_Position.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_Position.FormattingEnabled = true;
            cmb_Position.Items.AddRange(new object[] { "Admin", "Member" });
            cmb_Position.Location = new Point(189, 231);
            cmb_Position.Name = "cmb_Position";
            cmb_Position.Size = new Size(373, 23);
            cmb_Position.TabIndex = 18;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(34, 332);
            label1.Name = "label1";
            label1.Size = new Size(153, 18);
            label1.TabIndex = 19;
            label1.Text = "Re-enter Password: ";
            label1.Click += label1_Click;
            // 
            // tbx_ReenterPassword
            // 
            tbx_ReenterPassword.Location = new Point(189, 332);
            tbx_ReenterPassword.Name = "tbx_ReenterPassword";
            tbx_ReenterPassword.Size = new Size(372, 23);
            tbx_ReenterPassword.TabIndex = 20;
            tbx_ReenterPassword.UseSystemPasswordChar = true;
            // 
            // lbl_Status
            // 
            lbl_Status.AutoSize = true;
            lbl_Status.BackColor = Color.Transparent;
            lbl_Status.Font = new Font("Georgia", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_Status.ForeColor = Color.Red;
            lbl_Status.Location = new Point(190, 358);
            lbl_Status.Name = "lbl_Status";
            lbl_Status.Size = new Size(0, 16);
            lbl_Status.TabIndex = 21;
            // 
            // btn_Back
            // 
            btn_Back.BackColor = Color.Red;
            btn_Back.FlatAppearance.BorderColor = Color.FromArgb(0, 0, 0, 0);
            btn_Back.FlatStyle = FlatStyle.System;
            btn_Back.Font = new Font("Georgia", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_Back.ForeColor = Color.MediumVioletRed;
            btn_Back.Location = new Point(9, 411);
            btn_Back.Name = "btn_Back";
            btn_Back.Size = new Size(51, 23);
            btn_Back.TabIndex = 22;
            btn_Back.Text = "Back";
            btn_Back.UseVisualStyleBackColor = false;
            btn_Back.Click += btn_Back_Click;
            // 
            // Register
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightBlue;
            BackgroundImage = Properties.Resources.g;
            ClientSize = new Size(684, 441);
            Controls.Add(btn_Back);
            Controls.Add(lbl_Status);
            Controls.Add(tbx_ReenterPassword);
            Controls.Add(label1);
            Controls.Add(cmb_Position);
            Controls.Add(btn_Register);
            Controls.Add(cmb_MinistryName);
            Controls.Add(tbx_Password);
            Controls.Add(tbx_Username);
            Controls.Add(tbx_EmailAddress);
            Controls.Add(tbx_Age);
            Controls.Add(tbx_LastName);
            Controls.Add(tbx_FirstName);
            Controls.Add(lbl_Password);
            Controls.Add(lbl_Username);
            Controls.Add(lbl_Position);
            Controls.Add(lbl_MinistryName);
            Controls.Add(lbl_EmailAdd);
            Controls.Add(lbl_Age);
            Controls.Add(lbl_LastName);
            Controls.Add(lbl_FirstName);
            Controls.Add(lbl_Header);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Register";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Register";
            Load += Register_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_Header;
        private Label lbl_FirstName;
        private Label lbl_LastName;
        private Label lbl_Age;
        private Label lbl_EmailAdd;
        private Label lbl_MinistryName;
        private Label lbl_Position;
        private Label lbl_Username;
        private Label lbl_Password;
        private TextBox tbx_FirstName;
        private TextBox tbx_LastName;
        private TextBox tbx_Age;
        private TextBox tbx_EmailAddress;
        private TextBox tbx_Username;
        private TextBox tbx_Password;
        private ComboBox cmb_MinistryName;
        private Button btn_Register;
        private ComboBox cmb_Position;
        private Label label1;
        private TextBox tbx_ReenterPassword;
        private Label lbl_Status;
        private Button btn_Back;
    }
}