using CMSAccounts;
using CMSSchedules;
using Microsoft.Data.Sql;
using Microsoft.Data.SqlClient;
using System.Data.Common;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CMSDataLogic
{
    public class DBDataService : IMinistriesDataService
    {
        static string accountsConnectionString = "Data Source = DESKTOP-1PU2QVR\\SQLEXPRESS; Initial Catalog = Accounts; Integrated Security = True; TrustServerCertificate = True;";
        static string scheduleConnctionString = "Data Source = DESKTOP-1PU2QVR\\SQLEXPRESS; Initial Catalog = Schedules; Integrated Security = True; TrustServerCertificate = True;";
        static SqlConnection sqlConnection1, sqlConnection2;

        public DBDataService()
        {
            sqlConnection1 = new SqlConnection(accountsConnectionString);
            sqlConnection2 = new SqlConnection(scheduleConnctionString);

            GetAdminAcc();
        }
        public List<UserAccounts> GetAdminAcc()
        {
            string selectStatement = "SELECT * FROM tbl_AdminAccounts";

            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection1);

            sqlConnection1.Open();

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

            sqlConnection1.Close();
            return adminAccounts;

        }
        public string GetAdminMinistry(string username, string password)
        {
            sqlConnection1.Open();
            var getAdminStatement = $"SELECT MinistryName FROM tbl_AdminAccounts WHERE Username = @username AND Password = @password";

            SqlCommand getAdminCommand = new SqlCommand(getAdminStatement, sqlConnection1);
            getAdminCommand.Parameters.AddWithValue("@Username", username);
            getAdminCommand.Parameters.AddWithValue("@Password", password);

            SqlDataReader reader = getAdminCommand.ExecuteReader();
            string ministryName = "No match account";

            if (reader.Read())
            {
                ministryName = reader["MinistryName"].ToString();
            }
            reader.Close();
            sqlConnection1.Close();
            return ministryName;
        }
        public string GetUserRole(string username, string password)
        {
            sqlConnection1.Open();
            var getAdminRole = $"SELECT COUNT(*) FROM tbl_AdminAccounts WHERE Username = @Username AND Password = @Password";

            SqlCommand getAdminRoleCommand = new SqlCommand(getAdminRole, sqlConnection1);
            getAdminRoleCommand.Parameters.AddWithValue("@Username", username);
            getAdminRoleCommand.Parameters.AddWithValue("@Password", password);

            int adminCount = (int)getAdminRoleCommand.ExecuteScalar();
            if(adminCount > 0)
            {
                sqlConnection1.Close();
                return "Admin";
            }

            return "User";

        }
        public bool AddDevotionSchedule(string date, string songLeader, string presider, string speaker)
        {
            try {
                var insertStatement = "INSERT INTO tbl_DevotionSchedules VALUES(@Date, @SongLeader, @Presider, @Speaker)";

                SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection2);

                insertCommand.Parameters.AddWithValue("@Date", date);
                insertCommand.Parameters.AddWithValue("@SongLeader", songLeader);
                insertCommand.Parameters.AddWithValue("@Presider", presider);
                insertCommand.Parameters.AddWithValue("@Speaker", speaker);

                sqlConnection2.Open();
                insertCommand.ExecuteNonQuery();
                sqlConnection2.Close();

                return true;
            }
            catch{
                return false;
            }           
        }
        public bool AddDiscipleshipSchedule(string date, string speaker, string description, string note)
        {
            try
            {
                var insertStatement = "INSERT INTO tbl_DiscipleshipSchedules VALUES(@Date, @Speaker, @Description, @Note)";

                SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection2);

                insertCommand.Parameters.AddWithValue("@Date", date);
                insertCommand.Parameters.AddWithValue("@Speaker", speaker);
                insertCommand.Parameters.AddWithValue("@Description", description);
                insertCommand.Parameters.AddWithValue("@Note", note);

                sqlConnection2.Open();
                insertCommand.ExecuteNonQuery();
                sqlConnection2.Close();

                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool AddLesson(string date, string lesson, string materials)
        {
            try
            {
                var insertStatement = "INSERT INTO tbl_LessonsList VALUES(@Date, @Lesson, @Materials)";

                SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection2);

                insertCommand.Parameters.AddWithValue("@Date", date);
                insertCommand.Parameters.AddWithValue("@Lesson", lesson);
                insertCommand.Parameters.AddWithValue("@Materials", materials);

                sqlConnection2.Open();
                insertCommand.ExecuteNonQuery();
                sqlConnection2.Close();

                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool AddPraiseAndWorshipSchedule(string date, string songLeader, string instrumentalist)
        {
            try
            {
                var insertStatement = "INSERT INTO tbl_PraiseAndWorshipSchedules VALUES(@Date, @SongLeader, @Instrumentalist)";

                SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection2);

                insertCommand.Parameters.AddWithValue("@Date", date);
                insertCommand.Parameters.AddWithValue("@SongLeader", songLeader);
                insertCommand.Parameters.AddWithValue("@Instrumentalist", instrumentalist);

                sqlConnection2.Open();
                insertCommand.ExecuteNonQuery();
                sqlConnection2.Close();

                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool AddPrayerSchedule(string date, string songLeader, string presider, string speaker, string prayerItem)
        {
            try
            {
                var insertStatement = "INSERT INTO tbl_PrayerSchedules VALUES(@Date, @SongLeader, @Presider, @Speaker, @PrayerItem)";

                SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection2);

                insertCommand.Parameters.AddWithValue("@Date", date);
                insertCommand.Parameters.AddWithValue("@SongLeader", songLeader);
                insertCommand.Parameters.AddWithValue("@Presider", presider);
                insertCommand.Parameters.AddWithValue("@Speaker", speaker);
                insertCommand.Parameters.AddWithValue("@PrayerItem", prayerItem);

                sqlConnection2.Open();
                insertCommand.ExecuteNonQuery();
                sqlConnection2.Close();

                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool AddSundayWorshipSchedule(string date, string presider, string speaker, string flowers, string ushers)
        {
            try
            {
                var insertStatement = "INSERT INTO tbl_SundayWorshipSchedules VALUES(@Date, @Presider, @Speaker, @Flowers, @Ushers)";

                SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection2);

                insertCommand.Parameters.AddWithValue("@Date", date);
                insertCommand.Parameters.AddWithValue("@Presider", presider);
                insertCommand.Parameters.AddWithValue("@Speaker", speaker);
                insertCommand.Parameters.AddWithValue("@Flowers", flowers);
                insertCommand.Parameters.AddWithValue("@Ushers", ushers);

                sqlConnection2.Open();
                insertCommand.ExecuteNonQuery();
                sqlConnection2.Close();

                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool AddTeachers(string name, string designation)
        {
            try
            {
                var insertStatement = "INSERT INTO tbl_TeachersList VALUES(@Name, @Assignment)";

                SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection2);

                insertCommand.Parameters.AddWithValue("@Name", name);
                insertCommand.Parameters.AddWithValue("@Assignment", designation);

                sqlConnection2.Open();
                insertCommand.ExecuteNonQuery();
                sqlConnection2.Close();

                return true;
            }
            catch
            {
                return false;
            }
        }
        public void AdminAccounts(string firstName, string lastName, int age, string emailAddress, string ministryName, string position, string userName, string passWord)
        {
            var insertStatement = "INSERT INTO tbl_AdminAccounts VALUES(@FirstName, @LastName, @Age, @EmailAddress, @MinistryName, @Position, @Username, @Password)";

            SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection1);

            insertCommand.Parameters.AddWithValue("@FirstName", firstName);
            insertCommand.Parameters.AddWithValue("@LastName", lastName);
            insertCommand.Parameters.AddWithValue("@Age", age);
            insertCommand.Parameters.AddWithValue("@EmailAddress", emailAddress);
            insertCommand.Parameters.AddWithValue("MinistryName", ministryName);
            insertCommand.Parameters.AddWithValue("@Position", position);
            insertCommand.Parameters.AddWithValue("@Username", userName);
            insertCommand.Parameters.AddWithValue("@Password", passWord);

            sqlConnection1.Open();
            insertCommand.ExecuteNonQuery();
            sqlConnection1.Close();
        }
        public void RegularUserAccounts(string firstName, string lastName, int age, string emailAddress, string userName, string passWord)
        {
            throw new NotImplementedException();
        }
        public bool RemoveDevotionSchedule(string date)
        {
            try
            {
                sqlConnection2.Open();
                var deleteStatement = $"DELETE FROM tbl_DevotionSchedules WHERE Date = @Date";

                SqlCommand updateCommand = new SqlCommand(deleteStatement, sqlConnection2);
                updateCommand.Parameters.AddWithValue("@Date", date);

                updateCommand.ExecuteNonQuery();

                sqlConnection2.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool RemoveDiscipleshipSchedule(string date)
        {
            try
            {
                sqlConnection2.Open();
                var deleteStatement = $"DELETE FROM tbl_DiscipleshipSchedules WHERE Date = @Date";

                SqlCommand updateCommand = new SqlCommand(deleteStatement, sqlConnection2);
                updateCommand.Parameters.AddWithValue("@Date", date);

                updateCommand.ExecuteNonQuery();

                sqlConnection2.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool RemoveLesson(string date)
        {
            try
            {
                sqlConnection2.Open();
                var deleteStatement = $"DELETE FROM tbl_LessonsList WHERE Date = @Date";

                SqlCommand updateCommand = new SqlCommand(deleteStatement, sqlConnection2);
                updateCommand.Parameters.AddWithValue("@Date", date);

                updateCommand.ExecuteNonQuery();

                sqlConnection2.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool RemovePraiseAndWorshipSchedule(string date)
        {
            try
            {
                sqlConnection2.Open();
                var deleteStatement = $"DELETE FROM tbl_PraiseAndWorshipSchedules WHERE Date = @Date";

                SqlCommand updateCommand = new SqlCommand(deleteStatement, sqlConnection2);
                updateCommand.Parameters.AddWithValue("@Date", date);

                updateCommand.ExecuteNonQuery();

                sqlConnection2.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool RemovePrayerSchedule(string date)
        {
            try
            {
                sqlConnection2.Open();
                var deleteStatement = $"DELETE FROM tbl_PrayerSchedules WHERE Date = @Date";

                SqlCommand updateCommand = new SqlCommand(deleteStatement, sqlConnection2);
                updateCommand.Parameters.AddWithValue("@Date", date);

                updateCommand.ExecuteNonQuery();

                sqlConnection2.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool RemoveSundayWorshipSched(string date)
        {
            try
            {
                sqlConnection2.Open();
                var deleteStatement = $"DELETE FROM tbl_SundayWorshipSchedules WHERE Date = @Date";

                SqlCommand updateCommand = new SqlCommand(deleteStatement, sqlConnection2);
                updateCommand.Parameters.AddWithValue("@Date", date);

                updateCommand.ExecuteNonQuery();

                sqlConnection2.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool RemoveTeacher(string name)
        {
            try
            {
                sqlConnection2.Open();
                var deleteStatement = $"DELETE FROM tbl_TeachersList WHERE Name = @Name";

                SqlCommand updateCommand = new SqlCommand(deleteStatement, sqlConnection2);
                updateCommand.Parameters.AddWithValue("@Name", name);

                updateCommand.ExecuteNonQuery();

                sqlConnection2.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public List<Devotion> ViewDevotionSchedule()
        {
            string selectStatement = "SELECT * FROM tbl_DevotionSchedules";

            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection2);

            sqlConnection2.Open();

            SqlDataReader reader = selectCommand.ExecuteReader();

            var devotionSchedules = new List<Devotion>();

            while (reader.Read())
            {
                Devotion devotion = new Devotion();
                devotion.Date = reader["Date"].ToString();
                devotion.SongLeader = reader["SongLeader"].ToString();
                devotion.Presider = reader["Presider"].ToString();
                devotion.Speaker = reader["Speaker"].ToString();
                
                devotionSchedules.Add(devotion);
            }

            sqlConnection2.Close();
            return devotionSchedules;
        }

        public List<DiscipleshipMinistry> ViewDiscipleshipSchedule()
        {
            string selectStatement = "SELECT * FROM tbl_DiscipleshipSchedules";

            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection2);

            sqlConnection2.Open();

            SqlDataReader reader = selectCommand.ExecuteReader();

            var discipleshipSchedules = new List<DiscipleshipMinistry>();

            while (reader.Read())
            {
                DiscipleshipMinistry discipleship = new DiscipleshipMinistry();
                discipleship.Date = reader["Date"].ToString();
                discipleship.Speaker = reader["Speaker"].ToString();
                discipleship.Description = reader["Description"].ToString();
                discipleship.Note = reader["Note"].ToString();

                discipleshipSchedules.Add(discipleship);
            }

            sqlConnection2.Close();
            return discipleshipSchedules;
        }

        public List<Lesson> ViewLessons()
        {
            string selectStatement = "SELECT * FROM tbl_LessonsList";

            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection2);

            sqlConnection2.Open();

            SqlDataReader reader = selectCommand.ExecuteReader();

            var lessonList = new List<Lesson>();

            while (reader.Read())
            {
                Lesson lessons = new Lesson();
                lessons.Date = reader["Date"].ToString();
                lessons.Lessson = reader["Lesson"].ToString();
                lessons.Materials = reader["Materials"].ToString();

                lessonList.Add(lessons);
            }

            sqlConnection2.Close();
            return lessonList;
        }

        public List<PraiseAndWorship> ViewPraiseAndWorshipSchedule()
        {
            string selectStatement = "SELECT * FROM tbl_PraiseAndWorshipSchedules";

            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection2);

            sqlConnection2.Open();

            SqlDataReader reader = selectCommand.ExecuteReader();

            var praiseAndWorshipSchedule = new List<PraiseAndWorship>();

            while (reader.Read())
            {
                PraiseAndWorship praiseAndWorship = new PraiseAndWorship();
                praiseAndWorship.Date = reader["Date"].ToString();
                praiseAndWorship.SongLeader = reader["SongLeader"].ToString();
                praiseAndWorship.Instrumentalist = reader["Instrumentalist"].ToString();

                praiseAndWorshipSchedule.Add(praiseAndWorship);
            }

            sqlConnection2.Close();
            return praiseAndWorshipSchedule;
        }

        public List<PrayerMinistry> ViewPrayerMeetingSchedule()
        {
            string selectStatement = "SELECT * FROM tbl_PrayerSchedules";

            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection2);

            sqlConnection2.Open();

            SqlDataReader reader = selectCommand.ExecuteReader();

            var prayerSchedules = new List<PrayerMinistry>();

            while (reader.Read())
            {
                PrayerMinistry prayer = new PrayerMinistry();
                prayer.Date = reader["Date"].ToString();
                prayer.SongLeader = reader["SongLeader"].ToString();
                prayer.Presider = reader["Presider"].ToString();
                prayer.Speaker = reader["Speaker"].ToString();
                prayer.PrayerItem = reader["PrayerItem"].ToString();

                prayerSchedules.Add(prayer);
            }

            sqlConnection2.Close();
            return prayerSchedules;
        }

        public List<SundayWorshipService> ViewSundayWorshipSched()
        {
            string selectStatement = "SELECT * FROM tbl_SundayWorshipSchedules";

            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection2);

            sqlConnection2.Open();

            SqlDataReader reader = selectCommand.ExecuteReader();

            var sundayWorshipSchedule = new List<SundayWorshipService>();

            while (reader.Read())
            {
                SundayWorshipService sundayWorship = new SundayWorshipService();
                sundayWorship.Date = reader["Date"].ToString();
                sundayWorship.Presider = reader["Presider"].ToString();
                sundayWorship.Speaker = reader["Speaker"].ToString();
                sundayWorship.Flowers = reader["Flowers"].ToString();
                sundayWorship.Ushers = reader["Ushers"].ToString();

                sundayWorshipSchedule.Add(sundayWorship);
            }

            sqlConnection2.Close();
            return sundayWorshipSchedule;
        }

        public List<TeachersList> ViewTeachersList()
        {
            string selectStatement = "SELECT * FROM tbl_TeachersList";

            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection2);

            sqlConnection2.Open();

            SqlDataReader reader = selectCommand.ExecuteReader();

            var teachersLists = new List<TeachersList>();

            while (reader.Read())
            {
                TeachersList teachers = new TeachersList();
                teachers.TeachersName = reader["Name"].ToString();
                teachers.Assignment = reader["Assignment"].ToString();

                teachersLists.Add(teachers);
            }

            sqlConnection2.Close();
            return teachersLists;
        }
    }
}
