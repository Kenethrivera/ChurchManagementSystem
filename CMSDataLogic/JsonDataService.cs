﻿using CMSAccounts;
using CMSSchedules;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CMSDataLogic
{
    public class JsonDataService : IMinistriesDataService
    {
        string adminAccFilePath = "adminAccounts.json";
        string regularAccFilePath = "regularAccounts.json";
        string devotionScheduleFilePath = "devotionSchedule.json";
        string discipleshipScheduleFilePath = "discipleshipSchedule.json";
        string praiseAndWorshipScheduleFilePath = "praiseAndWorshipSchedule.json";
        string sundayWorshipServiceFilePath = "sundayWorshipSchedule.json";
        string prayerItemFilePath = "prayerItem.json";
        string prayerMeetingFilePath = "prayerMeeting.json";
        string lessonFilePath = "lesson.json";
        string teachersFilePath = "teacher.json";

        private List<UserAccounts> regularAccounts = new List<UserAccounts>();
        private List<UserAccounts> adminAccounts = new List<UserAccounts>();

        private List<DiscipleshipMinistry> discipleshipSchedules = new List<DiscipleshipMinistry>();
        private List<PrayerMinistry> prayerSchedules = new List<PrayerMinistry>();
        private List<SundayWorshipService> sundayWorshipSchedules = new List<SundayWorshipService>();
        private List<PraiseAndWorship> praiseAndWorshipSchedules = new List<PraiseAndWorship>();
        private List<Devotion> devotionSchedules = new List<Devotion>();
        private List<TeachersList> teachersList = new List<TeachersList>();
        private List<Lesson> lessonsList = new List<Lesson>();

        public JsonDataService()
        {
            ReadAdminAccFromFile();
            //ReadRegularAccFromFile();
        }

        private void ReadAdminAccFromFile()
        {
            string adminJson = File.ReadAllText(adminAccFilePath);
            adminAccounts = JsonSerializer.Deserialize<List<UserAccounts>>(adminJson,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );
        }
        private void ReadRegularAccFromFile()
        {
            string userJson = File.ReadAllText(regularAccFilePath);
            regularAccounts = JsonSerializer.Deserialize<List<UserAccounts>>(userJson,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
           );
        }
        public string GetAdminMinistry(string username, string password)
        {
            foreach (var admin in adminAccounts)
            {
                if (admin.UserName.Equals(username, StringComparison.Ordinal) &&
                    admin.Password.Equals(password, StringComparison.Ordinal))
                {
                    return admin.MinistryName;
                }
            }

            return "No match account";
        }
        public string GetUserRole(string username, string password)
        {
            foreach (var admin in adminAccounts)
            {
                if (admin.UserName.Equals(username, StringComparison.Ordinal) &&
                    admin.Password.Equals(password, StringComparison.Ordinal))
                {
                    return "Admin";
                }
            }
            foreach (var user in regularAccounts)
            {
                if (user.UserName.Equals(username, StringComparison.Ordinal) &&
                    user.Password.Equals(password, StringComparison.Ordinal))
                {
                    return "User";
                }
            }

            return "No Account Match";
        }

        public void LoadDevotionSchedule()
        {
            var jsonText = File.ReadAllText(devotionScheduleFilePath);
            devotionSchedules = JsonSerializer.Deserialize<List<Devotion>>(jsonText,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
        public void LoadDiscpleshipSchedule()
        {
            var jsonText = File.ReadAllText(discipleshipScheduleFilePath);
            discipleshipSchedules = JsonSerializer.Deserialize<List<DiscipleshipMinistry>>(jsonText,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
        public void LoadLessons()
        {
            var jsonText = File.ReadAllText(lessonFilePath);
            lessonsList = JsonSerializer.Deserialize<List<Lesson>>(jsonText,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
        public void LoadPraiseAndWorshipSchedule()
        {
            var jsonText = File.ReadAllText(praiseAndWorshipScheduleFilePath);
            praiseAndWorshipSchedules = JsonSerializer.Deserialize<List<PraiseAndWorship>>(jsonText,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
        //public void LoadPrayerItems()
        //{
        //    var jsonText = File.ReadAllText(prayerItemFilePath);
        //    prayerSchedules = JsonSerializer.Deserialize<List<PrayerMinistry>>(jsonText,
        //        new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        //}
        public void LoadPrayerSchedule()
        {
            var jsonText = File.ReadAllText(prayerMeetingFilePath);
            prayerSchedules = JsonSerializer.Deserialize<List<PrayerMinistry>>(jsonText,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
        public void LoadSundayWorshipServiceSchdule()
        {
            var jsonText = File.ReadAllText(sundayWorshipServiceFilePath);
            sundayWorshipSchedules = JsonSerializer.Deserialize<List<SundayWorshipService>>(jsonText,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
        public void LoadTeachersList()
        {
            var jsonText = File.ReadAllText(teachersFilePath);
            teachersList = JsonSerializer.Deserialize<List<TeachersList>>(jsonText,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
        public bool AddDevotionSchedule(string date, string songLeader, string presider, string speaker)
        {
            try
            {
                if (File.Exists(devotionScheduleFilePath))
                {
                    string jsonText = File.ReadAllText(devotionScheduleFilePath);
                    devotionSchedules = JsonSerializer.Deserialize<List<Devotion>>(jsonText) ?? new();
                }
                var newSchedule = new Devotion
                {
                    Date = date,
                    SongLeader = songLeader,
                    Presider = presider,
                    Speaker = speaker
                };
                devotionSchedules.Add(newSchedule);
                    
                string jsonString = JsonSerializer.Serialize(devotionSchedules, new JsonSerializerOptions
                { WriteIndented = true });
                File.WriteAllText(devotionScheduleFilePath, jsonString);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool AddDiscipleshipSchedule(string date, string speaker, string description, string note)
        {
            try
            {
                if (File.Exists(discipleshipScheduleFilePath))
                {
                    string jsonText = File.ReadAllText(discipleshipScheduleFilePath);
                    discipleshipSchedules = JsonSerializer.Deserialize<List<DiscipleshipMinistry>>(jsonText) ?? new();
                }
                var newSchedule = new DiscipleshipMinistry
                {
                    Date = date,
                    Speaker = speaker,
                    Description = description,
                    Note = note
                };
                discipleshipSchedules.Add(newSchedule);
                    
                string jsonString = JsonSerializer.Serialize(discipleshipSchedules, new JsonSerializerOptions
                { WriteIndented = true });
                File.WriteAllText(discipleshipScheduleFilePath, jsonString);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool AddLesson(string date, string lesson, string materials)
        {
            try
            {
                if (File.Exists(lessonFilePath))
                {
                    string jsonText = File.ReadAllText(lessonFilePath);
                    lessonsList = JsonSerializer.Deserialize<List<Lesson>>(jsonText) ?? new();
                }
                var newSchedule = new Lesson
                {
                    Date = date,
                    Lessson = lesson,
                    Materials = materials
                };
                lessonsList.Add(newSchedule);

                string jsonString = JsonSerializer.Serialize(lessonsList, new JsonSerializerOptions
                { WriteIndented = true });
                File.WriteAllText(lessonFilePath, jsonString);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool AddPraiseAndWorshipSchedule(string date, string songLeader, string instrumentalist)
        {
            try
            {
                if (File.Exists(praiseAndWorshipScheduleFilePath))
                {
                    string jsonText = File.ReadAllText(praiseAndWorshipScheduleFilePath);
                    praiseAndWorshipSchedules = JsonSerializer.Deserialize<List<PraiseAndWorship>>(jsonText) ?? new();
                }
                var newSchedule = new PraiseAndWorship
                {
                    Date = date,
                    SongLeader = songLeader,
                    Instrumentalist = instrumentalist
                };
                praiseAndWorshipSchedules.Add(newSchedule);

                string jsonString = JsonSerializer.Serialize(praiseAndWorshipSchedules, new JsonSerializerOptions
                { WriteIndented = true });
                File.WriteAllText(praiseAndWorshipScheduleFilePath, jsonString);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool AddPrayerItem(string date, string prayerItem)
        {
            try
            {
                if (File.Exists(prayerItemFilePath))
                {
                    string jsonText = File.ReadAllText(prayerItemFilePath);
                    prayerSchedules = JsonSerializer.Deserialize<List<PrayerMinistry>>(jsonText) ?? new();
                }
                var newSchedule = new PrayerMinistry
                {
                    Date = date,
                    PrayerItem = prayerItem
                };
                prayerSchedules.Add(newSchedule);

                string jsonString = JsonSerializer.Serialize(prayerSchedules, new JsonSerializerOptions
                { WriteIndented = true });
                File.WriteAllText(prayerItemFilePath, jsonString);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool AddPrayerSchedule(string date, string songLeader, string presider, string speaker, string prayerItem)
        {
            try
            {
                if (File.Exists(prayerMeetingFilePath))
                {
                    string jsonText = File.ReadAllText(prayerMeetingFilePath);
                    prayerSchedules = JsonSerializer.Deserialize<List<PrayerMinistry>>(jsonText) ?? new();
                }
                var newSchedule = new PrayerMinistry
                {
                    Date = date,
                    SongLeader = songLeader,
                    Presider = presider,
                    Speaker = speaker,
                    PrayerItem = prayerItem
                };
                prayerSchedules.Add(newSchedule);

                string jsonString = JsonSerializer.Serialize(prayerSchedules, new JsonSerializerOptions
                { WriteIndented = true });
                File.WriteAllText(prayerMeetingFilePath, jsonString);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool AddSundayWorshipSchedule(string date, string presider, string speaker, string flowers, string ushers)
        {
            try
            {
                if (File.Exists(sundayWorshipServiceFilePath))
                {
                    string jsonText = File.ReadAllText(sundayWorshipServiceFilePath);
                    sundayWorshipSchedules = JsonSerializer.Deserialize<List<SundayWorshipService>>(jsonText) ?? new();
                }
                var newSchedule = new SundayWorshipService
                {
                    Date = date,
                    Presider = presider,
                    Speaker = speaker,
                    Flowers = flowers,
                    Ushers = ushers
                };
                sundayWorshipSchedules.Add(newSchedule);

                string jsonString = JsonSerializer.Serialize(sundayWorshipSchedules, new JsonSerializerOptions
                { WriteIndented = true });
                File.WriteAllText(sundayWorshipServiceFilePath, jsonString);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool AddTeachers(string name, string designation)
        {
            try
            {
                if (File.Exists(teachersFilePath))
                {
                    string jsonText = File.ReadAllText(teachersFilePath);
                    teachersList = JsonSerializer.Deserialize<List<TeachersList>>(jsonText) ?? new();
                }
                var newSchedule = new TeachersList
                {
                    TeachersName = name,
                    Assignment = designation
                };
                teachersList.Add(newSchedule);

                string jsonString = JsonSerializer.Serialize(teachersList, new JsonSerializerOptions
                { WriteIndented = true });
                File.WriteAllText(teachersFilePath, jsonString);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public void AdminAccounts(string firstName, string lastName, int age, string emailAddress, string ministryName, string position, string userName, string passWord)
        {
            if (File.Exists(adminAccFilePath))
            {
                string jsonText = File.ReadAllText(adminAccFilePath);
                adminAccounts = JsonSerializer.Deserialize<List<UserAccounts>>(jsonText) ?? new();
            }
            var newSchedule = new UserAccounts
            {
                FirstName = firstName,
                LastName = lastName,
                Age = age,
                EmailAddress = emailAddress,
                MinistryName = ministryName,
                Position = position,
                UserName = userName,
                Password = passWord
            };
            adminAccounts.Add(newSchedule);

            string jsonString = JsonSerializer.Serialize(adminAccounts, new JsonSerializerOptions
            { WriteIndented = true });
            File.WriteAllText(adminAccFilePath, jsonString); 
        }
        public void RegularUserAccounts(string firstName, string lastName, int age, string emailAddress, string userName, string passWord)
        {
            throw new NotImplementedException();
        }

        private void WriteDevotionDataToFile()
        {
            string jsonString = JsonSerializer.Serialize(devotionSchedules, new JsonSerializerOptions
            { WriteIndented = true });

            File.WriteAllText(devotionScheduleFilePath, jsonString);
        }
        private void WriteDiscipleshipDataToFile()
        {
            string jsonString = JsonSerializer.Serialize(discipleshipSchedules, new JsonSerializerOptions
            { WriteIndented = true });

            File.WriteAllText(discipleshipScheduleFilePath, jsonString);
        }
        private void WriteLessonDataToFile()
        {
            string jsonString = JsonSerializer.Serialize(lessonsList, new JsonSerializerOptions
            { WriteIndented = true });

            File.WriteAllText(lessonFilePath, jsonString);
        }
        private void WritePraiseAndWorshipDataToFile()
        {
            string jsonString = JsonSerializer.Serialize(praiseAndWorshipSchedules, new JsonSerializerOptions
            { WriteIndented = true });

            File.WriteAllText(praiseAndWorshipScheduleFilePath, jsonString);
        }
        private void WritePrayerScheduleDataToFile()
        {
            string jsonString = JsonSerializer.Serialize(prayerSchedules, new JsonSerializerOptions
            { WriteIndented = true });

            File.WriteAllText(prayerMeetingFilePath, jsonString);
        }
        private void WriteSundayWorshipDataToFile()
        {
            string jsonString = JsonSerializer.Serialize(sundayWorshipSchedules, new JsonSerializerOptions
            { WriteIndented = true });

            File.WriteAllText(sundayWorshipServiceFilePath, jsonString);
        }
        private void WriteTeachersDataToFile()
        {
            string jsonString = JsonSerializer.Serialize(teachersList, new JsonSerializerOptions
            { WriteIndented = true });

            File.WriteAllText(teachersFilePath, jsonString);
        }
        public bool RemoveDevotionSchedule(string date)
        {
            int index = -1;
            for (int i = 0; i < devotionSchedules.Count; i++)
            {
                if (devotionSchedules[i].Date == date)
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
            {
                return false;
            }
            devotionSchedules.RemoveAt(index);
            WriteDevotionDataToFile();
            return true;
        }
        public bool RemoveDiscipleshipSchedule(string date)
        {
            int index = -1;
            for (int i = 0; i < discipleshipSchedules.Count; i++)
            {
                if (discipleshipSchedules[i].Date == date)
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
            {
                return false;
            }
            discipleshipSchedules.RemoveAt(index);
            WriteDiscipleshipDataToFile();
            return true;
        }
        public bool RemoveLesson(string date)
        {
            int index = -1;
            for (int i = 0; i < lessonsList.Count; i++)
            {
                if (lessonsList[i].Date == date)
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
            {
                return false;
            }
            lessonsList.RemoveAt(index);
            WriteLessonDataToFile();
            return true;
        }
        public bool RemovePraiseAndWorshipSchedule(string date)
        {
            int index = -1;
            for (int i = 0; i < praiseAndWorshipSchedules.Count; i++)
            {
                if (praiseAndWorshipSchedules[i].Date == date)
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
            {
                return false;
            }
            praiseAndWorshipSchedules.RemoveAt(index);
            WritePraiseAndWorshipDataToFile();
            return true;
        }
        public bool RemovePrayerSchedule(string date)
        {
            int index = -1;
            for (int i = 0; i < prayerSchedules.Count; i++)
            {
                if (prayerSchedules[i].Date == date)
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
            {
                return false;
            }
            prayerSchedules.RemoveAt(index);
            WritePrayerScheduleDataToFile();
            return true;
        }
        public bool RemoveSundayWorshipSched(string date)
        {
            int index = -1;
            for (int i = 0; i < sundayWorshipSchedules.Count; i++)
            {
                if (sundayWorshipSchedules[i].Date == date)
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
            {
                return false;
            }
            sundayWorshipSchedules.RemoveAt(index);
            WriteSundayWorshipDataToFile();
            return true;
        }
        public bool RemoveTeacher(string name)
        {
            int index = -1;
            for (int i = 0; i < teachersList.Count; i++)
            {
                if (teachersList[i].TeachersName == name)
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
            {
                return false;
            }
            teachersList.RemoveAt(index);
            WriteTeachersDataToFile();
            return true;
        }
        public List<Devotion> ViewDevotionSchedule()
        {
            LoadDevotionSchedule();
            return devotionSchedules;
        }
        public List<DiscipleshipMinistry> ViewDiscipleshipSchedule()
        {
            LoadDiscpleshipSchedule();
            return discipleshipSchedules;
        }

        public List<Lesson> ViewLessons()
        {
            LoadLessons();
            return lessonsList;
        }

        public List<PraiseAndWorship> ViewPraiseAndWorshipSchedule()
        {
            LoadPraiseAndWorshipSchedule();
            return praiseAndWorshipSchedules;
        }

        public List<PrayerMinistry> ViewPrayerMeetingSchedule()
        {
            LoadPrayerSchedule();
            return prayerSchedules;
        }

        public List<SundayWorshipService> ViewSundayWorshipSched()
        {
            LoadSundayWorshipServiceSchdule();
            return sundayWorshipSchedules;
        }

        public List<TeachersList> ViewTeachersList()
        {
            LoadTeachersList();
            return teachersList;
        }
    }
}
