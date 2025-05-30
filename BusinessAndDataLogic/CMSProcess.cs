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
        //viewing schedule

        
        //discipleship ministry
        public List<DiscipleshipMinistry> ViewDiscipleshipSchedule()
        {
            return dataProcess.ViewDiscipleshipSchedule();
        }

        public bool AddDicipleshipSched(string date, string speaker, string description, string note)
        {
            return dataProcess.AddDiscipleshipSchedule(date, speaker, description, note);
        }
        public bool RemoveDiscipleSched(string date)
        {
            return dataProcess.RemoveDiscipleshipSchedule(date);
        }
        
        //prayer ministry
        public List<PrayerMinistry> ViewPrayerSched()
        {
            return dataProcess.ViewPrayerMeetingSchedule();
        }
        public bool AddPrayerSched(string date, string songLeader, string presider, string speaker, string prayerItem)
        {
            return dataProcess.AddPrayerSchedule(date, songLeader, presider, speaker, prayerItem);
        }
        public bool RemovePrayerSched(string date)
        {
            return dataProcess.RemovePrayerSchedule(date);
        }

        //worship ministry
        public List<PraiseAndWorship> ViewPraiseAndWorshipSched()
        {
            return dataProcess.ViewPraiseAndWorshipSchedule();
        }
        public bool AddPraiseAndWorshipSched(string date, string songLeader, string instrumentalist)
        {
            return dataProcess.AddPraiseAndWorshipSchedule(date, songLeader, instrumentalist);
        }
        public bool RemovePraiseAndWorshipSched(string date)
        {
            return dataProcess.RemovePraiseAndWorshipSchedule(date);
        }
        public List<SundayWorshipService> ViewSundayWorshipSched()
        {
            return dataProcess.ViewSundayWorshipSched();
        }
        public bool AddSundayWorshipServiceSched(string date, string presider, string speaker, string flowers, string ushers)
        {
            return dataProcess.AddSundayWorshipSchedule(date, presider, speaker, flowers, ushers);
        }
        public bool RemoveSundayWorshipSched(string date)
        {
            return dataProcess.RemoveSundayWorshipSched(date);
        }
        public List<Devotion> ViewDevotionSched()
        {
            return dataProcess.ViewDevotionSchedule();
        }     
        public bool AddDevotionSched(string date, string songLeader, string presider, string speaker)
        {
            return dataProcess.AddDevotionSchedule(date, songLeader, presider, speaker);
        }
        public bool RemoveDevotionSched(string date)
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
        public bool RemoveTeacher(string date)
        {
            return dataProcess.RemoveTeacher(date);
        }
        public List<Lesson> GetLessons()
        {
            return dataProcess.ViewLessons();
        }
        public bool AddLesson(string date, string lesson, string materials)
        {
            return dataProcess.AddLesson(date, lesson, materials);
        }
        public bool RemoveLesson(string date)
        {
            return dataProcess.RemoveLesson(date);
        }



      
    }
}