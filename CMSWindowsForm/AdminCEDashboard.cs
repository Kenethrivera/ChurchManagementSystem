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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CMSWindowsForm
{
    public partial class AdminCEDashboard : Form
    {
        CMSProcess cmsProcess = new CMSProcess();
        private string selectedType = "Teacher";
        public AdminCEDashboard()
        {
            InitializeComponent();
            ToUpdateTeacherSched();
            ToUpdateLessonSched();
        }

        private void cmb_ScheduleType_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbx_UpdateName.Clear();
            tbx_UpdateMaterials.Clear();
            cmb_ToUpdate.SelectedIndex = -1;
            cmb_ToRemove.SelectedIndex = -1;
            lbl_UpdateStatus.Text = "";
            lbl_Status.Text = "";

            dtp_Date.Value = DateTime.Today;
            dtp_UpdateDate.Value = DateTime.Today;
            selectedType = cmb_ScheduleType.SelectedItem.ToString();
            SwitchTabContents(selectedType);
        }
        private void SwitchTabContents(string type)
        {
            if (selectedType == "Teacher")
            {
                //view tab
                lbl_ViewHeader.Text = "Teacher's List:";
                LoadTeachersList();// method that display teachers list

                //add tab
                lbl_AddHeader.Text = "Add Teacher: ";
                lbl_name.Text = "Name: ";
                lbl_assma.Text = "Assignment:";
                tbx_UpdateName.ReadOnly = true;
                lbl_Date.Visible = false;
                dtp_Date.Visible = false;
                btn_Add.Text = "Add Teacher";


                //update tab
                lbl_UpdateHeader.Text = "Update Teacher";
                btn_Update.Text = "Update Teacher";
                lbl_updateName.Text = "Name";
                lbl_UpdateMaterials.Text = "Assignment";
                lbl_UpdateDate.Visible = false;
                dtp_UpdateDate.Visible = false;
                ToUpdateTeacherSched();

                // delete tab
                lbl_RemoveHeader.Text = "Remove Teacher";
            }
            else if (selectedType == "Lesson")
            {
                lbl_ViewHeader.Text = "Lesson Schedule";
                LoadLessonSchedules(); // method that display lessons list

                //add tab
                lbl_AddHeader.Text = "Add Lesson: ";
                lbl_name.Text = "Lesson: ";
                lbl_assma.Text = "Materials:";
                lbl_Date.Visible = true;
                dtp_Date.Visible = true;
                btn_Add.Text = "Add Lesson";
                //update tab

                lbl_UpdateHeader.Text = "Update Lesson";
                btn_Update.Text = "Update Lesson";
                lbl_updateName.Text = "Lesson";
                lbl_UpdateMaterials.Text = "Materials";
                lbl_UpdateDate.Visible = true;
                dtp_UpdateDate.Visible = true;
                ToUpdateLessonSched();

                // delete tab
                lbl_RemoveHeader.Text = "Remove Lesson";
            }
            else
            {

            }
        }
        private void LoadTeachersList()
        {
            flp_ViewPanel.Controls.Clear();

            foreach (var sched in cmsProcess.GetTeachers())
            {
                Panel viewSchedulePanel = new Panel
                {
                    Width = flp_ViewPanel.Width - 30,
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

                flp_ViewPanel.Controls.Add(viewSchedulePanel);
            }
        }
        private void LoadLessonSchedules()
        {
            flp_ViewPanel.Controls.Clear();

            foreach (var sched in cmsProcess.GetLessons())
            {
                Panel viewSchedulePanel = new Panel
                {
                    Width = flp_ViewPanel.Width - 30,
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

                flp_ViewPanel.Controls.Add(viewSchedulePanel);
            }
        }

        // addd function
        private void btn_Add_Click(object sender, EventArgs e)
        {
            lbl_Status.Text = "";

            if (selectedType == "Teacher")
            {
                TeacherAddFunction();
            }
            else if (selectedType == "Lesson")
            {
                LessonAddFunction();
            }
            else
            {
                lbl_Status.Text = "Invalid Scheduling Type. Please Select one.";
            }
        }
        private void TeacherAddFunction()
        {
            string teacherName = tbx_name.Text.Trim();
            string assignment = tbx_materials.Text.Trim();

            if (string.IsNullOrEmpty(teacherName) || string.IsNullOrEmpty(assignment))
            {
                lbl_Status.Text = "Please fill all the fields needed";
                return;
            }
            if (cmsProcess.TeacherNameExist(teacherName))
            {
                lbl_Status.Text = "Teacher's Name already listed.";
                return;
            }

            bool isAdded = cmsProcess.AddTeachers(teacherName, assignment);
            if (isAdded)
            {
                lbl_Status.Text = "Teacher Added Successfully";
                LoadTeachersList();
                ToUpdateTeacherSched();
                tbx_name.Text = "";
                tbx_materials.Text = "";

            }
            else
            {
                lbl_Status.Text = "Failed to add Teacher.";
            }

        }
        private void LessonAddFunction()
        {
            DateTime date = dtp_Date.Value.Date;
            string lessonTitle = tbx_name.Text.Trim();
            string materials = tbx_materials.Text.Trim();

            if (string.IsNullOrEmpty(lessonTitle) || string.IsNullOrEmpty(materials))
            {
                MessageBox.Show("Please fill in all fields for Lesson schedule.");
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

            if (cmsProcess.LessonExist(date))
            {
                lbl_Status.Text = "Schedule already exists for this date.";
                return;
            }

            bool isAdded = cmsProcess.AddLesson(date, lessonTitle, materials);
            if (isAdded)
            {
                lbl_Status.Text = "Schedule Added Successfully";
                LoadLessonSchedules();
                ToUpdateLessonSched();
                dtp_Date.Value = DateTime.Today;
                tbx_name.Text = "";
                tbx_materials.Text = "";
            }
            else
            {
                lbl_Status.Text = "Failed to add schedule.";
            }
        }

        //update function
        private void ToUpdateTeacherSched()
        {
            cmb_ToUpdate.Items.Clear();
            cmb_ToRemove.Items.Clear();

            List<TeachersList> schedules = cmsProcess.GetTeachers();

            for (int i = 0; i < schedules.Count; i++)
            {
                cmb_ToUpdate.Items.Add(schedules[i].TeachersName.ToString());
                cmb_ToRemove.Items.Add(schedules[i].TeachersName.ToString());
            }
        }
        private void ToUpdateLessonSched()
        {
            cmb_ToUpdate.Items.Clear();
            cmb_ToRemove.Items.Clear();

            List<Lesson> schedules = cmsProcess.GetLessons();

            for (int i = 0; i < schedules.Count; i++)
            {
                cmb_ToUpdate.Items.Add(schedules[i].Date.ToString("MM-dd-yyyy"));
                cmb_ToRemove.Items.Add(schedules[i].Date.ToString("MM-dd-yyyy"));
            }
        }

        private void cmb_ToUpdate_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtp_Date.Value = DateTime.Today;
            tbx_UpdateName.Clear();
            tbx_UpdateMaterials.Clear();

            if (selectedType == "Teacher")
            {
                cmb_ToUpdate_SelectedIndexChanged_Teacher();
            }
            else if (selectedType == "Lesson")
            {
                cmb_ToUpdate_SelectedIndexChanged_Lesson();
            }
            else
            {
                lbl_UpdateStatus.Text = "Scheduling Type is not yet set. Please choose the type first";
            }

        }
        private void cmb_ToUpdate_SelectedIndexChanged_Teacher()
        {
            lbl_Status.Text = "";
            if (cmb_ToUpdate.SelectedIndex != -1)
            {
                string selectedString = cmb_ToUpdate.SelectedItem.ToString();

                List<TeachersList> teachers = cmsProcess.GetTeachers();
                TeachersList selectedName = null;

                for (int i = 0; i < teachers.Count; i++)
                {
                    if (teachers[i].TeachersName == selectedString)
                    {
                        selectedName = teachers[i];
                        break;
                    }
                }
                if (selectedName != null)
                {
                    tbx_UpdateName.Text = selectedName.TeachersName;
                    tbx_UpdateMaterials.Text = selectedName.Assignment;

                    lbl_UpdateStatus.Text = "Teacher's Info Loaded";
                }
                else
                {
                    lbl_UpdateStatus.Text = "Teacher's Name not found.";
                }
            }
        }
        private void cmb_ToUpdate_SelectedIndexChanged_Lesson()
        {
            lbl_Status.Text = "";
            if (cmb_ToUpdate.SelectedIndex != -1)
            {
                string selectedDateString = cmb_ToUpdate.SelectedItem.ToString();
                DateTime selectedDate = DateTime.ParseExact(selectedDateString, "MM-dd-yyyy", null);

                List<Lesson> schedules = cmsProcess.GetLessons();
                Lesson selectedSchedule = null;

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
                    tbx_UpdateName.Text = selectedSchedule.Lessson;
                    tbx_UpdateMaterials.Text = selectedSchedule.Materials;

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

            if (selectedType == "Teacher")
            {
                btn_Update_Click_Teacher();
            }
            else if (selectedType == "Lesson")
            {
                btn_Update_Click_Lesson();
            }
            else
            {
                lbl_UpdateStatus.Text = "Scheduling Type is not yet set. Please choose the type first";
            }
        }
        private void btn_Update_Click_Teacher()
        {
            if (cmb_ToUpdate.SelectedItem == null)
            {
                lbl_UpdateStatus.Text = "Please select a schedule.";
                return;
            }

            string teacherName = cmb_ToUpdate.SelectedItem.ToString();
            string assignment = tbx_UpdateMaterials.Text.Trim();

            if (string.IsNullOrWhiteSpace(assignment))
            {
                lbl_UpdateStatus.Text = "Please enter the new assignment.";
                return;
            }

            bool updated = cmsProcess.UpdateTeachers(teacherName, assignment);

            if (updated)
            {
                lbl_UpdateStatus.Text = "Assignment updated successfully.";
                LoadTeachersList();
                cmb_ToUpdate.SelectedIndex = -1;
                tbx_UpdateName.Clear();
                tbx_UpdateMaterials.Clear();
            }
            else
            {
                lbl_UpdateStatus.Text = "Failed to update assignment.";
            }
        }
        private void btn_Update_Click_Lesson()
        {
            if (cmb_ToUpdate.SelectedItem == null)
            {
                lbl_UpdateStatus.Text = "Please select a schedule.";
                return;
            }

            string selectedDateString = cmb_ToUpdate.SelectedItem.ToString();
            DateTime date = DateTime.ParseExact(selectedDateString, "MM-dd-yyyy", null);

            string lesson = tbx_UpdateName.Text.Trim();
            string materials = tbx_UpdateMaterials.Text.Trim();


            if (string.IsNullOrWhiteSpace(lesson) || string.IsNullOrWhiteSpace(materials))
            {
                lbl_UpdateStatus.Text = "Please fill all fields.";
                return;
            }
            bool updated = cmsProcess.UpdateLesson(date, lesson, materials);

            if (updated)
            {
                lbl_UpdateStatus.Text = "Schedule updated successfully.";
                LoadLessonSchedules();
                dtp_Date.Value = DateTime.Today;
                tbx_UpdateName.Text = "";
                tbx_UpdateMaterials.Text = "";

            }
            else
            {
                lbl_UpdateStatus.Text = "Failed to update schedule.";
            }
        }
        // remove function
        private void btn_Remove_Click(object sender, EventArgs e)
        {
            lbl_RemoveStatus.Text = "";

            if (selectedType == "Teacher")
            {
                btn_Remove_Click_Teacher();
            }
            else if (selectedType == "Lesson")
            {
                btn_Remove_Click_Lesson();
            }
            else
            {
                lbl_UpdateStatus.Text = "Scheduling Type is not yet set. Please choose the type first";
            }

        }
        private void btn_Remove_Click_Teacher()
        {
            string selectedTeacher = cmb_ToRemove.SelectedItem.ToString();

            bool toRemove = cmsProcess.RemoveTeacher(selectedTeacher);

            if (toRemove)
            {
                lbl_RemoveStatus.Text = "Schedule Removed Successfully.";
                LoadTeachersList();
                ToUpdateTeacherSched();
                cmb_ToRemove.SelectedIndex = -1;
            }
            else
            {
                lbl_RemoveStatus.Text = "Failed to update schedule.";
            }
        }
        private void btn_Remove_Click_Lesson()
        {
            string selectedDateString = cmb_ToRemove.SelectedItem.ToString();
            DateTime date = DateTime.ParseExact(selectedDateString, "MM-dd-yyyy", null);

            bool toRemove = cmsProcess.RemoveLesson(date);

            if (toRemove)
            {
                lbl_RemoveStatus.Text = "Schedule Removed Successfully.";
                LoadLessonSchedules();
                ToUpdateLessonSched();
                cmb_ToRemove.SelectedIndex = -1;
            }
            else
            {
                lbl_RemoveStatus.Text = "Failed to update schedule.";
            }
        }

        // log out function
        private void btn_Logout_Click_1(object sender, EventArgs e)
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

        private void flp_ViewPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AdminCEDashboard_Load(object sender, EventArgs e)
        {
            cmb_ScheduleType.SelectedIndex = 0;
        }
    }
}

