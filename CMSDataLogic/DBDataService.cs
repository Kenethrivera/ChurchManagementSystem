using CMSAccounts;
using CMSSchedules;
using Microsoft.Data.Sql;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;
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
        public List<UserAccounts> GetAllAccounts()
        {
            string selectStatement = "SELECT * FROM tbl_UserAccounts";

            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection1);

            sqlConnection1.Open();

            SqlDataReader reader = selectCommand.ExecuteReader();

            var userAccounts = new List<UserAccounts>();

            while (reader.Read())
            {
                UserAccounts userAccount = new UserAccounts();
                userAccount.FirstName = reader["FirstName"].ToString();
                userAccount.LastName = reader["LastName"].ToString();
                userAccount.Age = Convert.ToInt16(reader["Age"].ToString());
                userAccount.EmailAddress = reader["EmailAddress"].ToString();
                userAccount.MinistryName = reader["MinistryName"].ToString();
                userAccount.Position = reader["Position"].ToString();
                userAccount.UserName = reader["Username"].ToString();
                userAccount.Password = reader["Password"].ToString();
                userAccounts.Add(userAccount);
            }

            sqlConnection1.Close();
            return userAccounts;

        }
        public UserAccounts GetUserRole(UserAccounts loginAccounts, bool isAdmin)
        {
            sqlConnection1.Open();

            string query;

            if (isAdmin)
            {
                query = "SELECT * FROM tbl_AdminAccounts " +
                        "WHERE Username = @Username COLLATE Latin1_General_CS_AS " +
                        "AND Password = @Password COLLATE Latin1_General_CS_AS";
            }
            else
            {
                query = "SELECT * FROM tbl_UserAccounts " +
                        "WHERE Username = @Username COLLATE Latin1_General_CS_AS " +
                        "AND Password = @Password COLLATE Latin1_General_CS_AS";
            }

            SqlCommand cmd = new SqlCommand(query, sqlConnection1);
            cmd.Parameters.AddWithValue("@Username", loginAccounts.UserName.Trim());
            cmd.Parameters.AddWithValue("@Password", loginAccounts.Password.Trim());

            SqlDataReader reader = cmd.ExecuteReader();
            UserAccounts foundAccount = null;

            if (reader.Read())
            {
                foundAccount = new UserAccounts
                {
                    FirstName = reader["FirstName"].ToString(),
                    LastName = reader["LastName"].ToString(),
                    Age = Convert.ToInt32(reader["Age"].ToString()),
                    EmailAddress = reader["EmailAddress"].ToString(),
                    MinistryName = reader["MinistryName"].ToString(),
                    Position = reader["Position"].ToString(),
                    UserName = reader["Username"].ToString(),
                    Password = reader["Password"].ToString(),                                         
                };
            }

            reader.Close();
            sqlConnection1.Close();

            return foundAccount;
        }
        // add function
        public bool AddDevotionSchedule(Devotion devotionSched)
        {
            try {
                var insertStatement = "INSERT INTO tbl_DevotionSchedules VALUES(@Date, @SongLeader, @Presider, @Speaker, @SongLeaderStatus, @PresiderStatus, @SpeakerStatus)";

                SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection2);

                insertCommand.Parameters.AddWithValue("@Date", devotionSched.Date);
                insertCommand.Parameters.AddWithValue("@SongLeader", devotionSched.SongLeader);
                insertCommand.Parameters.AddWithValue("@Presider", devotionSched.Presider);
                insertCommand.Parameters.AddWithValue("@Speaker", devotionSched.Speaker);
                insertCommand.Parameters.AddWithValue("@SongLeaderStatus", devotionSched.SongLeaderStatus);
                insertCommand.Parameters.AddWithValue("@PresiderStatus", devotionSched.PresiderStatus);
                insertCommand.Parameters.AddWithValue("@SpeakerStatus", devotionSched.SpeakerStatus);

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
                var insertStatement = "INSERT INTO tbl_DiscipleshipSchedules VALUES(@Date, @Speaker, @Description, @Note, @SpeakerStatus)";

                SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection2);

                insertCommand.Parameters.AddWithValue("@Date", discipleshipSched.Date);
                insertCommand.Parameters.AddWithValue("@Speaker", discipleshipSched.Speaker);
                insertCommand.Parameters.AddWithValue("@Description", discipleshipSched.Description);
                insertCommand.Parameters.AddWithValue("@Note", discipleshipSched.Note);
                insertCommand.Parameters.AddWithValue("@SpeakerStatus", discipleshipSched.Status);

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
                var insertStatement = "INSERT INTO tbl_PraiseAndWorshipSchedules VALUES(@Date, @SongLeader, @Instrumentalist, @SongLeaderStatus)";

                SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection2);

                insertCommand.Parameters.AddWithValue("@Date", praiseAndWorshipSched.Date);
                insertCommand.Parameters.AddWithValue("@SongLeader", praiseAndWorshipSched.SongLeader);
                insertCommand.Parameters.AddWithValue("@Instrumentalist", praiseAndWorshipSched.Instrumentalist);
                insertCommand.Parameters.AddWithValue("@SongLeaderStatus", praiseAndWorshipSched.SongLeaderStatus);

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
                var insertStatement = "INSERT INTO tbl_PrayerSchedules VALUES(@Date, @SongLeader, @Presider, @Speaker, @PrayerItem, @SongLeaderStatus, @PresiderStatus, @SpeakerStatus)";

                SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection2);

                insertCommand.Parameters.AddWithValue("@Date", prayerSched.Date);
                insertCommand.Parameters.AddWithValue("@SongLeader", prayerSched.SongLeader);
                insertCommand.Parameters.AddWithValue("@Presider", prayerSched.Presider);
                insertCommand.Parameters.AddWithValue("@Speaker", prayerSched.Speaker);
                insertCommand.Parameters.AddWithValue("@PrayerItem", prayerSched.PrayerItem);
                insertCommand.Parameters.AddWithValue("@SongLeaderStatus", prayerSched.SongLeaderStatus);
                insertCommand.Parameters.AddWithValue("@PresiderStatus", prayerSched.PresiderStatus);
                insertCommand.Parameters.AddWithValue("@SpeakerStatus", prayerSched.SpeakerStatus);

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
                var insertStatement = "INSERT INTO tbl_SundayWorshipSchedules VALUES(@Date, @Presider, @Speaker, @Flowers, @Ushers, @PresiderStatus, @SpeakerStatus, @FlowersStatus, @UshersStatus)";

                SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection2);

                insertCommand.Parameters.AddWithValue("@Date", sundayWorshipSched.Date);
                insertCommand.Parameters.AddWithValue("@Presider", sundayWorshipSched.Presider);
                insertCommand.Parameters.AddWithValue("@Speaker", sundayWorshipSched.Speaker);
                insertCommand.Parameters.AddWithValue("@Flowers", sundayWorshipSched.Flowers);
                insertCommand.Parameters.AddWithValue("@Ushers", sundayWorshipSched.Ushers);
                insertCommand.Parameters.AddWithValue("@PresiderStatus", sundayWorshipSched.PresiderStatus);
                insertCommand.Parameters.AddWithValue("@SpeakerStatus", sundayWorshipSched.SpeakerStatus);
                insertCommand.Parameters.AddWithValue("@FlowersStatus", sundayWorshipSched.FlowersStatus);
                insertCommand.Parameters.AddWithValue("@UshersStatus", sundayWorshipSched.UshersStatus);

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
        // remove function
        public bool RegularUserAccounts(UserAccounts userAccounts)
        {
            try
            {
                var insertStatement = "INSERT INTO tbl_UserAccounts VALUES(@FirstName, @LastName, @Age, @EmailAddress, @MinistryName, @Position, @Username, @Password)";

                SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection1);

                insertCommand.Parameters.AddWithValue("@FirstName", userAccounts.FirstName);
                insertCommand.Parameters.AddWithValue("@LastName", userAccounts.LastName);
                insertCommand.Parameters.AddWithValue("@Age", userAccounts.Age);
                insertCommand.Parameters.AddWithValue("@EmailAddress", userAccounts.EmailAddress);
                insertCommand.Parameters.AddWithValue("MinistryName", userAccounts.MinistryName);
                insertCommand.Parameters.AddWithValue("@Position",  userAccounts.Position);
                insertCommand.Parameters.AddWithValue("@Username", userAccounts.UserName);
                insertCommand.Parameters.AddWithValue("@Password", userAccounts.Password);

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
        // view function
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
                devotion.SongLeaderStatus = reader["SongLeaderStatus"].ToString();
                devotion.PresiderStatus = reader["PresiderStatus"].ToString();
                devotion.SpeakerStatus = reader["SpeakerStatus"].ToString();
                
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
                discipleship.Status = reader["SpeakerStatus"].ToString();
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
                praiseAndWorship.SongLeaderStatus = reader["SongLeaderStatus"].ToString();

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
                prayer.SongLeaderStatus = reader["SongLeaderStatus"].ToString();
                prayer.PresiderStatus = reader["PresiderStatus"].ToString();
                prayer.SpeakerStatus = reader["SpeakerStatus"].ToString();

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
                sundayWorship.PresiderStatus = reader["PresiderStatus"].ToString();
                sundayWorship.SpeakerStatus = reader["SpeakerStatus"].ToString();
                sundayWorship.FlowersStatus = reader["FlowersStatus"].ToString();
                sundayWorship.UshersStatus = reader["UshersStatus"].ToString();

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
        // update function
        public bool UpdateDiscipleshipSchedule(DiscipleshipMinistry update)
        {
            try
            {
                sqlConnection2.Open();

                string updateQuery = "UPDATE tbl_DiscipleshipSchedules SET Speaker = @speaker, Description = @description, Note = @note, SpeakerStatus = @speakerStatus WHERE DATE = @date";

                SqlCommand updateCommand = new SqlCommand(updateQuery, sqlConnection2);
                updateCommand.Parameters.AddWithValue("@Date", update.Date);
                updateCommand.Parameters.AddWithValue("@Speaker", update.Speaker);
                updateCommand.Parameters.AddWithValue("@Description", update.Description);
                updateCommand.Parameters.AddWithValue("@Note", update.Note);
                updateCommand.Parameters.AddWithValue("@SpeakerStatus", update.Status);

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

                string updateQuery = "UPDATE tbl_PrayerSchedules SET SongLeader = @songLeader, Presider = @presider, Speaker = @speaker, PrayerItem = @prayerItem, SongLeaderStatus = @songLeaderStatus, PresiderStatus = @presiderStatus, SpeakerStatus = @speakerStatus WHERE DATE = @date";

                SqlCommand updateCommand = new SqlCommand(updateQuery, sqlConnection2);
                updateCommand.Parameters.AddWithValue("@Date", update.Date);
                updateCommand.Parameters.AddWithValue("@SongLeader", update.SongLeader);
                updateCommand.Parameters.AddWithValue("@Presider", update.Presider);
                updateCommand.Parameters.AddWithValue("@Speaker", update.Speaker);
                updateCommand.Parameters.AddWithValue("@PrayerItem", update.PrayerItem);
                updateCommand.Parameters.AddWithValue("@SongLeaderStatus", update.SongLeaderStatus);
                updateCommand.Parameters.AddWithValue("@PresiderStatus", update.PresiderStatus);
                updateCommand.Parameters.AddWithValue("@SpeakerStatus", update.SpeakerStatus);
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

                string updateQuery = "UPDATE tbl_PraiseAndWorshipSchedules SET SongLeader = @songLeader, SongLeaderStatus = @songLeaderStatus WHERE DATE = @date";

                SqlCommand updateCommand = new SqlCommand(updateQuery, sqlConnection2);
                updateCommand.Parameters.AddWithValue("@Date", update.Date);
                updateCommand.Parameters.AddWithValue("@SongLeader", update.SongLeader);
                updateCommand.Parameters.AddWithValue("@SongLeaderStatus", update.SongLeaderStatus);
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

                string updateQuery = "UPDATE tbl_SundayWorshipSchedules SET Presider = @presider, Speaker = @speaker, Flowers = @flowers, Ushers = @ushers, PresiderStatus = @presiderStatus, SpeakerStatus = @speakerStatus, FlowersStatus = @flowersStatus, UshersStatus = @ushersStatus WHERE DATE = @date";

                SqlCommand updateCommand = new SqlCommand(updateQuery, sqlConnection2);
                updateCommand.Parameters.AddWithValue("@Date", update.Date);
                updateCommand.Parameters.AddWithValue("@Presider", update.Presider);
                updateCommand.Parameters.AddWithValue("@Speaker", update.Speaker);
                updateCommand.Parameters.AddWithValue("@Flowers", update.Flowers);
                updateCommand.Parameters.AddWithValue("@Ushers", update.Ushers);
                updateCommand.Parameters.AddWithValue("@PresiderStatus", update.PresiderStatus);
                updateCommand.Parameters.AddWithValue("@SpeakerStatus", update.SpeakerStatus);
                updateCommand.Parameters.AddWithValue("@FlowersStatus", update.FlowersStatus);
                updateCommand.Parameters.AddWithValue("@UshersStatus", update.UshersStatus);
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

                string updateQuery = "UPDATE tbl_DevotionSchedules SET SongLeader = @songLeader, Presider = @presider, Speaker = @speaker, PresiderStatus = @presiderStatus, SpeakerStatus = @speakerStatus, SongLeaderStatus = @songLeaderStatus WHERE DATE = @date";

                SqlCommand updateCommand = new SqlCommand(updateQuery, sqlConnection2);
                updateCommand.Parameters.AddWithValue("@Date", update.Date);
                updateCommand.Parameters.AddWithValue("@Presider", update.Presider);
                updateCommand.Parameters.AddWithValue("@SongLeader", update.SongLeader);
                updateCommand.Parameters.AddWithValue("@Speaker", update.Speaker);
                updateCommand.Parameters.AddWithValue("@PresiderStatus", update.PresiderStatus);
                updateCommand.Parameters.AddWithValue("@SpeakerStatus", update.SpeakerStatus);
                updateCommand.Parameters.AddWithValue("@SongLeaderStatus", update.SongLeaderStatus);
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
        // process user response
        public bool ProcessUserResponseDiscipleship(DiscipleshipMinistry userResponse)
        {
            sqlConnection2.Open();
            bool updated = false;
            try
            {
                string query = @"UPDATE tbl_DiscipleshipSchedules SET SpeakerStatus = @Status WHERE Date = @Date;";

                SqlCommand updateCommand = new SqlCommand(query, sqlConnection2);
                updateCommand.Parameters.AddWithValue("@Status", userResponse.Status);
                updateCommand.Parameters.AddWithValue("@Date", userResponse.Date);
                updateCommand.ExecuteNonQuery();
                updated = true;
            }
            catch
            {
                updated = false;
            }
            sqlConnection2.Close();
            return updated;
            
        }
        public bool ProcessUserResponsePrayer(PrayerMinistry userResponse)
        {
            sqlConnection2.Open();
            bool updated = false;
            try
            {
                string query = @"UPDATE tbl_PrayerSchedules 
                                SET SongLeaderStatus = @SongLeaderStatus,
                                    PresiderStatus = @PresiderStatus,
                                    SpeakerStatus = @SpeakerStatus
                                WHERE Date = @Date;";

                SqlCommand updateCommand = new SqlCommand(query, sqlConnection2);
                updateCommand.Parameters.AddWithValue("@SongLeaderStatus", userResponse.SongLeaderStatus);
                updateCommand.Parameters.AddWithValue("@PresiderStatus", userResponse.PresiderStatus);
                updateCommand.Parameters.AddWithValue("@SpeakerStatus", userResponse.SpeakerStatus);
                updateCommand.Parameters.AddWithValue("@Date", userResponse.Date);
                updateCommand.ExecuteNonQuery();
                updated = true;
            }
            catch
            {
                updated = false;
            }
            sqlConnection2.Close();
            return updated;

        }
        public bool ProcessUserResponsePW(PraiseAndWorship userResponse)
        {
            sqlConnection2.Open();
            bool updated = false;
            try
            {
                string query = @"UPDATE tbl_PraiseAndWorshipSchedules 
                                SET SongLeaderStatus = @SongLeaderStatus
                                WHERE Date = @Date;";

                SqlCommand updateCommand = new SqlCommand(query, sqlConnection2);
                updateCommand.Parameters.AddWithValue("@SongLeaderStatus", userResponse.SongLeaderStatus);
                updateCommand.Parameters.AddWithValue("@Date", userResponse.Date);
                updateCommand.ExecuteNonQuery();
                updated = true;
            }
            catch
            {
                updated = false;
            }
            sqlConnection2.Close();
            return updated;
        }
        public bool ProcessUserResponseSundayWorship(SundayWorshipService userResponse)
        {
            sqlConnection2.Open();
            bool updated = false;
            try
            {
                string query = @"UPDATE tbl_SundayWorshipSchedules 
                                SET PresiderStatus = @PresiderStatus,
                                    SpeakerStatus = @SpeakerStatus,
                                    FlowersStatus = @FlowersStatus,
                                    UshersStatus = @UshersStatus
                                WHERE Date = @Date;";

                SqlCommand updateCommand = new SqlCommand(query, sqlConnection2);
                updateCommand.Parameters.AddWithValue("@PresiderStatus", userResponse.PresiderStatus);
                updateCommand.Parameters.AddWithValue("@SpeakerStatus", userResponse.SpeakerStatus);
                updateCommand.Parameters.AddWithValue("@FlowersStatus", userResponse.FlowersStatus);
                updateCommand.Parameters.AddWithValue("@UshersStatus", userResponse.UshersStatus);
                updateCommand.Parameters.AddWithValue("@Date", userResponse.Date);
                updateCommand.ExecuteNonQuery();
                updated = true;
            }
            catch
            {
                updated = false;
            }
            sqlConnection2.Close();
            return updated;
        }
        public bool ProcessUserResponseDevotion(Devotion userResponse)
        {
            sqlConnection2.Open();
            bool updated = false;
            try
            {
                string query = @"UPDATE tbl_DevotionSchedules 
                                SET SongLeaderStatus = @SongLeaderStatus,
                                    PresiderStatus = @PresiderStatus,
                                    SpeakerStatus = @SpeakerStatus
                                WHERE Date = @Date;";

                SqlCommand updateCommand = new SqlCommand(query, sqlConnection2);
                updateCommand.Parameters.AddWithValue("@SongLeaderStatus", userResponse.SongLeaderStatus);
                updateCommand.Parameters.AddWithValue("@PresiderStatus", userResponse.PresiderStatus);
                updateCommand.Parameters.AddWithValue("@SpeakerStatus", userResponse.SpeakerStatus);
                updateCommand.Parameters.AddWithValue("@Date", userResponse.Date);
                updateCommand.ExecuteNonQuery();
                updated = true;
            }
            catch
            {
                updated = false;
            }
            sqlConnection2.Close();
            return updated;
        }
    }
}
