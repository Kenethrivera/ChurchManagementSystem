namespace CMSWindowsForm
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            btn_Login = new Button();
            btn_Register = new Button();
            label1 = new Label();
            panel_bg = new Panel();
            panel1 = new Panel();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            panel2 = new Panel();
            panel_bg.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btn_Login
            // 
            btn_Login.BackColor = Color.Transparent;
            btn_Login.FlatAppearance.BorderColor = Color.FromArgb(0, 0, 0, 0);
            btn_Login.FlatStyle = FlatStyle.Flat;
            btn_Login.Font = new Font("Georgia", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_Login.ForeColor = Color.White;
            btn_Login.Location = new Point(254, 403);
            btn_Login.Name = "btn_Login";
            btn_Login.Size = new Size(99, 48);
            btn_Login.TabIndex = 2;
            btn_Login.Text = "Login";
            btn_Login.UseVisualStyleBackColor = false;
            btn_Login.Click += btn_Login_Click;
            btn_Login.MouseEnter += btn_Login_MouseEnter;
            btn_Login.MouseLeave += btn_Login_MouseLeave;
            btn_Login.MouseHover += btn_Login_MouseEnter;
            // 
            // btn_Register
            // 
            btn_Register.BackColor = Color.Transparent;
            btn_Register.FlatAppearance.BorderColor = Color.FromArgb(0, 0, 0, 0);
            btn_Register.FlatStyle = FlatStyle.Flat;
            btn_Register.Font = new Font("Georgia", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_Register.ForeColor = Color.White;
            btn_Register.Location = new Point(418, 403);
            btn_Register.Name = "btn_Register";
            btn_Register.Padding = new Padding(10);
            btn_Register.Size = new Size(100, 48);
            btn_Register.TabIndex = 1;
            btn_Register.Text = "Register";
            btn_Register.UseVisualStyleBackColor = false;
            btn_Register.Click += btn_Register_Click;
            btn_Register.MouseEnter += btn_Register_MouseEnter;
            btn_Register.MouseLeave += btn_Register_MouseLeave;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.FlatStyle = FlatStyle.Popup;
            label1.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(254, 125);
            label1.Name = "label1";
            label1.Size = new Size(274, 25);
            label1.TabIndex = 0;
            label1.Text = "Adelina Christian Church";
            label1.Click += label1_Click;
            // 
            // panel_bg
            // 
            panel_bg.BackColor = Color.LightSlateGray;
            panel_bg.BackgroundImage = Properties.Resources.main_bg;
            panel_bg.BackgroundImageLayout = ImageLayout.Center;
            panel_bg.Controls.Add(panel1);
            panel_bg.Location = new Point(-217, -56);
            panel_bg.Name = "panel_bg";
            panel_bg.Size = new Size(901, 502);
            panel_bg.TabIndex = 3;
            panel_bg.Paint += panel_bg_Paint;
            // 
            // panel1
            // 
            panel1.BackgroundImage = Properties.Resources.panel_bg;
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(btn_Login);
            panel1.Controls.Add(btn_Register);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(573, 502);
            panel1.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.FlatStyle = FlatStyle.Popup;
            label4.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(319, 355);
            label4.Name = "label4";
            label4.Size = new Size(133, 15);
            label4.TabIndex = 6;
            label4.Text = "Let Jesus be known";
            label4.Click += label4_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.FlatStyle = FlatStyle.Popup;
            label3.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(307, 331);
            label3.Name = "label3";
            label3.Size = new Size(167, 15);
            label3.TabIndex = 5;
            label3.Text = "Let us spread the Gospel";
            label3.Click += label3_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.FlatStyle = FlatStyle.Popup;
            label2.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(277, 303);
            label2.Name = "label2";
            label2.Size = new Size(223, 18);
            label2.TabIndex = 4;
            label2.Text = "A Family, A Friend, A Church";
            // 
            // panel2
            // 
            panel2.BackgroundImage = Properties.Resources.acc_logo;
            panel2.BackgroundImageLayout = ImageLayout.Stretch;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Location = new Point(301, 163);
            panel2.Name = "panel2";
            panel2.Size = new Size(173, 132);
            panel2.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.CadetBlue;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(684, 441);
            Controls.Add(panel_bg);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Adelina Christian Church";
            panel_bg.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btn_Login;
        private Button btn_Register;
        private Label label1;
        private Panel panel_bg;
        private Panel panel1;
        private Panel panel2;
        private Label label2;
        private Label label4;
        private Label label3;
    }
}
