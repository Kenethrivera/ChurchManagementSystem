using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMSDataLogic;
using CMSSchedules;

namespace BusinessAndDataLogic
{
    public class CMSProcess
    {
        private CMSDataProcess dataProcess = new CMSDataProcess();

        // about Login/sign up
        public void RegisteringRegularAccounts(string firstName, string lastName, int age, string emailAddress, string username, string password)
        {
            dataProcess.RegularUserAccounts(firstName, lastName, age, emailAddress, username, password);
        }
        public void RegisteringAdminAccounts(string firstName, string lastName, int age, string emailAddress, string ministryName, string position, string userName, string passWord)
        {
            dataProcess.AdminAccounts(firstName, lastName, age, emailAddress, ministryName, position, userName, passWord);
        }
        public static bool CheckPasswordMatch(string password, string re_Enter_Password)
        {
            if( password == re_Enter_Password)
            {
                return true;
            } 
            else
            {
                return false;
            }
        }
        public string ValidatingUserRole(string username, string password)
        {
            return dataProcess.GetUserRole(username, password);
        }
        public string ValidatingAdminMinistry(string username, string password)
        {
            return dataProcess.GetAdminMinistry(username, password);
        }


        // about the ministries schedule
        public string[] MinistryNamesList()
        {
            string[] ministryName = { "[1] Discipleship Ministry", "[2] Prayer Ministry", "[3] Worship Ministry", "[4] Christian Education", "[5] EXIT" };
            return ministryName;
        }
        
        //discipleship ministry
        public List<DiscipleshipMinistry> ViewDiscipleshipSchedule()
        {
            return dataProcess.ViewDiscipleshipSchedule();
        }
        public bool AddDiscipleshipSched(DateTime date, string speaker, string description, string note)
        {
            return dataProcess.AddDiscipleshipSchedule(date, speaker, description, note);
        }
        public bool UpdateDiscipleshipSched(DateTime date, string speaker, string description, string note)
        {
            return dataProcess.UpdateDiscipleshipSchedule(date, speaker, description, note);
        }
        public bool RemoveDiscipleSched(DateTime date)
        {
            return dataProcess.RemoveDiscipleshipSchedule(date);
        }
        
        //prayer ministry
        public List<PrayerMinistry> ViewPrayerSched()
        {
            return dataProcess.ViewPrayerMeetingSchedule();
        }
        public bool AddPrayerSched(DateTime date, string songLeader, string presider, string speaker, string prayerItem)
        {
            return dataProcess.AddPrayerSchedule(date, songLeader, presider, speaker, prayerItem);
        }
        public bool UpdatePrayerSched(DateTime date, string songLeader, string presider, string speaker, string prayerItem)
        {
            return dataProcess.UpdatePrayerSchedule(date, songLeader, presider, speaker, prayerItem);
        }
        public bool RemovePrayerSched(DateTime date)
        {
            return dataProcess.RemovePrayerSchedule(date);
        }

        //worship ministry
        public List<PraiseAndWorship> ViewPraiseAndWorshipSched()
        {
            return dataProcess.ViewPraiseAndWorshipSchedule();
        }
        public bool AddPraiseAndWorshipSched(DateTime date, string songLeader, string instrumentalist)
        {
            return dataProcess.AddPraiseAndWorshipSchedule(date, songLeader, instrumentalist);
        }
        public bool UpdatePraiseAndWorshipSched(DateTime date, string songLeader)
        {
            return dataProcess.UpdatePraiseAndWorshipSchedule(date, songLeader);
        }
        public bool RemovePraiseAndWorshipSched(DateTime date)
        {
            return dataProcess.RemovePraiseAndWorshipSchedule(date);
        }

        public List<SundayWorshipService> ViewSundayWorshipSched()
        {
            return dataProcess.ViewSundayWorshipSched();
        }
        public bool AddSundayWorshipServiceSched(DateTime date, string presider, string speaker, string flowers, string ushers)
        {
            return dataProcess.AddSundayWorshipSchedule(date, presider, speaker, flowers, ushers);
        }
        public bool UpdateSundayWorshipServiceSched(DateTime date, string presider, string speaker, string flowers, string ushers)
        {
            return dataProcess.UpdateSundayWorshipSchedule(date, presider, speaker, flowers, ushers);
        }
        public bool RemoveSundayWorshipSched(DateTime date)
        {
            return dataProcess.RemoveSundayWorshipSched(date);
        }

