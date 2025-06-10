using CMSAccounts;
using CMSSchedules;
using System;
using System.Reflection;
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
            adminAccounts.Clear();
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
        public string GetAdminMinistry(UserAccounts loginAccounts)
        {
            foreach (var admin in adminAccounts)
            {
                if (admin.UserName.Equals(loginAccounts.UserName, StringComparison.Ordinal) &&
                    admin.Password.Equals(loginAccounts.Password, StringComparison.Ordinal))
                {
                    return admin.MinistryName;
                }
            }

            return "No match account";
        }
        public string GetUserRole(UserAccounts loginAccounts)
        {
            foreach (var admin in adminAccounts)
            {
                if (admin.UserName.Equals(loginAccounts.UserName, StringComparison.Ordinal) &&
                    admin.Password.Equals(loginAccounts.Password, StringComparison.Ordinal))
                {
                    return "Admin";
                }
            }
            foreach (var user in regularAccounts)
            {
                if (user.UserName.Equals(loginAccounts.UserName, StringComparison.Ordinal) &&
                    user.Password.Equals(loginAccounts.Password, StringComparison.Ordinal))
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
        public void LoadDiscipleshipSchedule()
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
        public bool AddDevotionSchedule(Devotion devotionSched)
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
                    Date = devotionSched.Date,
                    SongLeader = devotionSched.SongLeader,
                    Presider = devotionSched.Presider,
                    Speaker = devotionSched.Speaker
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
        public bool AddDiscipleshipSchedule(DiscipleshipMinistry discpleshipSched)
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
                    Date = discpleshipSched.Date,
                    Speaker = discpleshipSched.Speaker,
                    Description = discpleshipSched.Description,
                    Note = discpleshipSched.Note
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
        public bool AddLesson(Lesson lessonsLists)
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
                    Date = lessonsLists.Date,
                    Lessson = lessonsLists.Lessson,
                    Materials = lessonsLists.Materials
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
        public bool AddPraiseAndWorshipSchedule(PraiseAndWorship praiseAndWorshipSched)
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
                    Date = praiseAndWorshipSched.Date,
                    SongLeader = praiseAndWorshipSched.SongLeader,
                    Instrumentalist = praiseAndWorshipSched.Instrumentalist
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
        public bool AddPrayerSchedule(PrayerMinistry prayerSched)
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
                    Date = prayerSched.Date,
                    SongLeader = prayerSched.SongLeader,
                    Presider = prayerSched.Presider,
                    Speaker = prayerSched.Speaker,
                    PrayerItem = prayerSched.PrayerItem
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
        public bool AddSundayWorshipSchedule(SundayWorshipService sundayWorshipSched)
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
                    Date = sundayWorshipSched.Date,
                    Presider = sundayWorshipSched.Presider,
                    Speaker = sundayWorshipSched.Speaker,
                    Flowers = sundayWorshipSched.Flowers,
                    Ushers = sundayWorshipSched.Ushers
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
        public bool AddTeachers(TeachersList teachersLists)
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
                    TeachersName = teachersLists.TeachersName,
                    Assignment = teachersLists.Assignment
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
        public bool AdminAccounts(UserAccounts admin)
        {
            try
            {
                if (File.Exists(adminAccFilePath))
                {
                    string jsonText = File.ReadAllText(adminAccFilePath);
                    adminAccounts = JsonSerializer.Deserialize<List<UserAccounts>>(jsonText) ?? new();
                }
                var newAccounts = new UserAccounts
                {
                    FirstName = admin.FirstName,
                    LastName = admin.LastName,
                    Age = admin.Age,
                    EmailAddress = admin.EmailAddress,
                    MinistryName = admin.MinistryName,
                    Position = admin.Position,
                    UserName = admin.UserName,
                    Password = admin.Password
                };
                adminAccounts.Add(newAccounts);

                string jsonString = JsonSerializer.Serialize(adminAccounts, new JsonSerializerOptions
                { WriteIndented = true });
                File.WriteAllText(adminAccFilePath, jsonString);
                ReadAdminAccFromFile();
                return true;
            }
            catch
            {
                return false;
            }


        }
        public bool RegularUserAccounts(UserAccounts userAccounts)
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
        public bool RemoveDevotionSchedule(Devotion toDelete)
        {
            LoadDevotionSchedule();
            for (int i = 0; i < devotionSchedules.Count; i++)
            {
                if (devotionSchedules[i].Date.Date == toDelete.Date.Date)
                {
                    devotionSchedules.RemoveAt(i);
                    WriteDevotionDataToFile();
                    return true;
                }
            }
            return false;
        }
        public bool RemoveDiscipleshipSchedule(DiscipleshipMinistry toDelete)
        {
            LoadDiscipleshipSchedule();
            for (int i = 0; i < discipleshipSchedules.Count; i++)
            {
                if (discipleshipSchedules[i].Date.Date == toDelete.Date.Date)
                {
                    discipleshipSchedules.RemoveAt(i);
                    WriteDiscipleshipDataToFile();
                    return true;
                }
            }
            return false;
        }
        public bool RemoveLesson(Lesson toDelete)
        {
            LoadLessons();
            for (int i = 0; i < lessonsList.Count; i++)
            {
                if (lessonsList[i].Date.Date == toDelete.Date.Date)
                {
                    lessonsList.RemoveAt(i);
                    WriteLessonDataToFile();
                    return true;
                }
            }
            return false;
        }
        public bool RemovePraiseAndWorshipSchedule(PraiseAndWorship toDelete)
        {
            LoadPraiseAndWorshipSchedule();
            for (int i = 0; i < praiseAndWorshipSchedules.Count; i++)
            {
                if (praiseAndWorshipSchedules[i].Date.Date == toDelete.Date)
                {
                    praiseAndWorshipSchedules.RemoveAt(i);
                    WritePraiseAndWorshipDataToFile();
                    return true;
                }
            }
            return false;
           
        }
        public bool RemovePrayerSchedule(PrayerMinistry toDelete)
        {
            LoadPrayerSchedule();
            for (int i = 0; i < prayerSchedules.Count; i++)
            {
                if (prayerSchedules[i].Date.Date == toDelete.Date.Date)
                {
                    prayerSchedules.RemoveAt(i);
                    WritePrayerScheduleDataToFile();
                    return true;
                }
            }
            return false;
        }
        public bool RemoveSundayWorshipSched(SundayWorshipService toDelete)
        {
            LoadSundayWorshipServiceSchdule();
            for (int i = 0; i < sundayWorshipSchedules.Count; i++)
            {
                if (sundayWorshipSchedules[i].Date.Date == toDelete.Date.Date)
                {
                    sundayWorshipSchedules.RemoveAt(i);
                    WriteSundayWorshipDataToFile();
                    return true;
                }
            }
            return false;
        }
        public bool RemoveTeacher(TeachersList toDelete)
        {
            LoadTeachersList();
            for (int i = 0; i < teachersList.Count; i++)
            {
                if (teachersList[i].TeachersName == toDelete.TeachersName)
                {
                    teachersList.RemoveAt(i);
                    WriteTeachersDataToFile();
                    return true;
                }
            }
            return false;
        }
        public List<Devotion> ViewDevotionSchedule()
        {
            LoadDevotionSchedule();
            return devotionSchedules;
        }
        public List<DiscipleshipMinistry> ViewDiscipleshipSchedule()
        {
            LoadDiscipleshipSchedule();
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

        public bool UpdateDiscipleshipSchedule(DiscipleshipMinistry update)
        {
            string jsonFile = File.ReadAllText(discipleshipScheduleFilePath);
            discipleshipSchedules = JsonSerializer.Deserialize<List<DiscipleshipMinistry>>(jsonFile);

            bool updated = false;
            for (int i = 0; i < discipleshipSchedules.Count; i++)
            {
                if (discipleshipSchedules[i].Date.Date == update.Date.Date)
                {
                    discipleshipSchedules[i].Speaker = update.Speaker;
                    discipleshipSchedules[i].Description = update.Description;
                    discipleshipSchedules[i].Note = update.Note;
                    updated = true;
                    break;
                }
            }
            if (updated)
            {
                string updatedJson = JsonSerializer.Serialize(discipleshipSchedules, new JsonSerializerOptions{ WriteIndented = true });
                File.WriteAllText(discipleshipScheduleFilePath, updatedJson);
                return true;
            }
            return false;
        }
        public bool UpdatePrayerSchedule(PrayerMinistry update)
        {
            string jsonFile = File.ReadAllText(prayerMeetingFilePath);
            prayerSchedules = JsonSerializer.Deserialize<List<PrayerMinistry>>(jsonFile);

            bool updated = false;
            for (int i = 0; i < prayerSchedules.Count; i++)
            {
                if (prayerSchedules[i].Date.Date == update.Date.Date)
                {
                    prayerSchedules[i].SongLeader = update.SongLeader;
                    prayerSchedules[i].Presider = update.Presider;
                    prayerSchedules[i].Speaker = update.Speaker;
                    prayerSchedules[i].PrayerItem = update.PrayerItem;
                    updated = true;
                    break;
                }
            }
            if (updated)
            {
                string updatedJson = JsonSerializer.Serialize(prayerSchedules, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(prayerMeetingFilePath, updatedJson);
                return true;
            }
            return false;
        }
        public bool UpdatePraiseAndWorshipSchedule(PraiseAndWorship update)
        {
            string jsonFile = File.ReadAllText(praiseAndWorshipScheduleFilePath);
            praiseAndWorshipSchedules = JsonSerializer.Deserialize<List<PraiseAndWorship>>(jsonFile);

            bool updated = false;
            for (int i = 0; i < praiseAndWorshipSchedules.Count; i++)
            {
                if (praiseAndWorshipSchedules[i].Date.Date == update.Date.Date)
                {
                    praiseAndWorshipSchedules[i].SongLeader = update.SongLeader;
                    updated = true;
                    break;
                }
            }
            if (updated)
            {
                string updatedJson = JsonSerializer.Serialize(praiseAndWorshipSchedules, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(praiseAndWorshipScheduleFilePath, updatedJson);
                return true;
            }
            return false;
        }
        public bool UpdateSundayWorshipSchedule(SundayWorshipService update)
        {
            string jsonFile = File.ReadAllText(sundayWorshipServiceFilePath);
            sundayWorshipSchedules = JsonSerializer.Deserialize<List<SundayWorshipService>>(jsonFile);

            bool updated = false;
            for (int i = 0; i < sundayWorshipSchedules.Count; i++)
            {
                if (sundayWorshipSchedules[i].Date.Date == update.Date.Date)
                {
                    sundayWorshipSchedules[i].Presider = update.Presider;
                    sundayWorshipSchedules[i].Speaker = update.Speaker;
                    sundayWorshipSchedules[i].Flowers = update.Flowers;
                    sundayWorshipSchedules[i].Ushers = update.Ushers;
                    updated = true;
                    break;
                }
            }
            if (updated)
            {
                string updatedJson = JsonSerializer.Serialize(sundayWorshipSchedules, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(sundayWorshipServiceFilePath, updatedJson);
                return true;
            }
            return false;
        }
        public bool UpdateDevotionSchedule(Devotion update)
        {
            string jsonFile = File.ReadAllText(devotionScheduleFilePath);
            devotionSchedules = JsonSerializer.Deserialize<List<Devotion>>(jsonFile);

            bool updated = false;
            for (int i = 0; i < devotionSchedules.Count; i++)
            {
                if (devotionSchedules[i].Date.Date == update.Date.Date)
                {
                    devotionSchedules[i].SongLeader = update.SongLeader;
                    devotionSchedules[i].Presider = update.Presider;
                    devotionSchedules[i].Speaker = update.Speaker;
                    updated = true;
                    break;
                }
            }
            if (updated)
            {
                string updatedJson = JsonSerializer.Serialize(devotionSchedules, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(devotionScheduleFilePath, updatedJson);
                return true;
            }
            return false;
        }
        public bool UpdateTeachers(TeachersList update)
        {
            string jsonFile = File.ReadAllText(teachersFilePath);
            teachersList = JsonSerializer.Deserialize<List<TeachersList>>(jsonFile);

            bool updated = false;
            for (int i = 0; i < teachersList.Count; i++)
            {
                if (teachersList[i].TeachersName == update.TeachersName)
                {
                    teachersList[i].Assignment = update.Assignment;
                    updated = true;
                    break;
                }
            }
            if (updated)
            {
                string updatedJson = JsonSerializer.Serialize(teachersList, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(teachersFilePath, updatedJson);
                return true;
            }
            return false;
        }
        public bool UpdateLesson(Lesson update)
        {
            string jsonFile = File.ReadAllText(lessonFilePath);
            lessonsList = JsonSerializer.Deserialize<List<Lesson>>(jsonFile);

            bool updated = false;
            for (int i = 0; i < lessonsList.Count; i++)
            {
                if (lessonsList[i].Date.Date == update.Date.Date)
                {
                    lessonsList[i].Lessson = update.Lessson;
                    lessonsList[i].Materials = update.Materials;
                    updated = true;
                    break;
                }
            }
            if (updated)
            {
                string updatedJson = JsonSerializer.Serialize(lessonsList, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(lessonFilePath, updatedJson);
                return true;
            }
            return false;
        }
    }
}
