namespace CMSWindowsForm
{
    partial class AdminPrayerDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminPrayerDashboard));
            lbl_PrayerHeader = new Label();
            btn_Logout = new Button();
            tab_PrayerTab = new TabControl();
            tab_View = new TabPage();
            flp_ViewPanel = new FlowLayoutPanel();
            tbl_ViewHeader = new Label();
            tab_Add = new TabPage();
            cmb_Speaker = new ComboBox();
            cmb_Presider = new ComboBox();
            cmb_PrayerItem = new ComboBox();
            lbl_PrayerItem = new Label();
            lbl_Status = new Label();
            btn_Register = new Button();
            cmb_SongLeader = new ComboBox();
            lbl_Speaker = new Label();
            lbl_Presider = new Label();
            lbl_SongLeader = new Label();
            lbl_Date = new Label();
            dtp_Date = new DateTimePicker();
            lbl_AddHeader = new Label();
            tab_Update = new TabPage();
            cmb_UpdateSpeaker = new ComboBox();
            cmb_UpdatePresider = new ComboBox();
            cmb_UpdatePrayerItem = new ComboBox();
            label1 = new Label();
            cmb_UpdateSongLeader = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            lbl_UpdateStatus = new Label();
            btn_Update = new Button();
            lbl_UpdateDate = new Label();
            dtp_UpdateDate = new DateTimePicker();
            cmb_ToUpdate = new ComboBox();
            lbl_UpdateHeader = new Label();
            tab_Delete = new TabPage();
            lbl_RemoveStatus = new Label();
            btn_Remove = new Button();
            cmb_ToRemove = new ComboBox();
            lbl_RemoveHeader = new Label();
            tab_PrayerTab.SuspendLayout();
            tab_View.SuspendLayout();
            tab_Add.SuspendLayout();
            tab_Update.SuspendLayout();
            tab_Delete.SuspendLayout();
            SuspendLayout();
            // 
            // lbl_PrayerHeader
            // 
            lbl_PrayerHeader.AutoSize = true;
            lbl_PrayerHeader.BackColor = Color.Transparent;
            lbl_PrayerHeader.Font = new Font("Georgia", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_PrayerHeader.ForeColor = Color.White;
            lbl_PrayerHeader.Location = new Point(12, 9);
            lbl_PrayerHeader.Name = "lbl_PrayerHeader";
            lbl_PrayerHeader.Size = new Size(250, 34);
            lbl_PrayerHeader.TabIndex = 3;
            lbl_PrayerHeader.Text = "Prayer Ministry";
            // 
            // btn_Logout
            // 
            btn_Logout.BackColor = Color.Red;
            btn_Logout.FlatAppearance.BorderColor = Color.FromArgb(0, 0, 0, 0);
            btn_Logout.FlatStyle = FlatStyle.System;
            btn_Logout.Font = new Font("Georgia", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_Logout.ForeColor = Color.Red;
            btn_Logout.Location = new Point(10, 439);
            btn_Logout.Name = "btn_Logout";
            btn_Logout.Size = new Size(62, 23);
            btn_Logout.TabIndex = 29;
            btn_Logout.Text = "Logout";
            btn_Logout.UseVisualStyleBackColor = false;
            btn_Logout.Click += btn_Logout_Click;
            // 
            // tab_PrayerTab
            // 
            tab_PrayerTab.Controls.Add(tab_View);
            tab_PrayerTab.Controls.Add(tab_Add);
            tab_PrayerTab.Controls.Add(tab_Update);
            tab_PrayerTab.Controls.Add(tab_Delete);
            tab_PrayerTab.Location = new Point(19, 55);
            tab_PrayerTab.Name = "tab_PrayerTab";
            tab_PrayerTab.SelectedIndex = 0;
            tab_PrayerTab.Size = new Size(647, 379);
            tab_PrayerTab.TabIndex = 28;
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
            tbl_ViewHeader.Location = new Point(6, 9);
            tbl_ViewHeader.Name = "tbl_ViewHeader";
            tbl_ViewHeader.Size = new Size(102, 18);
            tbl_ViewHeader.TabIndex = 4;
            tbl_ViewHeader.Text = "Schedules: ";
            // 
            // tab_Add
            // 
            tab_Add.BackgroundImageLayout = ImageLayout.Stretch;
            tab_Add.Controls.Add(cmb_Speaker);
            tab_Add.Controls.Add(cmb_Presider);
            tab_Add.Controls.Add(cmb_PrayerItem);
            tab_Add.Controls.Add(lbl_PrayerItem);
            tab_Add.Controls.Add(lbl_Status);
            tab_Add.Controls.Add(btn_Register);
            tab_Add.Controls.Add(cmb_SongLeader);
            tab_Add.Controls.Add(lbl_Speaker);
            tab_Add.Controls.Add(lbl_Presider);
            tab_Add.Controls.Add(lbl_SongLeader);
            tab_Add.Controls.Add(lbl_Date);
            tab_Add.Controls.Add(dtp_Date);
            tab_Add.Controls.Add(lbl_AddHeader);
            tab_Add.Location = new Point(4, 24);
            tab_Add.Name = "tab_Add";
            tab_Add.Padding = new Padding(3);
            tab_Add.Size = new Size(639, 351);
            tab_Add.TabIndex = 1;
            tab_Add.Text = "Add Schedule";
            tab_Add.UseVisualStyleBackColor = true;
            // 
            // cmb_Speaker
            // 
            cmb_Speaker.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_Speaker.FormattingEnabled = true;
            cmb_Speaker.Location = new Point(193, 164);
            cmb_Speaker.Name = "cmb_Speaker";
            cmb_Speaker.Size = new Size(200, 23);
            cmb_Speaker.TabIndex = 23;
            // 
            // cmb_Presider
            // 
            cmb_Presider.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_Presider.FormattingEnabled = true;
            cmb_Presider.Items.AddRange(new object[] { "" });
            cmb_Presider.Location = new Point(193, 124);
            cmb_Presider.Name = "cmb_Presider";
            cmb_Presider.Size = new Size(200, 23);
            cmb_Presider.TabIndex = 22;
            // 
            // cmb_PrayerItem
            // 
            cmb_PrayerItem.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_PrayerItem.FormattingEnabled = true;
            cmb_PrayerItem.Items.AddRange(new object[] { "A", "B", "C", "D" });
            cmb_PrayerItem.Location = new Point(193, 203);
            cmb_PrayerItem.Name = "cmb_PrayerItem";
            cmb_PrayerItem.Size = new Size(200, 23);
            cmb_PrayerItem.TabIndex = 21;
            // 
            // lbl_PrayerItem
            // 
            lbl_PrayerItem.AutoSize = true;
            lbl_PrayerItem.BackColor = Color.Transparent;
            lbl_PrayerItem.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_PrayerItem.ForeColor = Color.Black;
            lbl_PrayerItem.Location = new Point(73, 208);
            lbl_PrayerItem.Name = "lbl_PrayerItem";
            lbl_PrayerItem.Size = new Size(101, 18);
            lbl_PrayerItem.TabIndex = 20;
            lbl_PrayerItem.Text = "Prayer Item:";
            // 
            // lbl_Status
            // 
            lbl_Status.AutoSize = true;
            lbl_Status.Font = new Font("Georgia", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_Status.ForeColor = Color.Red;
            lbl_Status.Location = new Point(198, 239);
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
            btn_Register.Location = new Point(193, 257);
            btn_Register.Name = "btn_Register";
            btn_Register.Size = new Size(200, 47);
            btn_Register.TabIndex = 18;
            btn_Register.Text = "Add Schedule";
            btn_Register.UseVisualStyleBackColor = false;
            btn_Register.Click += btn_Register_Click;
            // 
            // cmb_SongLeader
            // 
            cmb_SongLeader.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_SongLeader.FormattingEnabled = true;
            cmb_SongLeader.Items.AddRange(new object[] { "" });
            cmb_SongLeader.Location = new Point(193, 83);
            cmb_SongLeader.Name = "cmb_SongLeader";
            cmb_SongLeader.Size = new Size(200, 23);
            cmb_SongLeader.TabIndex = 11;
            // 
            // lbl_Speaker
            // 
            lbl_Speaker.AutoSize = true;
            lbl_Speaker.BackColor = Color.Transparent;
            lbl_Speaker.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_Speaker.ForeColor = Color.Black;
            lbl_Speaker.Location = new Point(103, 169);
            lbl_Speaker.Name = "lbl_Speaker";
            lbl_Speaker.Size = new Size(71, 18);
            lbl_Speaker.TabIndex = 10;
            lbl_Speaker.Text = "Speaker:";
            // 
            // lbl_Presider
            // 
            lbl_Presider.AutoSize = true;
            lbl_Presider.BackColor = Color.Transparent;
            lbl_Presider.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_Presider.ForeColor = Color.Black;
            lbl_Presider.Location = new Point(101, 129);
            lbl_Presider.Name = "lbl_Presider";
            lbl_Presider.Size = new Size(73, 18);
            lbl_Presider.TabIndex = 9;
            lbl_Presider.Text = "Presider:";
            // 
            // lbl_SongLeader
            // 
            lbl_SongLeader.AutoSize = true;
            lbl_SongLeader.BackColor = Color.Transparent;
            lbl_SongLeader.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_SongLeader.ForeColor = Color.Black;
            lbl_SongLeader.Location = new Point(73, 91);
            lbl_SongLeader.Name = "lbl_SongLeader";
            lbl_SongLeader.Size = new Size(101, 18);
            lbl_SongLeader.TabIndex = 8;
            lbl_SongLeader.Text = "Song Leader:";
            // 
            // lbl_Date
            // 
            lbl_Date.AutoSize = true;
            lbl_Date.BackColor = Color.Transparent;
            lbl_Date.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_Date.ForeColor = Color.Black;
            lbl_Date.Location = new Point(128, 51);
            lbl_Date.Name = "lbl_Date";
            lbl_Date.Size = new Size(46, 18);
            lbl_Date.TabIndex = 7;
            lbl_Date.Text = "Date:";
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
            lbl_AddHeader.Location = new Point(9, 10);
            lbl_AddHeader.Name = "lbl_AddHeader";
            lbl_AddHeader.Size = new Size(132, 18);
            lbl_AddHeader.TabIndex = 5;
            lbl_AddHeader.Text = "Add Schedule: ";
            // 
            // tab_Update
            // 
            tab_Update.Controls.Add(cmb_UpdateSpeaker);
            tab_Update.Controls.Add(cmb_UpdatePresider);
            tab_Update.Controls.Add(cmb_UpdatePrayerItem);
            tab_Update.Controls.Add(label1);
            tab_Update.Controls.Add(cmb_UpdateSongLeader);
            tab_Update.Controls.Add(label2);
            tab_Update.Controls.Add(label3);
            tab_Update.Controls.Add(label4);
            tab_Update.Controls.Add(lbl_UpdateStatus);
            tab_Update.Controls.Add(btn_Update);
            tab_Update.Controls.Add(lbl_UpdateDate);
            tab_Update.Controls.Add(dtp_UpdateDate);
            tab_Update.Controls.Add(cmb_ToUpdate);
            tab_Update.Controls.Add(lbl_UpdateHeader);
            tab_Update.Location = new Point(4, 24);
            tab_Update.Name = "tab_Update";
            tab_Update.Size = new Size(639, 351);
            tab_Update.TabIndex = 2;
            tab_Update.Text = "Update Schedules";
            tab_Update.UseVisualStyleBackColor = true;
            // 
            // cmb_UpdateSpeaker
            // 
            cmb_UpdateSpeaker.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_UpdateSpeaker.FormattingEnabled = true;
            cmb_UpdateSpeaker.Location = new Point(258, 177);
            cmb_UpdateSpeaker.Name = "cmb_UpdateSpeaker";
            cmb_UpdateSpeaker.Size = new Size(200, 23);
            cmb_UpdateSpeaker.TabIndex = 37;
            // 
            // cmb_UpdatePresider
            // 
            cmb_UpdatePresider.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_UpdatePresider.FormattingEnabled = true;
            cmb_UpdatePresider.Items.AddRange(new object[] { "" });
            cmb_UpdatePresider.Location = new Point(258, 137);
            cmb_UpdatePresider.Name = "cmb_UpdatePresider";
            cmb_UpdatePresider.Size = new Size(200, 23);
            cmb_UpdatePresider.TabIndex = 36;
            // 
            // cmb_UpdatePrayerItem
            // 
            cmb_UpdatePrayerItem.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_UpdatePrayerItem.FormattingEnabled = true;
            cmb_UpdatePrayerItem.Items.AddRange(new object[] { "A", "B", "C", "D" });
            cmb_UpdatePrayerItem.Location = new Point(258, 216);
            cmb_UpdatePrayerItem.Name = "cmb_UpdatePrayerItem";
            cmb_UpdatePrayerItem.Size = new Size(200, 23);
            cmb_UpdatePrayerItem.TabIndex = 35;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(138, 219);
            label1.Name = "label1";
            label1.Size = new Size(101, 18);
            label1.TabIndex = 34;
            label1.Text = "Prayer Item:";
            // 
            // cmb_UpdateSongLeader
            // 
            cmb_UpdateSongLeader.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_UpdateSongLeader.FormattingEnabled = true;
            cmb_UpdateSongLeader.Items.AddRange(new object[] { "" });
            cmb_UpdateSongLeader.Location = new Point(258, 99);
            cmb_UpdateSongLeader.Name = "cmb_UpdateSongLeader";
            cmb_UpdateSongLeader.Size = new Size(200, 23);
            cmb_UpdateSongLeader.TabIndex = 33;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(168, 179);
            label2.Name = "label2";
            label2.Size = new Size(71, 18);
            label2.TabIndex = 32;
            label2.Text = "Speaker:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(166, 140);
            label3.Name = "label3";
            label3.Size = new Size(73, 18);
            label3.TabIndex = 31;
            label3.Text = "Presider:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(138, 101);
            label4.Name = "label4";
            label4.Size = new Size(101, 18);
            label4.TabIndex = 30;
            label4.Text = "Song Leader:";
            // 
            // lbl_UpdateStatus
            // 
            lbl_UpdateStatus.AutoSize = true;
            lbl_UpdateStatus.Font = new Font("Georgia", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_UpdateStatus.ForeColor = Color.Red;
            lbl_UpdateStatus.Location = new Point(262, 248);
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
            btn_Update.Location = new Point(259, 269);
            btn_Update.Name = "btn_Update";
            btn_Update.Size = new Size(200, 47);
            btn_Update.TabIndex = 28;
            btn_Update.Text = "Update Schedule";
            btn_Update.UseVisualStyleBackColor = false;
            btn_Update.Click += btn_Update_Click;
            // 
            // lbl_UpdateDate
            // 
            lbl_UpdateDate.AutoSize = true;
            lbl_UpdateDate.BackColor = Color.Transparent;
            lbl_UpdateDate.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_UpdateDate.ForeColor = Color.Black;
            lbl_UpdateDate.Location = new Point(191, 65);
            lbl_UpdateDate.Name = "lbl_UpdateDate";
            lbl_UpdateDate.Size = new Size(46, 18);
            lbl_UpdateDate.TabIndex = 21;
            lbl_UpdateDate.Text = "Date:";
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
            // lbl_UpdateHeader
            // 
            lbl_UpdateHeader.AutoSize = true;
            lbl_UpdateHeader.BackColor = Color.Transparent;
            lbl_UpdateHeader.Font = new Font("Georgia", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_UpdateHeader.ForeColor = Color.Black;
            lbl_UpdateHeader.Location = new Point(9, 9);
            lbl_UpdateHeader.Name = "lbl_UpdateHeader";
            lbl_UpdateHeader.Size = new Size(159, 18);
            lbl_UpdateHeader.TabIndex = 6;
            lbl_UpdateHeader.Text = "Update Schedule: ";
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
            // AdminPrayerDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.main_bg1;
            ClientSize = new Size(684, 471);
            Controls.Add(btn_Logout);
            Controls.Add(tab_PrayerTab);
            Controls.Add(lbl_PrayerHeader);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AdminPrayerDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Admin - Prayer Dashboard";
            tab_PrayerTab.ResumeLayout(false);
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

        private Label lbl_PrayerHeader;
        private Button btn_Logout;
        private TabControl tab_PrayerTab;
        private TabPage tab_View;
        private FlowLayoutPanel flp_ViewPanel;
        private Label tbl_ViewHeader;
        private TabPage tab_Add;
        private Label lbl_Status;
        private Button btn_Register;
        private ComboBox cmb_SongLeader;
        private Label lbl_Speaker;
        private Label lbl_Presider;
        private Label lbl_SongLeader;
        private Label lbl_Date;
        private DateTimePicker dtp_Date;
        private Label lbl_AddHeader;
        private TabPage tab_Update;
        private Label lbl_UpdateStatus;
        private Button btn_Update;
        private Label lbl_UpdateDate;
        private DateTimePicker dtp_UpdateDate;
        private ComboBox cmb_ToUpdate;
        private Label lbl_UpdateHeader;
        private TabPage tab_Delete;
        private Label lbl_RemoveStatus;
        private Button btn_Remove;
        private ComboBox cmb_ToRemove;
        private Label lbl_RemoveHeader;
        private ComboBox cmb_PrayerItem;
        private Label lbl_PrayerItem;
        private ComboBox cmb_Speaker;
        private ComboBox cmb_Presider;
        private ComboBox cmb_UpdateSpeaker;
        private ComboBox cmb_UpdatePresider;
        private ComboBox cmb_UpdatePrayerItem;
        private Label label1;
        private ComboBox cmb_UpdateSongLeader;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}