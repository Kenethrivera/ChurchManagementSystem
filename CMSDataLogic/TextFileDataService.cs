using CMSAccounts;
using CMSSchedules;
using System;
using System.Globalization;
using System.Reflection;


namespace CMSDataLogic
{
    public class TextFileDataService : IMinistriesDataService
    {
        string adminAccFilePath = "adminAccounts.txt";
        string regularAccFilePath = "regularAccounts.txt";
        string devotionScheduleFilePath = "devotionSchedule.txt";
        string discipleshipScheduleFilePath = "discipleshipSchedule.txt";
        string praiseAndWorshipScheduleFilePath = "praiseAndWorshipSchedule.txt";
        string sundayWorshipServiceFilePath = "sundayWorshipSchedule.txt";
        string prayerMeetingFilePath = "prayerMeeting.txt";
        string lessonFilePath = "lesson.txt";
        string teachersFilePath = "teacher.txt";

        private List<UserAccounts> regularAccounts = new List<UserAccounts>();
        private List<UserAccounts> adminAccounts = new List<UserAccounts>();

        private List<DiscipleshipMinistry> discipleshipSchedules = new List<DiscipleshipMinistry>();
        private List<PrayerMinistry> prayerSchedules = new List<PrayerMinistry>();
        private List<SundayWorshipService> sundayWorshipSchedules = new List<SundayWorshipService>();
        private List<PraiseAndWorship> praiseAndWorshipSchedules = new List<PraiseAndWorship>();
        private List<Devotion> devotionSchedules = new List<Devotion>();
        private List<TeachersList> teachersList = new List<TeachersList>();
        private List<Lesson> lessonsList = new List<Lesson>();

