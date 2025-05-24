using CMSAccounts;
using CMSSchedules;
using Microsoft.Data.Sql;
using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace CMSDataLogic
{
    public class DBDataService : IMinistriesDataService
    {
        static string connectionString = "Data Source = DESKTOP-1PU2QVR\\SQLEXPRESS; Initial Catalog = Accounts; Integrated Security = True; TrustServerCertificate = True;";
        static SqlConnection sqlConnection;

        public DBDataService()
        {
            sqlConnection = new SqlConnection(connectionString);
        }

        public List<UserAccounts> GetAdminAcc()
        {
            string selectStatement = "SELECT * FROM tbl_AdminAccounts";

            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);

            sqlConnection.Open();

            SqlDataReader reader = selectCommand.ExecuteReader();

            var adminAccounts = new List<UserAccounts>();

            while (reader.Read())
            {
                UserAccounts adminAccount = new UserAccounts();
                adminAccount.FirstName = reader["FirstName"].ToString();
                adminAccount.LastName = reader["LastName"].ToString();
                adminAccount.Age = Convert.ToInt16(reader["Age"].ToString());
                adminAccount.EmailAddress = reader["EmailAddress"].ToString();
                adminAccount.MinistryName = reader["MinistryName"].ToString();
                adminAccount.Position = reader["Position"].ToString();
                adminAccount.UserName = reader["Username"].ToString();
                adminAccount.Password = reader["Password"].ToString();

                adminAccounts.Add(adminAccount);
            }

            sqlConnection.Close();
            return adminAccounts;

        }


        public bool AddDevotionSchedule(string date, string songLeader, string presider, string speaker)
        {
            throw new NotImplementedException();
        }

        public bool AddDiscipleshipSchedule(string date, string speaker, string description, string note)
        {
            throw new NotImplementedException();
        }

        public bool AddLesson(string date, string lesson, string materials)
        {
            throw new NotImplementedException();
        }

        public bool AddPraiseAndWorshipSchedule(string date, string songLeader, string instrumentalist)
        {
            throw new NotImplementedException();
        }

        public bool AddPrayerItem(string date, string prayerItem)
        {
            throw new NotImplementedException();
        }

        public bool AddPrayerSchedule(string date, string songLeader, string presider, string speaker)
        {
            throw new NotImplementedException();
        }

        public bool AddSundayWorshipSchedule(string date, string presider, string speaker, string flowers, string ushers)
        {
            throw new NotImplementedException();
        }

        public bool AddTeachers(string name, string designation)
        {
            throw new NotImplementedException();
        }

        public void AdminAccounts(string firstName, string lastName, int age, string emailAddress, string ministryName, string position, string userName, string passWord)
        {
            throw new NotImplementedException();
        }

        public string GetAdminMinistry(string username, string password)
        {
            throw new NotImplementedException();
        }

        public string GetUserRole(string username, string password)
        {
            throw new NotImplementedException();
        }

        public void RegularUserAccounts(string firstName, string lastName, int age, string emailAddress, string userName, string passWord)
        {
            throw new NotImplementedException();
        }

        public bool RemoveDevotionSchedule(string date)
        {
            throw new NotImplementedException();
        }

        public bool RemoveDiscipleshipSchedule(string date)
        {
            throw new NotImplementedException();
        }

        public bool RemoveLesson(string date)
        {
            throw new NotImplementedException();
        }

        public bool RemovePraiseAndWorshipSchedule(string date)
        {
            throw new NotImplementedException();
        }

        public bool RemovePrayerSchedule(string date)
        {
            throw new NotImplementedException();
        }

        public bool RemoveSundayWorshipSched(string date)
        {
            throw new NotImplementedException();
        }

        public bool RemoveTeacher(string name)
        {
            throw new NotImplementedException();
        }

        public List<Devotion> ViewDevotionSchedule()
        {
            throw new NotImplementedException();
        }

        public List<DiscipleshipMinistry> ViewDiscipleshipSchedule()
        {
            throw new NotImplementedException();
        }

        public List<Lesson> ViewLessons()
        {
            throw new NotImplementedException();
        }

        public List<PraiseAndWorship> ViewPraiseAndWorshipSchedule()
        {
            throw new NotImplementedException();
        }

        public List<PrayerMinistry> ViewPrayerMeetingSchedule()
        {
            throw new NotImplementedException();
        }

        public List<SundayWorshipService> ViewSundayWorshipSched()
        {
            throw new NotImplementedException();
        }

        public List<TeachersList> ViewTeachersList()
        {
            throw new NotImplementedException();
        }
    }
}
