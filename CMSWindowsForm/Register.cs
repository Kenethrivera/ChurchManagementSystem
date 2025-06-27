using BusinessAndDataLogic;
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
    public partial class Register : Form
    {
        private CMSProcess cmsProcess = new CMSProcess();
        public Register()
        {
            InitializeComponent();
        }

        private void btn_Register_Click(object sender, EventArgs e)
        {
            string firstName = tbx_FirstName.Text.Trim();
            string lastName = tbx_LastName.Text.Trim();
            int age = int.TryParse(tbx_Age.Text.Trim(), out int parsedAge) ? parsedAge : 0;
            string emailAddress = tbx_EmailAddress.Text.Trim();
            string ministryName = cmb_MinistryName.Text.Trim();
            string position = cmb_Position.Text.Trim();
            string username = tbx_Username.Text.Trim();
            string password = tbx_Password.Text.Trim();
            string reEnterPassword = tbx_ReenterPassword.Text.Trim();

            string role = cmb_Position.SelectedItem?.ToString() ?? "";

            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) ||
                age <= 0 || string.IsNullOrWhiteSpace(emailAddress) || string.IsNullOrWhiteSpace(ministryName) ||
                string.IsNullOrWhiteSpace(position) || string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || cmb_Position.SelectedItem == null)
            {
                lbl_Status.Text = "Please fill all fields";
                return;
            }
            if (password != reEnterPassword)
            {
                lbl_Status.Text = "Password does not match";
                return;
            }


            bool isAdmin = role == "Admin";
            bool isAdded = false;
            if (isAdmin)
            {
                isAdded = cmsProcess.RegisteringAdminAccounts(firstName, lastName, age, emailAddress, ministryName, position, username, password);

            }
            else
            {
                position = "Member";
                isAdded = cmsProcess.RegisteringRegularAccounts(firstName, lastName, age, emailAddress, ministryName, position, username, password);
            }

            if (isAdded)
            {
                MessageBox.Show("Accounts Registered Successfully. Return to Homepage", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form1 mainForm = new Form1();
                mainForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Oops. There must be an invalid input in your formss", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Register_Load(object sender, EventArgs e)
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
