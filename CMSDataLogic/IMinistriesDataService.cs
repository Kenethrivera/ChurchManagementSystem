using CMSAccounts;
using CMSSchedules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSDataLogic
{
    interface IMinistriesDataService
    {
        public void RegularUserAccounts(string firstName, string lastName, int age, string emailAddress, string userName, string passWord);
        public void AdminAccounts(string firstName, string lastName, int age, string emailAddress, string ministryName, string position, string userName, string passWord);
        public string GetUserRole(string username, string password);
        public string GetAdminMinistry(string username, string password);
        public List<DiscipleshipMinistry> ViewDiscipleshipSchedule();
        public bool AddDiscipleshipSchedule(string date, string speaker, string description, string note);
        public bool RemoveDiscipleshipSchedule(string date);
        public List<PrayerMinistry> ViewPrayerMeetingSchedule();
        public bool AddPrayerSchedule(string date, string songLeader, string presider, string speaker);
        public bool RemovePrayerSchedule(string date);
        public bool AddPrayerItem(string date, string prayerItem);
        public List<PraiseAndWorship> ViewPraiseAndWorshipSchedule();
        public bool AddPraiseAndWorshipSchedule(string date, string songLeader, string instrumentalist);
        public bool RemovePraiseAndWorshipSchedule(string date);
        public List<SundayWorshipService> ViewSundayWorshipSched();
        public bool AddSundayWorshipSchedule(string date, string presider, string speaker, string flowers, string ushers);
        public bool RemoveSundayWorshipSched(string date);
        public List<Devotion> ViewDevotionSchedule();
        public bool AddDevotionSchedule(string date, string songLeader, string presider, string speaker);
        public bool RemoveDevotionSchedule(string date);
        public List<TeachersList> ViewTeachersList();
        public bool AddTeachers(string name, string designation);
        public bool RemoveTeacher(string name);
        public List<Lesson> ViewLessons();
        public bool AddLesson(string date, string lesson, string materials);
        public bool RemoveLesson(string date);



    }
}