        public TextFileDataService()
        {
            GetAdminAccount();
            GetRegularAccount();
        }
        private void LoadDevotionSched()
        {
            devotionSchedules.Clear();

            var lines = File.ReadAllLines(devotionScheduleFilePath);

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                var parts = line.Split('|');

                if (DateTime.TryParseExact(parts[0].Trim(), "MM-dd-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
                {
                    devotionSchedules.Add(new Devotion
                    {
                        Date = parsedDate,
                        SongLeader = parts[1],
                        Presider = parts[2],
                        Speaker = parts[3]
                    });
                }
                else
                {
                    Console.WriteLine($"Invalid date format found in line: {line}");
                }
            }
        }
        private void LoadDiscipleshipSched()
        {
            discipleshipSchedules.Clear();

            var lines = File.ReadAllLines(discipleshipScheduleFilePath);

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                var parts = line.Split('|');

                if (DateTime.TryParseExact(parts[0].Trim(), "MM-dd-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
                {
                    discipleshipSchedules.Add(new DiscipleshipMinistry
                    {
                        Date = parsedDate,
                        Speaker = parts[1],
                        Description = parts[2],
                        Note = parts[3],

                    });
                }
                else
                {
                    Console.WriteLine($"Invalid date format found in line: {line}");
                }

                
            }
        }
        private void LoadLessonList()
        {
            lessonsList.Clear();

            var lines = File.ReadAllLines(lessonFilePath);

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                var parts = line.Split('|');

                if (DateTime.TryParseExact(parts[0].Trim(), "MM-dd-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
                {
                    lessonsList.Add(new Lesson
                    {
                        Date = parsedDate,
                        Lessson = parts[1],
                        Materials = parts[2]
                    });
                }
                else
                {
                    Console.WriteLine($"Invalid date format found in line: {line}");
                }
            }
        }
        private void LoadTeachersList()
        {
            teachersList.Clear();
            
            var lines = File.ReadAllLines(teachersFilePath);

            foreach (var line in lines)
            {
                var parts = line.Split('|');

                teachersList.Add(new TeachersList
                {
                    TeachersName = parts[0],
                    Assignment = parts[1]
                });
            }

        }
        private void LoadPrayerSched()
        {
            prayerSchedules.Clear();

            var lines = File.ReadAllLines(prayerMeetingFilePath);

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                var parts = line.Split('|');
                if (DateTime.TryParseExact(parts[0].Trim(), "MM-dd-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
                {

                    prayerSchedules.Add(new PrayerMinistry
                    {
                        Date = parsedDate,
                        SongLeader = parts[1],
                        Presider = parts[2],
                        Speaker = parts[3],
                        PrayerItem = parts[4]
                    });
                }
                else
                {
                    Console.WriteLine($"Invalid date format found in line: {line}");
                }

            }

        }
        private void LoadPraiseAndWorshipSched()
        {
            praiseAndWorshipSchedules.Clear();

            var lines = File.ReadAllLines(praiseAndWorshipScheduleFilePath);

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                var parts = line.Split('|');

                if (DateTime.TryParseExact(parts[0].Trim(), "MM-dd-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
                {
                    praiseAndWorshipSchedules.Add(new PraiseAndWorship
                    {
                        Date = parsedDate,
                        SongLeader = parts[1],
                        Instrumentalist = parts[2]
                    });
                }
                else
                {
                    Console.WriteLine($"Invalid date format found in line: {line}");
                } 
            }
        }
        private void LoadSundayWorshipSched()
        {
            sundayWorshipSchedules.Clear();

            var lines = File.ReadAllLines(sundayWorshipServiceFilePath);

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                var parts = line.Split('|');

                if (DateTime.TryParseExact(parts[0].Trim(), "MM-dd-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
                {
                    sundayWorshipSchedules.Add(new SundayWorshipService
                    {
                        Date = parsedDate,
                        Presider = parts[1],
                        Speaker = parts[2],
                        Flowers = parts[3],
                        Ushers = parts[4]
                    });
                }
                else
                {
                    Console.WriteLine($"Invalid date format found in line: {line}");
                }
            }
        }
        private void GetAdminAccount()
        {
            adminAccounts.Clear();
            try
            {
                if (File.Exists(adminAccFilePath))
                {
                    var lines = File.ReadAllLines(adminAccFilePath);
                    foreach (var line in lines)
                    {
                        if (!string.IsNullOrWhiteSpace(line))
                        {
                            var parts = line.Split(',');
                            if (parts.Length >= 8)
                            {
                                adminAccounts.Add(new UserAccounts
                                {
                                    FirstName = parts[0].Trim(),
                                    LastName = parts[1].Trim(),
                                    Age = Convert.ToInt16(parts[2].Trim()),
                                    EmailAddress = parts[3].Trim(),
                                    MinistryName = parts[4].Trim(),
                                    Position = parts[5].Trim(),
                                    UserName = parts[6].Trim(),
                                    Password = parts[7].Trim()
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading admin accounts: {ex.Message}");
            }
        }
        private void GetRegularAccount()
        {
            try
            {
                if (File.Exists(regularAccFilePath))
                {
                    var lines = File.ReadAllLines(regularAccFilePath);
                    foreach (var line in lines)
                    {
                        if (!string.IsNullOrWhiteSpace(line))
                        {
                            var parts = line.Split('|');
                            if (parts.Length >= 6)
                            {
                                regularAccounts.Add(new UserAccounts
                                {
                                    FirstName = parts[0].Trim(),
                                    LastName = parts[1].Trim(),
                                    Age = Convert.ToInt16(parts[2].Trim()),
                                    EmailAddress = parts[3].Trim(),
                                    Position = "Member",           
                                    UserName = parts[4].Trim(),
                                    Password = parts[5].Trim()
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                Console.WriteLine($"Error reading regular accounts: {ex.Message}");
            }
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
        public bool RegularUserAccounts(UserAccounts userAccounts)
        {
            try
            {
                var newlines = $"{userAccounts.FirstName}|{userAccounts.LastName}|{userAccounts.Age}|{userAccounts.EmailAddress}|{userAccounts.EmailAddress}|{userAccounts.Password}";
                File.AppendAllText(regularAccFilePath, newlines + Environment.NewLine);
                return true;
            }
            catch
            {
                return false;
            }
        }
        private bool AppendLineToFile(string filePath, string line)
        {
            try
            {
                File.AppendAllText(filePath, line + Environment.NewLine);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool AddDevotionSchedule(Devotion devotionSched)
        {
            var newLines = $"{devotionSched.Date.ToString("MM-dd-yyyy")}|{devotionSched.SongLeader}|{devotionSched.Presider}|{devotionSched.Speaker}";
            return AppendLineToFile(devotionScheduleFilePath, newLines);
        }
        public bool AddDiscipleshipSchedule(DiscipleshipMinistry discipleshipSched)
        {
            var newLines = $"{discipleshipSched.Date.ToString("MM-dd-yyyy")}|{discipleshipSched.Speaker}|{discipleshipSched.Description}|{discipleshipSched.Note}";
            return AppendLineToFile(discipleshipScheduleFilePath, newLines);
        }
        public bool AddLesson(Lesson lessonsLists)
        {
            var newLines = $"{lessonsLists.Date.ToString("MM-dd-yyyy")}|{lessonsLists.Lessson}|{lessonsLists.Materials}";
            return AppendLineToFile(lessonFilePath, newLines);
        }
        public bool AddPraiseAndWorshipSchedule(PraiseAndWorship praiseAndWorshipSched)
        {
            var newLines = $"{praiseAndWorshipSched.Date.ToString("MM-dd-yyyy")}|{praiseAndWorshipSched.SongLeader}|{praiseAndWorshipSched.Instrumentalist}";
            return AppendLineToFile(praiseAndWorshipScheduleFilePath, newLines);
        }
        public bool AddPrayerSchedule(PrayerMinistry prayerSched)
        {
            var newLines = $"{prayerSched.Date.ToString("MM-dd-yyyy")}|{prayerSched.SongLeader}|{prayerSched.Presider}|{prayerSched.Speaker}|{prayerSched.PrayerItem}";
            return AppendLineToFile(prayerMeetingFilePath, newLines);
        }
        public bool AddSundayWorshipSchedule(SundayWorshipService sundayWorshipSched)
        {
            var newLines = $"{sundayWorshipSched.Date.ToString("MM-dd-yyyy")}|{sundayWorshipSched.Presider}|{sundayWorshipSched.Speaker}|{sundayWorshipSched.Flowers}|{sundayWorshipSched.Ushers}";
            return AppendLineToFile(sundayWorshipServiceFilePath, newLines);
        }
        public bool AddTeachers(TeachersList teachersList)
        {
            var newLines = $"{teachersList.TeachersName}|{teachersList.Assignment}";
            return AppendLineToFile(teachersFilePath, newLines);
        }
        public bool AdminAccounts(UserAccounts adminAccounts)
        {
            try
            {
                var newlines = $"{adminAccounts.FirstName},{adminAccounts.LastName},{adminAccounts.Age},{adminAccounts.EmailAddress},{adminAccounts.MinistryName},{adminAccounts.Position},{adminAccounts.UserName},{adminAccounts.Password}";
                File.AppendAllText(adminAccFilePath, newlines + Environment.NewLine);
                GetAdminAccount();
                return true;
            }
            catch
            {
                return false;
            }

        }
        private void WriteDevotionSchedToFile()
        {
            var lines = new string[devotionSchedules.Count];

            for (int i = 0; i < devotionSchedules.Count; i++)
            {
                lines[i] = $"{devotionSchedules[i].Date.ToString("MM-dd-yyyy")}|{devotionSchedules[i].Presider}|{devotionSchedules[i].Speaker}";
            }

            File.WriteAllLines(devotionScheduleFilePath, lines);
        }
        private void WriteDiscipleshipSchedToFile()
        {
            var lines = new string[discipleshipSchedules.Count];

            for (int i = 0; i < discipleshipSchedules.Count; i++)
            {
                lines[i] = $"{discipleshipSchedules[i].Date.ToString("MM-dd-yyyy")}|{discipleshipSchedules[i].Speaker}|{discipleshipSchedules[i].Description}| {discipleshipSchedules[i].Note}";
            }

            File.WriteAllLines(discipleshipScheduleFilePath, lines);
        }
        private void WriteLessonToFile()
        {
            var lines = new string[lessonsList.Count];

            for (int i = 0; i < lessonsList.Count; i++)
            {
                lines[i] = $"{lessonsList[i].Date.ToString("MM-dd-yyyy")}|{lessonsList[i].Lessson}|{lessonsList[i].Materials}";
            }

            File.WriteAllLines(lessonFilePath, lines);
        }
        private void WritePraiseAndWorshipToFile()
        {
            var lines = new string[praiseAndWorshipSchedules.Count];

            for (int i = 0; i < praiseAndWorshipSchedules.Count; i++)
            {
                lines[i] = $"{praiseAndWorshipSchedules[i].Date.ToString("MM-dd-yyyy")}|{praiseAndWorshipSchedules[i].SongLeader}|{praiseAndWorshipSchedules[i].Instrumentalist}";
            }

            File.WriteAllLines(praiseAndWorshipScheduleFilePath, lines);
        }
        private void WritePrayerToFile()
        {
            var lines = new string[prayerSchedules.Count];

            for (int i = 0; i < prayerSchedules.Count; i++)
            {
                lines[i] = $"{prayerSchedules[i].Date.ToString("MM-dd-yyyy")}|{prayerSchedules[i].SongLeader}|{prayerSchedules[i].Presider}|{prayerSchedules[i].Speaker}|{prayerSchedules[i].PrayerItem}";
            }

            File.WriteAllLines(prayerMeetingFilePath, lines);
        }
        private void WriteSundayWorshipToFile()
        {
            var lines = new string[sundayWorshipSchedules.Count];

            for (int i = 0; i < sundayWorshipSchedules.Count; i++)
            {
                lines[i] = $"{sundayWorshipSchedules[i].Date.ToString("MM-dd-yyyy")}|{sundayWorshipSchedules[i].Presider}|{sundayWorshipSchedules[i].Speaker}|{sundayWorshipSchedules[i].Flowers}|{sundayWorshipSchedules[i].Ushers}";
            }

            File.WriteAllLines(sundayWorshipServiceFilePath, lines);
        }
        private void WriteTeacherToFile()
        {
            var lines = new string[teachersList.Count];

            for (int i = 0; i < teachersList.Count; i++)
            {
                lines[i] = $"{teachersList[i].TeachersName}|{teachersList[i].Assignment}";
            }

            File.WriteAllLines(teachersFilePath, lines);
        }
        public bool RemoveDevotionSchedule(Devotion toDelete)
        {
            LoadDevotionSched();
            for (int i = 0; i < devotionSchedules.Count; i++)
            {
                if (devotionSchedules[i].Date.Date == toDelete.Date.Date)
                {
                    devotionSchedules.RemoveAt(i);
                    WriteDevotionSchedToFile();
                    return true;
                }
            }
            return false;
        }
        public bool RemoveDiscipleshipSchedule(DiscipleshipMinistry toDelete)
        {
            LoadDiscipleshipSched();
            for (int i = 0; i < discipleshipSchedules.Count; i++)
            {
                if (discipleshipSchedules[i].Date.Date == toDelete.Date.Date)
                {
                    discipleshipSchedules.RemoveAt(i);
                    WriteDiscipleshipSchedToFile();
                    return true;
                }
            }
            return false;
        }
        public bool RemoveLesson(Lesson toDelete)
        {
            LoadLessonList();
            for (int i = 0; i < lessonsList.Count; i++)
            {
                if (lessonsList[i].Date.Date == toDelete.Date.Date)
                {
                    lessonsList.RemoveAt(i);
                    WriteLessonToFile();
                    return true;
                }
            }
            return false;
        }
        public bool RemovePraiseAndWorshipSchedule(PraiseAndWorship toDelete)
        {
            LoadPraiseAndWorshipSched();
            for (int i = 0; i < praiseAndWorshipSchedules.Count; i++)
            {
                if (praiseAndWorshipSchedules[i].Date.Date == toDelete.Date.Date)
                {
                    praiseAndWorshipSchedules.RemoveAt(i);
                    WritePraiseAndWorshipToFile();
                    return true;
                }
            }
            return false;

        }
        public bool RemovePrayerSchedule(PrayerMinistry toDelete)
        {
            LoadPrayerSched();
            for (int i = 0; i < prayerSchedules.Count; i++)
            {
                if (prayerSchedules[i].Date.Date == toDelete.Date.Date)
                {
                    prayerSchedules.RemoveAt(i);
                }
            }
            WritePrayerToFile();
            return true;
        }
        public bool RemoveSundayWorshipSched(SundayWorshipService toDelete)
        {
            LoadSundayWorshipSched();
            for (int i = 0; i < sundayWorshipSchedules.Count; i++)
            {
                if (sundayWorshipSchedules[i].Date.Date == toDelete.Date.Date)
                {
                    sundayWorshipSchedules.RemoveAt(i);
                    WriteSundayWorshipToFile();
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
                    WriteTeacherToFile();
                    return true;
                }
            }
            return false;
        }
        public List<Devotion> ViewDevotionSchedule()
        {
            LoadDevotionSched();
            return devotionSchedules;
        }
        public List<DiscipleshipMinistry> ViewDiscipleshipSchedule()
        {
            LoadDiscipleshipSched();
            return discipleshipSchedules;
        }
        public List<Lesson> ViewLessons()
        {
            LoadLessonList();
            return lessonsList;
        }
        public List<PraiseAndWorship> ViewPraiseAndWorshipSchedule()
        {
            LoadPraiseAndWorshipSched();
            return praiseAndWorshipSchedules;
        }
        public List<PrayerMinistry> ViewPrayerMeetingSchedule()
        {
            LoadPrayerSched();
            return prayerSchedules;
        }
        public List<SundayWorshipService> ViewSundayWorshipSched()
        {
            LoadSundayWorshipSched();
            return sundayWorshipSchedules;
        }
        public List<TeachersList> ViewTeachersList()
        {
            LoadTeachersList();
            return teachersList;
        }

        public bool UpdateDiscipleshipSchedule(DiscipleshipMinistry update)
        {
            string[] lines = File.ReadAllLines(discipleshipScheduleFilePath);

            bool updated = false;
            for (int i = 0; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split("|");
                if (DateTime.Parse(parts[0]).Date == update.Date.Date)
                {
                    lines[i] = $"{update.Date.ToString("MM-dd-yyyy")}|{update.Speaker}|{update.Description}|{update.Note}";
                    updated = true;
                    break;
                }
            }
            if (updated)
            {
                File.WriteAllLines(discipleshipScheduleFilePath, lines);
                return true;
            }
            return false;
        }
        public bool UpdatePrayerSchedule(PrayerMinistry update)
        {
            string[] lines = File.ReadAllLines(prayerMeetingFilePath);

            bool updated = false;
            for (int i = 0; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split("|");
                if (DateTime.Parse(parts[0]).Date == update.Date.Date)
                {
                    lines[i] = $"{update.Date.ToString("MM-dd-yyyy")}|{update.SongLeader}|{update.Presider}|{update.Speaker}|{update.PrayerItem}";
                    updated = true;
                    break;
                }
            }
            if (updated)
            {
                File.WriteAllLines(prayerMeetingFilePath, lines);
                return true;
            }
            return false;
        }
        public bool UpdatePraiseAndWorshipSchedule(PraiseAndWorship update)
        {
            string[] lines = File.ReadAllLines(praiseAndWorshipScheduleFilePath);

            bool updated = false;
            for (int i = 0; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split("|");
                if (DateTime.Parse(parts[0]).Date == update.Date.Date)
                {
                    string instrumentalist = parts.Length > 2 ? parts[2] : "";
                    lines[i] = $"{update.Date.ToString("MM-dd-yyyy")}|{update.SongLeader}|{instrumentalist}";
                    updated = true;
                    break;
                }
            }
            if (updated)
            {
                File.WriteAllLines(praiseAndWorshipScheduleFilePath, lines);
                return true;
            }
            return false;
        }
        public bool UpdateSundayWorshipSchedule(SundayWorshipService update)
        {
            string[] lines = File.ReadAllLines(sundayWorshipServiceFilePath);

            bool updated = false;
            for (int i = 0; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split("|");
                if (DateTime.Parse(parts[0]).Date == update.Date.Date)
                {
                    lines[i] = $"{update.Date.ToString("MM-dd-yyyy")}|{update.Presider}|{update.Speaker}|{update.Flowers}|{update.Ushers}";
                    updated = true;
                    break;
                }
            }
            if (updated)
            {
                File.WriteAllLines(sundayWorshipServiceFilePath, lines);
                return true;
            }
            return false;
        }
        public bool UpdateDevotionSchedule(Devotion update)
        {
            string[] lines = File.ReadAllLines(devotionScheduleFilePath);

            bool updated = false;
            for (int i = 0; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split("|");
                if (DateTime.Parse(parts[0]).Date == update.Date.Date)
                {
                    lines[i] = $"{update.Date.ToString("MM-dd-yyyy")}|{update.SongLeader}|{update.Presider}|{update.Speaker}";
                    updated = true;
                    break;
                }
            }
            if (updated)
            {
                File.WriteAllLines(devotionScheduleFilePath, lines);
                return true;
            }
            return false;
        }
        public bool UpdateTeachers(TeachersList update)
        {
            string[] lines = File.ReadAllLines(teachersFilePath);

            bool updated = false;
            for (int i = 0; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split("|");
                if (parts[0].Equals(update.TeachersName))
                {
                    lines[i] = $"{update.TeachersName}|{update.Assignment}";
                    updated = true;
                    break;
                }
            }
            if (updated)
            {
                File.WriteAllLines(teachersFilePath, lines);
                return true;
            }
            return false;
        }
        public bool UpdateLesson(Lesson update)
        {
            string[] lines = File.ReadAllLines(lessonFilePath);

            bool updated = false;
            for (int i = 0; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split("|");
                if (DateTime.Parse(parts[0]).Date == update.Date.Date)
                {
                    lines[i] = $"{update.Date.ToString("MM-dd-yyyy")}|{update.Lessson}|{update.Materials}";
                    updated = true;
                    break;
                }
            }
            if (updated)
            {
                File.WriteAllLines(lessonFilePath, lines);
                return true;
            }
            return false;
        }
    }
}