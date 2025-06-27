using BusinessAndDataLogic;
using CMSDataLogic;
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
    public partial class Login : Form
    {
        CMSProcess cmsProcess = new CMSProcess();
        public Login()
        {
            InitializeComponent();
        }
        private int attempt = 0;
        private int maxAttempt = 3;

        private void btn_Login_Click(object sender, EventArgs e)
        {
            string username = tbx_Username.Text.Trim();
            string password = tbx_Password.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || cmb_Position.SelectedItem == null)
            {
                lbl_Status.Text = "Please Fill all Fields";
                return;
            }
            bool isAdmin = cmb_Position.SelectedItem.ToString() == "Admin";
            var user = cmsProcess.ValidatingUserRole(isAdmin, username, password);


            if (user != null)
            {
                var ministryName = user.MinistryName;
                lbl_Status.Text = "";
                MessageBox.Show("Login Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (isAdmin)
                {
                    if (ministryName == "Discipleship Ministry")
                    {
                        AdminDiscipleshipDashboard adminDiscipleshipForm = new AdminDiscipleshipDashboard();
                        adminDiscipleshipForm.Show();
                        this.Hide();
                    }
                    if (ministryName == "Prayer Ministry")
                    {
                        AdminPrayerDashboard adminPrayerForm = new AdminPrayerDashboard();
                        adminPrayerForm.Show();
                        this.Hide();
                    }
                    if (ministryName == "Christian Education")
                    {
                        AdminCEDashboard adminCEForm = new AdminCEDashboard();
                        adminCEForm.Show();
                        this.Hide();
                    }
                    if (ministryName == "Worship Ministry")
                    {
                        AdminWorshipDashboard adminWorshipForm = new AdminWorshipDashboard();
                        adminWorshipForm.Show();
                        this.Hide();
                    }
                }
                else
                {
                    UserDashboard userDashboard = new UserDashboard(user, isAdmin);
                    userDashboard.Show();
                    this.Hide();
                }
            }
            else
            {
                attempt++;
                int attemptsLeft = maxAttempt - attempt;
                lbl_Status.Text = $"Wrong username/password. Please Try Again. Attempts left: {attemptsLeft}";
                tbx_Username.Text = "";
                tbx_Password.Text = "";

                if (attempt >= maxAttempt)
                {
                    MessageBox.Show("Too many failed attempts. Returning to main menu.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    Form1 mainForm = new Form1();
                    mainForm.Show();
                }
            }

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            Form1 mainForm = new Form1();
            mainForm.Show();
            this.Hide();
        }
    }
}
