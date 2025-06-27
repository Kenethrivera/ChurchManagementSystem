namespace CMSWindowsForm
{
    partial class AdminWorshipDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminWorshipDashboard));
            cmb_ScheduleType = new ComboBox();
            lbl_ScheduleType = new Label();
            lbl_WorshipHeader = new Label();
            tab_PrayerTab = new TabControl();
            tab_View = new TabPage();
            flp_ViewPanel = new FlowLayoutPanel();
            lbl_ViewHeader = new Label();
            tab_Add = new TabPage();
            cmb_AddPresider = new ComboBox();
            cmb_AddSongLeader = new ComboBox();
            cmb_AddUshers = new ComboBox();
            cmb_AddSpeaker = new ComboBox();
            lbl_AddUshers = new Label();
            lbl_AddSpeaker = new Label();
            lbl_AddDate = new Label();
            dtp_Date = new DateTimePicker();
            lbl_AddStatus = new Label();
            btn_Add = new Button();
            lbl_AddPresider = new Label();
            lbl_AddSongLeader = new Label();
            lbl_AddHeader = new Label();
            tab_Update = new TabPage();
            cmb_UpdatePresider = new ComboBox();
            lbl_UpdateStatus = new Label();
            cmb_UpdateSongLeader = new ComboBox();
            btn_Update = new Button();
            cmb_UpdateUshers = new ComboBox();
            cmb_ToUpdate = new ComboBox();
            cmb_UpdateSpeaker = new ComboBox();
            lbl_UpdateHeader = new Label();
            lbl_UpdateUshers = new Label();
            lbl_UpdateDate = new Label();
            lbl_UpdateSpeaker = new Label();
            lbl_UpdateSongLeader = new Label();
            lbl_UpdatePresider = new Label();
            dtp_UpdateDate = new DateTimePicker();
            tab_Delete = new TabPage();
            lbl_RemoveStatus = new Label();
            btn_Remove = new Button();
            cmb_ToRemove = new ComboBox();
            lbl_RemoveHeader = new Label();
            btn_Logout = new Button();
            tab_PrayerTab.SuspendLayout();
            tab_View.SuspendLayout();
            tab_Add.SuspendLayout();
            tab_Update.SuspendLayout();
            tab_Delete.SuspendLayout();
            SuspendLayout();
            // 
            // cmb_ScheduleType
            // 
            cmb_ScheduleType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_ScheduleType.ForeColor = Color.Black;
            cmb_ScheduleType.FormattingEnabled = true;
            cmb_ScheduleType.Items.AddRange(new object[] { "Praise and Worship", "Sunday Worship Service", "Devotion" });
            cmb_ScheduleType.Location = new Point(562, 14);
            cmb_ScheduleType.Name = "cmb_ScheduleType";
            cmb_ScheduleType.Size = new Size(105, 23);
            cmb_ScheduleType.TabIndex = 16;
            cmb_ScheduleType.SelectedIndexChanged += cmb_ScheduleType_SelectedIndexChanged;
            // 
            // lbl_ScheduleType
            // 
            lbl_ScheduleType.AutoSize = true;
            lbl_ScheduleType.BackColor = Color.Transparent;
            lbl_ScheduleType.Font = new Font("Georgia", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_ScheduleType.ForeColor = Color.Transparent;
            lbl_ScheduleType.Location = new Point(520, 18);
            lbl_ScheduleType.Name = "lbl_ScheduleType";
            lbl_ScheduleType.Size = new Size(36, 15);
            lbl_ScheduleType.TabIndex = 15;
            lbl_ScheduleType.Text = "Type";
            // 
            // lbl_WorshipHeader
            // 
            lbl_WorshipHeader.AutoSize = true;
            lbl_WorshipHeader.BackColor = Color.Transparent;
            lbl_WorshipHeader.Font = new Font("Georgia", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_WorshipHeader.ForeColor = Color.Transparent;
            lbl_WorshipHeader.Location = new Point(8, 7);
            lbl_WorshipHeader.Name = "lbl_WorshipHeader";
            lbl_WorshipHeader.Size = new Size(280, 34);
            lbl_WorshipHeader.TabIndex = 14;
            lbl_WorshipHeader.Text = "Worship Ministry";
            // 
            // tab_PrayerTab
            // 
            tab_PrayerTab.Controls.Add(tab_View);
            tab_PrayerTab.Controls.Add(tab_Add);
            tab_PrayerTab.Controls.Add(tab_Update);
            tab_PrayerTab.Controls.Add(tab_Delete);
            tab_PrayerTab.Location = new Point(20, 57);
            tab_PrayerTab.Name = "tab_PrayerTab";
            tab_PrayerTab.SelectedIndex = 0;
            tab_PrayerTab.Size = new Size(647, 379);
            tab_PrayerTab.TabIndex = 31;
            // 
            // tab_View
            // 
            tab_View.BackgroundImageLayout = ImageLayout.Stretch;
            tab_View.Controls.Add(flp_ViewPanel);
            tab_View.Controls.Add(lbl_ViewHeader);
            tab_View.Location = new Point(4, 24);
            tab_View.Name = "tab_View";
            tab_View.Padding = new Padding(3);
            tab_View.Size = new Size(639, 351);
            tab_View.TabIndex = 0;
            tab_View.Text = "View Schedule";
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
            // lbl_ViewHeader
            // 
            lbl_ViewHeader.AutoSize = true;
            lbl_ViewHeader.BackColor = Color.Transparent;
            lbl_ViewHeader.Font = new Font("Georgia", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_ViewHeader.ForeColor = Color.Black;
            lbl_ViewHeader.Location = new Point(12, 11);
            lbl_ViewHeader.Name = "lbl_ViewHeader";
            lbl_ViewHeader.Size = new Size(102, 18);
            lbl_ViewHeader.TabIndex = 4;
            lbl_ViewHeader.Text = "Schedules: ";
            // 
            // tab_Add
            // 
            tab_Add.BackgroundImageLayout = ImageLayout.Stretch;
            tab_Add.Controls.Add(cmb_AddPresider);
            tab_Add.Controls.Add(cmb_AddSongLeader);
            tab_Add.Controls.Add(cmb_AddUshers);
            tab_Add.Controls.Add(cmb_AddSpeaker);
            tab_Add.Controls.Add(lbl_AddUshers);
            tab_Add.Controls.Add(lbl_AddSpeaker);
            tab_Add.Controls.Add(lbl_AddDate);
            tab_Add.Controls.Add(dtp_Date);
            tab_Add.Controls.Add(lbl_AddStatus);
            tab_Add.Controls.Add(btn_Add);
            tab_Add.Controls.Add(lbl_AddPresider);
            tab_Add.Controls.Add(lbl_AddSongLeader);
            tab_Add.Controls.Add(lbl_AddHeader);
            tab_Add.Location = new Point(4, 24);
            tab_Add.Name = "tab_Add";
            tab_Add.Padding = new Padding(3);
            tab_Add.Size = new Size(639, 351);
            tab_Add.TabIndex = 1;
            tab_Add.Text = "Add Schedule";
            tab_Add.UseVisualStyleBackColor = true;
            // 
            // cmb_AddPresider
            // 
            cmb_AddPresider.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_AddPresider.ForeColor = Color.Black;
            cmb_AddPresider.FormattingEnabled = true;
            cmb_AddPresider.Location = new Point(231, 133);
            cmb_AddPresider.Name = "cmb_AddPresider";
            cmb_AddPresider.Size = new Size(200, 23);
            cmb_AddPresider.TabIndex = 45;
            // 
            // cmb_AddSongLeader
            // 
            cmb_AddSongLeader.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_AddSongLeader.ForeColor = Color.Black;
            cmb_AddSongLeader.FormattingEnabled = true;
            cmb_AddSongLeader.Location = new Point(231, 97);
            cmb_AddSongLeader.Name = "cmb_AddSongLeader";
            cmb_AddSongLeader.Size = new Size(200, 23);
            cmb_AddSongLeader.TabIndex = 44;
            // 
            // cmb_AddUshers
            // 
            cmb_AddUshers.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_AddUshers.ForeColor = Color.Black;
            cmb_AddUshers.FormattingEnabled = true;
            cmb_AddUshers.Location = new Point(231, 203);
            cmb_AddUshers.Name = "cmb_AddUshers";
            cmb_AddUshers.Size = new Size(200, 23);
            cmb_AddUshers.TabIndex = 43;
            // 
            // cmb_AddSpeaker
            // 
            cmb_AddSpeaker.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_AddSpeaker.ForeColor = Color.Black;
            cmb_AddSpeaker.FormattingEnabled = true;
            cmb_AddSpeaker.Location = new Point(231, 167);
            cmb_AddSpeaker.Name = "cmb_AddSpeaker";
            cmb_AddSpeaker.Size = new Size(200, 23);
            cmb_AddSpeaker.TabIndex = 33;
            // 
            // lbl_AddUshers
            // 
            lbl_AddUshers.BackColor = Color.Transparent;
            lbl_AddUshers.FlatStyle = FlatStyle.Flat;
            lbl_AddUshers.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_AddUshers.ForeColor = Color.Black;
            lbl_AddUshers.Location = new Point(149, 203);
            lbl_AddUshers.Name = "lbl_AddUshers";
            lbl_AddUshers.Size = new Size(77, 18);
            lbl_AddUshers.TabIndex = 42;
            lbl_AddUshers.Text = "Ushers:";
            // 
            // lbl_AddSpeaker
            // 
            lbl_AddSpeaker.BackColor = Color.Transparent;
            lbl_AddSpeaker.FlatStyle = FlatStyle.Flat;
            lbl_AddSpeaker.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_AddSpeaker.ForeColor = Color.Black;
            lbl_AddSpeaker.Location = new Point(142, 167);
            lbl_AddSpeaker.Name = "lbl_AddSpeaker";
            lbl_AddSpeaker.Size = new Size(84, 18);
            lbl_AddSpeaker.TabIndex = 41;
            lbl_AddSpeaker.Text = "Speaker:";
            // 
            // lbl_AddDate
            // 
            lbl_AddDate.AutoSize = true;
            lbl_AddDate.BackColor = Color.Transparent;
            lbl_AddDate.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_AddDate.ForeColor = Color.Black;
            lbl_AddDate.Location = new Point(168, 59);
            lbl_AddDate.Name = "lbl_AddDate";
            lbl_AddDate.Size = new Size(46, 18);
            lbl_AddDate.TabIndex = 25;
            lbl_AddDate.Text = "Date:";
            // 
            // dtp_Date
            // 
            dtp_Date.Location = new Point(231, 53);
            dtp_Date.Name = "dtp_Date";
            dtp_Date.Size = new Size(200, 23);
            dtp_Date.TabIndex = 24;
            // 
            // lbl_AddStatus
            // 
            lbl_AddStatus.AutoSize = true;
            lbl_AddStatus.Font = new Font("Georgia", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_AddStatus.ForeColor = Color.Red;
            lbl_AddStatus.Location = new Point(237, 233);
            lbl_AddStatus.Name = "lbl_AddStatus";
            lbl_AddStatus.Size = new Size(0, 15);
            lbl_AddStatus.TabIndex = 19;
            // 
            // btn_Add
            // 
            btn_Add.BackColor = Color.Transparent;
            btn_Add.BackgroundImage = Properties.Resources.registerBg;
            btn_Add.FlatAppearance.BorderColor = Color.FromArgb(0, 0, 0, 0);
            btn_Add.Font = new Font("Georgia", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_Add.ForeColor = Color.Black;
            btn_Add.Location = new Point(231, 249);
            btn_Add.Name = "btn_Add";
            btn_Add.Size = new Size(200, 47);
            btn_Add.TabIndex = 18;
            btn_Add.Text = "Add Schedule";
            btn_Add.UseVisualStyleBackColor = false;
            btn_Add.Click += btn_Add_Click;
            // 
            // lbl_AddPresider
            // 
            lbl_AddPresider.BackColor = Color.Transparent;
            lbl_AddPresider.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_AddPresider.ForeColor = Color.Black;
            lbl_AddPresider.Location = new Point(86, 133);
            lbl_AddPresider.Name = "lbl_AddPresider";
            lbl_AddPresider.Size = new Size(178, 18);
            lbl_AddPresider.TabIndex = 9;
            lbl_AddPresider.Text = "              Presider:  ";
            // 
            // lbl_AddSongLeader
            // 
            lbl_AddSongLeader.BackColor = Color.Transparent;
            lbl_AddSongLeader.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_AddSongLeader.ForeColor = Color.Black;
            lbl_AddSongLeader.Location = new Point(112, 97);
            lbl_AddSongLeader.Name = "lbl_AddSongLeader";
            lbl_AddSongLeader.Size = new Size(114, 18);
            lbl_AddSongLeader.TabIndex = 8;
            lbl_AddSongLeader.Text = "Song Leader:";
            // 
            // lbl_AddHeader
            // 
            lbl_AddHeader.AutoSize = true;
            lbl_AddHeader.BackColor = Color.Transparent;
            lbl_AddHeader.Font = new Font("Georgia", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_AddHeader.ForeColor = Color.Black;
            lbl_AddHeader.Location = new Point(15, 16);
            lbl_AddHeader.Name = "lbl_AddHeader";
            lbl_AddHeader.Size = new Size(132, 18);
            lbl_AddHeader.TabIndex = 5;
            lbl_AddHeader.Text = "Add Schedule: ";
            // 
            // tab_Update
            // 
            tab_Update.BackColor = Color.WhiteSmoke;
            tab_Update.Controls.Add(cmb_UpdatePresider);
            tab_Update.Controls.Add(lbl_UpdateStatus);
            tab_Update.Controls.Add(cmb_UpdateSongLeader);
            tab_Update.Controls.Add(btn_Update);
            tab_Update.Controls.Add(cmb_UpdateUshers);
            tab_Update.Controls.Add(cmb_ToUpdate);
            tab_Update.Controls.Add(cmb_UpdateSpeaker);
            tab_Update.Controls.Add(lbl_UpdateHeader);
            tab_Update.Controls.Add(lbl_UpdateUshers);
            tab_Update.Controls.Add(lbl_UpdateDate);
            tab_Update.Controls.Add(lbl_UpdateSpeaker);
            tab_Update.Controls.Add(lbl_UpdateSongLeader);
            tab_Update.Controls.Add(lbl_UpdatePresider);
            tab_Update.Controls.Add(dtp_UpdateDate);
            tab_Update.Location = new Point(4, 24);
            tab_Update.Name = "tab_Update";
            tab_Update.Size = new Size(639, 351);
            tab_Update.TabIndex = 2;
            tab_Update.Text = "Update Schedule";
            // 
            // cmb_UpdatePresider
            // 
            cmb_UpdatePresider.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_UpdatePresider.ForeColor = Color.Black;
            cmb_UpdatePresider.FormattingEnabled = true;
            cmb_UpdatePresider.Location = new Point(234, 138);
            cmb_UpdatePresider.Name = "cmb_UpdatePresider";
            cmb_UpdatePresider.Size = new Size(200, 23);
            cmb_UpdatePresider.TabIndex = 55;
            // 
            // lbl_UpdateStatus
            // 
            lbl_UpdateStatus.AutoSize = true;
            lbl_UpdateStatus.Font = new Font("Georgia", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_UpdateStatus.ForeColor = Color.Red;
            lbl_UpdateStatus.Location = new Point(238, 237);
            lbl_UpdateStatus.Name = "lbl_UpdateStatus";
            lbl_UpdateStatus.Size = new Size(0, 15);
            lbl_UpdateStatus.TabIndex = 29;
            // 
            // cmb_UpdateSongLeader
            // 
            cmb_UpdateSongLeader.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_UpdateSongLeader.ForeColor = Color.Black;
            cmb_UpdateSongLeader.FormattingEnabled = true;
            cmb_UpdateSongLeader.Location = new Point(234, 102);
            cmb_UpdateSongLeader.Name = "cmb_UpdateSongLeader";
            cmb_UpdateSongLeader.Size = new Size(200, 23);
            cmb_UpdateSongLeader.TabIndex = 54;
            // 
            // btn_Update
            // 
            btn_Update.BackColor = Color.WhiteSmoke;
            btn_Update.BackgroundImage = Properties.Resources.registerBg;
            btn_Update.FlatAppearance.BorderColor = Color.FromArgb(0, 0, 0, 0);
            btn_Update.Font = new Font("Georgia", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_Update.ForeColor = Color.Black;
            btn_Update.Location = new Point(230, 257);
            btn_Update.Name = "btn_Update";
            btn_Update.Size = new Size(200, 47);
            btn_Update.TabIndex = 28;
            btn_Update.Text = "Update Schedule";
            btn_Update.UseVisualStyleBackColor = false;
            btn_Update.Click += btn_Update_Click;
            // 
            // cmb_UpdateUshers
            // 
            cmb_UpdateUshers.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_UpdateUshers.ForeColor = Color.Black;
            cmb_UpdateUshers.FormattingEnabled = true;
            cmb_UpdateUshers.Location = new Point(234, 208);
            cmb_UpdateUshers.Name = "cmb_UpdateUshers";
            cmb_UpdateUshers.Size = new Size(200, 23);
            cmb_UpdateUshers.TabIndex = 53;
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
            // cmb_UpdateSpeaker
            // 
            cmb_UpdateSpeaker.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_UpdateSpeaker.ForeColor = Color.Black;
            cmb_UpdateSpeaker.FormattingEnabled = true;
            cmb_UpdateSpeaker.Location = new Point(234, 172);
            cmb_UpdateSpeaker.Name = "cmb_UpdateSpeaker";
            cmb_UpdateSpeaker.Size = new Size(200, 23);
            cmb_UpdateSpeaker.TabIndex = 50;
            // 
            // lbl_UpdateHeader
            // 
            lbl_UpdateHeader.AutoSize = true;
            lbl_UpdateHeader.BackColor = Color.WhiteSmoke;
            lbl_UpdateHeader.Font = new Font("Georgia", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_UpdateHeader.ForeColor = Color.Black;
            lbl_UpdateHeader.Location = new Point(9, 9);
            lbl_UpdateHeader.Name = "lbl_UpdateHeader";
            lbl_UpdateHeader.Size = new Size(159, 18);
            lbl_UpdateHeader.TabIndex = 6;
            lbl_UpdateHeader.Text = "Update Schedule: ";
            // 
            // lbl_UpdateUshers
            // 
            lbl_UpdateUshers.BackColor = Color.Transparent;
            lbl_UpdateUshers.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_UpdateUshers.ForeColor = Color.Black;
            lbl_UpdateUshers.Location = new Point(152, 208);
            lbl_UpdateUshers.Name = "lbl_UpdateUshers";
            lbl_UpdateUshers.Size = new Size(115, 18);
            lbl_UpdateUshers.TabIndex = 52;
            lbl_UpdateUshers.Text = "Ushers:";
            // 
            // lbl_UpdateDate
            // 
            lbl_UpdateDate.AutoSize = true;
            lbl_UpdateDate.BackColor = Color.Transparent;
            lbl_UpdateDate.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_UpdateDate.ForeColor = Color.Black;
            lbl_UpdateDate.Location = new Point(171, 64);
            lbl_UpdateDate.Name = "lbl_UpdateDate";
            lbl_UpdateDate.Size = new Size(46, 18);
            lbl_UpdateDate.TabIndex = 49;
            lbl_UpdateDate.Text = "Date:";
            // 
            // lbl_UpdateSpeaker
            // 
            lbl_UpdateSpeaker.BackColor = Color.Transparent;
            lbl_UpdateSpeaker.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_UpdateSpeaker.ForeColor = Color.Black;
            lbl_UpdateSpeaker.Location = new Point(145, 172);
            lbl_UpdateSpeaker.Name = "lbl_UpdateSpeaker";
            lbl_UpdateSpeaker.Size = new Size(94, 18);
            lbl_UpdateSpeaker.TabIndex = 51;
            lbl_UpdateSpeaker.Text = "Speaker:";
            // 
            // lbl_UpdateSongLeader
            // 
            lbl_UpdateSongLeader.BackColor = Color.Transparent;
            lbl_UpdateSongLeader.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_UpdateSongLeader.ForeColor = Color.Black;
            lbl_UpdateSongLeader.Location = new Point(115, 102);
            lbl_UpdateSongLeader.Name = "lbl_UpdateSongLeader";
            lbl_UpdateSongLeader.Size = new Size(114, 18);
            lbl_UpdateSongLeader.TabIndex = 46;
            lbl_UpdateSongLeader.Text = "Song Leader:";
            // 
            // lbl_UpdatePresider
            // 
            lbl_UpdatePresider.BackColor = Color.Transparent;
            lbl_UpdatePresider.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_UpdatePresider.ForeColor = Color.Black;
            lbl_UpdatePresider.Location = new Point(89, 138);
            lbl_UpdatePresider.Name = "lbl_UpdatePresider";
            lbl_UpdatePresider.Size = new Size(178, 18);
            lbl_UpdatePresider.TabIndex = 47;
            lbl_UpdatePresider.Text = "              Presider:  ";
            // 
            // dtp_UpdateDate
            // 
            dtp_UpdateDate.Location = new Point(234, 58);
            dtp_UpdateDate.Name = "dtp_UpdateDate";
            dtp_UpdateDate.Size = new Size(200, 23);
            dtp_UpdateDate.TabIndex = 48;
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
            btn_Logout.Location = new Point(12, 442);
            btn_Logout.Name = "btn_Logout";
            btn_Logout.Size = new Size(62, 23);
            btn_Logout.TabIndex = 32;
            btn_Logout.Text = "Logout";
            btn_Logout.UseVisualStyleBackColor = false;
            btn_Logout.Click += btn_Logout_Click;
            // 
            // AdminWorshipDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.main_bg1;
            ClientSize = new Size(684, 471);
            Controls.Add(btn_Logout);
            Controls.Add(tab_PrayerTab);
            Controls.Add(cmb_ScheduleType);
            Controls.Add(lbl_ScheduleType);
            Controls.Add(lbl_WorshipHeader);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AdminWorshipDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Admin- Worship Dashboard";
            Load += AdminWorshipDashboard_Load;
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

        private ComboBox cmb_ScheduleType;
        private Label lbl_ScheduleType;
        private Label lbl_WorshipHeader;
        private TabControl tab_PrayerTab;
        private TabPage tab_View;
        private FlowLayoutPanel flp_ViewPanel;
        private Label lbl_ViewHeader;
        private TabPage tab_Add;
        private Label lbl_AddDate;
        private DateTimePicker dtp_Date;
        private Label lbl_AddStatus;
        private Button btn_Add;
        private Label lbl_AddPresider;
        private Label lbl_AddSongLeader;
        private Label lbl_AddHeader;
        private TabPage tab_Update;
        private Label lbl_UpdateStatus;
        private Button btn_Update;
        private ComboBox cmb_ToUpdate;
        private Label lbl_UpdateHeader;
        private TabPage tab_Delete;
        private Label lbl_RemoveStatus;
        private Button btn_Remove;
        private ComboBox cmb_ToRemove;
        private Label lbl_RemoveHeader;
        private Button btn_Logout;
        private ComboBox cmb_AddUshers;
        private ComboBox cmb_AddSpeaker;
        private Label lbl_AddUshers;
        private Label lbl_AddSpeaker;
        private ComboBox cmb_AddPresider;
        private ComboBox cmb_AddSongLeader;
        private ComboBox cmb_UpdatePresider;
        private ComboBox cmb_UpdateSongLeader;
        private ComboBox cmb_UpdateUshers;
        private ComboBox cmb_UpdateSpeaker;
        private Label lbl_UpdateUshers;
        private Label lbl_UpdateDate;
        private Label lbl_UpdateSpeaker;
        private Label lbl_UpdateSongLeader;
        private Label lbl_UpdatePresider;
        private DateTimePicker dtp_UpdateDate;
    }
}