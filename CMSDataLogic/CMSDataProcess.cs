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
            //cmsDataService = new InMemoryDataService();
            //cmsDataService = new TextFileDataService();
            //cmsDataService = new JsonDataService();
            cmsDataService = new DBDataService();            
        }
        public bool RegularUserAccounts(UserAccounts userAccounts)
        { 
            return cmsDataService.RegularUserAccounts(userAccounts);
        }
        public bool AdminAccounts(UserAccounts adminAccounts)
        {
            
            return cmsDataService.AdminAccounts(adminAccounts);
        }
        public string GetUserRole(UserAccounts loginAccounts)
        {
            return cmsDataService.GetUserRole(loginAccounts);
        }
        public string GetAdminMinistry(UserAccounts loginAccounts)
        {
            return cmsDataService.GetAdminMinistry(loginAccounts);
        }
        public List<DiscipleshipMinistry> ViewDiscipleshipSchedule()
        {
            return cmsDataService.ViewDiscipleshipSchedule();
        }
        public bool AddDiscipleshipSchedule(DiscipleshipMinistry discipleshipSched)
        {
            return cmsDataService.AddDiscipleshipSchedule(discipleshipSched);
        }
        public bool UpdateDiscipleshipSchedule(DiscipleshipMinistry update)
        {
            return cmsDataService.UpdateDiscipleshipSchedule(update);
        }
        public bool RemoveDiscipleshipSchedule(DiscipleshipMinistry toDelete)
        {
            return cmsDataService.RemoveDiscipleshipSchedule(toDelete);
        }
        public List<PrayerMinistry> ViewPrayerMeetingSchedule()
        {
            return cmsDataService.ViewPrayerMeetingSchedule();
        }
        public bool AddPrayerSchedule(PrayerMinistry prayerSched)
        {
            return cmsDataService.AddPrayerSchedule(prayerSched);
        }
        public bool UpdatePrayerSchedule(PrayerMinistry update)
        {
            return cmsDataService.UpdatePrayerSchedule(update);
        }
        public bool RemovePrayerSchedule(PrayerMinistry toDelete)
        {
            return cmsDataService.RemovePrayerSchedule(toDelete);
        }
        public List<PraiseAndWorship> ViewPraiseAndWorshipSchedule()
        {
            return cmsDataService.ViewPraiseAndWorshipSchedule();
        }
        public bool AddPraiseAndWorshipSchedule(PraiseAndWorship praiseAndWorshipSched)
        {
            return cmsDataService.AddPraiseAndWorshipSchedule(praiseAndWorshipSched);
        }
        public bool UpdatePraiseAndWorshipSchedule(PraiseAndWorship update)
        {
            return cmsDataService.UpdatePraiseAndWorshipSchedule(update);
        }
        public bool RemovePraiseAndWorshipSchedule(PraiseAndWorship toDelete)
        {
            return cmsDataService.RemovePraiseAndWorshipSchedule(toDelete);
        }
        public List<SundayWorshipService> ViewSundayWorshipSched()
        {
            return cmsDataService.ViewSundayWorshipSched();
        }
        public bool AddSundayWorshipSchedule(SundayWorshipService sundayWorshipSched)
        {
            return cmsDataService.AddSundayWorshipSchedule(sundayWorshipSched);
        }
        public bool UpdateSundayWorshipSchedule(SundayWorshipService update)
        {
            return cmsDataService.UpdateSundayWorshipSchedule(update);
        }
        public bool RemoveSundayWorshipSched(SundayWorshipService toDelete)
        {
            return cmsDataService.RemoveSundayWorshipSched(toDelete);
        }
        public List<Devotion> ViewDevotionSchedule()
        {
            return cmsDataService.ViewDevotionSchedule();
        }
        public bool AddDevotionSchedule(Devotion devotionSched)
        {
            return cmsDataService.AddDevotionSchedule(devotionSched);
        }
        public bool UpdateDevotionSchedule(Devotion update)
        {
            return cmsDataService.UpdateDevotionSchedule(update);
        }

        public bool RemoveDevotionSchedule(Devotion toDelete)
        {
            return cmsDataService.RemoveDevotionSchedule(toDelete);
        }
        public List<TeachersList> ViewTeachersList()
        {
            return cmsDataService.ViewTeachersList();
        }
        public bool AddTeachers(TeachersList teachersList)
        {
            return cmsDataService.AddTeachers(teachersList);
        }
        public bool UpdateTeachers(TeachersList update)
        {
            return cmsDataService.UpdateTeachers(update);
        }

        public bool RemoveTeacher(TeachersList toDelete)
        {
            return cmsDataService.RemoveTeacher(toDelete);
        }
        public List<Lesson> ViewLessons()
        {
            return cmsDataService.ViewLessons();
        }
        public bool AddLesson(Lesson lessonsList)
        {
            return cmsDataService.AddLesson(lessonsList);
        }
        public bool UpdateLesson(Lesson update)
        {
            return cmsDataService.UpdateLesson(update);
        }

        public bool RemoveLesson(Lesson toDelete)
        {
            return cmsDataService.RemoveLesson(toDelete);
        }
    }
}
    

