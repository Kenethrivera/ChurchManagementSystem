using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAndDataLogic
{
    public static class CMSProcess
    {
        public static List<string> usernames = new List<string>();
        public static List<string> passwords = new List<string>();

        public static List<string> adminUsernames = new List<string>();
        public static List<string> adminPasswords = new List<string>();

        public static List<string> discipleshipSchedules = new List<string>();
        public static List<string> discipleshipTopics = new List<string>();

        public static List<string> prayerSchedules = new List<string>();
        public static List<string> prayerRequest = new List<string>();

        public static List<string> worshipSchedules = new List<string>();
        public static List<string> worshipRepertoire = new List<string>();

        public static List<string> christianEdTeachers = new List<string>();
        public static List<string> christianEdTopics = new List<string>();

        public static List<string> ministries = new List<string>();



        // about Login/sign up
        public static void RegisteredUsernameAndPassword(string username, string password, bool isAdmin)
        {
            if (isAdmin)
            {
                adminUsernames.Add(username);
                adminPasswords.Add(password);
            }
            else
            {
                usernames.Add(username);
                passwords.Add(password);
            }
        }
        public static bool CheckPasswordMatch(string password, string re_Enter_Password)
        {
            return password == re_Enter_Password;
        }
        public static bool ValidatingUsernameAndPassword(string username, string password, bool isAdmin)
        {
            if (isAdmin)
            {
                int index = adminUsernames.IndexOf(username);
                if (index != -1 && adminPasswords[index] == password)
                {
                    return true;
                }
                return false;

            }
            else
            {
                int index = usernames.IndexOf(username);
                if (index != -1 && passwords[index] == password)
                {
                    return true;
                }
                return false;
            }
        }

        // about the ministries
        public static string[] MinistryNamesList()
        {
            string[] ministryName = { "[1] Discipleship Ministry", "[2] Prayer Ministry", "[3] Worship Ministry", "[4] Christian Education" };
            return ministryName;
        }

        public static List<string> ViewSchedule(string ministryName)
        {
            if (ministryName == "[1] Discipleship Ministry")
            {
                return discipleshipSchedules;
            }
            else if (ministryName == "[2] Prayer Ministry")
            {
                return prayerSchedules;
            }
            else if (ministryName == "[3] Worship Ministry")
            {
                return worshipSchedules;
            }
            else if (ministryName == "[4] Christian Education")
            { 
                return christianEdTeachers;
            }
            else
            {
                return new List<string>();
            }
        }

        public static bool RemoveScheduleItem(string ministryName, string toRemove)
        {
            if (ministryName == "[1] Discipleship Ministry")
            {
                return discipleshipSchedules.Remove(toRemove);
            }
            else if (ministryName == "[2] Prayer Ministry")
            {
                return prayerSchedules.Remove(toRemove);
            }
            else if (ministryName == "[3] Worship Ministry")
            {
                return worshipSchedules.Remove(toRemove);
            }
            else if (ministryName == "[4] Christian Education")
            {
                return christianEdTeachers.Remove(toRemove);
            }
            else
            {
                return false;
            }
        }   

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

        public static bool AddConfirmedSchedule(string ministryName, string schedule)
        {
            switch (ministryName)
            {
                case "[1] Discipleship Ministry":
                    discipleshipSchedules.Add(schedule);
                    return true;
                case "[2] Prayer Ministry":
                    prayerSchedules.Add(schedule);
                    return true;
                case "[3] Worship Ministry":
                    worshipSchedules.Add(schedule);
                    return true;
                case "[4] Christian Education":
                    christianEdTeachers.Add(schedule);
                    return true;
                default:
                    return false;
            }
        }
        public static bool ProcessingType1Scheduling(string ministryName, int day, string speaker, string presider, string description)
        {
            
            string schedule = $"April {day}, 2025\nSpeaker: {speaker}\nPresider: {presider}\nDescription: {description}";
            return AddConfirmedSchedule(ministryName, schedule);
        }

        public static bool ProcessingType2Scheduling(string ministryName, int userChoice, string field1, string field2, string day1, string time1, string day2 = "", string time2 = "")
        {
            //string schedule = $"April {day}, 2025\nSpeaker: {speaker}\nPresider: {presider}\nDescription: {description}";
            string schedule = " ";
            if (userChoice == 2)
            {
                schedule = $"Song Leader: {field1}\nDate (First Rehearsal): {day1}\nTime (Time): {time1}\nDate (Final Rehearsal): {day2}\nTime (Time): {time2}";
            }
            else if (userChoice == 3)
            {
                schedule = $"Speaker: {field1}\nPresider: {field2}\nDate: {day1}\nTime: {time1}";
            }
            return AddConfirmedSchedule(ministryName, schedule);
        }

        public static bool ProcessingTeachersList(string ministryName, string name)
        {
            return AddConfirmedSchedule(ministryName, name);
        }








        //topic business logic

        public static List<string> ViewTopicList(string ministryName)
        {
            if (ministryName == "[1] Discipleship Ministry")
            {
                return discipleshipTopics;
            }
            else if (ministryName == "[2] Prayer Ministry")
            {
                return prayerRequest;
            }
            else if (ministryName == "[3] Worship Ministry")
            {
                return worshipRepertoire;
            }
            else if (ministryName == "[4] Christian Education")
            {
                return christianEdTopics;
            }
            else
            {
                return new List<string>();
            }
        }
        public static bool RemoveTopics(string ministryName, string toRemove)
        {
            if (ministryName == "[1] Discipleship Ministry")
            {
                return discipleshipTopics.Remove(toRemove);
            }
            else if (ministryName == "[2] Prayer Ministry")
            {
                return prayerRequest.Remove(toRemove);
            }
            else if (ministryName == "[3] Worship Ministry")
            {
                return worshipRepertoire.Remove(toRemove);
            }
            else if (ministryName == "[4] Christian Education")
            {
                return christianEdTopics.Remove(toRemove);
            }
            else
            {
                return false;
            }
        }
        public static bool AddConfirmedTopics(string ministryName, string schedule)
        {
            switch (ministryName)
            {
                case "[1] Discipleship Ministry":
                    discipleshipTopics.Add(schedule);
                    return true;
                case "[2] Prayer Ministry":
                    prayerRequest.Add(schedule);
                    return true;
                case "[3] Worship Ministry":
                    worshipRepertoire.Add(schedule);
                    return true;
                case "[4] Christian Education":
                    christianEdTopics.Add(schedule);
                    return true;
                default:
                    return false;
            }
        }
        public static bool ProcessingTopicTypes1(string ministryName, string details)
        {
            return AddConfirmedTopics(ministryName, details);
        }
    }
}