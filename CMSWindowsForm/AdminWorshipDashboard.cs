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
    public partial class AdminWorshipDashboard : Form
    {
        CMSProcess cmsProcess = new CMSProcess();
        private string selectedType = "Praise and Worship";


        public AdminWorshipDashboard()
        {
            InitializeComponent();
            LoadWorshipUserList("Worship Ministry");
            ToUpdateDevotionSched();
            ToUpdatePraiseAndWorshipSched();
            ToUpdateSundayWorshipSched();
        }

        private void cmb_ScheduleType_SelectedIndexChanged(object sender, EventArgs e)
        {

            cmb_AddSongLeader.SelectedIndex = -1;
            cmb_AddPresider.SelectedIndex = -1;
            cmb_AddSpeaker.SelectedIndex = -1;
            cmb_AddUshers.SelectedIndex = -1;

            cmb_UpdateSongLeader.SelectedIndex = -1;
            cmb_UpdatePresider.SelectedIndex = -1;
            cmb_UpdateSpeaker.SelectedIndex = -1;
            cmb_UpdateUshers.SelectedIndex = -1;

            selectedType = cmb_ScheduleType.SelectedItem.ToString();
            SwitchTabContents(selectedType);
        }
        private void SwitchTabContents(string type)
        {
            if (selectedType == "Praise and Worship")
            {
                //view tab
                LoadPraiseAndWorshipSchedule();// method that display teachers list

                //add tab
                lbl_AddSongLeader.Text = "Song Leader:";
                lbl_AddPresider.Text = "Instrumentalist: ";
                lbl_AddSpeaker.Visible = false;
                lbl_AddUshers.Visible = false;
                cmb_AddSpeaker.Visible = false;
                cmb_AddUshers.Visible = false;
                cmb_AddSongLeader.Enabled = true;
                cmb_AddSongLeader.Visible = true;

                lbl_UpdateSongLeader.Text = "Song Leader:";
                lbl_UpdatePresider.Text = "Instrumentalist: ";
                lbl_UpdateSpeaker.Visible = false;
                lbl_UpdateUshers.Visible = false;
                cmb_UpdateSpeaker.Visible = false;
                cmb_UpdateUshers.Visible = false;
                cmb_UpdateSongLeader.Enabled = true;

                //update tab
                ToUpdatePraiseAndWorshipSched();
                // delete tab

            }
            else if (selectedType == "Sunday Worship Service")
            {
                LoadSundayWorshipSchedule(); // method that display lessons list

                //add tab
                lbl_AddPresider.Text = "              Presider:";
                lbl_AddSpeaker.Visible = true;
                lbl_AddUshers.Visible = true;
                cmb_AddSpeaker.Visible = true;
                cmb_AddUshers.Visible = true;

                lbl_AddSongLeader.Text = "        Flowers:";
                cmb_AddUshers.Enabled = true;

                lbl_UpdatePresider.Text = "              Presider:";
                lbl_UpdateSpeaker.Visible = true;
                lbl_UpdateUshers.Visible = true;
                cmb_UpdateSpeaker.Visible = true;
                cmb_UpdateUshers.Visible = true;

                lbl_UpdateSongLeader.Text = "        Flowers:";
                cmb_UpdateUshers.Enabled = true;

                //update 
                ToUpdateSundayWorshipSched();

                // delete tab

            }
            else if (selectedType == "Devotion")
            {
                LoadDevotionSchedule(); // method that display lessons list

                lbl_AddPresider.Text = "              Presider:";
                lbl_AddSpeaker.Visible = true;
                lbl_AddUshers.Visible = true;
                cmb_AddSpeaker.Visible = true;
                cmb_AddUshers.Visible = true;

                cmb_AddUshers.Items.Add("This field is set by Sunday Worship Ministry");
                cmb_AddUshers.SelectedIndex = -1;
                cmb_AddUshers.Enabled = false;
                lbl_AddSongLeader.Text = "Song Leader:";
                cmb_AddSongLeader.Enabled = true;

                lbl_UpdatePresider.Text = "              Presider:";
                lbl_UpdateSpeaker.Visible = true;
                lbl_UpdateUshers.Visible = true;
                cmb_UpdateSpeaker.Visible = true;
                cmb_UpdateUshers.Visible = true;

                cmb_UpdateUshers.Enabled = false;
                lbl_UpdateSongLeader.Text = "Song Leader:";
                cmb_UpdateSongLeader.Enabled = true;
                //add tab

                //update
                ToUpdateDevotionSched();
            }
            else
            {

            }
        }
        // view function
        private void LoadPraiseAndWorshipSchedule()
        {
            flp_ViewPanel.Controls.Clear();

            foreach (var sched in cmsProcess.ViewPraiseAndWorshipSched())
            {
                Panel viewSchedulePanel = new Panel
                {
                    Width = flp_ViewPanel.Width - 30,
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

                flp_ViewPanel.Controls.Add(viewSchedulePanel);
            }
        }
        private void LoadSundayWorshipSchedule()
        {
            flp_ViewPanel.Controls.Clear();

            foreach (var sched in cmsProcess.ViewSundayWorshipSched())
            {
                Panel viewSchedulePanel = new Panel
                {
                    Width = flp_ViewPanel.Width - 30,
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

                flp_ViewPanel.Controls.Add(viewSchedulePanel);
            }
        }
        private void LoadDevotionSchedule()
        {
            flp_ViewPanel.Controls.Clear();

            foreach (var sched in cmsProcess.ViewDevotionSched())
            {
                Panel viewSchedulePanel = new Panel
                {
                    Width = flp_ViewPanel.Width - 30,
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

                flp_ViewPanel.Controls.Add(viewSchedulePanel);
            }
        }

        private void LoadWorshipUserList(string ministryName)
        {
            List<string> users = cmsProcess.GetAllUsersPerMinistry(ministryName);

            cmb_AddSongLeader.Items.Clear();
            cmb_AddPresider.Items.Clear();
            cmb_AddSpeaker.Items.Clear();
            cmb_AddUshers.Items.Clear();

            cmb_UpdateSongLeader.Items.Clear();
            cmb_UpdatePresider.Items.Clear();
            cmb_UpdateSpeaker.Items.Clear();
            cmb_UpdateUshers.Items.Clear();

            foreach (var user in users)
            {
                cmb_AddSongLeader.Items.Add(user);
                cmb_AddPresider.Items.Add(user);
                cmb_AddSpeaker.Items.Add(user);
                cmb_AddUshers.Items.Add(user);
                cmb_UpdateSongLeader.Items.Add(user);
                cmb_UpdatePresider.Items.Add(user);
                cmb_UpdateSpeaker.Items.Add(user);
                cmb_UpdateUshers.Items.Add(user);
            }
        }
        private void AdminWorshipDashboard_Load(object sender, EventArgs e)
        {
            cmb_ScheduleType.SelectedIndex = 0;
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            lbl_AddStatus.Text = "";

            if (selectedType == "Praise and Worship")
            {
                PraiseAndWorshipAddFunction();
            }
            else if (selectedType == "Sunday Worship Service")
            {
                SundayWorshipAddFunction();
            }
            else if (selectedType == "Devotion")
            {
                DevotionAddFunction();
            }
            else
            {
                lbl_AddStatus.Text = "Invalid Scheduling Type. Please Select one.";
            }
        }
        private void PraiseAndWorshipAddFunction()
        {

            DateTime date = dtp_Date.Value.Date;
            string songLeader = cmb_AddSongLeader.Text.Trim();
            string instrumentalist = cmb_AddPresider.Text.Trim();

            if (string.IsNullOrEmpty(songLeader) || string.IsNullOrEmpty(instrumentalist))
            {
                lbl_AddStatus.Text = "Please fill all fields needed.";
                return;
            }
            if (!cmsProcess.ValidateSundayDate(date))
            {
                lbl_AddStatus.Text = "Date must be a Sunday.";
                return;
            }

            if (!cmsProcess.DateIsPast(date))
            {
                lbl_AddStatus.Text = "Date must not be in the past.";
                return;
            }

            if (cmsProcess.PraiseAndWorshipScheduleExist(date))
            {
                lbl_AddStatus.Text = "Schedule already exists for this date.";
                return;
            }

            bool isAdded = cmsProcess.AddPraiseAndWorshipSched(date, songLeader, instrumentalist);
            if (isAdded)
            {
                lbl_AddStatus.Text = "Schedule Added Successfully";
                LoadPraiseAndWorshipSchedule();
                ToUpdatePraiseAndWorshipSched();
                ResetFields();
            }
            else
            {
                lbl_AddStatus.Text = "Failed to add schedule.";
            }

        }
        private void SundayWorshipAddFunction()
        {
            DateTime date = dtp_Date.Value.Date;
            string presider = cmb_AddPresider.Text.Trim();
            string speaker = cmb_AddSpeaker.Text.Trim();
            string flowers = cmb_AddSongLeader.Text.Trim();
            string ushers = cmb_AddUshers.Text.Trim();

            if (string.IsNullOrEmpty(presider) || string.IsNullOrEmpty(speaker) || string.IsNullOrEmpty(flowers) || string.IsNullOrEmpty(ushers))
            {
                lbl_AddStatus.Text = "Please fill all fields needed.";
                return;
            }
            if (!cmsProcess.ValidateSundayDate(date))
            {
                lbl_AddStatus.Text = "Date must be a Sunday.";
                return;
            }

            if (!cmsProcess.DateIsPast(date))
            {
                lbl_AddStatus.Text = "Date must not be in the past.";
                return;
            }

            if (cmsProcess.SundayWorshipScheduleExist(date))
            {
                lbl_AddStatus.Text = "Schedule already exists for this date.";
                return;
            }

            bool isAdded = cmsProcess.AddSundayWorshipServiceSched(date, presider, speaker, flowers, ushers);
            if (isAdded)
            {
                lbl_AddStatus.Text = "Schedule Added Successfully";
                LoadSundayWorshipSchedule();
                ToUpdateSundayWorshipSched();
                ResetFields();
            }
            else
            {
                lbl_AddStatus.Text = "Failed to add schedule.";
            }
        }
        private void DevotionAddFunction()
        {
            DateTime date = dtp_Date.Value.Date;
            string presider = cmb_AddPresider.Text.Trim();
            string speaker = cmb_AddSpeaker.Text.Trim();
            string songLeader = cmb_AddSongLeader.Text.Trim();

            if (string.IsNullOrEmpty(presider) || string.IsNullOrEmpty(speaker))
            {
                lbl_AddStatus.Text = "Please fill all fields needed.";
                return;
            }
            if (!cmsProcess.ValidateFridayDate(date))
            {
                lbl_AddStatus.Text = "Date must be a Friday.";
                return;
            }

            if (!cmsProcess.DateIsPast(date))
            {
                lbl_AddStatus.Text = "Date must not be in the past.";
                return;
            }

            if (cmsProcess.DevotionScheduleExist(date))
            {
                lbl_AddStatus.Text = "Schedule already exists for this date.";
                return;
            }

            bool isAdded = cmsProcess.AddDevotionSched(date, songLeader, presider, speaker);
            if (isAdded)
            {
                lbl_AddStatus.Text = "Schedule Added Successfully";
                LoadDevotionSchedule();
                ToUpdateDevotionSched();
                ResetFields();
            }
            else
            {
                lbl_AddStatus.Text = "Failed to add schedule.";
            }
        }

        private void ToUpdatePraiseAndWorshipSched()
        {
            cmb_ToUpdate.Items.Clear();
            cmb_ToRemove.Items.Clear();

            List<PraiseAndWorship> schedules = cmsProcess.ViewPraiseAndWorshipSched();

            for (int i = 0; i < schedules.Count; i++)
            {
                cmb_ToUpdate.Items.Add(schedules[i].Date.ToString("MM-dd-yyyy"));
                cmb_ToRemove.Items.Add(schedules[i].Date.ToString("MM-dd-yyyy"));
            }
        }
        private void ToUpdateSundayWorshipSched()
        {
            cmb_ToUpdate.Items.Clear();
            cmb_ToRemove.Items.Clear();

            List<SundayWorshipService> schedules = cmsProcess.ViewSundayWorshipSched();

            for (int i = 0; i < schedules.Count; i++)
            {
                cmb_ToUpdate.Items.Add(schedules[i].Date.ToString("MM-dd-yyyy"));
                cmb_ToRemove.Items.Add(schedules[i].Date.ToString("MM-dd-yyyy"));
            }
        }
        private void ToUpdateDevotionSched()
        {
            cmb_ToUpdate.Items.Clear();
            cmb_ToRemove.Items.Clear();

            List<Devotion> schedules = cmsProcess.ViewDevotionSched();

            for (int i = 0; i < schedules.Count; i++)
            {
                cmb_ToUpdate.Items.Add(schedules[i].Date.ToString("MM-dd-yyyy"));
                cmb_ToRemove.Items.Add(schedules[i].Date.ToString("MM-dd-yyyy"));
            }
        }

        private void ResetFields()
        {
            dtp_Date.Value = DateTime.Today;
            dtp_UpdateDate.Value = DateTime.Today;

            cmb_AddSongLeader.SelectedIndex = -1;
            cmb_AddPresider.SelectedIndex = -1;
            cmb_AddSpeaker.SelectedIndex = -1;
            cmb_AddUshers.SelectedIndex = -1;

            cmb_UpdateSongLeader.SelectedIndex = -1;
            cmb_UpdatePresider.SelectedIndex = -1;
            cmb_UpdateSpeaker.SelectedIndex = -1;
            cmb_UpdateUshers.SelectedIndex = -1;

        }

        private void cmb_ToUpdate_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetFields();

            if (selectedType == "Praise and Worship")
            {
                cmb_ToUpdate_SelectedIndexChanged_PW();
            }
            else if (selectedType == "Sunday Worship Service")
            {
                cmb_ToUpdate_SelectedIndexChanged_SWC();
            }
            else if (selectedType == "Devotion")
            {
                cmb_ToUpdate_SelectedIndexChanged_Devo();
            }
            else
            {
                lbl_UpdateStatus.Text = "Scheduling Type is not yet set. Please choose the type first";
            }
        }

        private void cmb_ToUpdate_SelectedIndexChanged_PW()
        {
            lbl_UpdateStatus.Text = "";
            if (cmb_ToUpdate.SelectedIndex != -1)
            {
                string selectedDateString = cmb_ToUpdate.SelectedItem.ToString();
                DateTime selectedDate = DateTime.ParseExact(selectedDateString, "MM-dd-yyyy", null);

                List<PraiseAndWorship> schedules = cmsProcess.ViewPraiseAndWorshipSched();
                PraiseAndWorship selectedSchedule = null;

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
                    dtp_UpdateDate.Value = selectedSchedule.Date;
                    cmb_UpdateSongLeader.Text = selectedSchedule.SongLeader;
                    cmb_UpdatePresider.Text = selectedSchedule.Instrumentalist;

                    lbl_UpdateStatus.Text = "Schedule loaded.";
                }
                else
                {
                    lbl_UpdateStatus.Text = "Schedule not found.";
                }
            }
        }
        private void cmb_ToUpdate_SelectedIndexChanged_SWC()
        {
            lbl_UpdateStatus.Text = "";
            if (cmb_ToUpdate.SelectedIndex != -1)
            {
                string selectedDateString = cmb_ToUpdate.SelectedItem.ToString();
                DateTime selectedDate = DateTime.ParseExact(selectedDateString, "MM-dd-yyyy", null);

                List<SundayWorshipService> schedules = cmsProcess.ViewSundayWorshipSched();
                SundayWorshipService selectedSchedule = null;

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
                    dtp_UpdateDate.Value = selectedSchedule.Date;
                    cmb_UpdateSongLeader.Text = selectedSchedule.Flowers;
                    cmb_UpdatePresider.Text = selectedSchedule.Presider;
                    cmb_UpdateSpeaker.Text = selectedSchedule.Speaker;
                    cmb_UpdateUshers.Text = selectedSchedule.Ushers;

                    lbl_UpdateStatus.Text = "Schedule loaded.";
                }
                else
                {
                    lbl_UpdateStatus.Text = "Schedule not found.";
                }
            }
        }
        private void cmb_ToUpdate_SelectedIndexChanged_Devo()
        {
            lbl_UpdateStatus.Text = "";
            if (cmb_ToUpdate.SelectedIndex != -1)
            {
                string selectedDateString = cmb_ToUpdate.SelectedItem.ToString();
                DateTime selectedDate = DateTime.ParseExact(selectedDateString, "MM-dd-yyyy", null);

                List<Devotion> schedules = cmsProcess.ViewDevotionSched();
                Devotion selectedSchedule = null;

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
                    dtp_UpdateDate.Value = selectedSchedule.Date;
                    cmb_UpdateSongLeader.Text = selectedSchedule.SongLeader;
                    cmb_UpdatePresider.Text = selectedSchedule.Presider;
                    cmb_UpdateSpeaker.Text = selectedSchedule.Speaker;

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
            lbl_UpdateStatus.Text = "";

            if (selectedType == "Praise and Worship")
            {
                btn_Update_Click_PW();
            }
            else if (selectedType == "Sunday Worship Service")
            {
                btn_Update_Click_SWC();
            }
            else if (selectedType == "Devotion")
            {
                btn_Update_Click_Devo();
            }
            else
            {
                lbl_UpdateStatus.Text = "Scheduling Type is not yet set. Please choose the type first";
            }
        }
        private void btn_Update_Click_PW()
        {
            if (cmb_ToUpdate.SelectedItem == null)
            {
                lbl_UpdateStatus.Text = "Please select a schedule.";
                return;
            }

            string selectedDateString = cmb_ToUpdate.SelectedItem.ToString();
            DateTime date = DateTime.ParseExact(selectedDateString, "MM-dd-yyyy", null);

            string songLeader = cmb_UpdateSongLeader.Text.Trim();
            string instrumentatlist = cmb_AddPresider.Text.Trim();


            if (string.IsNullOrWhiteSpace(songLeader))
            {
                lbl_UpdateStatus.Text = "Please fill all fields.";
                return;
            }
            string status = "Confirmed";
            bool updated = cmsProcess.UpdatePraiseAndWorshipSched(date, songLeader, status);

            if (updated)
            {
                lbl_UpdateStatus.Text = "Schedule updated successfully.";
                LoadPraiseAndWorshipSchedule();
                cmb_ToUpdate.SelectedIndex = -1;
                ResetFields();

            }
            else
            {
                lbl_UpdateStatus.Text = "Failed to update schedule.";
            }
        }
        private void btn_Update_Click_SWC()
        {
            if (cmb_ToUpdate.SelectedItem == null)
            {
                lbl_UpdateStatus.Text = "Please select a schedule.";
                return;
            }

            string selectedDateString = cmb_ToUpdate.SelectedItem.ToString();
            DateTime date = DateTime.ParseExact(selectedDateString, "MM-dd-yyyy", null);

            string presider = cmb_UpdatePresider.Text.Trim();
            string speaker = cmb_UpdateSpeaker.Text.Trim();
            string flowers = cmb_UpdateSongLeader.Text.Trim();
            string ushers = cmb_UpdateUshers.Text.Trim();


            if (string.IsNullOrWhiteSpace(presider) || string.IsNullOrWhiteSpace(speaker) ||
                string.IsNullOrWhiteSpace(flowers) || string.IsNullOrWhiteSpace(ushers))
            {
                lbl_UpdateStatus.Text = "Please fill all fields.";
                return;
            }
            string status = "Confirmed";
            bool updated = cmsProcess.UpdateSundayWorshipServiceSched(date, presider, status, speaker, status, flowers, status, ushers, status);

            if (updated)
            {
                lbl_UpdateStatus.Text = "Schedule updated successfully.";
                LoadSundayWorshipSchedule();
                cmb_ToUpdate.SelectedIndex = -1;
                ResetFields();

            }
            else
            {
                lbl_UpdateStatus.Text = "Failed to update schedule.";
            }
        }
        private void btn_Update_Click_Devo()
        {
            if (cmb_ToUpdate.SelectedItem == null)
            {
                lbl_UpdateStatus.Text = "Please select a schedule.";
                return;
            }

            string selectedDateString = cmb_ToUpdate.SelectedItem.ToString();
            DateTime date = DateTime.ParseExact(selectedDateString, "MM-dd-yyyy", null);

            string presider = cmb_UpdatePresider.Text.Trim();
            string speaker = cmb_UpdateSpeaker.Text.Trim();
            string songLeader = cmb_UpdateSongLeader.Text.Trim();


            if (string.IsNullOrWhiteSpace(presider) || string.IsNullOrWhiteSpace(speaker) || string.IsNullOrWhiteSpace(songLeader))
            {
                lbl_UpdateStatus.Text = "Please fill all fields.";
                return;
            }
            string status = "Confirmed";
            bool updated = cmsProcess.UpdateDevotionSched(date, songLeader, status, presider, status, speaker, status);

            if (updated)
            {
                lbl_UpdateStatus.Text = "Schedule updated successfully.";
                LoadSundayWorshipSchedule();
                cmb_ToUpdate.SelectedIndex = -1;
                ResetFields();

            }
            else
            {
                lbl_UpdateStatus.Text = "Failed to update schedule.";
            }
        }

        private void btn_Remove_Click(object sender, EventArgs e)
        {
            lbl_RemoveStatus.Text = "";

            if (selectedType == "Praise and Worship")
            {
                btn_Remove_Click_PW();
            }
            else if (selectedType == "Sunday Worship Service")
            {
                btn_Remove_Click_SWC();
            }
            else if (selectedType == "Devotion")
            {
                btn_Remove_Click_Devo();
            }
            else
            {
                lbl_UpdateStatus.Text = "Scheduling Type is not yet set. Please choose the type first";
            }

        }
        private void btn_Remove_Click_PW()
        {
            string selectedDateString = cmb_ToRemove.SelectedItem.ToString();
            DateTime date = DateTime.ParseExact(selectedDateString, "MM-dd-yyyy", null);

            bool toRemove = cmsProcess.RemovePraiseAndWorshipSched(date);

            if (toRemove)
            {
                lbl_RemoveStatus.Text = "Schedule Removed Successfully.";
                LoadPraiseAndWorshipSchedule();
                ToUpdatePraiseAndWorshipSched();
                cmb_ToRemove.SelectedIndex = -1;
            }
            else
            {
                lbl_RemoveStatus.Text = "Failed to update schedule.";
            }
        }
        private void btn_Remove_Click_SWC()
        {
            string selectedDateString = cmb_ToRemove.SelectedItem.ToString();
            DateTime date = DateTime.ParseExact(selectedDateString, "MM-dd-yyyy", null);

            bool toRemove = cmsProcess.RemoveSundayWorshipSched(date);

            if (toRemove)
            {
                lbl_RemoveStatus.Text = "Schedule Removed Successfully.";
                LoadSundayWorshipSchedule();
                ToUpdateSundayWorshipSched();
                cmb_ToRemove.SelectedIndex = -1;
            }
            else
            {
                lbl_RemoveStatus.Text = "Failed to update schedule.";
            }
        }
        private void btn_Remove_Click_Devo()
        {
            string selectedDateString = cmb_ToRemove.SelectedItem.ToString();
            DateTime date = DateTime.ParseExact(selectedDateString, "MM-dd-yyyy", null);

            bool toRemove = cmsProcess.RemoveDevotionSched(date);

            if (toRemove)
            {
                lbl_RemoveStatus.Text = "Schedule Removed Successfully.";
                LoadDevotionSchedule();
                ToUpdateDevotionSched();
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
    }
}

