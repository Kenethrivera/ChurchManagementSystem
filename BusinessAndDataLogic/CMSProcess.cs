using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMSDataLogic;

namespace BusinessAndDataLogic
{
    public class CMSProcess
    {
        private CMSDataProcess dataProcess = new CMSDataProcess();

        //storage for ministries
        public static List<string> discipleshipSchedules = new List<string>();
        public static List<string> discipleshipTopics = new List<string>();

        public static List<string> prayerSchedules = new List<string>();
        public static List<string> prayerRequest = new List<string>();

        public static List<string> worshipSchedules = new List<string>();
        public static List<string> worshipRepertoire = new List<string>();

        public static List<string> christianEdTeachers = new List<string>();
        public static List<string> christianEdTopics = new List<string>();

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
        public bool ValidatingUsernameAndPassword(string username, string password, bool isAdmin)
        {
            return dataProcess.ValidatingRegisteredUser(username, password, isAdmin);
        }


        // about the ministries schedule
        public string[] MinistryNamesList()
        {
            string[] ministryName = { "[1] Discipleship Ministry", "[2] Prayer Ministry", "[3] Worship Ministry", "[4] Christian Education", "[5] EXIT" };
            return ministryName;
        }
        //viewing schedule
        public string ViewSchedules(string ministryName)
        {
            if (ministryName == "[1] Discipleship Ministry")
            {
                return dataProcess.ViewDiscipleshipSchedule();
            }
            else if (ministryName == "[2] Prayer Ministry")
            {
                return dataProcess.ViewPrayerSchedule();
            }
            else if (ministryName == "[3] Worship Ministry")
            {
                return dataProcess.ViewSundayWorshipSchedule();
            }
            else if (ministryName == "[4] Christian Education")
            {
                return dataProcess.ViewTeachersList();
            }
            else
            {
                return "false";
            }
        }
        //view praise and worship schedule
        public string ViewPraiseAndWorshipSchedule()
        {
            return dataProcess.ViewPraiseAndWorshipDetails();
        }
        //view devotion schedules
        public string ViewDevotionSchedule()
        {
            return dataProcess.ViewDevotionDetails();
        }
        //add schedule for 1,2,3.1 ministry
        public bool AddMinistrySchedule(string ministryName, int date, string speaker, string presider, string description)
        {
            switch (ministryName)
            {
                case "[1] Discipleship Ministry":
                    dataProcess.AddDiscipleshipSchedule(date, speaker, presider, description);
                    return true;
                case "[2] Prayer Ministry":
                    dataProcess.AddPrayerSchedule(date, speaker, presider, description);
                    return true;
                case "[3] Worship Ministry":
                    dataProcess.AddSundayWorshipSchedule(date, speaker, presider, description);
                    return true;    
            }
            return false;
        }
        //add praise and worship schedule
        public bool AddPraiseAndWorshipSchedule(string songLeader, string firstRehearsalDate, string firstRehearsalTime, string finalRehearsalDate,  string finalRehearsalTime)
        {
            dataProcess.AddPraiseAndWorshipSchedule(songLeader, firstRehearsalDate, firstRehearsalTime, finalRehearsalDate, finalRehearsalTime);
            return true;
        }
        //add devotion schedule
        public bool AddDevotionSchedule(string speaker, string presider, string devotionDate, string devotionTime)
        {
            dataProcess.AddDevotionSchedules(speaker, presider, devotionDate, devotionTime);
            return true;
        }
        //add teacher
        public bool AddTeachersName(string teachersName)
        {
            dataProcess.AddTeachersName(teachersName);
            return true;
        }
        //remove logic for ministry 1, 2, 3.1, 4
        public bool RemoveSchedule(string ministryName, int index)
        {
            if (ministryName == "[1] Discipleship Ministry")
            {
                return dataProcess.RemoveDiscipleshipSchedule(index);
            }
            else if (ministryName == "[2] Prayer Ministry")
            {
                return dataProcess.RemovePrayerSchedule(index);
            }
            else if (ministryName == "[3] Worship Ministry")
            {
                return dataProcess.RemoveSundayWorshipSchedule(index);
            }
            else if (ministryName == "[4] Christian Education")
            {
                return dataProcess.RemoveTeachers(index);
            }
            else
            {
                return false;
            }       
        } 
        //remove praise and worship schedule
        public bool RemovePraiseAndWorshipSchedule(int index)
        {
            return dataProcess.RemovePraiseAndWorshipSchedule(index);
        }
        //remove devotion schedule
        public bool RemoveDevotionSchedule(int index)
        {
            return dataProcess.RemoveDevotionSchedule(index);
        }
        //choose types of schedule
        public int SetTypeOfScheduling(string ministryName)
        {
            if (ministryName == "[1] Discipleship Ministry" || ministryName == "[2] Prayer Ministry")
            {
                return 1;
            }
            else if (ministryName == "[3] Worship Ministry")
            {
                return 2;
            }
            else if (ministryName == "[4] Christian Education")
            {
                return 3;
            }
            else
            {
                return 4;
            }
        }
        //dates
        public static int[] GetAvailableDates(string ministryName)
        {
            if(ministryName == "[1] Discipleship Ministry" || ministryName == "[3] Worship Ministry")
            {
                return new int[] { 6, 13, 20, 27 };
            } else
            {
                return new int[] { 3, 10, 17, 24 };
            }
            
        }


        public bool AddMinistryTopics(string ministryName, string field1 = "", string field2= "", string field3 = "", string field4 = "")
        {
            switch (ministryName)
            {
                case "[1] Discipleship Ministry":
                    dataProcess.AddDiscipleshipTopics(field1, field2, field3, field4);
                    return true;
                case "[2] Prayer Ministry":
                    dataProcess.AddPrayerRequest(field1);
                    return true;
                case "[3] Worship Ministry":
                    dataProcess.AddRepertoire(field1);
                    return true;
                case "[4] Christian Education":
                    dataProcess.AddLesson(field1);
                    return true;
                default:
                    return false;
            }
        }

        public string ViewTopics(string ministryName)
        {
            if (ministryName == "[1] Discipleship Ministry")
            {
                return dataProcess.ViewDiscipleshipTopics();
            }
            else if (ministryName == "[2] Prayer Ministry")
            {
                return dataProcess.ViewPrayerRequest();
            }
            else if (ministryName == "[3] Worship Ministry")
            {
                return dataProcess.ViewRepertoire();
            }
            else if (ministryName == "[4] Christian Education")
            {
                return dataProcess.ViewLesson();
            }
            else
            {
                return "false";
            }    
        }
        public bool RemoveTopics(string ministryName, int index)
        {
            if (ministryName == "[1] Discipleship Ministry")
            {
                return dataProcess.RemoveDiscipleshipTopics(index);
            }
            else if (ministryName == "[2] Prayer Ministry")
            {
                return dataProcess.RemovePrayerRequest(index);
            }
            else if (ministryName == "[3] Worship Ministry")
            {
                return dataProcess.RemoveRepertoire(index);
            }
            else if (ministryName == "[4] Christian Education")
            {
                return dataProcess.RemoveLessons(index);
            }
            else
            {
                return false;
            }

        }      
    }
}