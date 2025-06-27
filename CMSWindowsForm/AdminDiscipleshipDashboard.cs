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
    public partial class AdminDiscipleshipDashboard : Form
    {
        CMSProcess cmsProcess = new CMSProcess();
        public AdminDiscipleshipDashboard()
        {
            InitializeComponent();
            flp_ViewPanel_Paint();
            LoadSpeakerList("Discipleship Ministry");
            ToUpdateSched();
        }



        private void flp_ViewPanel_Paint()
        {
            flp_ViewPanel.Controls.Clear();

            foreach (var sched in cmsProcess.ViewDiscipleshipSchedule())
            {
                Panel viewSchedulePanel = new Panel
                {
                    Width = flp_ViewPanel.Width - 30,
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

                flp_ViewPanel.Controls.Add(viewSchedulePanel);
            }
        }


        private void LoadSpeakerList(string ministryName)
        {
            List<string> users = cmsProcess.GetAllUsersPerMinistry(ministryName);

            cmb_Speaker.Items.Clear();
            cmb_UpdateSpeaker.Items.Clear();
            foreach (var user in users)
            {
                cmb_UpdateSpeaker.Items.Add(user);
                cmb_Speaker.Items.Add(user);
            }
        }

        private void btn_Register_Click(object sender, EventArgs e)
        {
            DateTime date = dtp_Date.Value.Date;
            string speaker = cmb_Speaker.Text.Trim();
            string description = tbx_Description.Text.Trim();
            string note = tbx_Note.Text.Trim();

            if (string.IsNullOrWhiteSpace(speaker) || string.IsNullOrWhiteSpace(description) || string.IsNullOrWhiteSpace(note))
            {
                lbl_Status.Text = "Please fill all fields.";
                return;
            }
            if (!cmsProcess.ValidateSundayDate(date))
            {
                lbl_Status.Text = "Date must be a Sunday.";
                return;
            }

            if (!cmsProcess.DateIsPast(date))
            {
                lbl_Status.Text = "Date must not be in the past.";
                return;
            }

            if (cmsProcess.DiscipleshipScheduleExist(date))
            {
                lbl_Status.Text = "Schedule already exists for this date.";
                return;
            }

            bool isAdded = cmsProcess.AddDiscipleshipSched(date, speaker, description, note);
            if (isAdded)
            {
                lbl_Status.Text = "Schedule Added Successfully";
                flp_ViewPanel_Paint();
                ToUpdateSched();
                dtp_Date.Value = DateTime.Today;
                cmb_Speaker.SelectedIndex = -1;
                tbx_Description.Text = "";
                tbx_Note.Text = "";

            }
            else
            {
                lbl_Status.Text = "Failed to add schedule.";
            }
        }


        private void ToUpdateSched()
        {
            cmb_ToUpdate.Items.Clear();
            cmb_ToRemove.Items.Clear();

            List<DiscipleshipMinistry> schedules = cmsProcess.ViewDiscipleshipSchedule();

            for (int i = 0; i < schedules.Count; i++)
            {
                cmb_ToUpdate.Items.Add(schedules[i].Date.ToString("MM-dd-yyyy"));
                cmb_ToRemove.Items.Add(schedules[i].Date.ToString("MM-dd-yyyy"));
            }
        }

        private void cmb_ToUpdate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_ToUpdate.SelectedIndex != -1)
            {
                string selectedDateString = cmb_ToUpdate.SelectedItem.ToString();
                DateTime selectedDate = DateTime.ParseExact(selectedDateString, "MM-dd-yyyy", null);

                List<DiscipleshipMinistry> schedules = cmsProcess.ViewDiscipleshipSchedule();
                DiscipleshipMinistry selectedSchedule = null;

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
                    LoadSpeakerList("Discipleship Ministry");
                    dtp_UpdateDate.Value = selectedSchedule.Date;
                    cmb_UpdateSpeaker.SelectedItem = selectedSchedule.Speaker;
                    tbx_UpdateDescription.Text = selectedSchedule.Description;
                    tbx_UpdateNote.Text = selectedSchedule.Note;

                    lbl_UpdateStatus.Text = "Schedule loaded.";
                }
                else
                {
                    lbl_UpdateStatus.Text = "Schedule not found.";
                }


            }
        }

        private void btn_Update_Click_1(object sender, EventArgs e)
        {
            if (cmb_ToUpdate.SelectedItem == null)
            {
                lbl_UpdateStatus.Text = "Please select a schedule.";
                return;
            }

            string selectedDateString = cmb_ToUpdate.SelectedItem.ToString();
            DateTime date = DateTime.ParseExact(selectedDateString, "MM-dd-yyyy", null);

            string speaker = cmb_UpdateSpeaker.Text.Trim();
            string description = tbx_UpdateDescription.Text.Trim();
            string note = tbx_UpdateNote.Text.Trim();

            if (string.IsNullOrWhiteSpace(speaker) || string.IsNullOrWhiteSpace(description) || string.IsNullOrWhiteSpace(note))
            {
                lbl_UpdateStatus.Text = "Please fill all fields.";
                return;
            }
            bool updated = cmsProcess.UpdateDiscipleshipSched(date, speaker, "Confirmed", description, note);

            if (updated)
            {
                lbl_UpdateStatus.Text = "Schedule updated successfully.";
                flp_ViewPanel_Paint();
            }
            else
            {
                lbl_UpdateStatus.Text = "Failed to update schedule.";
            }
        }

        private void btn_Remove_Click(object sender, EventArgs e)
        {
            string selectedDateString = cmb_ToRemove.SelectedItem.ToString();
            DateTime date = DateTime.ParseExact(selectedDateString, "MM-dd-yyyy", null);

            bool toRemove = cmsProcess.RemoveDiscipleSched(date);

            if (toRemove)
            {
                lbl_RemoveStatus.Text = "Schedule Removed Successfully.";
                flp_ViewPanel_Paint();
                ToUpdateSched();
                cmb_ToRemove.SelectedIndex = -1;
            }
            else
            {
                lbl_RemoveStatus.Text = "Failed to update schedule.";
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

        private void tab_Add_Click(object sender, EventArgs e)
        {

        }
    }
}
