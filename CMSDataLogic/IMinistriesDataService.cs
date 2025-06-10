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
        public bool RegularUserAccounts(UserAccounts userAccounts);
        public bool AdminAccounts(UserAccounts adminAccounts);
        public string GetUserRole(UserAccounts loginAccounts);
        public string GetAdminMinistry(UserAccounts loginAccounts);
        public List<DiscipleshipMinistry> ViewDiscipleshipSchedule();
        public bool AddDiscipleshipSchedule(DiscipleshipMinistry discipleshipSched);
        public bool UpdateDiscipleshipSchedule(DiscipleshipMinistry update);
        public bool RemoveDiscipleshipSchedule(DiscipleshipMinistry toDelete);
        
        public List<PrayerMinistry> ViewPrayerMeetingSchedule();
        public bool AddPrayerSchedule(PrayerMinistry prayerSched);
        public bool UpdatePrayerSchedule(PrayerMinistry update);
        public bool RemovePrayerSchedule(PrayerMinistry toDelete);

        public List<PraiseAndWorship> ViewPraiseAndWorshipSchedule();
        public bool AddPraiseAndWorshipSchedule(PraiseAndWorship praiseAndWorshipSched);
        public bool UpdatePraiseAndWorshipSchedule(PraiseAndWorship update);        
        public bool RemovePraiseAndWorshipSchedule(PraiseAndWorship toDelete);
        public List<SundayWorshipService> ViewSundayWorshipSched();
        public bool AddSundayWorshipSchedule(SundayWorshipService sundayWorshipSched);
        public bool UpdateSundayWorshipSchedule(SundayWorshipService update);
        public bool RemoveSundayWorshipSched(SundayWorshipService toDelete);
        public List<Devotion> ViewDevotionSchedule();
        public bool AddDevotionSchedule(Devotion devotionSched);
        public bool UpdateDevotionSchedule(Devotion update);
        public bool RemoveDevotionSchedule(Devotion toDelete);
        public List<TeachersList> ViewTeachersList();
        public bool AddTeachers(TeachersList teachersList);
        public bool UpdateTeachers(TeachersList update);
        public bool RemoveTeacher(TeachersList toDelete);
        public List<Lesson> ViewLessons();
        public bool AddLesson(Lesson lessonsList);
        public bool UpdateLesson(Lesson update);
        public bool RemoveLesson(Lesson toDelete);

    }
}
