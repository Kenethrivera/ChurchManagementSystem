using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using CMSAccounts;
using CMSSchedules;
using CMSTopics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CMSDataLogic
{

    public class CMSDataProcess
    {
        private List<UserAccounts> regularAccounts = new List<UserAccounts>();
        private List<UserAccounts> adminAccounts = new List<UserAccounts>();
        UserAccounts userAccount = new UserAccounts();

        private List<DiscipleshipMinistry> discipleshipSchedules = new List<DiscipleshipMinistry>();
        private List<PrayerMinistry> prayerSchedules = new List<PrayerMinistry>();
        private List<WorshipMinistry> sundayWorshipSchedules = new List<WorshipMinistry>();
        private List<WorshipMinistry> praiseAndWorshipSchedules = new List<WorshipMinistry>();
        private List<WorshipMinistry> devotionSchedules = new List<WorshipMinistry>();
        private List<ChristianEducation> christianEducationList = new List<ChristianEducation>();

        private List<DiscipleshipTopics> discipleshipTopics = new List<DiscipleshipTopics>();
        private List<PrayerMinistryTopics> prayerRequest = new List<PrayerMinistryTopics>();
        private List<WorshipMinistryTopics> repertoires = new List<WorshipMinistryTopics>();
        private List<ChristianEducationTopics> lessons = new List<ChristianEducationTopics>();

        public void RegularUserAccounts(string firstName, string lastName, int age, string emailAddress, string userName, string passWord)
        {
            UserAccounts regular = new UserAccounts();  
            regular.FirstName = firstName;
            regular.LastName = lastName;
            regular.Age = age;
            regular.EmailAddress = emailAddress;
            regular.UserName = userName;
            regular.Password = passWord;
            regular.MinistryName = "N/A";
            regular.Position = "Regular User";
            regularAccounts.Add(regular);
        }

        public void AdminAccounts (string firstName, string lastName, int age, string emailAddress, string ministryName, string position, string userName, string passWord)
        {
            UserAccounts adminAccount = new UserAccounts();
            adminAccount.FirstName = firstName;
            adminAccount.LastName = lastName;
            adminAccount.Age = age;
            adminAccount.MinistryName = ministryName;
            adminAccount.Position = position;
            adminAccount.UserName = userName;
            adminAccount.Password = passWord;
            adminAccounts.Add(adminAccount);
        }

        public bool ValidatingRegisteredUser(string username, string password, bool isAdmin)
        {
            if (isAdmin)
            {
                foreach(UserAccounts user in adminAccounts)
                {
                    if(user.UserName == username && user.Password == password)
                    {
                        return true;
                    }   
                }
            } 
            else
            {
                foreach (UserAccounts user in regularAccounts)
                {
                    if (user.UserName == username && user.Password == password)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        
        //add logic for discipleship
        public void AddDiscipleshipSchedule(int date, string speaker , string presider, string description)
        {
            DiscipleshipMinistry schedule = new DiscipleshipMinistry();
            schedule.Date = date;
            schedule.Speaker = speaker;
            schedule.Presider = presider;
            schedule.Description = description;
            discipleshipSchedules.Add(schedule);
        }

        //view logic for Discipleship
        public string ViewDiscipleshipSchedule()
        {
            string result = "";
            for (int i = 0; i < discipleshipSchedules.Count; i++)
            {
                DiscipleshipMinistry schedule = discipleshipSchedules[i];
                result += "Schedule " + (i + 1) + ":\n";
                result += schedule.GetDiscipleshipScheduleDetails();
                result += "\n----------------------\n";
            }
            return result;
        }

        //delete logic in DiscipleshipSchedule
        public bool RemoveDiscipleshipSchedule(int index)
        {
            if(index >= 0  && index < discipleshipSchedules.Count)
            {
                discipleshipSchedules.RemoveAt(index);
                return true;
            }
            return false;
        }

        //add logic for Prayer
        public void AddPrayerSchedule(int date, string speaker, string presider, string description)
        {
            PrayerMinistry schedule = new PrayerMinistry();
            schedule.Date = date;
            schedule.Speaker = speaker;
            schedule.Presider = presider;
            schedule.Description = description;
            prayerSchedules.Add(schedule);
        }

        //view logic for prayer
        public string ViewPrayerSchedule()
        {
            string result = "";
            for (int i = 0; i < prayerSchedules.Count; i++)
            {
                PrayerMinistry schedule = prayerSchedules[i];
                result += "Schedule " + (i + 1) + ":\n";
                result += schedule.GetPrayerScheduleDetails();
                result += "\n----------------------\n";
            }
            return result;
        }

        //delete logic for prayer
        public bool RemovePrayerSchedule(int index)
        {
            if (index >= 0 && index < prayerSchedules.Count)
            {
                prayerSchedules.RemoveAt(index);
                return true;
            }
            return false;
        }

        public void AddSundayWorshipSchedule(int date, string speaker, string presider, string description)
        {
            WorshipMinistry schedule = new WorshipMinistry();
            schedule.Date = date;
            schedule.Speaker = speaker;
            schedule.Presider = presider;
            schedule.Description = description;
            sundayWorshipSchedules.Add(schedule);
        }

        public void AddPraiseAndWorshipSchedule(string songLeader, string firstRehearsalDate, string firstRehearsalTime, string finalRehearsalDate, string finalRehearsalTime)
        {
            WorshipMinistry schedule = new WorshipMinistry();
            schedule.SongLeader = songLeader;
            schedule.FirstRehearsalDate = firstRehearsalDate;
            schedule.FirstRehearsalTime = firstRehearsalTime;
            schedule.FinalRehearsalDate = finalRehearsalDate;
            schedule.FinalRehearsalTime = finalRehearsalTime;
            praiseAndWorshipSchedules.Add(schedule);
        }
        public void AddDevotionSchedules(string speaker, string presider, string devotionDate, string devotionTime)
        {
            WorshipMinistry schedule = new WorshipMinistry();
            schedule.DevotionSpeaker = speaker;
            schedule.DevotionPresider = presider;
            schedule.DevotionDate = devotionDate;
            schedule.DevotionTime = devotionTime;
            devotionSchedules.Add(schedule);
        }

        public string ViewSundayWorshipSchedule()
        {
            string result = "";
            for (int i = 0; i < sundayWorshipSchedules.Count; i++)
            {
                WorshipMinistry schedule = sundayWorshipSchedules[i];
                result += "Schedule " + (i + 1) + ":\n";
                result += schedule.GetSundayWorshipServiceDetails();
                result += "\n----------------------\n";
            }
            return result;
        }
        public string ViewPraiseAndWorshipDetails()
        {
            string result = "";
            for (int i = 0; i < praiseAndWorshipSchedules.Count; i++)
            {
                WorshipMinistry schedule = praiseAndWorshipSchedules[i];
                result += "Schedule " + (i + 1) + ":\n";
                result += schedule.GetPraiseAndWorshipDetails();
                result += "\n----------------------\n";
            }
            return result;
        }
        public string ViewDevotionDetails()
        {
            string result = "";
            for (int i = 0; i < devotionSchedules.Count; i++)
            {
                WorshipMinistry schedule = devotionSchedules[i];
                result += "Schedule " + (i + 1) + ":\n";
                result += schedule.GetDevotionDetails();
                result += "\n----------------------\n";
            }
            return result;
        }

        public bool RemoveSundayWorshipSchedule(int index)
        {
            if (index >= 0 && index < sundayWorshipSchedules.Count)
            {
                sundayWorshipSchedules.RemoveAt(index);
                return true;
            }
            return false;
        }
        public bool RemovePraiseAndWorshipSchedule(int index)
        {
            if (index >= 0 && index < praiseAndWorshipSchedules.Count)
            {
                praiseAndWorshipSchedules.RemoveAt(index);
                return true;
            }
            return false;
        }
        public bool RemoveDevotionSchedule(int index)
        {
            if (index >= 0 && index < devotionSchedules.Count)
            {
                devotionSchedules.RemoveAt(index);
                return true;
            }
            return false;
        }

        public void AddTeachersName(string teacherName)
        {
            ChristianEducation names = new ChristianEducation();
            names.TeachersName = teacherName;
            christianEducationList.Add(names);
        }
        public string ViewTeachersList()
        {
            string result = "";
            for (int i = 0; i < christianEducationList.Count; i++)
            {
                ChristianEducation names = christianEducationList[i];
                result += "Schedule " + (i + 1) + ":\n";
                result += names.GetTeachersList();
                result += "\n----------------------\n";
            }
            return result;
        }
        public bool RemoveTeachers(int index)
        {
            if (index >= 0 && index < christianEducationList.Count)
            {
                christianEducationList.RemoveAt(index);
                return true;
            }
            return false;
        }


        //topics
        public void AddDiscipleshipTopics(string topic, string description, string materials, string dateTime)
        {
            DiscipleshipTopics details = new DiscipleshipTopics();
            details.Topic = topic;
            details.Description = description;
            details.Materials = materials;
            details.DateTime = dateTime;
            discipleshipTopics.Add(details);
        }
        public string ViewDiscipleshipTopics()
        {
            string result = "";
            for (int i = 0; i < discipleshipTopics.Count; i++)
            {
                DiscipleshipTopics names = discipleshipTopics[i];
                result += "Details " + (i + 1) + ":\n";
                result += names.GetDiscipleshipTopicDetails();
                result += "\n----------------------\n";
            }
            return result;
        }
        public bool RemoveDiscipleshipTopics(int index)
        {
            if (index >= 0 && index < discipleshipTopics.Count)
            {
                discipleshipTopics.RemoveAt(index);
                return true;
            }
            return false;
        }

        public void AddPrayerRequest(string prayerRequests)
        {
            PrayerMinistryTopics details = new PrayerMinistryTopics();
            details.PrayerRequest = prayerRequests;
            prayerRequest.Add(details);
        }
        public string ViewPrayerRequest()
        {
            string result = "";
            for (int i = 0; i < prayerRequest.Count; i++)
            {
                PrayerMinistryTopics names = prayerRequest[i];
                result += "Prayer Request " + (i + 1) + ":\n";
                result += names.GetPrayerRequest();
                result += "\n----------------------\n";
            }
            return result;
        }
        public bool RemovePrayerRequest(int index)
        {
            if (index >= 0 && index < prayerRequest.Count)
            {
                prayerRequest.RemoveAt(index);
                return true;
            }
            return false;
        }
        public void AddRepertoire(string repertoire)
        {
            WorshipMinistryTopics details = new WorshipMinistryTopics();
            details.Repertoire = repertoire;
            repertoires.Add(details);
        }
        public string ViewRepertoire()
        {
            string result = "";
            for (int i = 0; i < repertoires.Count; i++)
            {
                WorshipMinistryTopics names = repertoires[i];
                result += "Repertoire " + (i + 1) + ":\n";
                result += names.GetRepertoire();
                result += "\n----------------------\n";
            }
            return result;
        }
        public bool RemoveRepertoire(int index)
        {
            if (index >= 0 && index < repertoires.Count)
            {
                repertoires.RemoveAt(index);
                return true;
            }
            return false;
        }



        public void AddLesson(string lesson)
        {
            ChristianEducationTopics details = new ChristianEducationTopics();
            details.Lesson = lesson;
            lessons.Add(details);
        }
        public string ViewLesson()
        {
            string result = "";
            for (int i = 0; i < lessons.Count; i++)
            {
                ChristianEducationTopics names = lessons[i];
                result += "Lesson " + (i + 1) + ":\n";
                result += names.GetLessonDetails();
                result += "\n----------------------\n";
            }
            return result;
        }
        public bool RemoveLessons(int index)
        {
            if (index >= 0 && index < lessons.Count)
            {
                lessons.RemoveAt(index);
                return true;
            }
            return false;
        }
    }

}
    

