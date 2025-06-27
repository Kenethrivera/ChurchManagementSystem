namespace CMSWindowsForm
{
    partial class AdminDiscipleshipDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminDiscipleshipDashboard));
            lbl_Header = new Label();
            tabControl1 = new TabControl();
            tab_View = new TabPage();
            flp_ViewPanel = new FlowLayoutPanel();
            tbl_ViewHeader = new Label();
            tab_Add = new TabPage();
            lbl_Status = new Label();
            btn_Register = new Button();
            tbx_Note = new TextBox();
            tbx_Description = new TextBox();
            cmb_Speaker = new ComboBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            lbl_FirstName = new Label();
            dtp_Date = new DateTimePicker();
            lbl_AddHeader = new Label();
            tab_Update = new TabPage();
            lbl_UpdateStatus = new Label();
            btn_Update = new Button();
            tbx_UpdateNote = new TextBox();
            tbx_UpdateDescription = new TextBox();
            cmb_UpdateSpeaker = new ComboBox();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            dtp_UpdateDate = new DateTimePicker();
            cmb_ToUpdate = new ComboBox();
            label4 = new Label();
            tab_Delete = new TabPage();
            lbl_RemoveStatus = new Label();
            btn_Remove = new Button();
            cmb_ToRemove = new ComboBox();
            lbl_RemoveHeader = new Label();
            btn_Logout = new Button();
            tabControl1.SuspendLayout();
            tab_View.SuspendLayout();
            tab_Add.SuspendLayout();
            tab_Update.SuspendLayout();
            tab_Delete.SuspendLayout();
            SuspendLayout();
            // 
            // lbl_Header
            // 
            lbl_Header.AutoSize = true;
            lbl_Header.BackColor = Color.Transparent;
            lbl_Header.Font = new Font("Georgia", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_Header.ForeColor = Color.Transparent;
            lbl_Header.Location = new Point(7, 5);
            lbl_Header.Name = "lbl_Header";
            lbl_Header.Size = new Size(334, 34);
            lbl_Header.TabIndex = 2;
            lbl_Header.Text = "Discipleship Ministry";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tab_View);
            tabControl1.Controls.Add(tab_Add);
            tabControl1.Controls.Add(tab_Update);
            tabControl1.Controls.Add(tab_Delete);
            tabControl1.Location = new Point(12, 50);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(647, 379);
            tabControl1.TabIndex = 3;
            // 
            // tab_View
            // 
            tab_View.BackgroundImageLayout = ImageLayout.Stretch;
            tab_View.Controls.Add(flp_ViewPanel);
            tab_View.Controls.Add(tbl_ViewHeader);
            tab_View.Location = new Point(4, 24);
            tab_View.Name = "tab_View";
            tab_View.Padding = new Padding(3);
            tab_View.Size = new Size(639, 351);
            tab_View.TabIndex = 0;
            tab_View.Text = "View Schedules";
            tab_View.UseVisualStyleBackColor = true;
            // 
            // flp_ViewPanel
            // 
            flp_ViewPanel.AutoScroll = true;
            flp_ViewPanel.BorderStyle = BorderStyle.FixedSingle;
            flp_ViewPanel.FlowDirection = FlowDirection.TopDown;
            flp_ViewPanel.Location = new Point(16, 30);
            flp_ViewPanel.Name = "flp_ViewPanel";
            flp_ViewPanel.Size = new Size(608, 302);
            flp_ViewPanel.TabIndex = 5;
            flp_ViewPanel.WrapContents = false;
            // 
            // tbl_ViewHeader
            // 
            tbl_ViewHeader.AutoSize = true;
            tbl_ViewHeader.BackColor = Color.Transparent;
            tbl_ViewHeader.Font = new Font("Georgia", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tbl_ViewHeader.ForeColor = Color.Black;
            tbl_ViewHeader.Location = new Point(7, 9);
            tbl_ViewHeader.Name = "tbl_ViewHeader";
            tbl_ViewHeader.Size = new Size(102, 18);
            tbl_ViewHeader.TabIndex = 4;
            tbl_ViewHeader.Text = "Schedules: ";
            // 
            // tab_Add
            // 
            tab_Add.BackgroundImageLayout = ImageLayout.Stretch;
            tab_Add.Controls.Add(lbl_Status);
            tab_Add.Controls.Add(btn_Register);
            tab_Add.Controls.Add(tbx_Note);
            tab_Add.Controls.Add(tbx_Description);
            tab_Add.Controls.Add(cmb_Speaker);
            tab_Add.Controls.Add(label3);
            tab_Add.Controls.Add(label2);
            tab_Add.Controls.Add(label1);
            tab_Add.Controls.Add(lbl_FirstName);
            tab_Add.Controls.Add(dtp_Date);
            tab_Add.Controls.Add(lbl_AddHeader);
            tab_Add.Location = new Point(4, 24);
            tab_Add.Name = "tab_Add";
            tab_Add.Padding = new Padding(3);
            tab_Add.Size = new Size(639, 351);
            tab_Add.TabIndex = 1;
            tab_Add.Text = "Add Schedule";
            tab_Add.UseVisualStyleBackColor = true;
            tab_Add.Click += tab_Add_Click;
            // 
            // lbl_Status
            // 
            lbl_Status.AutoSize = true;
            lbl_Status.Font = new Font("Georgia", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_Status.ForeColor = Color.Red;
            lbl_Status.Location = new Point(198, 196);
            lbl_Status.Name = "lbl_Status";
            lbl_Status.Size = new Size(0, 15);
            lbl_Status.TabIndex = 19;
            // 
            // btn_Register
            // 
            btn_Register.BackColor = Color.Transparent;
            btn_Register.BackgroundImage = Properties.Resources.registerBg;
            btn_Register.FlatAppearance.BorderColor = Color.FromArgb(0, 0, 0, 0);
            btn_Register.Font = new Font("Georgia", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_Register.ForeColor = Color.Black;
            btn_Register.Location = new Point(193, 223);
            btn_Register.Name = "btn_Register";
            btn_Register.Size = new Size(200, 47);
            btn_Register.TabIndex = 18;
            btn_Register.Text = "Add Schedule";
            btn_Register.UseVisualStyleBackColor = false;
            btn_Register.Click += btn_Register_Click;
            // 
            // tbx_Note
            // 
            tbx_Note.Location = new Point(194, 161);
            tbx_Note.Name = "tbx_Note";
            tbx_Note.Size = new Size(200, 23);
            tbx_Note.TabIndex = 13;
            // 
            // tbx_Description
            // 
            tbx_Description.Location = new Point(194, 122);
            tbx_Description.Name = "tbx_Description";
            tbx_Description.Size = new Size(200, 23);
            tbx_Description.TabIndex = 12;
            // 
            // cmb_Speaker
            // 
            cmb_Speaker.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_Speaker.FormattingEnabled = true;
            cmb_Speaker.Items.AddRange(new object[] { "Select a Speaker" });
            cmb_Speaker.Location = new Point(193, 83);
            cmb_Speaker.Name = "cmb_Speaker";
            cmb_Speaker.Size = new Size(200, 23);
            cmb_Speaker.TabIndex = 11;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(125, 166);
            label3.Name = "label3";
            label3.Size = new Size(47, 18);
            label3.TabIndex = 10;
            label3.Text = "Note:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(79, 126);
            label2.Name = "label2";
            label2.Size = new Size(93, 18);
            label2.TabIndex = 9;
            label2.Text = "Description:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(100, 88);
            label1.Name = "label1";
            label1.Size = new Size(71, 18);
            label1.TabIndex = 8;
            label1.Text = "Speaker:";
            // 
            // lbl_FirstName
            // 
            lbl_FirstName.AutoSize = true;
            lbl_FirstName.BackColor = Color.Transparent;
            lbl_FirstName.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_FirstName.ForeColor = Color.Black;
            lbl_FirstName.Location = new Point(125, 48);
            lbl_FirstName.Name = "lbl_FirstName";
            lbl_FirstName.Size = new Size(46, 18);
            lbl_FirstName.TabIndex = 7;
            lbl_FirstName.Text = "Date:";
            // 
            // dtp_Date
            // 
            dtp_Date.Location = new Point(193, 45);
            dtp_Date.Name = "dtp_Date";
            dtp_Date.Size = new Size(200, 23);
            dtp_Date.TabIndex = 6;
            // 
            // lbl_AddHeader
            // 
            lbl_AddHeader.AutoSize = true;
            lbl_AddHeader.BackColor = Color.Transparent;
            lbl_AddHeader.Font = new Font("Georgia", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_AddHeader.ForeColor = Color.Black;
            lbl_AddHeader.Location = new Point(6, 7);
            lbl_AddHeader.Name = "lbl_AddHeader";
            lbl_AddHeader.Size = new Size(132, 18);
            lbl_AddHeader.TabIndex = 5;
            lbl_AddHeader.Text = "Add Schedule: ";
            // 
            // tab_Update
            // 
            tab_Update.Controls.Add(lbl_UpdateStatus);
            tab_Update.Controls.Add(btn_Update);
            tab_Update.Controls.Add(tbx_UpdateNote);
            tab_Update.Controls.Add(tbx_UpdateDescription);
            tab_Update.Controls.Add(cmb_UpdateSpeaker);
            tab_Update.Controls.Add(label6);
            tab_Update.Controls.Add(label7);
            tab_Update.Controls.Add(label8);
            tab_Update.Controls.Add(label9);
            tab_Update.Controls.Add(dtp_UpdateDate);
            tab_Update.Controls.Add(cmb_ToUpdate);
            tab_Update.Controls.Add(label4);
            tab_Update.Location = new Point(4, 24);
            tab_Update.Name = "tab_Update";
            tab_Update.Size = new Size(639, 351);
            tab_Update.TabIndex = 2;
            tab_Update.Text = "Update Schedules";
            tab_Update.UseVisualStyleBackColor = true;
            // 
            // lbl_UpdateStatus
            // 
            lbl_UpdateStatus.AutoSize = true;
            lbl_UpdateStatus.Font = new Font("Georgia", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_UpdateStatus.ForeColor = Color.Red;
            lbl_UpdateStatus.Location = new Point(264, 213);
            lbl_UpdateStatus.Name = "lbl_UpdateStatus";
            lbl_UpdateStatus.Size = new Size(0, 15);
            lbl_UpdateStatus.TabIndex = 29;
            // 
            // btn_Update
            // 
            btn_Update.BackColor = Color.Transparent;
            btn_Update.BackgroundImage = Properties.Resources.registerBg;
            btn_Update.FlatAppearance.BorderColor = Color.FromArgb(0, 0, 0, 0);
            btn_Update.Font = new Font("Georgia", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_Update.ForeColor = Color.Black;
            btn_Update.Location = new Point(259, 240);
            btn_Update.Name = "btn_Update";
            btn_Update.Size = new Size(200, 47);
            btn_Update.TabIndex = 28;
            btn_Update.Text = "Update Schedule";
            btn_Update.UseVisualStyleBackColor = false;
            btn_Update.Click += btn_Update_Click_1;
            // 
            // tbx_UpdateNote
            // 
            tbx_UpdateNote.Location = new Point(260, 178);
            tbx_UpdateNote.Name = "tbx_UpdateNote";
            tbx_UpdateNote.Size = new Size(200, 23);
            tbx_UpdateNote.TabIndex = 27;
            // 
            // tbx_UpdateDescription
            // 
            tbx_UpdateDescription.Location = new Point(260, 139);
            tbx_UpdateDescription.Name = "tbx_UpdateDescription";
            tbx_UpdateDescription.Size = new Size(200, 23);
            tbx_UpdateDescription.TabIndex = 26;
            // 
            // cmb_UpdateSpeaker
            // 
            cmb_UpdateSpeaker.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_UpdateSpeaker.FormattingEnabled = true;
            cmb_UpdateSpeaker.Location = new Point(259, 100);
            cmb_UpdateSpeaker.Name = "cmb_UpdateSpeaker";
            cmb_UpdateSpeaker.Size = new Size(200, 23);
            cmb_UpdateSpeaker.TabIndex = 25;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.Black;
            label6.Location = new Point(191, 183);
            label6.Name = "label6";
            label6.Size = new Size(47, 18);
            label6.TabIndex = 24;
            label6.Text = "Note:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.Black;
            label7.Location = new Point(145, 143);
            label7.Name = "label7";
            label7.Size = new Size(93, 18);
            label7.TabIndex = 23;
            label7.Text = "Description:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.Black;
            label8.Location = new Point(166, 105);
            label8.Name = "label8";
            label8.Size = new Size(71, 18);
            label8.TabIndex = 22;
            label8.Text = "Speaker:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.Black;
            label9.Location = new Point(191, 65);
            label9.Name = "label9";
            label9.Size = new Size(46, 18);
            label9.TabIndex = 21;
            label9.Text = "Date:";
            // 
            // dtp_UpdateDate
            // 
            dtp_UpdateDate.Location = new Point(259, 62);
            dtp_UpdateDate.Name = "dtp_UpdateDate";
            dtp_UpdateDate.Size = new Size(200, 23);
            dtp_UpdateDate.TabIndex = 20;
            // 
            // cmb_ToUpdate
            // 
            cmb_ToUpdate.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_ToUpdate.FormattingEnabled = true;
            cmb_ToUpdate.Location = new Point(172, 7);
            cmb_ToUpdate.Name = "cmb_ToUpdate";
            cmb_ToUpdate.Size = new Size(200, 23);
            cmb_ToUpdate.TabIndex = 13;
            cmb_ToUpdate.SelectedIndexChanged += cmb_ToUpdate_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Georgia", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.MediumBlue;
            label4.Location = new Point(9, 9);
            label4.Name = "label4";
            label4.Size = new Size(159, 18);
            label4.TabIndex = 6;
            label4.Text = "Update Schedule: ";
            // 
            // tab_Delete
            // 
            tab_Delete.Controls.Add(lbl_RemoveStatus);
            tab_Delete.Controls.Add(btn_Remove);
            tab_Delete.Controls.Add(cmb_ToRemove);
            tab_Delete.Controls.Add(lbl_RemoveHeader);
            tab_Delete.Location = new Point(4, 24);
            tab_Delete.Name = "tab_Delete";
            tab_Delete.Size = new Size(639, 351);
            tab_Delete.TabIndex = 3;
            tab_Delete.Text = "Remove Schedule";
            tab_Delete.UseVisualStyleBackColor = true;
            // 
            // lbl_RemoveStatus
            // 
            lbl_RemoveStatus.AutoSize = true;
            lbl_RemoveStatus.Font = new Font("Georgia", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_RemoveStatus.ForeColor = Color.Red;
            lbl_RemoveStatus.Location = new Point(187, 114);
            lbl_RemoveStatus.Name = "lbl_RemoveStatus";
            lbl_RemoveStatus.Size = new Size(0, 15);
            lbl_RemoveStatus.TabIndex = 30;
            // 
            // btn_Remove
            // 
            btn_Remove.BackColor = Color.LightCoral;
            btn_Remove.FlatAppearance.BorderColor = Color.FromArgb(0, 0, 0, 0);
            btn_Remove.Font = new Font("Georgia", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_Remove.ForeColor = Color.Black;
            btn_Remove.Location = new Point(178, 54);
            btn_Remove.Name = "btn_Remove";
            btn_Remove.Size = new Size(200, 47);
            btn_Remove.TabIndex = 29;
            btn_Remove.Text = "Remove Schedule";
            btn_Remove.UseVisualStyleBackColor = false;
            btn_Remove.Click += btn_Remove_Click;
            // 
            // cmb_ToRemove
            // 
            cmb_ToRemove.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_ToRemove.FormattingEnabled = true;
            cmb_ToRemove.Location = new Point(178, 13);
            cmb_ToRemove.Name = "cmb_ToRemove";
            cmb_ToRemove.Size = new Size(200, 23);
            cmb_ToRemove.TabIndex = 15;
            // 
            // lbl_RemoveHeader
            // 
            lbl_RemoveHeader.AutoSize = true;
            lbl_RemoveHeader.BackColor = Color.Transparent;
            lbl_RemoveHeader.Font = new Font("Georgia", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_RemoveHeader.ForeColor = Color.Black;
            lbl_RemoveHeader.Location = new Point(15, 15);
            lbl_RemoveHeader.Name = "lbl_RemoveHeader";
            lbl_RemoveHeader.Size = new Size(163, 18);
            lbl_RemoveHeader.TabIndex = 14;
            lbl_RemoveHeader.Text = "Remove Schedule: ";
            // 
            // btn_Logout
            // 
            btn_Logout.BackColor = Color.Red;
            btn_Logout.FlatAppearance.BorderColor = Color.FromArgb(0, 0, 0, 0);
            btn_Logout.FlatStyle = FlatStyle.System;
            btn_Logout.Font = new Font("Georgia", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_Logout.ForeColor = Color.Red;
            btn_Logout.Location = new Point(7, 439);
            btn_Logout.Name = "btn_Logout";
            btn_Logout.Size = new Size(62, 23);
            btn_Logout.TabIndex = 27;
            btn_Logout.Text = "Logout";
            btn_Logout.UseVisualStyleBackColor = false;
            btn_Logout.Click += btn_Logout_Click;
            // 
            // AdminDiscipleshipDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PowderBlue;
            BackgroundImage = Properties.Resources.main_bg1;
            ClientSize = new Size(684, 471);
            Controls.Add(btn_Logout);
            Controls.Add(tabControl1);
            Controls.Add(lbl_Header);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AdminDiscipleshipDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Admin - Discipleship Dashboard";
            tabControl1.ResumeLayout(false);
            tab_View.ResumeLayout(false);
            tab_View.PerformLayout();
            tab_Add.ResumeLayout(false);
            tab_Add.PerformLayout();
            tab_Update.ResumeLayout(false);
            tab_Update.PerformLayout();
            tab_Delete.ResumeLayout(false);
            tab_Delete.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_Header;
        private TabControl tabControl1;
        private TabPage tab_View;
        private Label tbl_ViewHeader;
        private TabPage tab_Add;
        private TabPage tab_Update;
        private TabPage tab_Delete;
        private FlowLayoutPanel flp_ViewPanel;
        private Label lbl_AddHeader;
        private DateTimePicker dtp_Date;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label lbl_FirstName;
        private ComboBox cmb_Speaker;
        private TextBox tbx_Description;
        private TextBox tbx_Note;
        private Button btn_Register;
        private Label lbl_Status;
        private Label label4;
        private ComboBox cmb_ToUpdate;
        private Label lbl_UpdateStatus;
        private Button btn_Update;
        private TextBox tbx_UpdateNote;
        private TextBox tbx_UpdateDescription;
        private ComboBox cmb_UpdateSpeaker;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private DateTimePicker dtp_UpdateDate;
        private Button btn_Remove;
        private ComboBox cmb_ToRemove;
        private Label lbl_RemoveHeader;
        private Label lbl_RemoveStatus;
        private Button btn_Logout;
    }
}