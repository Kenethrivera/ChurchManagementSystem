﻿using CMSAccounts;
using CMSSchedules;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        string prayerItemFilePath = "prayerItem.txt";
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
            var lines = File.ReadAllLines(devotionScheduleFilePath);

            foreach (var line in lines)
            {
                var parts = line.Split('|');

                devotionSchedules.Add(new Devotion
                {
                    Date = parts[0],
                    SongLeader = parts[1],
                    Presider = parts[2],
                    Speaker = parts[3]
                });
            }
        }
        private void LoadDiscipleshipSched()
        {
            var lines = File.ReadAllLines(devotionScheduleFilePath);

            foreach (var line in lines)
            {
                var parts = line.Split('|');

                discipleshipSchedules.Add(new DiscipleshipMinistry
                {
                    Date = parts[0],
                    Speaker = parts[1],
                    Description = parts[2],
                    Note  = parts[3],

                });
            }
        }
        private void LoadLessonList()
        {
            var lines = File.ReadAllLines(lessonFilePath);

            foreach (var line in lines)
            {
                var parts = line.Split('|');

                lessonsList.Add(new Lesson
                {
                    Date = parts[0],
                    Lessson = parts[1],
                    Materials = parts[2]
                });
            }
        }
        private void LoadTeachersList()
        {
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
            var lines = File.ReadAllLines(prayerMeetingFilePath);

            foreach (var line in lines)
            {
                var parts = line.Split('|');

                prayerSchedules.Add(new PrayerMinistry
                {
                    Date = parts[0],
                    SongLeader = parts[1],
                    Presider = parts[2],
                    Speaker = parts[3]
                });
            }

        }
        private void LoadPraiseAndWorshipSched()
        {
            var lines = File.ReadAllLines(praiseAndWorshipScheduleFilePath);

            foreach (var line in lines)
            {
                var parts = line.Split('|');

                praiseAndWorshipSchedules.Add(new PraiseAndWorship
                {
                    Date = parts[0],
                    SongLeader = parts[1],
                    Instrumentalist = parts[2]
                });
            }
        }
        private void LoadSundayWorshipSched()
        {
            var lines = File.ReadAllLines(sundayWorshipServiceFilePath);

            foreach (var line in lines)
            {
                var parts = line.Split('|');

                sundayWorshipSchedules.Add(new SundayWorshipService
                {
                    Date = parts[0],
                    Presider = parts[1],
                    Speaker = parts[2],
                    Flowers = parts[3],
                    Ushers = parts[4]
                });
            }
        }
        private void GetAdminAccount()
        {
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

        // Fixed login method
        public string GetAdminMinistry(string username, string password)
        {
            foreach (var admin in adminAccounts)
            {
                if (admin.UserName.Equals(username, StringComparison.OrdinalIgnoreCase) &&
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
                if (admin.UserName.Equals(username, StringComparison.OrdinalIgnoreCase) &&
                    admin.Password.Equals(password, StringComparison.Ordinal))
                {
                    return "Admin";
                }
            }
            foreach (var user in regularAccounts)
            {
                if (user.UserName.Equals(username, StringComparison.OrdinalIgnoreCase) &&
                    user.Password.Equals(password, StringComparison.Ordinal))
                {
                    return "User";
                }
            }

            return "No Account Match";            
        }
        public void RegularUserAccounts(string firstName, string lastName, int age, string emailAddress, string userName, string passWord)
        {
            var newlines = $"{firstName}|{lastName}|{age}|{emailAddress}|{userName}|{passWord}";
            File.AppendAllText(regularAccFilePath, newlines + Environment.NewLine);
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

        public bool AddDevotionSchedule(string date, string songLeader, string presider, string speaker)
        {
            var newLines = $"{date}|{songLeader}|{presider}|{speaker}";
            return AppendLineToFile(devotionScheduleFilePath, newLines);
        }

        public bool AddDiscipleshipSchedule(string date, string speaker, string description, string note)
        {
            var newLines = $"{date}|{speaker}|{description}|{note}";
            return AppendLineToFile(discipleshipScheduleFilePath, newLines);
        }

        public bool AddLesson(string date, string lesson, string materials)
        {
            var newLines = $"{date}|{lesson}|{materials}";
            return AppendLineToFile(lessonFilePath, newLines);
        }

        public bool AddPraiseAndWorshipSchedule(string date, string songLeader, string instrumentalist)
        {
            var newLines = $"{date}|{songLeader}|{instrumentalist}";
            return AppendLineToFile(praiseAndWorshipScheduleFilePath, newLines);
        }
        public bool AddPrayerSchedule(string date, string songLeader, string presider, string speaker, string prayerItem)
        {
            var newLines = $"{date}|{songLeader}|{presider}|{speaker}|{prayerItem}";
            return AppendLineToFile(prayerMeetingFilePath, newLines);
        }

        public bool AddSundayWorshipSchedule(string date, string presider, string speaker, string flowers, string ushers)
        {
            var newLines = $"{date}|{presider}|{speaker}|{flowers}|{ushers}";
            return AppendLineToFile(sundayWorshipServiceFilePath, newLines);
        }

        public bool AddTeachers(string name, string designation)
        {
            var newLines = $"{name}|{designation}";
            return AppendLineToFile(teachersFilePath, newLines);
        }

        public void AdminAccounts(string firstName, string lastName, int age, string emailAddress, string ministryName, string position, string userName, string passWord)
        {
            var newlines = $"{firstName}|{lastName}|{age}|{emailAddress}|{ministryName}|{position}|{userName}|{passWord}";
            File.AppendAllText(adminAccFilePath, newlines + Environment.NewLine);
        }

        private void WriteDevotionSchedToFile()
        {
            var lines = new string[devotionSchedules.Count];

            for (int i = 0; i < devotionSchedules.Count; i++)
            {
                lines[i] = $"{devotionSchedules[i].Date}|{devotionSchedules[i].Presider}|{devotionSchedules[i].Speaker}";
            }

            File.WriteAllLines(devotionScheduleFilePath, lines);
        }

        private void WriteDiscipleshipSchedToFile()
        {
            var lines = new string[discipleshipSchedules.Count];

            for (int i = 0; i < discipleshipSchedules.Count; i++)
            {
                lines[i] = $"{discipleshipSchedules[i].Date}|{discipleshipSchedules[i].Speaker}|{discipleshipSchedules[i].Description}| {discipleshipSchedules[i].Note}";
            }

            File.WriteAllLines(discipleshipScheduleFilePath, lines);
        }

        private void WriteLessonToFile()
        {
            var lines = new string[lessonsList.Count];

            for (int i = 0; i < lessonsList.Count; i++)
            {
                lines[i] = $"{lessonsList[i].Date}|{lessonsList[i].Lessson}|{lessonsList[i].Materials}";
            }

            File.WriteAllLines(lessonFilePath, lines);
        }

        private void WritePraiseAndWorshipToFile()
        {
            var lines = new string[praiseAndWorshipSchedules.Count];

            for (int i = 0; i < praiseAndWorshipSchedules.Count; i++)
            {
                lines[i] = $"{praiseAndWorshipSchedules[i].Date}|{praiseAndWorshipSchedules[i].SongLeader}|{praiseAndWorshipSchedules[i].Instrumentalist}";
            }

            File.WriteAllLines(praiseAndWorshipScheduleFilePath, lines);
        }

        private void WritePrayerToFile()
        {
            var lines = new string[prayerSchedules.Count];

            for (int i = 0; i < prayerSchedules.Count; i++)
            {
                lines[i] = $"{prayerSchedules[i].Date}|{prayerSchedules[i].SongLeader}|{prayerSchedules[i].Presider}|{prayerSchedules[i].Speaker}|{prayerSchedules[i].PrayerItem}";
            }

            File.WriteAllLines(prayerMeetingFilePath, lines);
        }

        private void WriteSundayWorshipToFile()
        {
            var lines = new string[sundayWorshipSchedules.Count];

            for (int i = 0; i < sundayWorshipSchedules.Count; i++)
            {
                lines[i] = $"{sundayWorshipSchedules[i].Date}|{sundayWorshipSchedules[i].Presider}|{sundayWorshipSchedules[i].Speaker}|{sundayWorshipSchedules[i].Flowers}|{sundayWorshipSchedules[i].Ushers}";
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
            WriteDevotionSchedToFile();
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
            WriteDiscipleshipSchedToFile();
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
            WriteLessonToFile();
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
            WritePraiseAndWorshipToFile();
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
            WritePrayerToFile();
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
            WriteSundayWorshipToFile();
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
            WriteTeacherToFile();
            return true;
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
    }
}