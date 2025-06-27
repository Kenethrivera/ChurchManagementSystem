using BusinessAndDataLogic;
using CMSAccounts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMSWindowsForm
{
    public partial class UserDashboard : Form
    {

        private UserAccounts currentUser;
        private bool isAdmin;
        private string selectedType = "";
        public UserDashboard(UserAccounts user, bool isAdmin)
        {
            InitializeComponent();
            this.currentUser = user;
            this.isAdmin = isAdmin;
        }
        CMSProcess cmsProcess = new CMSProcess();
        private void UserDashboard_Load(object sender, EventArgs e)
        {
            lbl_Header.Text = $"WELCOME {currentUser.FirstName}".ToUpper();
            SetupMinistryView(currentUser);

            Name = $"{currentUser.FirstName} {currentUser.LastName}";
            LoadPendingSchedulesPanel(Name);
            LoadConfirmedSchedulesPanel(Name);
        }

        //current user pathing
        private void SetupMinistryView(UserAccounts currentUser)
        {
            string ministryName = currentUser.MinistryName;
            cmb_ScheduleType.Visible = false;
            lbl_ScheduleType.Visible = false;
            cmb_ScheduleType.Items.Clear();

            switch (ministryName)
            {
                case "Discipleship Ministry":
                    LoadDiscipleshipMinistryView();
                    break;

                case "Prayer Ministry":
                    LoadPrayerMinistryView();
                    break;

                case "Worship Ministry":
                    cmb_ScheduleType.Visible = true;
                    cmb_ScheduleType.Items.Add("Praise and Worship");
                    cmb_ScheduleType.Items.Add("Devotion");
                    cmb_ScheduleType.Items.Add("Sunday Worship Service");
                    cmb_ScheduleType.SelectedIndex = 0; // default
                    break;

                case "Christian Education":
                    cmb_ScheduleType.Visible = true;
                    cmb_ScheduleType.Items.Add("Teachers");
                    cmb_ScheduleType.Items.Add("Lesson");
                    cmb_ScheduleType.SelectedIndex = 0; // default
                    LoadTeachersList();
                    tab_PrayerTab.TabPages["tab_Pending"].Enabled = false;
                    tab_PrayerTab.TabPages["tab_Confirm"].Enabled = false;
                    tab_PrayerTab.TabPages["tab_Confirm"].Hide();
                    tab_PrayerTab.TabPages["tab_Pending"].Hide();
                    break;

                default:
                    MessageBox.Show("Ministry view not configured.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
        }
        //load all schedule
        private void LoadDiscipleshipMinistryView()
        {
            flowLayoutPanel1.Controls.Clear();

            foreach (var sched in cmsProcess.ViewDiscipleshipSchedule())
            {
                Panel viewSchedulePanel = new Panel
                {
                    Width = flowLayoutPanel1.Width - 30,
                    Height = 120,
                    BorderStyle = BorderStyle.FixedSingle,
                    BackColor = Color.LightBlue,
                    Margin = new Padding(5)
                };
                Label lblDate = new Label
                {
                    Text = $"📅 Date: {sched.Date:MM-dd-yyyy}",
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    Location = new Point(10, 10),
                    AutoSize = true
                };

                Label lblSpeaker = new Label
                {
                    Text = $"🗣 Speaker: {sched.Speaker} - {sched.Status}",
                    Location = new Point(10, 35),
                    AutoSize = true
                };

                Label lblDescription = new Label
                {
                    Text = $"📘 Description: {sched.Description}",
                    Location = new Point(10, 60),
                    AutoSize = true
                };

                Label lblNote = new Label
                {
                    Text = $"📝 Note: {sched.Note}",
                    Location = new Point(10, 85),
                    AutoSize = true
                };

                viewSchedulePanel.Controls.Add(lblDate);
                viewSchedulePanel.Controls.Add(lblSpeaker);
                viewSchedulePanel.Controls.Add(lblDescription);
                viewSchedulePanel.Controls.Add(lblNote);
                viewSchedulePanel.Height = lblNote.Bottom + 15;

                flowLayoutPanel1.Controls.Add(viewSchedulePanel);
            }
        }
        private void LoadPrayerMinistryView()
        {
            flowLayoutPanel1.Controls.Clear();

            foreach (var sched in cmsProcess.ViewPrayerSched())
            {
                Panel viewSchedulePanel = new Panel
                {
                    Width = flowLayoutPanel1.Width - 30,
                    Height = 140,
                    BorderStyle = BorderStyle.FixedSingle,
                    BackColor = Color.LightBlue,
                    Margin = new Padding(5)
                };

                Label lblDate = new Label
                {
                    Text = $"📅 Date: {sched.Date:MM-dd-yyyy}",
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    Location = new Point(10, 10),
                    AutoSize = true
                };

                Label lblSongLeader = new Label
                {
                    Text = $"🎤 Song Leader: {sched.SongLeader} - {sched.SongLeaderStatus}",
                    Location = new Point(10, 35),
                    AutoSize = true
                };

                Label lblPresider = new Label
                {
                    Text = $"🙏 Presider: {sched.Presider} - {sched.PresiderStatus}",
                    Location = new Point(10, 60),
                    AutoSize = true
                };

                Label lblSpeaker = new Label
                {
                    Text = $"🗣 Speaker: {sched.Speaker} - {sched.SpeakerStatus}",
                    Location = new Point(10, 85),
                    AutoSize = true
                };

                Label lblPrayerItem = new Label
                {
                    Text = $"🧎 Prayer Item: {sched.PrayerItem}",
                    Location = new Point(10, 110),
                    AutoSize = true
                };
                viewSchedulePanel.Controls.Add(lblDate);
                viewSchedulePanel.Controls.Add(lblSongLeader);
                viewSchedulePanel.Controls.Add(lblPresider);
                viewSchedulePanel.Controls.Add(lblSpeaker);
                viewSchedulePanel.Controls.Add(lblPrayerItem);

                flowLayoutPanel1.Controls.Add(viewSchedulePanel);
            }
        }
        private void LoadPraiseAndWorshipView()
        {
            flowLayoutPanel1.Controls.Clear();

            foreach (var sched in cmsProcess.ViewPraiseAndWorshipSched())
            {
                Panel viewSchedulePanel = new Panel
                {
                    Width = flowLayoutPanel1.Width - 30,
                    Height = 100,
                    BorderStyle = BorderStyle.FixedSingle,
                    BackColor = Color.LightCoral,
                    Margin = new Padding(5)
                };

                Label lblDate = new Label
                {
                    Text = $"📅 Date: {sched.Date:MM-dd-yyyy}",
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    Location = new Point(10, 10),
                    AutoSize = true
                };

                Label lblSongLeader = new Label
                {
                    Text = $"🎤 Song Leader: {sched.SongLeader} -- {sched.SongLeaderStatus}",
                    Location = new Point(10, 35),
                    AutoSize = true
                };

                Label lblInstrumentalist = new Label
                {
                    Text = $"🎸 Instrumentalist: {sched.Instrumentalist}",
                    Location = new Point(10, 60),
                    AutoSize = true
                };

                viewSchedulePanel.Controls.Add(lblDate);
                viewSchedulePanel.Controls.Add(lblSongLeader);
                viewSchedulePanel.Controls.Add(lblInstrumentalist);

                flowLayoutPanel1.Controls.Add(viewSchedulePanel);
            }
        }
        private void LoadSundayWorshipView()
        {
            flowLayoutPanel1.Controls.Clear();

            foreach (var sched in cmsProcess.ViewSundayWorshipSched())
            {
                Panel viewSchedulePanel = new Panel
                {
                    Width = flowLayoutPanel1.Width - 30,
                    Height = 140,
                    BorderStyle = BorderStyle.FixedSingle,
                    BackColor = Color.LightSkyBlue,
                    Margin = new Padding(5)
                };

                Label lblDate = new Label
                {
                    Text = $"📅 Date: {sched.Date:MM-dd-yyyy}",
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    Location = new Point(10, 10),
                    AutoSize = true
                };

                Label lblPresider = new Label
                {
                    Text = $"🙏 Presider: {sched.Presider} -- {sched.PresiderStatus}",
                    Location = new Point(10, 35),
                    AutoSize = true
                };

                Label lblSpeaker = new Label
                {
                    Text = $"🗣 Speaker: {sched.Speaker} -- {sched.SpeakerStatus}",
                    Location = new Point(10, 60),
                    AutoSize = true
                };

                Label lblFlowers = new Label
                {
                    Text = $"🌸 Flowers: {sched.Flowers} -- {sched.FlowersStatus}",
                    Location = new Point(10, 85),
                    AutoSize = true
                };

                Label lblUshers = new Label
                {
                    Text = $"🚪 Ushers: {sched.Ushers} -- {sched.UshersStatus}",
                    Location = new Point(10, 110),
                    AutoSize = true
                };

                viewSchedulePanel.Controls.Add(lblDate);
                viewSchedulePanel.Controls.Add(lblPresider);
                viewSchedulePanel.Controls.Add(lblSpeaker);
                viewSchedulePanel.Controls.Add(lblFlowers);
                viewSchedulePanel.Controls.Add(lblUshers);

                flowLayoutPanel1.Controls.Add(viewSchedulePanel);
            }
        }
        private void LoadDevotionView()
        {
            flowLayoutPanel1.Controls.Clear();

            foreach (var sched in cmsProcess.ViewDevotionSched())
            {
                Panel viewSchedulePanel = new Panel
                {
                    Width = flowLayoutPanel1.Width - 30,
                    Height = 120,
                    BorderStyle = BorderStyle.FixedSingle,
                    BackColor = Color.LightCoral,
                    Margin = new Padding(5)
                };

                Label lblDate = new Label
                {
                    Text = $"📅 Date: {sched.Date:MM-dd-yyyy}",
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    Location = new Point(10, 10),
                    AutoSize = true
                };

                Label lblSongLeader = new Label
                {
                    Text = $"🎤 Song Leader: {sched.SongLeader} -- {sched.SongLeaderStatus}",
                    Location = new Point(10, 35),
                    AutoSize = true
                };

                Label lblPresider = new Label
                {
                    Text = $"🙏 Presider: {sched.Presider} -- {sched.PresiderStatus}",
                    Location = new Point(10, 60),
                    AutoSize = true
                };

                Label lblSpeaker = new Label
                {
                    Text = $"🗣 Speaker: {sched.Speaker} -- {sched.SpeakerStatus}",
                    Location = new Point(10, 85),
                    AutoSize = true
                };

                viewSchedulePanel.Controls.Add(lblDate);
                viewSchedulePanel.Controls.Add(lblSongLeader);
                viewSchedulePanel.Controls.Add(lblPresider);
                viewSchedulePanel.Controls.Add(lblSpeaker);

                flowLayoutPanel1.Controls.Add(viewSchedulePanel);
            }
        }
        private void LoadTeachersList()
        {
            flowLayoutPanel1.Controls.Clear();

            foreach (var sched in cmsProcess.GetTeachers())
            {
                Panel viewSchedulePanel = new Panel
                {
                    Width = flowLayoutPanel1.Width - 30,
                    Height = 100,
                    BorderStyle = BorderStyle.FixedSingle,
                    BackColor = Color.LightGreen,
                    Margin = new Padding(5)
                };

                Label lblName = new Label
                {
                    Text = $"👩‍🏫 Name: {sched.TeachersName}",
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    Location = new Point(10, 10),
                    AutoSize = true
                };

                Label lblAssignment = new Label
                {
                    Text = $"📚 Assignment: {sched.Assignment}",
                    Location = new Point(10, 35),
                    AutoSize = true
                };

                viewSchedulePanel.Controls.Add(lblName);
                viewSchedulePanel.Controls.Add(lblAssignment);

                flowLayoutPanel1.Controls.Add(viewSchedulePanel);
            }
        }
        private void LoadLessonSchedules()
        {
            flowLayoutPanel1.Controls.Clear();

            foreach (var sched in cmsProcess.GetLessons())
            {
                Panel viewSchedulePanel = new Panel
                {
                    Width = flowLayoutPanel1.Width - 30,
                    Height = 110,
                    BorderStyle = BorderStyle.FixedSingle,
                    BackColor = Color.LightYellow,
                    Margin = new Padding(5)
                };

                Label lblDate = new Label
                {
                    Text = $"📅 Date: {sched.Date:MM-dd-yyyy}",
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    Location = new Point(10, 10),
                    AutoSize = true
                };

                Label lblLesson = new Label
                {
                    Text = $"📖 Lesson: {sched.Lessson}",
                    Location = new Point(10, 35),
                    AutoSize = true
                };

                Label lblMaterials = new Label
                {
                    Text = $"📋 Materials: {sched.Materials}",
                    Location = new Point(10, 60),
                    AutoSize = true
                };

                viewSchedulePanel.Controls.Add(lblDate);
                viewSchedulePanel.Controls.Add(lblLesson);
                viewSchedulePanel.Controls.Add(lblMaterials);

                flowLayoutPanel1.Controls.Add(viewSchedulePanel);
            }
        }

        private void lbl_Header_Click(object sender, EventArgs e)
        {

        }
        // log out 
        private void btn_Logout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Logout Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Form1 mainForm = new Form1();
                mainForm.Show();
                this.Hide();
            }
            else if (result == DialogResult.No)
            {

            }
            else if (result == DialogResult.Cancel)
            {

            }
        }
        // type of sched for Worship and Christian Ed
        private void cmb_ScheduleType_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedType = cmb_ScheduleType.SelectedItem.ToString();

            if (currentUser.MinistryName == "Worship Ministry")
            {
                if (selectedType == "Praise and Worship")
                    LoadPraiseAndWorshipView();
                else if (selectedType == "Devotion")
                    LoadDevotionView();
                else if (selectedType == "Sunday Worship Service")
                    LoadSundayWorshipView();
            }
            else if (currentUser.MinistryName == "Christian Education")
            {
                if (selectedType == "Teachers")
                    LoadTeachersList();
                else if (selectedType == "Lesson")
                    LoadLessonSchedules();
            }
        }

        // FUNCTION 2
        // User Pending Sched
        private void AddSchedulePanel(DateTime date, string ministry, string role, string status)
        {
            Panel panel = new Panel
            {
                Width = flp_PendingSchedules.Width - 30,
                Height = 130,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.LightYellow,
                Margin = new Padding(5)
            };

            Label lblDate = new Label
            {
                Text = $"📅 Date: {date:MM-dd-yyyy}",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(10, 10),
                AutoSize = true
            };

            Label lblMinistry = new Label
            {
                Text = $"🏛 Ministry: {ministry}",
                Location = new Point(10, 35),
                AutoSize = true
            };

            Label lblRole = new Label
            {
                Text = $"👤 Role: {role}",
                Location = new Point(10, 60),
                AutoSize = true
            };

            Label lblStatus = new Label
            {
                Text = $"⚠ Status: {status}",
                Location = new Point(10, 85),
                AutoSize = true,
                ForeColor = Color.OrangeRed
            };

            Button btnConfirm = new Button
            {
                Text = "Confirm",
                Location = new Point(panel.Width - 180, 40),
                Width = 75,
                BackColor = Color.LightGreen,
                FlatStyle = FlatStyle.Flat,
                Name = $"Confirmed|{date:MM-dd-yyyy}|{ministry}|{role}"
            };
            btnConfirm.Click += BtnConfirm_Click;

            Button btnRequestChange = new Button
            {
                Text = "Request to be Changed",
                Location = new Point(panel.Width - 95, 40),
                Width = 90,
                BackColor = Color.LightCoral,
                FlatStyle = FlatStyle.Flat,
                Name = $"Request to be Changed|{date:MM-dd-yyyy}|{ministry}|{role}"
            };
            btnRequestChange.Click += BtnRequestChange_Click;

            panel.Controls.Add(lblDate);
            panel.Controls.Add(lblMinistry);
            panel.Controls.Add(lblRole);
            panel.Controls.Add(lblStatus);
            panel.Controls.Add(btnConfirm);
            panel.Controls.Add(btnRequestChange);

            flp_PendingSchedules.Controls.Add(panel);
        }
        private void LoadPendingSchedulesPanel(string currentUSER)
        {
            flp_PendingSchedules.Controls.Clear();

            // Discipleship Ministry
            foreach (var sched in cmsProcess.ViewDiscipleshipSchedule())
            {
                if (sched.Speaker == currentUSER && sched.Status == "Pending")
                {
                    AddSchedulePanel(sched.Date, "Discipleship Ministry", "Speaker", sched.Status);
                }
            }

            // Prayer Ministry
            foreach (var sched in cmsProcess.ViewPrayerSched())
            {
                if (sched.Presider == currentUSER && sched.PresiderStatus == "Pending")
                    AddSchedulePanel(sched.Date, "Prayer Ministry", "Presider", sched.PresiderStatus);

                if (sched.Speaker == currentUSER && sched.SpeakerStatus == "Pending")
                    AddSchedulePanel(sched.Date, "Prayer Ministry", "Speaker", sched.SpeakerStatus);

                if (sched.SongLeader == currentUSER && sched.SongLeaderStatus == "Pending")
                    AddSchedulePanel(sched.Date, "Prayer Ministry", "Song Leader", sched.SongLeaderStatus);
            }

            // Praise and Worship Ministry
            foreach (var sched in cmsProcess.ViewPraiseAndWorshipSched())
            {
                if (sched.SongLeader == currentUSER && sched.SongLeaderStatus == "Pending")
                    AddSchedulePanel(sched.Date, "Praise and Worship", "Song Leader", sched.SongLeaderStatus);
            }

            // Sunday Worship Ministry
            foreach (var sched in cmsProcess.ViewSundayWorshipSched())
            {
                if (sched.Presider == currentUSER && sched.PresiderStatus == "Pending")
                    AddSchedulePanel(sched.Date, "Sunday Worship Service", "Presider", sched.PresiderStatus);

                if (sched.Speaker == currentUSER && sched.SpeakerStatus == "Pending")
                    AddSchedulePanel(sched.Date, "Sunday Worship Service", "Speaker", sched.SpeakerStatus);

                if (sched.Flowers == currentUSER && sched.FlowersStatus == "Pending")
                    AddSchedulePanel(sched.Date, "Sunday Worship Service", "Flowers", sched.FlowersStatus);

                if (sched.Ushers == currentUSER && sched.UshersStatus == "Pending")
                    AddSchedulePanel(sched.Date, "Sunday Worship Service", "Ushers", sched.UshersStatus);
            }

            // Devotion Ministry
            foreach (var sched in cmsProcess.ViewDevotionSched())
            {
                if (sched.Presider == currentUSER && sched.PresiderStatus == "Pending")
                    AddSchedulePanel(sched.Date, "Devotion", "Presider", sched.PresiderStatus);

                if (sched.Speaker == currentUSER && sched.SpeakerStatus == "Pending")
                    AddSchedulePanel(sched.Date, "Devotion", "Speaker", sched.SpeakerStatus);

                if (sched.SongLeader == currentUSER && sched.SongLeaderStatus == "Pending")
                    AddSchedulePanel(sched.Date, "Devotion", "Song Leader", sched.SongLeaderStatus);
            }
        }
        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string[] parts = btn.Name.Split('|');

            string newStatus = parts[0];
            DateTime date = DateTime.ParseExact(parts[1], "MM-dd-yyyy", null);
            string ministry = parts[2];
            string role = parts[3];

            ProcessUserResponse(ministry, role, date, newStatus);
        }
        private void BtnRequestChange_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string[] parts = btn.Name.Split('|');

            string newStatus = parts[0]; // Request to be Changed
            DateTime date = DateTime.ParseExact(parts[1], "MM-dd-yyyy", null);
            string ministry = parts[2];
            string role = parts[3];

            ProcessUserResponse(ministry, role, date, newStatus);
        }
        private void ProcessUserResponse(string ministry, string role, DateTime date, string newStatus)
        {
            bool updated = false;

            if (ministry == "Discipleship Ministry")
            {
                updated = cmsProcess.ProcessUserResponseDiscipleship(date, newStatus);
            }
            else if (ministry == "Prayer Ministry")
            {
                updated = cmsProcess.ProcessUserResponsePrayer(date, role, newStatus);
            }
            else if (ministry == "Praise and Worship")
            {
                updated = cmsProcess.ProcessUserResponsePraiseAndWorship(date, role, newStatus);
            }
            else if (ministry == "Sunday Worship Service")
            {
                updated = cmsProcess.ProcessUserResponseSundayWorship(date, role, newStatus);
            }
            else if (ministry == "Devotion")
            {
                updated = cmsProcess.ProcessUserResponseDevotion(date, role, newStatus);
            }

            if (updated)
            {
                MessageBox.Show("Your response has been submitted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Name = $"{currentUser.FirstName} {currentUser.LastName}";
                ScheduleLoader(currentUser);
                LoadPendingSchedulesPanel(Name);
                LoadConfirmedSchedulesPanel(Name);
            }
            else
            {
                MessageBox.Show("Something went wrong. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void tab_PrayerTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tab_PrayerTab.SelectedTab == tab_View)
            {
                ScheduleLoader(currentUser);
            }
        }
        public void ScheduleLoader(UserAccounts user)
        {
            string ministryName = user.MinistryName;

            if (ministryName == "Devotion")
            {
                LoadDevotionView();
            }
            else if (ministryName == "Discipleship Ministry")
            {
                LoadDiscipleshipMinistryView();
            }
            else if (ministryName == "Praise and Worship")
            {
                LoadPraiseAndWorshipView();
            }
            else if (ministryName == "Prayer Ministry")
            {
                LoadPrayerMinistryView();
            }
            else if (ministryName == "Sunday Worship Service")
            {
                LoadSundayWorshipView();
            }
        }


        //FUNCTION 3
        // USER CONFIRMED SCHEDULE
        private void AddConfirmedSchedulePanel(DateTime date, string ministry, string role, string status)
        {
            Panel panel = new Panel
            {
                Width = flp_ConfirmedSchedules.Width - 30,
                Height = 130,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.LightGreen,
                Margin = new Padding(5)
            };

            Label lblDate = new Label
            {
                Text = $"📅 Date: {date:MM-dd-yyyy}",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(10, 10),
                AutoSize = true
            };

            Label lblMinistry = new Label
            {
                Text = $"🏛 Ministry: {ministry}",
                Location = new Point(10, 35),
                AutoSize = true
            };

            Label lblRole = new Label
            {
                Text = $"👤 Role: {role}",
                Location = new Point(10, 60),
                AutoSize = true
            };

            Label lblStatus = new Label
            {
                Text = $"✅ Status: {status}",
                Location = new Point(10, 85),
                AutoSize = true,
                ForeColor = Color.DarkGreen
            };

            panel.Controls.Add(lblDate);
            panel.Controls.Add(lblMinistry);
            panel.Controls.Add(lblRole);
            panel.Controls.Add(lblStatus);

            flp_ConfirmedSchedules.Controls.Add(panel);
        }
        private void LoadConfirmedSchedulesPanel(string currentUSER)
        {
            flp_ConfirmedSchedules.Controls.Clear();

            // Discipleship Ministry
            foreach (var sched in cmsProcess.ViewDiscipleshipSchedule())
            {
                if (sched.Speaker == currentUSER && sched.Status == "Confirmed")
                {
                    AddConfirmedSchedulePanel(sched.Date, "Discipleship Ministry", "Speaker", sched.Status);
                }
            }

            // Prayer Ministry
            foreach (var sched in cmsProcess.ViewPrayerSched())
            {
                if (sched.Presider == currentUSER && sched.PresiderStatus == "Confirmed")
                    AddConfirmedSchedulePanel(sched.Date, "Prayer Ministry", "Presider", sched.PresiderStatus);

                if (sched.Speaker == currentUSER && sched.SpeakerStatus == "Confirmed")
                    AddConfirmedSchedulePanel(sched.Date, "Prayer Ministry", "Speaker", sched.SpeakerStatus);

                if (sched.SongLeader == currentUSER && sched.SongLeaderStatus == "Confirmed")
                    AddConfirmedSchedulePanel(sched.Date, "Prayer Ministry", "Song Leader", sched.SongLeaderStatus);
            }

            // Praise and Worship Ministry
            foreach (var sched in cmsProcess.ViewPraiseAndWorshipSched())
            {
                if (sched.SongLeader == currentUSER && sched.SongLeaderStatus == "Confirmed")
                    AddConfirmedSchedulePanel(sched.Date, "Praise and Worship", "Song Leader", sched.SongLeaderStatus);
            }

            // Sunday Worship Service
            foreach (var sched in cmsProcess.ViewSundayWorshipSched())
            {
                if (sched.Presider == currentUSER && sched.PresiderStatus == "Confirmed")
                    AddConfirmedSchedulePanel(sched.Date, "Sunday Worship Service", "Presider", sched.PresiderStatus);

                if (sched.Speaker == currentUSER && sched.SpeakerStatus == "Confirmed")
                    AddConfirmedSchedulePanel(sched.Date, "Sunday Worship Service", "Speaker", sched.SpeakerStatus);

                if (sched.Flowers == currentUSER && sched.FlowersStatus == "Confirmed")
                    AddConfirmedSchedulePanel(sched.Date, "Sunday Worship Service", "Flowers", sched.FlowersStatus);

                if (sched.Ushers == currentUSER && sched.UshersStatus == "Confirmed")
                    AddConfirmedSchedulePanel(sched.Date, "Sunday Worship Service", "Ushers", sched.UshersStatus);
            }

            // Devotion Ministry
            foreach (var sched in cmsProcess.ViewDevotionSched())
            {
                if (sched.Presider == currentUSER && sched.PresiderStatus == "Confirmed")
                    AddConfirmedSchedulePanel(sched.Date, "Devotion", "Presider", sched.PresiderStatus);

                if (sched.Speaker == currentUSER && sched.SpeakerStatus == "Confirmed")
                    AddConfirmedSchedulePanel(sched.Date, "Devotion", "Speaker", sched.SpeakerStatus);

                if (sched.SongLeader == currentUSER && sched.SongLeaderStatus == "Confirmed")
                    AddConfirmedSchedulePanel(sched.Date, "Devotion", "Song Leader", sched.SongLeaderStatus);
            }
        }


        private void tab_Update_Click(object sender, EventArgs e)
        {

        }
    }

}

