using BusinessAndDataLogic;
using CMSSchedules;
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
    public partial class AdminPrayerDashboard : Form
    {
        CMSProcess cmsProcess = new CMSProcess();
        public AdminPrayerDashboard()
        {
            InitializeComponent();
            LoadPrayerSchedules();
            LoadPrayerUserList("Prayer Ministry");
            LoadSongLeaderList("Worship Ministry");
            ToUpdateSched();
        }
        private void LoadPrayerSchedules()
        {
            flp_ViewPanel.Controls.Clear();

            foreach (var sched in cmsProcess.ViewPrayerSched())
            {
                Panel viewSchedulePanel = new Panel
                {
                    Width = flp_ViewPanel.Width - 30,
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
                    Text = $"🎤 Song Leader: {sched.SongLeader}",
                    Location = new Point(10, 35),
                    AutoSize = true
                };

                Label lblPresider = new Label
                {
                    Text = $"🙏 Presider: {sched.Presider}",
                    Location = new Point(10, 60),
                    AutoSize = true
                };

                Label lblSpeaker = new Label
                {
                    Text = $"🗣 Speaker: {sched.Speaker}",
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

                flp_ViewPanel.Controls.Add(viewSchedulePanel);
            }
        }

        private void btn_Register_Click(object sender, EventArgs e)
        {
            DateTime date = dtp_Date.Value.Date;
            string songLeader = cmb_SongLeader.Text.Trim();
            string speaker = cmb_Speaker.Text.Trim();
            string presider = cmb_Presider.Text.Trim();
            string prayerItem = cmb_PrayerItem.Text.Trim();

            if (cmb_SongLeader.SelectedIndex == -1 || string.IsNullOrWhiteSpace(songLeader) || cmb_Speaker.SelectedIndex == -1 || string.IsNullOrWhiteSpace(speaker) || cmb_Presider.SelectedIndex == -1 || string.IsNullOrWhiteSpace(presider) ||
                cmb_PrayerItem.SelectedIndex == -1 || string.IsNullOrWhiteSpace(prayerItem))
            {
                lbl_Status.Text = "Please fill all fields.";
                return;
            }

            if (!cmsProcess.ValidateThursdayDate(date))
            {
                lbl_Status.Text = "Date must be a Sunday.";
                return;
            }

            if (!cmsProcess.DateIsPast(date))
            {
                lbl_Status.Text = "Date must not be in the past.";
                return;
            }

            if (cmsProcess.PrayerScheduleExist(date))
            {
                lbl_Status.Text = "Schedule already exists for this date.";
                return;
            }

            bool isAdded = cmsProcess.AddPrayerSched(date, songLeader, presider, speaker, prayerItem);
            if (isAdded)
            {
                lbl_Status.Text = "Schedule Added Successfully";
                LoadPrayerSchedules();
                ToUpdateSched();
                dtp_Date.Value = DateTime.Today;
                cmb_Speaker.SelectedIndex = -1;
                cmb_PrayerItem.SelectedIndex = -1;
                cmb_Presider.SelectedIndex = -1;
                cmb_SongLeader.SelectedIndex = -1;
            }
            else
            {
                lbl_Status.Text = "Failed to add schedule.";
            }
        }

        private void LoadPrayerUserList(string ministryName)
        {
            List<string> users = cmsProcess.GetAllUsersPerMinistry(ministryName);

            cmb_Speaker.Items.Clear();
            cmb_UpdateSpeaker.Items.Clear();
            cmb_UpdatePresider.Items.Clear();
            cmb_Presider.Items.Clear();

            foreach (var user in users)
            {
                cmb_UpdateSpeaker.Items.Add(user);
                cmb_UpdatePresider.Items.Add(user);
                cmb_Speaker.Items.Add(user);
                cmb_Presider.Items.Add(user);
            }
        }
        private void LoadSongLeaderList(string ministryName)
        {
            List<string> users = cmsProcess.GetAllUsersPerMinistry(ministryName);

            cmb_SongLeader.Items.Clear();
            cmb_UpdateSongLeader.Items.Clear();

            foreach (var user in users)
            {
                cmb_SongLeader.Items.Add(user);
                cmb_UpdateSongLeader.Items.Add(user);
            }
        }

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

        private void ToUpdateSched()
        {
            cmb_ToUpdate.Items.Clear();
            cmb_ToRemove.Items.Clear();

            List<PrayerMinistry> schedules = cmsProcess.ViewPrayerSched();

            for (int i = 0; i < schedules.Count; i++)
            {
                cmb_ToUpdate.Items.Add(schedules[i].Date.ToString("MM-dd-yyyy"));
                cmb_ToRemove.Items.Add(schedules[i].Date.ToString("MM-dd-yyyy"));
            }
        }


        private void btn_Remove_Click(object sender, EventArgs e)
        {
            string selectedDateString = cmb_ToRemove.SelectedItem.ToString();
            DateTime date = DateTime.ParseExact(selectedDateString, "MM-dd-yyyy", null);

            bool toRemove = cmsProcess.RemovePrayerSched(date);

            if (toRemove)
            {
                lbl_RemoveStatus.Text = "Schedule Removed Successfully.";
                LoadPrayerSchedules();
                ToUpdateSched();
                cmb_ToRemove.SelectedIndex = -1;
            }
            else
            {
                lbl_RemoveStatus.Text = "Failed to update schedule.";
            }
        }

        private void cmb_ToUpdate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_ToUpdate.SelectedIndex != -1)
            {
                string selectedDateString = cmb_ToUpdate.SelectedItem.ToString();
                DateTime selectedDate = DateTime.ParseExact(selectedDateString, "MM-dd-yyyy", null);

                List<PrayerMinistry> schedules = cmsProcess.ViewPrayerSched();
                PrayerMinistry selectedSchedule = null;

                for (int i = 0; i < schedules.Count; i++)
                {
                    if (schedules[i].Date == selectedDate)
                    {
                        selectedSchedule = schedules[i];
                        break;
                    }
                }
                if (selectedSchedule != null)
                {
                    LoadPrayerUserList("Prayer Ministry");
                    LoadSongLeaderList("Worship Ministry");
                    dtp_UpdateDate.Value = selectedSchedule.Date;
                    cmb_UpdateSongLeader.SelectedItem = selectedSchedule.SongLeader;
                    cmb_UpdatePresider.SelectedItem = selectedSchedule.Speaker;
                    cmb_UpdateSpeaker.SelectedItem = selectedSchedule.Speaker;
                    cmb_UpdatePrayerItem.SelectedItem = selectedSchedule.PrayerItem;

                    lbl_UpdateStatus.Text = "Schedule loaded.";
                }
                else
                {
                    lbl_UpdateStatus.Text = "Schedule not found.";
                }
            }
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            if (cmb_ToUpdate.SelectedItem == null)
            {
                lbl_UpdateStatus.Text = "Please select a schedule.";
                return;
            }

            string selectedDateString = cmb_ToUpdate.SelectedItem.ToString();
            DateTime date = DateTime.ParseExact(selectedDateString, "MM-dd-yyyy", null);

            string songLeader = cmb_UpdateSongLeader.Text.Trim();
            string presider = cmb_UpdatePresider.Text.Trim();
            string speaker = cmb_UpdateSpeaker.Text.Trim();
            string prayerItem = cmb_UpdatePrayerItem.Text.Trim();
           

            if (string.IsNullOrWhiteSpace(speaker) || string.IsNullOrWhiteSpace(songLeader) || string.IsNullOrWhiteSpace(presider)|| string.IsNullOrWhiteSpace(prayerItem))
            {
                lbl_UpdateStatus.Text = "Please fill all fields.";
                return;
            }
            string status = "Confirmed";
            bool updated = cmsProcess.UpdatePrayerSched(date, songLeader, status, presider, status, speaker, status, prayerItem);

            if (updated)
            {
                lbl_UpdateStatus.Text = "Schedule updated successfully.";
                LoadPrayerSchedules();
                dtp_Date.Value = DateTime.Today;
                cmb_UpdateSpeaker.SelectedIndex = -1;
                cmb_UpdatePresider.SelectedIndex = -1;
                cmb_UpdateSongLeader.SelectedIndex = -1;
                cmb_UpdatePrayerItem.SelectedIndex = -1;
                cmb_ToUpdate.SelectedIndex = -1;
            }
            else
            {
                lbl_UpdateStatus.Text = "Failed to update schedule.";
            }
        }
    }
}
