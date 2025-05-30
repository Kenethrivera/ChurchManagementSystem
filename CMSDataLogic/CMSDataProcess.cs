using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using CMSAccounts;
using CMSSchedules;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CMSDataLogic
{

    public class CMSDataProcess
    {
        IMinistriesDataService cmsDataService;
        public CMSDataProcess()
        {
            // cmsDataService = new InMemoryDataService();
            // cmsDataService = new TextFileDataService();
            //cmsDataService = new JsonDataService();
            cmsDataService = new DBDataService();            
        }
        public void RegularUserAccounts(string firstName, string lastName, int age, string emailAddress, string userName, string passWord)
        {
            cmsDataService.RegularUserAccounts(firstName, lastName, age, emailAddress, userName, passWord);
        }
        public void AdminAccounts(string firstName, string lastName, int age, string emailAddress, string ministryName, string position, string userName, string passWord)
        {
            cmsDataService.AdminAccounts(firstName, lastName, age, emailAddress, ministryName, position, userName, passWord);
        }
        public string GetUserRole(string username, string password)
        {
            return cmsDataService.GetUserRole(username, password);
        }
        public string GetAdminMinistry(string username, string password)
        {
            return cmsDataService.GetAdminMinistry(username, password);
        }
        public List<DiscipleshipMinistry> ViewDiscipleshipSchedule()
        {
            return cmsDataService.ViewDiscipleshipSchedule();
        }
        public bool AddDiscipleshipSchedule(string date, string speaker, string description, string note)
        {
            return cmsDataService.AddDiscipleshipSchedule(date, speaker, description, note);
        }
        public bool RemoveDiscipleshipSchedule(string date)
        {
            return cmsDataService.RemoveDiscipleshipSchedule(date);
        }
        public List<PrayerMinistry> ViewPrayerMeetingSchedule()
        {
            return cmsDataService.ViewPrayerMeetingSchedule();
        }
        public bool AddPrayerSchedule(string date, string songLeader, string presider, string speaker, string prayerItem)
        {
            return cmsDataService.AddPrayerSchedule(date, songLeader, presider, speaker, prayerItem);
        }
        public bool RemovePrayerSchedule(string date)
        {
            return cmsDataService.RemovePrayerSchedule(date);
        }
        public List<PraiseAndWorship> ViewPraiseAndWorshipSchedule()
        {
            return cmsDataService.ViewPraiseAndWorshipSchedule();
        }
        public bool AddPraiseAndWorshipSchedule(string date, string songLeader, string instrumentalist)
        {
            return cmsDataService.AddPraiseAndWorshipSchedule(date, songLeader, instrumentalist);
        }
        public bool RemovePraiseAndWorshipSchedule(string date)
        {
            return cmsDataService.RemovePraiseAndWorshipSchedule(date);
        }
        public List<SundayWorshipService> ViewSundayWorshipSched()
        {
            return cmsDataService.ViewSundayWorshipSched();
        }
        public bool AddSundayWorshipSchedule(string date, string presider, string speaker, string flowers, string ushers)
        {
            return cmsDataService.AddSundayWorshipSchedule(date, presider, speaker, flowers, ushers);
        }
        public bool RemoveSundayWorshipSched(string date)
        {
            return cmsDataService.RemoveSundayWorshipSched(date);
        }
        public List<Devotion> ViewDevotionSchedule()
        {
            return cmsDataService.ViewDevotionSchedule();
        }
        public bool AddDevotionSchedule(string date, string songLeader, string presider, string speaker)
        {
            return cmsDataService.AddDevotionSchedule(date, songLeader, presider, speaker);
        }
        public bool RemoveDevotionSchedule(string date)
        {
            return cmsDataService.RemoveDevotionSchedule(date);
        }
        public List<TeachersList> ViewTeachersList()
        {
            return cmsDataService.ViewTeachersList();
        }
        public bool AddTeachers(string name, string designation)
        {
            return cmsDataService.AddTeachers(name, designation);
        }
        public bool RemoveTeacher(string name)
        {
            return cmsDataService.RemoveTeacher(name);
        }
        public List<Lesson> ViewLessons()
        {
            return cmsDataService.ViewLessons();
        }
        public bool AddLesson(string date, string lesson, string materials)
        {
            return cmsDataService.AddLesson(date, lesson, materials);
        }
        public bool RemoveLesson(string date)
        {
            return cmsDataService.RemoveLesson(date);
        }
    }

}
    

