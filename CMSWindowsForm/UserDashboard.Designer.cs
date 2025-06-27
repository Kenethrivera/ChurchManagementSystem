namespace CMSWindowsForm
{
    partial class UserDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserDashboard));
            lbl_Header = new Label();
            tab_PrayerTab = new TabControl();
            tab_View = new TabPage();
            flowLayoutPanel1 = new FlowLayoutPanel();
            lbl_ViewHeader = new Label();
            tab_Pending = new TabPage();
            label1 = new Label();
            flp_PendingSchedules = new FlowLayoutPanel();
            tab_Confirm = new TabPage();
            flp_ConfirmedSchedules = new FlowLayoutPanel();
            lbl_UpdateHeader = new Label();
            btn_Logout = new Button();
            cmb_ScheduleType = new ComboBox();
            lbl_ScheduleType = new Label();
            tab_PrayerTab.SuspendLayout();
            tab_View.SuspendLayout();
            tab_Pending.SuspendLayout();
            tab_Confirm.SuspendLayout();
            SuspendLayout();
            // 
            // lbl_Header
            // 
            lbl_Header.AutoSize = true;
            lbl_Header.BackColor = Color.Transparent;
            lbl_Header.Font = new Font("Georgia", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_Header.ForeColor = Color.Transparent;
            lbl_Header.Location = new Point(19, 9);
            lbl_Header.Name = "lbl_Header";
            lbl_Header.Size = new Size(189, 38);
            lbl_Header.TabIndex = 2;
            lbl_Header.Text = "Welcome, ";
            lbl_Header.Click += lbl_Header_Click;
            // 
            // tab_PrayerTab
            // 
            tab_PrayerTab.Controls.Add(tab_View);
            tab_PrayerTab.Controls.Add(tab_Pending);
            tab_PrayerTab.Controls.Add(tab_Confirm);
            tab_PrayerTab.Location = new Point(18, 58);
            tab_PrayerTab.Name = "tab_PrayerTab";
            tab_PrayerTab.SelectedIndex = 0;
            tab_PrayerTab.Size = new Size(647, 379);
            tab_PrayerTab.TabIndex = 32;
            tab_PrayerTab.SelectedIndexChanged += tab_PrayerTab_SelectedIndexChanged;
            // 
            // tab_View
            // 
            tab_View.BackgroundImageLayout = ImageLayout.Stretch;
            tab_View.Controls.Add(flowLayoutPanel1);
            tab_View.Controls.Add(lbl_ViewHeader);
            tab_View.Location = new Point(4, 24);
            tab_View.Name = "tab_View";
            tab_View.Padding = new Padding(3);
            tab_View.Size = new Size(639, 351);
            tab_View.TabIndex = 0;
            tab_View.Text = "Your Ministry";
            tab_View.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Location = new Point(14, 34);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(608, 292);
            flowLayoutPanel1.TabIndex = 5;
            // 
            // lbl_ViewHeader
            // 
            lbl_ViewHeader.AutoSize = true;
            lbl_ViewHeader.BackColor = Color.Transparent;
            lbl_ViewHeader.Font = new Font("Georgia", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_ViewHeader.ForeColor = Color.Black;
            lbl_ViewHeader.Location = new Point(16, 11);
            lbl_ViewHeader.Name = "lbl_ViewHeader";
            lbl_ViewHeader.Size = new Size(102, 18);
            lbl_ViewHeader.TabIndex = 4;
            lbl_ViewHeader.Text = "Schedules: ";
            // 
            // tab_Pending
            // 
            tab_Pending.BackgroundImageLayout = ImageLayout.Stretch;
            tab_Pending.Controls.Add(label1);
            tab_Pending.Controls.Add(flp_PendingSchedules);
            tab_Pending.Location = new Point(4, 24);
            tab_Pending.Name = "tab_Pending";
            tab_Pending.Padding = new Padding(3);
            tab_Pending.Size = new Size(639, 351);
            tab_Pending.TabIndex = 1;
            tab_Pending.Text = "Pending Schedule";
            tab_Pending.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Georgia", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(13, 7);
            label1.Name = "label1";
            label1.Size = new Size(174, 18);
            label1.TabIndex = 7;
            label1.Text = "Pending Schedules: ";
            // 
            // flp_PendingSchedules
            // 
            flp_PendingSchedules.AutoScroll = true;
            flp_PendingSchedules.BackColor = Color.Transparent;
            flp_PendingSchedules.Location = new Point(13, 30);
            flp_PendingSchedules.Name = "flp_PendingSchedules";
            flp_PendingSchedules.Size = new Size(612, 312);
            flp_PendingSchedules.TabIndex = 6;
            // 
            // tab_Confirm
            // 
            tab_Confirm.BackColor = Color.WhiteSmoke;
            tab_Confirm.Controls.Add(flp_ConfirmedSchedules);
            tab_Confirm.Controls.Add(lbl_UpdateHeader);
            tab_Confirm.Location = new Point(4, 24);
            tab_Confirm.Name = "tab_Confirm";
            tab_Confirm.Size = new Size(639, 351);
            tab_Confirm.TabIndex = 2;
            tab_Confirm.Text = "Confirmed Schedule";
            tab_Confirm.Click += tab_Update_Click;
            // 
            // flp_ConfirmedSchedules
            // 
            flp_ConfirmedSchedules.Location = new Point(17, 33);
            flp_ConfirmedSchedules.Name = "flp_ConfirmedSchedules";
            flp_ConfirmedSchedules.Size = new Size(605, 304);
            flp_ConfirmedSchedules.TabIndex = 7;
            // 
            // lbl_UpdateHeader
            // 
            lbl_UpdateHeader.AutoSize = true;
            lbl_UpdateHeader.BackColor = Color.WhiteSmoke;
            lbl_UpdateHeader.Font = new Font("Georgia", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_UpdateHeader.ForeColor = Color.Black;
            lbl_UpdateHeader.Location = new Point(9, 9);
            lbl_UpdateHeader.Name = "lbl_UpdateHeader";
            lbl_UpdateHeader.Size = new Size(139, 18);
            lbl_UpdateHeader.TabIndex = 6;
            lbl_UpdateHeader.Text = "Your Schedule: ";
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
            btn_Logout.TabIndex = 33;
            btn_Logout.Text = "Logout";
            btn_Logout.UseVisualStyleBackColor = false;
            btn_Logout.Click += btn_Logout_Click;
            // 
            // cmb_ScheduleType
            // 
            cmb_ScheduleType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_ScheduleType.FormattingEnabled = true;
            cmb_ScheduleType.Items.AddRange(new object[] { "Teacher", "Lesson" });
            cmb_ScheduleType.Location = new Point(563, 11);
            cmb_ScheduleType.Name = "cmb_ScheduleType";
            cmb_ScheduleType.Size = new Size(105, 23);
            cmb_ScheduleType.TabIndex = 35;
            cmb_ScheduleType.SelectedIndexChanged += cmb_ScheduleType_SelectedIndexChanged;
            // 
            // lbl_ScheduleType
            // 
            lbl_ScheduleType.AutoSize = true;
            lbl_ScheduleType.BackColor = Color.Transparent;
            lbl_ScheduleType.Font = new Font("Georgia", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_ScheduleType.ForeColor = Color.White;
            lbl_ScheduleType.Location = new Point(521, 15);
            lbl_ScheduleType.Name = "lbl_ScheduleType";
            lbl_ScheduleType.Size = new Size(36, 15);
            lbl_ScheduleType.TabIndex = 34;
            lbl_ScheduleType.Text = "Type";
            // 
            // UserDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.main_bg1;
            ClientSize = new Size(684, 471);
            Controls.Add(cmb_ScheduleType);
            Controls.Add(lbl_ScheduleType);
            Controls.Add(btn_Logout);
            Controls.Add(tab_PrayerTab);
            Controls.Add(lbl_Header);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "UserDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Adelina Christian Church";
            Load += UserDashboard_Load;
            tab_PrayerTab.ResumeLayout(false);
            tab_View.ResumeLayout(false);
            tab_View.PerformLayout();
            tab_Pending.ResumeLayout(false);
            tab_Pending.PerformLayout();
            tab_Confirm.ResumeLayout(false);
            tab_Confirm.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_Header;
        private TabControl tab_PrayerTab;
        private TabPage tab_View;
        private Label lbl_ViewHeader;
        private TabPage tab_Pending;
        private TabPage tab_Confirm;
        private Button btn_Logout;
        private Label lbl_UpdateHeader;
        private ComboBox cmb_ScheduleType;
        private Label lbl_ScheduleType;
        private FlowLayoutPanel flp_PendingSchedules;
        private Label label1;
        private FlowLayoutPanel flowLayoutPanel1;
        private FlowLayoutPanel flp_ConfirmedSchedules;
    }
}