        public List<Devotion> ViewDevotionSched()
        {
            return dataProcess.ViewDevotionSchedule();
        }     
        public bool AddDevotionSched(DateTime date, string songLeader, string presider, string speaker)
        {
            return dataProcess.AddDevotionSchedule(date, songLeader, presider, speaker);
        }
        public bool UpdateDevotionSched(DateTime date, string songLeader, string presider, string speaker)
        {
            return dataProcess.UpdateDevotionSchedule(date, songLeader, presider, speaker);
        }

        public bool RemoveDevotionSched(DateTime date)
        {
            return dataProcess.RemoveDevotionSchedule(date);

        }

        public List<TeachersList> GetTeachers()
        {
            return dataProcess.ViewTeachersList();
        }
        public bool AddTeachers(string name, string designation)
        {
            return dataProcess.AddTeachers(name, designation);
        }
        public bool UpdateTeachers(string name, string designation)
        {
            return dataProcess.UpdateTeachers(name, designation);
        }
        public bool RemoveTeacher(string date)
        {
            return dataProcess.RemoveTeacher(date);
        }

        public List<Lesson> GetLessons()
        {
            return dataProcess.ViewLessons();
        }
        public bool AddLesson(DateTime date, string lesson, string materials)
        {
            return dataProcess.AddLesson(date, lesson, materials);
        }
        public bool UpdateLesson(DateTime date, string lesson, string materials)
        {
            return dataProcess.UpdateLesson(date, lesson, materials);
        }
        public bool RemoveLesson(DateTime date)
        {
            return dataProcess.RemoveLesson(date);
        }

        public bool ValidateSundayDate(DateTime date)
        {
            if (date.DayOfWeek != DayOfWeek.Sunday)
            {
                return false;
            }
            return true;
        }
        public bool ValidateFridayDate(DateTime date)
        {
            if (date.DayOfWeek != DayOfWeek.Friday)
            {
                return false;
            }
            return true;
        }
        public bool ValidateThursdayDate(DateTime date)
        {
            if (date.DayOfWeek != DayOfWeek.Thursday)
            {
                return false;
            }
            return true;
        }
        public bool DateIsPast(DateTime date)
        {
            if(date.Date < DateTime.Today)
            {
                return false;
            }
            return true;
        }

        //checking if date exist
        public bool DiscipleshipScheduleExist(DateTime date)
        {
            foreach (DiscipleshipMinistry sched in dataProcess.ViewDiscipleshipSchedule())
            {
                if (sched.Date.Date == date.Date)
                {
                    return true;
                }
            }
            return false;
        }
        public bool PrayerScheduleExist(DateTime date)
        {
            foreach (PrayerMinistry sched in dataProcess.ViewPrayerMeetingSchedule())
            {
                if (sched.Date.Date == date.Date)
                {
                    return true;
                }
            }
            return false;
        }
        public bool PraiseAndWorshipScheduleExist(DateTime date)
        {
            foreach (PraiseAndWorship sched in dataProcess.ViewPraiseAndWorshipSchedule())
            {
                if (sched.Date.Date == date.Date)
                {
                    return true;
                }
            }
            return false;
        }
        public bool SundayWorshipScheduleExist(DateTime date)
        {
            foreach (SundayWorshipService sched in dataProcess.ViewSundayWorshipSched())
            {
                if (sched.Date.Date == date.Date)
                {
                    return true;
                }
            }
            return false;
        }
        public bool DevotionScheduleExist(DateTime date)
        {
            foreach (Devotion sched in dataProcess.ViewDevotionSchedule())
            {
                if (sched.Date.Date == date.Date)
                {
                    return true;
                }
            }
            return false;
        }
        public bool TeacherNameExist(string name)
        {
            foreach (TeachersList sched in dataProcess.ViewTeachersList())
            {
                if (sched.TeachersName == name)
                {
                    return true;
                }
            }
            return false;
        }
        public bool LessonExist(DateTime date)
        {
            foreach (Lesson sched in dataProcess.ViewLessons())
            {
                if (sched.Date.Date == date.Date)
                {
                    return true;
                }
            }
            return false;
        }

    }
}