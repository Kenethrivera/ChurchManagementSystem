using CMSAccounts;
using CMSSchedules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CMSDataLogic
{
    public class JsonDataService : IMinistriesDataService
    {
        string adminAccFilePath = "adminAccounts.json";
        string regularAccFilePath = "regularAccounts.txt";
        string devotionScheduleFilePath = "devotionSchedule.txt";
        string discipleshipScheduleFilePath = "discipleshipSchedule.txt";
        string praiseAndWorshipScheduleFilePath = "praiseAndWorshipSchedule.txt";
        string sundayWorshipServiceFilePath = "sundayWorshipSchedule.txt";
        string prayerItemFilePath = "prayerItem.txt";
        string prayerMeetingFilePath = "prayerMeeting.txt";
        string lessonFilePath = "lesson.txt";
        string teachersFilePath = "teacher.txt";

        private List<UserAccounts> regularAccounts = new List<UserAccounts>();
        private List<UserAccounts> adminAccounts = new List<UserAccounts>();

        private List<DiscipleshipMinistry> discipleshipSchedules = new List<DiscipleshipMinistry>();
        private List<PrayerMinistry> prayerSchedules = new List<PrayerMinistry>();
        private List<SundayWorshipService> sundayWorshipSchedules = new List<SundayWorshipService>();
        private List<PraiseAndWorship> praiseAndWorshipSchedules = new List<PraiseAndWorship>();
        private List<Devotion> devotionSchedules = new List<Devotion>();
        private List<TeachersList> teachersList = new List<TeachersList>();
        private List<Lesson> lessonsList = new List<Lesson>();

        public JsonDataService()
        {
            ReadAdminAccFromFile();
        }
        private void ReadAdminAccFromFile()
        {
            string jsonText = File.ReadAllText(adminAccFilePath);
            adminAccounts = JsonSerializer.Deserialize<List<UserAccounts>>(jsonText,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );
        }


        public bool AddDevotionSchedule(string date, string songLeader, string presider, string speaker)
        {
            try
            {
                var newSchedule = new Devotion
                {
                    Date = date,
                    SongLeader = songLeader,
                    Presider = presider,
                    Speaker = speaker
                };
                return true;
            }
            catch
            {
                return false;
            }
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
