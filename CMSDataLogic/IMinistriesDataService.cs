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
        public bool AddDiscipleshipSchedule(DateTime date, string speaker, string description, string note);
        public bool UpdateDiscipleshipSchedule(DateTime date, string speaker, string description, string note);
        public bool RemoveDiscipleshipSchedule(DateTime date);
        public List<PrayerMinistry> ViewPrayerMeetingSchedule();
        public bool AddPrayerSchedule(DateTime date, string songLeader, string presider, string speaker, string prayerItem);
        public bool UpdatePrayerSchedule(DateTime date, string songLeader, string presider, string speaker, string prayerItem);

        public bool RemovePrayerSchedule(DateTime date);
        public List<PraiseAndWorship> ViewPraiseAndWorshipSchedule();
        public bool AddPraiseAndWorshipSchedule(DateTime date, string songLeader, string instrumentalist);
        public bool UpdatePraiseAndWorshipSchedule(DateTime date, string songLeader);        
        public bool RemovePraiseAndWorshipSchedule(DateTime date);
        public List<SundayWorshipService> ViewSundayWorshipSched();
        public bool AddSundayWorshipSchedule(DateTime date, string presider, string speaker, string flowers, string ushers);
        public bool UpdateSundayWorshipSchedule(DateTime date, string presider, string speaker, string flowers, string ushers);
        public bool RemoveSundayWorshipSched(DateTime date);
        public List<Devotion> ViewDevotionSchedule();
        public bool AddDevotionSchedule(DateTime date, string songLeader, string presider, string speaker);
        public bool UpdateDevotionSchedule(DateTime date, string songLeader, string presider, string speaker);
        public bool RemoveDevotionSchedule(DateTime date);
        public List<TeachersList> ViewTeachersList();
        public bool AddTeachers(string name, string designation);
        public bool UpdateTeachers(string name, string designation);
        public bool RemoveTeacher(string name);
        public List<Lesson> ViewLessons();
        public bool AddLesson(DateTime date, string lesson, string materials);
        public bool UpdateLesson(DateTime date, string lesson, string materials);
        public bool RemoveLesson(DateTime date);

    }
}
