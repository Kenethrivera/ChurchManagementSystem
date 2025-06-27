namespace CMSWindowsForm
{
    partial class AdminCEDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminCEDashboard));
            lbl_CEHeader = new Label();
            btn_Logout = new Button();
            tab_PrayerTab = new TabControl();
            tab_View = new TabPage();
            flp_ViewPanel = new FlowLayoutPanel();
            lbl_ViewHeader = new Label();
            tab_Add = new TabPage();
            tbx_materials = new TextBox();
            tbx_name = new TextBox();
            lbl_Date = new Label();
            dtp_Date = new DateTimePicker();
            lbl_Status = new Label();
            btn_Add = new Button();
            lbl_assma = new Label();
            lbl_name = new Label();
            lbl_AddHeader = new Label();
            tab_Update = new TabPage();
            tbx_UpdateMaterials = new TextBox();
            tbx_UpdateName = new TextBox();
            lbl_UpdateStatus = new Label();
            lbl_UpdateMaterials = new Label();
            btn_Update = new Button();
            lbl_updateName = new Label();
            lbl_UpdateDate = new Label();
            dtp_UpdateDate = new DateTimePicker();
            cmb_ToUpdate = new ComboBox();
            lbl_UpdateHeader = new Label();
            tab_Delete = new TabPage();
            lbl_RemoveStatus = new Label();
            btn_Remove = new Button();
            cmb_ToRemove = new ComboBox();
            lbl_RemoveHeader = new Label();
            cmb_ScheduleType = new ComboBox();
            label5 = new Label();
            tab_PrayerTab.SuspendLayout();
            tab_View.SuspendLayout();
            tab_Add.SuspendLayout();
            tab_Update.SuspendLayout();
            tab_Delete.SuspendLayout();
            SuspendLayout();
            // 
            // lbl_CEHeader
            // 
            lbl_CEHeader.AutoSize = true;
            lbl_CEHeader.BackColor = Color.Transparent;
            lbl_CEHeader.Font = new Font("Georgia", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_CEHeader.ForeColor = Color.White;
            lbl_CEHeader.Location = new Point(7, 10);
            lbl_CEHeader.Name = "lbl_CEHeader";
            lbl_CEHeader.Size = new Size(314, 34);
            lbl_CEHeader.TabIndex = 4;
            lbl_CEHeader.Text = "Christian Education";
            // 
            // btn_Logout
            // 
            btn_Logout.BackColor = Color.Red;
            btn_Logout.FlatAppearance.BorderColor = Color.FromArgb(0, 0, 0, 0);
            btn_Logout.FlatStyle = FlatStyle.System;
            btn_Logout.Font = new Font("Georgia", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_Logout.ForeColor = Color.Red;
            btn_Logout.Location = new Point(7, 441);
            btn_Logout.Name = "btn_Logout";
            btn_Logout.Size = new Size(62, 23);
            btn_Logout.TabIndex = 31;
            btn_Logout.Text = "Logout";
            btn_Logout.UseVisualStyleBackColor = false;
            btn_Logout.Click += btn_Logout_Click_1;
            // 
            // tab_PrayerTab
            // 
            tab_PrayerTab.Controls.Add(tab_View);
            tab_PrayerTab.Controls.Add(tab_Add);
            tab_PrayerTab.Controls.Add(tab_Update);
            tab_PrayerTab.Controls.Add(tab_Delete);
            tab_PrayerTab.Location = new Point(19, 54);
            tab_PrayerTab.Name = "tab_PrayerTab";
            tab_PrayerTab.SelectedIndex = 0;
            tab_PrayerTab.Size = new Size(647, 379);
            tab_PrayerTab.TabIndex = 30;
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
            tab_View.Text = "View Teacher's List";
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
            flp_ViewPanel.Paint += flp_ViewPanel_Paint;
            // 
            // lbl_ViewHeader
            // 
            lbl_ViewHeader.AutoSize = true;
            lbl_ViewHeader.BackColor = Color.Transparent;
            lbl_ViewHeader.Font = new Font("Georgia", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_ViewHeader.ForeColor = Color.Black;
            lbl_ViewHeader.Location = new Point(9, 12);
            lbl_ViewHeader.Name = "lbl_ViewHeader";
            lbl_ViewHeader.Size = new Size(102, 18);
            lbl_ViewHeader.TabIndex = 4;
            lbl_ViewHeader.Text = "Schedules: ";
            // 
            // tab_Add
            // 
            tab_Add.BackgroundImageLayout = ImageLayout.Stretch;
            tab_Add.Controls.Add(tbx_materials);
            tab_Add.Controls.Add(tbx_name);
            tab_Add.Controls.Add(lbl_Date);
            tab_Add.Controls.Add(dtp_Date);
            tab_Add.Controls.Add(lbl_Status);
            tab_Add.Controls.Add(btn_Add);
            tab_Add.Controls.Add(lbl_assma);
            tab_Add.Controls.Add(lbl_name);
            tab_Add.Controls.Add(lbl_AddHeader);
            tab_Add.Location = new Point(4, 24);
            tab_Add.Name = "tab_Add";
            tab_Add.Padding = new Padding(3);
            tab_Add.Size = new Size(639, 351);
            tab_Add.TabIndex = 1;
            tab_Add.Text = "Add Teachers";
            tab_Add.UseVisualStyleBackColor = true;
            // 
            // tbx_materials
            // 
            tbx_materials.Location = new Point(231, 131);
            tbx_materials.Name = "tbx_materials";
            tbx_materials.Size = new Size(200, 23);
            tbx_materials.TabIndex = 40;
            // 
            // tbx_name
            // 
            tbx_name.Location = new Point(231, 92);
            tbx_name.Name = "tbx_name";
            tbx_name.Size = new Size(200, 23);
            tbx_name.TabIndex = 39;
            // 
            // lbl_Date
            // 
            lbl_Date.AutoSize = true;
            lbl_Date.BackColor = Color.Transparent;
            lbl_Date.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_Date.ForeColor = Color.Black;
            lbl_Date.Location = new Point(165, 56);
            lbl_Date.Name = "lbl_Date";
            lbl_Date.Size = new Size(46, 18);
            lbl_Date.TabIndex = 25;
            lbl_Date.Text = "Date:";
            // 
            // dtp_Date
            // 
            dtp_Date.Location = new Point(231, 53);
            dtp_Date.Name = "dtp_Date";
            dtp_Date.Size = new Size(200, 23);
            dtp_Date.TabIndex = 24;
            // 
            // lbl_Status
            // 
            lbl_Status.AutoSize = true;
            lbl_Status.Font = new Font("Georgia", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_Status.ForeColor = Color.Red;
            lbl_Status.Location = new Point(239, 165);
            lbl_Status.Name = "lbl_Status";
            lbl_Status.Size = new Size(0, 15);
            lbl_Status.TabIndex = 19;
            // 
            // btn_Add
            // 
            btn_Add.BackColor = Color.Transparent;
            btn_Add.BackgroundImage = Properties.Resources.registerBg;
            btn_Add.FlatAppearance.BorderColor = Color.FromArgb(0, 0, 0, 0);
            btn_Add.Font = new Font("Georgia", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_Add.ForeColor = Color.Black;
            btn_Add.Location = new Point(231, 184);
            btn_Add.Name = "btn_Add";
            btn_Add.Size = new Size(200, 47);
            btn_Add.TabIndex = 18;
            btn_Add.Text = "Add Schedule";
            btn_Add.UseVisualStyleBackColor = false;
            btn_Add.Click += btn_Add_Click;
            // 
            // lbl_assma
            // 
            lbl_assma.BackColor = Color.Transparent;
            lbl_assma.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_assma.ForeColor = Color.Black;
            lbl_assma.Location = new Point(129, 133);
            lbl_assma.Name = "lbl_assma";
            lbl_assma.Size = new Size(115, 18);
            lbl_assma.TabIndex = 9;
            lbl_assma.Text = "Materials:";
            // 
            // lbl_name
            // 
            lbl_name.BackColor = Color.Transparent;
            lbl_name.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_name.ForeColor = Color.Black;
            lbl_name.Location = new Point(154, 97);
            lbl_name.Name = "lbl_name";
            lbl_name.Size = new Size(94, 18);
            lbl_name.TabIndex = 8;
            lbl_name.Text = "Name:";
            // 
            // lbl_AddHeader
            // 
            lbl_AddHeader.AutoSize = true;
            lbl_AddHeader.BackColor = Color.Transparent;
            lbl_AddHeader.Font = new Font("Georgia", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_AddHeader.ForeColor = Color.Black;
            lbl_AddHeader.Location = new Point(12, 13);
            lbl_AddHeader.Name = "lbl_AddHeader";
            lbl_AddHeader.Size = new Size(132, 18);
            lbl_AddHeader.TabIndex = 5;
            lbl_AddHeader.Text = "Add Schedule: ";
            // 
            // tab_Update
            // 
            tab_Update.BackColor = Color.WhiteSmoke;
            tab_Update.Controls.Add(tbx_UpdateMaterials);
            tab_Update.Controls.Add(tbx_UpdateName);
            tab_Update.Controls.Add(lbl_UpdateStatus);
            tab_Update.Controls.Add(lbl_UpdateMaterials);
            tab_Update.Controls.Add(btn_Update);
            tab_Update.Controls.Add(lbl_updateName);
            tab_Update.Controls.Add(lbl_UpdateDate);
            tab_Update.Controls.Add(dtp_UpdateDate);
            tab_Update.Controls.Add(cmb_ToUpdate);
            tab_Update.Controls.Add(lbl_UpdateHeader);
            tab_Update.Location = new Point(4, 24);
            tab_Update.Name = "tab_Update";
            tab_Update.Size = new Size(639, 351);
            tab_Update.TabIndex = 2;
            tab_Update.Text = "Update Teachers";
            // 
            // tbx_UpdateMaterials
            // 
            tbx_UpdateMaterials.Location = new Point(259, 133);
            tbx_UpdateMaterials.Name = "tbx_UpdateMaterials";
            tbx_UpdateMaterials.Size = new Size(200, 23);
            tbx_UpdateMaterials.TabIndex = 44;
            // 
            // tbx_UpdateName
            // 
            tbx_UpdateName.Location = new Point(259, 94);
            tbx_UpdateName.Name = "tbx_UpdateName";
            tbx_UpdateName.Size = new Size(200, 23);
            tbx_UpdateName.TabIndex = 43;
            // 
            // lbl_UpdateStatus
            // 
            lbl_UpdateStatus.AutoSize = true;
            lbl_UpdateStatus.Font = new Font("Georgia", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_UpdateStatus.ForeColor = Color.Red;
            lbl_UpdateStatus.Location = new Point(262, 169);
            lbl_UpdateStatus.Name = "lbl_UpdateStatus";
            lbl_UpdateStatus.Size = new Size(0, 15);
            lbl_UpdateStatus.TabIndex = 29;
            // 
            // lbl_UpdateMaterials
            // 
            lbl_UpdateMaterials.BackColor = Color.WhiteSmoke;
            lbl_UpdateMaterials.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_UpdateMaterials.ForeColor = Color.Black;
            lbl_UpdateMaterials.Location = new Point(157, 135);
            lbl_UpdateMaterials.Name = "lbl_UpdateMaterials";
            lbl_UpdateMaterials.Size = new Size(115, 18);
            lbl_UpdateMaterials.TabIndex = 42;
            lbl_UpdateMaterials.Text = "Materials:";
            // 
            // btn_Update
            // 
            btn_Update.BackColor = Color.WhiteSmoke;
            btn_Update.BackgroundImage = Properties.Resources.registerBg;
            btn_Update.FlatAppearance.BorderColor = Color.FromArgb(0, 0, 0, 0);
            btn_Update.Font = new Font("Georgia", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_Update.ForeColor = Color.Black;
            btn_Update.Location = new Point(259, 190);
            btn_Update.Name = "btn_Update";
            btn_Update.Size = new Size(200, 47);
            btn_Update.TabIndex = 28;
            btn_Update.Text = "Update Schedule";
            btn_Update.UseVisualStyleBackColor = false;
            btn_Update.Click += btn_Update_Click;
            // 
            // lbl_updateName
            // 
            lbl_updateName.BackColor = Color.WhiteSmoke;
            lbl_updateName.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_updateName.ForeColor = Color.Black;
            lbl_updateName.Location = new Point(182, 99);
            lbl_updateName.Name = "lbl_updateName";
            lbl_updateName.Size = new Size(94, 18);
            lbl_updateName.TabIndex = 41;
            lbl_updateName.Text = "Name:";
            // 
            // lbl_UpdateDate
            // 
            lbl_UpdateDate.AutoSize = true;
            lbl_UpdateDate.BackColor = Color.WhiteSmoke;
            lbl_UpdateDate.Font = new Font("Georgia", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_UpdateDate.ForeColor = Color.Black;
            lbl_UpdateDate.Location = new Point(192, 67);
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
            lbl_UpdateHeader.BackColor = Color.WhiteSmoke;
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
            tab_Delete.Text = "Remove Teacher";
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
            // cmb_ScheduleType
            // 
            cmb_ScheduleType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_ScheduleType.FormattingEnabled = true;
            cmb_ScheduleType.Items.AddRange(new object[] { "Teacher", "Lesson" });
            cmb_ScheduleType.Location = new Point(557, 15);
            cmb_ScheduleType.Name = "cmb_ScheduleType";
            cmb_ScheduleType.Size = new Size(105, 23);
            cmb_ScheduleType.TabIndex = 13;
            cmb_ScheduleType.SelectedIndexChanged += cmb_ScheduleType_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Georgia", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(515, 19);
            label5.Name = "label5";
            label5.Size = new Size(36, 15);
            label5.TabIndex = 12;
            label5.Text = "Type";
            // 
            // AdminCEDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.main_bg1;
            ClientSize = new Size(684, 471);
            Controls.Add(cmb_ScheduleType);
            Controls.Add(btn_Logout);
            Controls.Add(label5);
            Controls.Add(tab_PrayerTab);
            Controls.Add(lbl_CEHeader);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AdminCEDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Admin- Christian Ed Dashboard";
            Load += AdminCEDashboard_Load;
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

        private Label lbl_CEHeader;
        private Button btn_Logout;
        private TabControl tab_PrayerTab;
        private TabPage tab_View;
        private FlowLayoutPanel flp_ViewPanel;
        private Label lbl_ViewHeader;
        private TabPage tab_Add;
        private Label lbl_Status;
        private Button btn_Add;
        private Label lbl_assma;
        private Label lbl_name;
        private Label lbl_AddHeader;
        private TabPage tab_Delete;
        private Label lbl_RemoveStatus;
        private Button btn_Remove;
        private ComboBox cmb_ToRemove;
        private Label lbl_RemoveHeader;
        private ComboBox cmb_ScheduleType;
        private Label label5;
        private Label lbl_Date;
        private DateTimePicker dtp_Date;
        private TextBox tbx_materials;
        private TextBox tbx_name;
        private TabPage tab_Update;
        private TextBox tbx_UpdateMaterials;
        private TextBox tbx_UpdateName;
        private Label lbl_UpdateStatus;
        private Label lbl_UpdateMaterials;
        private Button btn_Update;
        private Label lbl_updateName;
        private Label lbl_UpdateDate;
        private DateTimePicker dtp_UpdateDate;
        private ComboBox cmb_ToUpdate;
        private Label lbl_UpdateHeader;
    }
}