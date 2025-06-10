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
        static string scheduleConnectionString = "Data Source = DESKTOP-1PU2QVR\\SQLEXPRESS; Initial Catalog = Schedules; Integrated Security = True; TrustServerCertificate = True;";
        static SqlConnection sqlConnection1, sqlConnection2;

        public DBDataService()
        {
            sqlConnection1 = new SqlConnection(accountsConnectionString);
            sqlConnection2 = new SqlConnection(scheduleConnectionString);
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
        public string GetAdminMinistry(UserAccounts loginAccounts)
        {
            sqlConnection1.Open();
            var getAdminStatement = $"SELECT MinistryName FROM tbl_AdminAccounts WHERE Username = @username COLLATE Latin1_General_CS_AS AND Password = @password COLLATE Latin1_General_CS_AS";

            SqlCommand getAdminCommand = new SqlCommand(getAdminStatement, sqlConnection1);
            getAdminCommand.Parameters.AddWithValue("@Username", loginAccounts.UserName);
            getAdminCommand.Parameters.AddWithValue("@Password", loginAccounts.Password);

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
        public string GetUserRole(UserAccounts loginAccounts)
        {
            sqlConnection1.Open();
            var getAdminRole = $"SELECT COUNT(*) FROM tbl_AdminAccounts WHERE Username = @Username COLLATE Latin1_General_CS_AS AND Password = @Password COLLATE Latin1_General_CS_AS";

            SqlCommand getAdminRoleCommand = new SqlCommand(getAdminRole, sqlConnection1);
            getAdminRoleCommand.Parameters.AddWithValue("@Username", loginAccounts.UserName);
            getAdminRoleCommand.Parameters.AddWithValue("@Password", loginAccounts.Password);

            int adminCount = (int)getAdminRoleCommand.ExecuteScalar();
            if(adminCount > 0)
            {
                sqlConnection1.Close();
                return "Admin";
            }

            sqlConnection1.Close();
            return "User";

        }
        public bool AddDevotionSchedule(Devotion devotionSched)
        {
            try {
                var insertStatement = "INSERT INTO tbl_DevotionSchedules VALUES(@Date, @SongLeader, @Presider, @Speaker)";

                SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection2);

                insertCommand.Parameters.AddWithValue("@Date", devotionSched.Date);
                insertCommand.Parameters.AddWithValue("@SongLeader", devotionSched.SongLeader);
                insertCommand.Parameters.AddWithValue("@Presider", devotionSched.Presider);
                insertCommand.Parameters.AddWithValue("@Speaker", devotionSched.Speaker);

                sqlConnection2.Open();
                insertCommand.ExecuteNonQuery();
                sqlConnection2.Close();

                return true;
            }
            catch{
                return false;
            }           
        }
        public bool AddDiscipleshipSchedule(DiscipleshipMinistry discipleshipSched)
        {
            try
            {
                var insertStatement = "INSERT INTO tbl_DiscipleshipSchedules VALUES(@Date, @Speaker, @Description, @Note)";

                SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection2);

                insertCommand.Parameters.AddWithValue("@Date", discipleshipSched.Date);
                insertCommand.Parameters.AddWithValue("@Speaker", discipleshipSched.Speaker);
                insertCommand.Parameters.AddWithValue("@Description", discipleshipSched.Description);
                insertCommand.Parameters.AddWithValue("@Note", discipleshipSched.Note);

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
        public bool AddLesson(Lesson lesssonsLists)
        {
            try
            {
                var insertStatement = "INSERT INTO tbl_LessonsList VALUES(@Date, @Lesson, @Materials)";

                SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection2);

                insertCommand.Parameters.AddWithValue("@Date", lesssonsLists.Date);
                insertCommand.Parameters.AddWithValue("@Lesson", lesssonsLists.Lessson);
                insertCommand.Parameters.AddWithValue("@Materials", lesssonsLists.Materials);

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
        public bool AddPraiseAndWorshipSchedule(PraiseAndWorship praiseAndWorshipSched)
        {
            try
            {
                var insertStatement = "INSERT INTO tbl_PraiseAndWorshipSchedules VALUES(@Date, @SongLeader, @Instrumentalist)";

                SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection2);

                insertCommand.Parameters.AddWithValue("@Date", praiseAndWorshipSched.Date);
                insertCommand.Parameters.AddWithValue("@SongLeader", praiseAndWorshipSched.SongLeader);
                insertCommand.Parameters.AddWithValue("@Instrumentalist", praiseAndWorshipSched.Instrumentalist);

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
        public bool AddPrayerSchedule(PrayerMinistry prayerSched)
        {
            try
            {
                var insertStatement = "INSERT INTO tbl_PrayerSchedules VALUES(@Date, @SongLeader, @Presider, @Speaker, @PrayerItem)";

                SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection2);

                insertCommand.Parameters.AddWithValue("@Date", prayerSched.Date);
                insertCommand.Parameters.AddWithValue("@SongLeader", prayerSched.SongLeader);
                insertCommand.Parameters.AddWithValue("@Presider", prayerSched.Presider);
                insertCommand.Parameters.AddWithValue("@Speaker", prayerSched.Speaker);
                insertCommand.Parameters.AddWithValue("@PrayerItem", prayerSched.PrayerItem);

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
        public bool AddSundayWorshipSchedule(SundayWorshipService sundayWorshipSched)
        {
            try
            {
                var insertStatement = "INSERT INTO tbl_SundayWorshipSchedules VALUES(@Date, @Presider, @Speaker, @Flowers, @Ushers)";

                SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection2);

                insertCommand.Parameters.AddWithValue("@Date", sundayWorshipSched.Date);
                insertCommand.Parameters.AddWithValue("@Presider", sundayWorshipSched.Presider);
                insertCommand.Parameters.AddWithValue("@Speaker", sundayWorshipSched.Speaker);
                insertCommand.Parameters.AddWithValue("@Flowers", sundayWorshipSched.Flowers);
                insertCommand.Parameters.AddWithValue("@Ushers", sundayWorshipSched.Ushers);

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
        public bool AddTeachers(TeachersList teachersList)
        {
            try
            {
                var insertStatement = "INSERT INTO tbl_TeachersList VALUES(@Name, @Assignment)";

                SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection2);

                insertCommand.Parameters.AddWithValue("@Name", teachersList.TeachersName);
                insertCommand.Parameters.AddWithValue("@Assignment", teachersList.Assignment);

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
        public bool AdminAccounts(UserAccounts adminAccounts)
        {
            try
            {
                var insertStatement = "INSERT INTO tbl_AdminAccounts VALUES(@FirstName, @LastName, @Age, @EmailAddress, @MinistryName, @Position, @Username, @Password)";

                SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection1);

                insertCommand.Parameters.AddWithValue("@FirstName", adminAccounts.FirstName);
                insertCommand.Parameters.AddWithValue("@LastName", adminAccounts.LastName);
                insertCommand.Parameters.AddWithValue("@Age", adminAccounts.Age);
                insertCommand.Parameters.AddWithValue("@EmailAddress", adminAccounts.EmailAddress);
                insertCommand.Parameters.AddWithValue("MinistryName", adminAccounts.MinistryName);
                insertCommand.Parameters.AddWithValue("@Position", adminAccounts.Position);
                insertCommand.Parameters.AddWithValue("@Username", adminAccounts.UserName);
                insertCommand.Parameters.AddWithValue("@Password", adminAccounts.Password);

                sqlConnection1.Open();
                insertCommand.ExecuteNonQuery();
                sqlConnection1.Close();
                return true;
            }
            catch
            {
                return false;
            }
            
        }
        public bool RegularUserAccounts(UserAccounts userAccounts)
        {
            throw new NotImplementedException();
        }
        public bool RemoveDevotionSchedule(Devotion toDelete)
        {
            try
            {
                sqlConnection2.Open();
                var deleteStatement = $"DELETE FROM tbl_DevotionSchedules WHERE Date = @Date";

                SqlCommand updateCommand = new SqlCommand(deleteStatement, sqlConnection2);
                updateCommand.Parameters.AddWithValue("@Date", toDelete.Date);

                updateCommand.ExecuteNonQuery();

                sqlConnection2.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool RemoveDiscipleshipSchedule(DiscipleshipMinistry toDelete)
        {
            try
            {
                sqlConnection2.Open();
                var deleteStatement = $"DELETE FROM tbl_DiscipleshipSchedules WHERE Date = @Date";

                SqlCommand updateCommand = new SqlCommand(deleteStatement, sqlConnection2);
                updateCommand.Parameters.AddWithValue("@Date", toDelete.Date);

                updateCommand.ExecuteNonQuery();

                sqlConnection2.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool RemoveLesson(Lesson toDelete)
        {
            try
            {
                sqlConnection2.Open();
                var deleteStatement = $"DELETE FROM tbl_LessonsList WHERE Date = @Date";

                SqlCommand updateCommand = new SqlCommand(deleteStatement, sqlConnection2);
                updateCommand.Parameters.AddWithValue("@Date", toDelete.Date);
                updateCommand.ExecuteNonQuery();
                
                sqlConnection2.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool RemovePraiseAndWorshipSchedule(PraiseAndWorship toDelete)
        {
            try
            {
                sqlConnection2.Open();
                var deleteStatement = $"DELETE FROM tbl_PraiseAndWorshipSchedules WHERE Date = @Date";

                SqlCommand updateCommand = new SqlCommand(deleteStatement, sqlConnection2);
                updateCommand.Parameters.AddWithValue("@Date", toDelete.Date);

                updateCommand.ExecuteNonQuery();

                sqlConnection2.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool RemovePrayerSchedule(PrayerMinistry toDelete)
        {
            try
            {
                sqlConnection2.Open();
                var deleteStatement = $"DELETE FROM tbl_PrayerSchedules WHERE Date = @Date";

                SqlCommand updateCommand = new SqlCommand(deleteStatement, sqlConnection2);
                updateCommand.Parameters.AddWithValue("@Date", toDelete.Date);

                updateCommand.ExecuteNonQuery();

                sqlConnection2.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool RemoveSundayWorshipSched(SundayWorshipService toDelete)
        {
            try
            {
                sqlConnection2.Open();
                var deleteStatement = $"DELETE FROM tbl_SundayWorshipSchedules WHERE Date = @Date";

                SqlCommand updateCommand = new SqlCommand(deleteStatement, sqlConnection2);
                updateCommand.Parameters.AddWithValue("@Date", toDelete.Date);

                updateCommand.ExecuteNonQuery();

                sqlConnection2.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool RemoveTeacher(TeachersList toDelete)
        {
            try
            {
                sqlConnection2.Open();
                var deleteStatement = $"DELETE FROM tbl_TeachersList WHERE Name = @Name";

                SqlCommand updateCommand = new SqlCommand(deleteStatement, sqlConnection2);
                updateCommand.Parameters.AddWithValue("@Name", toDelete.TeachersName);

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
                devotion.Date = Convert.ToDateTime(reader["Date"]);
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
                discipleship.Date = Convert.ToDateTime(reader["Date"]);
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
                lessons.Date = Convert.ToDateTime(reader["Date"]);
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
                praiseAndWorship.Date = Convert.ToDateTime(reader["Date"]);
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
                prayer.Date = Convert.ToDateTime(reader["Date"]);
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
                sundayWorship.Date = Convert.ToDateTime(reader["Date"]);
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

        public bool UpdateDiscipleshipSchedule(DiscipleshipMinistry update)
        {
            try
            {
                sqlConnection2.Open();

                string updateQuery = "UPDATE tbl_DiscipleshipSchedules SET Speaker = @speaker, Description = @description, Note = @note WHERE DATE = @date";

                SqlCommand updateCommand = new SqlCommand(updateQuery, sqlConnection2);
                updateCommand.Parameters.AddWithValue("@Date", update.Date);
                updateCommand.Parameters.AddWithValue("@Speaker", update.Speaker);
                updateCommand.Parameters.AddWithValue("@Description", update.Description);
                updateCommand.Parameters.AddWithValue("@Note", update.Note);
                updateCommand.ExecuteNonQuery();

                sqlConnection2.Close();
                return true;

            }
            catch
            {
                return false;
            }
        }
        public bool UpdatePrayerSchedule(PrayerMinistry update)
        {
            try
            {
                sqlConnection2.Open();

                string updateQuery = "UPDATE tbl_PrayerSchedules SET SongLeader = @songLeader, Presider = @presider, Speaker = @speaker, PrayerItem = @prayerItem WHERE DATE = @date";

                SqlCommand updateCommand = new SqlCommand(updateQuery, sqlConnection2);
                updateCommand.Parameters.AddWithValue("@Date", update.Date);
                updateCommand.Parameters.AddWithValue("@SongLeader", update.SongLeader);
                updateCommand.Parameters.AddWithValue("@Presider", update.Presider);
                updateCommand.Parameters.AddWithValue("@Speaker", update.Speaker);
                updateCommand.Parameters.AddWithValue("@PrayerItem", update.PrayerItem);
                updateCommand.ExecuteNonQuery();

                sqlConnection2.Close();
                return true;
                
            }
            catch
            {
                return false;
            }
        }
        public bool UpdatePraiseAndWorshipSchedule(PraiseAndWorship update)
        {
            try
            {
                sqlConnection2.Open();

                string updateQuery = "UPDATE tbl_PraiseAndWorshipSchedules SET SongLeader = @songLeader WHERE DATE = @date";

                SqlCommand updateCommand = new SqlCommand(updateQuery, sqlConnection2);
                updateCommand.Parameters.AddWithValue("@Date", update.Date);
                updateCommand.Parameters.AddWithValue("@SongLeader", update.SongLeader);
                updateCommand.ExecuteNonQuery();

                sqlConnection2.Close();
                return true;

            }
            catch
            {
                return false;
            }
        }
        public bool UpdateSundayWorshipSchedule(SundayWorshipService update)
        {
            try
            {
                sqlConnection2.Open();

                string updateQuery = "UPDATE tbl_SundayWorshipSchedules SET Presider = @presider, Speaker = @speaker, Flowers = @flowers, Ushers = @ushers WHERE DATE = @date";

                SqlCommand updateCommand = new SqlCommand(updateQuery, sqlConnection2);
                updateCommand.Parameters.AddWithValue("@Date", update.Date);
                updateCommand.Parameters.AddWithValue("@Presider", update.Presider);
                updateCommand.Parameters.AddWithValue("@Speaker", update.Speaker);
                updateCommand.Parameters.AddWithValue("@Flowers", update.Flowers);
                updateCommand.Parameters.AddWithValue("@Ushers", update.Ushers);
                updateCommand.ExecuteNonQuery();

                sqlConnection2.Close();
                return true;

            }
            catch
            {
                return false;
            }
        }
        public bool UpdateDevotionSchedule(Devotion update)
        {
            try
            {
                sqlConnection2.Open();

                string updateQuery = "UPDATE tbl_DevotionSchedules SET SongLeader = @songLeader, Presider = @presider, Speaker = @speaker WHERE DATE = @date";

                SqlCommand updateCommand = new SqlCommand(updateQuery, sqlConnection2);
                updateCommand.Parameters.AddWithValue("@Date", update.Date);
                updateCommand.Parameters.AddWithValue("@Presider", update.Presider);
                updateCommand.Parameters.AddWithValue("@SongLeader", update.SongLeader);
                updateCommand.Parameters.AddWithValue("@Speaker", update.Speaker);
                updateCommand.ExecuteNonQuery();

                sqlConnection2.Close();
                return true;

            }
            catch
            {
                return false;
            }
        }
        public bool UpdateTeachers(TeachersList update)
        {
            try
            {
                sqlConnection2.Open();

                string updateQuery = "UPDATE tbl_TeachersList SET Assignment = @Assignment WHERE Name = @name";

                SqlCommand updateCommand = new SqlCommand(updateQuery, sqlConnection2);
                updateCommand.Parameters.AddWithValue("@Name", update.TeachersName);
                updateCommand.Parameters.AddWithValue("@Assignment", update.Assignment);
                updateCommand.ExecuteNonQuery();

                sqlConnection2.Close();
                return true;

            }
            catch
            {
                return false;
            }
        }
        public bool UpdateLesson(Lesson update)
        {
            try
            {
                sqlConnection2.Open();

                string updateQuery = "UPDATE tbl_LessonsList SET Lesson = @lesson, Materials = @materials WHERE DATE = @date";

                SqlCommand updateCommand = new SqlCommand(updateQuery, sqlConnection2);
                updateCommand.Parameters.AddWithValue("@Date", update.Date);
                updateCommand.Parameters.AddWithValue("@Lesson", update.Lessson);
                updateCommand.Parameters.AddWithValue("@Materials", update.Materials);
                updateCommand.ExecuteNonQuery();

                sqlConnection2.Close();
                return true;

            }
            catch
            {
                return false;
            }
        }
    }
}
