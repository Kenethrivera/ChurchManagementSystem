namespace CMSWindowsForm
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            lbl_Header = new Label();
            btn_Login = new Button();
            tbx_Password = new TextBox();
            tbx_Username = new TextBox();
            lbl_Password = new Label();
            lbl_Username = new Label();
            lbl_Status = new Label();
            cmb_Position = new ComboBox();
            lbl_Position = new Label();
            btn_Back = new Button();
            SuspendLayout();
            // 
            // lbl_Header
            // 
            lbl_Header.AutoSize = true;
            lbl_Header.BackColor = Color.Transparent;
            lbl_Header.Font = new Font("Georgia", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_Header.ForeColor = Color.Black;
            lbl_Header.Location = new Point(25, 23);
            lbl_Header.Name = "lbl_Header";
            lbl_Header.Size = new Size(110, 38);
            lbl_Header.TabIndex = 1;
            lbl_Header.Text = "Login";
            // 
            // btn_Login
            // 
            btn_Login.BackColor = Color.Transparent;
            btn_Login.BackgroundImage = Properties.Resources.registerBg;
            btn_Login.FlatAppearance.BorderColor = Color.FromArgb(0, 0, 0, 0);
            btn_Login.Font = new Font("Georgia", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_Login.ForeColor = Color.Black;
            btn_Login.Location = new Point(243, 242);
            btn_Login.Name = "btn_Login";
            btn_Login.Size = new Size(247, 47);
            btn_Login.TabIndex = 22;
            btn_Login.Text = "Login";
            btn_Login.UseVisualStyleBackColor = false;
            btn_Login.Click += btn_Login_Click;
            // 
            // tbx_Password
            // 
            tbx_Password.Location = new Point(194, 182);
            tbx_Password.Name = "tbx_Password";
            tbx_Password.Size = new Size(373, 23);
            tbx_Password.TabIndex = 21;
            tbx_Password.UseSystemPasswordChar = true;
            // 
            // tbx_Username
            // 
            tbx_Username.Location = new Point(194, 137);
            tbx_Username.Name = "tbx_Username";
            tbx_Username.Size = new Size(373, 23);
            tbx_Username.TabIndex = 20;
            // 
            // lbl_Password
            // 
            lbl_Password.AutoSize = true;
            lbl_Password.BackColor = Color.Transparent;
            lbl_Password.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_Password.ForeColor = Color.Black;
            lbl_Password.Location = new Point(107, 187);
            lbl_Password.Name = "lbl_Password";
            lbl_Password.Size = new Size(85, 18);
            lbl_Password.TabIndex = 19;
            lbl_Password.Text = "Password: ";
            // 
            // lbl_Username
            // 
            lbl_Username.AutoSize = true;
            lbl_Username.BackColor = Color.Transparent;
            lbl_Username.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_Username.ForeColor = Color.Black;
            lbl_Username.Location = new Point(102, 137);
            lbl_Username.Name = "lbl_Username";
            lbl_Username.Size = new Size(86, 18);
            lbl_Username.TabIndex = 18;
            lbl_Username.Text = "Username:";
            // 
            // lbl_Status
            // 
            lbl_Status.AutoSize = true;
            lbl_Status.BackColor = Color.Transparent;
            lbl_Status.Font = new Font("Georgia", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_Status.ForeColor = Color.Red;
            lbl_Status.Location = new Point(198, 220);
            lbl_Status.Name = "lbl_Status";
            lbl_Status.Size = new Size(0, 16);
            lbl_Status.TabIndex = 23;
            // 
            // cmb_Position
            // 
            cmb_Position.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_Position.FormattingEnabled = true;
            cmb_Position.Items.AddRange(new object[] { "Admin", "Member" });
            cmb_Position.Location = new Point(194, 95);
            cmb_Position.Name = "cmb_Position";
            cmb_Position.Size = new Size(373, 23);
            cmb_Position.TabIndex = 25;
            // 
            // lbl_Position
            // 
            lbl_Position.AutoSize = true;
            lbl_Position.BackColor = Color.Transparent;
            lbl_Position.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_Position.ForeColor = Color.Black;
            lbl_Position.Location = new Point(119, 95);
            lbl_Position.Name = "lbl_Position";
            lbl_Position.Size = new Size(69, 18);
            lbl_Position.TabIndex = 24;
            lbl_Position.Text = "Position:";
            // 
            // btn_Back
            // 
            btn_Back.BackColor = Color.Red;
            btn_Back.FlatAppearance.BorderColor = Color.FromArgb(0, 0, 0, 0);
            btn_Back.FlatStyle = FlatStyle.System;
            btn_Back.Font = new Font("Georgia", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_Back.ForeColor = Color.MediumVioletRed;
            btn_Back.Location = new Point(6, 411);
            btn_Back.Name = "btn_Back";
            btn_Back.Size = new Size(51, 23);
            btn_Back.TabIndex = 26;
            btn_Back.Text = "Back";
            btn_Back.UseVisualStyleBackColor = false;
            btn_Back.Click += btn_Back_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.g;
            ClientSize = new Size(684, 441);
            Controls.Add(btn_Back);
            Controls.Add(cmb_Position);
            Controls.Add(lbl_Position);
            Controls.Add(lbl_Status);
            Controls.Add(btn_Login);
            Controls.Add(tbx_Password);
            Controls.Add(tbx_Username);
            Controls.Add(lbl_Password);
            Controls.Add(lbl_Username);
            Controls.Add(lbl_Header);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            Load += Login_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_Header;
        private Button btn_Login;
        private TextBox tbx_Password;
        private TextBox tbx_Username;
        private Label lbl_Password;
        private Label lbl_Username;
        private Label lbl_Status;
        private ComboBox cmb_Position;
        private Label lbl_Position;
        private Button btn_Back;
    }
}