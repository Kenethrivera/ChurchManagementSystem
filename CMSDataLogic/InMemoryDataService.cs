using CMSAccounts;
using CMSSchedules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSDataLogic
{
    public class InMemoryDataService : IMinistriesDataService
    {
        private List<UserAccounts> regularAccounts = new List<UserAccounts>();
        private List<UserAccounts> adminAccounts = new List<UserAccounts>();

        private List<DiscipleshipMinistry> discipleshipSchedules = new List<DiscipleshipMinistry>();
        private List<PrayerMinistry> prayerSchedules = new List<PrayerMinistry>();
        private List<SundayWorshipService> sundayWorshipSchedules = new List<SundayWorshipService>();
        private List<PraiseAndWorship> praiseAndWorshipSchedules = new List<PraiseAndWorship>();
        private List<Devotion> devotionSchedules = new List<Devotion>();
        private List<TeachersList> teachersList = new List<TeachersList>();
        private List<Lesson> lessonsList = new List<Lesson>();

        public InMemoryDataService()
        {
            DummyAccount();
        }

        private void DummyAccount()
        {
            adminAccounts.Add(new UserAccounts
            {
                FirstName = "keneth",
                LastName = "rivera",
                Age = 20,
                EmailAddress = "ken123@gmail.com",
                MinistryName = "Discipleship Ministry",
                Position = "Leader",
                UserName = "ken",
                Password = "123"
            });
            adminAccounts.Add(new UserAccounts
            {
                FirstName = "keneth",
                LastName = "rivera",
                Age = 20,
                EmailAddress = "ken123@gmail.com",
                MinistryName = "Prayer Ministry",
                Position = "Leader",
                UserName = "ken",
                Password = "1234"
            });
            adminAccounts.Add(new UserAccounts
            {
                FirstName = "keneth",
                LastName = "rivera",
                Age = 20,
                EmailAddress = "ken123@gmail.com",
                MinistryName = "Worship Ministry",
                Position = "Leader",
                UserName = "ken",
                Password = "12345"
            });
            adminAccounts.Add(new UserAccounts
            {
                FirstName = "keneth",
                LastName = "rivera",
                Age = 20,
                EmailAddress = "ken123@gmail.com",
                MinistryName = "Christian Education",
                Position = "Leader",
                UserName = "ken",
                Password = "123456"
            });
        }
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

        public void AdminAccounts(string firstName, string lastName, int age, string emailAddress, string ministryName, string position, string userName, string passWord)
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

        public string GetUserRole(string username, string password)
        {

            foreach (UserAccounts admin in adminAccounts)
            {
                if (admin.UserName == username && admin.Password == password)
                {
                    return "Admin";
                }
            }

            foreach (UserAccounts user in regularAccounts)
            {
                if (user.UserName == username && user.Password == password)
                {
                    return "User";
                }
            }

            return "No Account Match";
        }
        public string GetAdminMinistry(string username, string password)
        {

            foreach (UserAccounts admin in adminAccounts)
            {
                if (admin.UserName == username && admin.Password == password)
                {
                    return admin.MinistryName;
                }
            }
            return "NO match account";
        }

        //discipleship ministry
        public List<DiscipleshipMinistry> ViewDiscipleshipSchedule()
        {
            return discipleshipSchedules;
        }
        public bool AddDiscipleshipSchedule(string date, string speaker, string description, string note)
        {
            try
            {
                discipleshipSchedules.Add(new DiscipleshipMinistry
                {
                    Date = date,
                    Speaker = speaker,
                    Description = description,
                    Note = note
                });
                return true;
            }
            catch
            {
                return false;
            }

        }
        public bool RemoveDiscipleshipSchedule(string date)
        {
            for (int i = 0; i < discipleshipSchedules.Count; i++)
            {
                if (discipleshipSchedules[i].Date == date)
                {
                    discipleshipSchedules.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        //prayer ministry
        public List<PrayerMinistry> ViewPrayerMeetingSchedule()
        {
            return prayerSchedules;
        }
        public bool AddPrayerSchedule(string date, string songLeader, string presider, string speaker)
        {
            try
            {
                prayerSchedules.Add(new PrayerMinistry
                {
                    Date = date,
                    SongLeader = songLeader,
                    Presider = presider,
                    Speaker = speaker
                });
                return true;
            }
            catch
            {
                return false;
            }

        }
        public bool RemovePrayerSchedule(string date)
        {
            for (int i = 0; i < prayerSchedules.Count; i++)
            {
                if (prayerSchedules[i].Date == date)
                {
                    prayerSchedules.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
        public bool AddPrayerItem(string date, string prayerItem)
        {
            for (int i = 0; i < prayerSchedules.Count; i++)
            {
                if (prayerSchedules[i].Date == date)
                {
                    prayerSchedules.Add(new PrayerMinistry
                    {
                        PrayerItem = prayerItem
                    });
                    return true;
                }
            }
            return false;
        }

        //worship ministry

        public List<PraiseAndWorship> ViewPraiseAndWorshipSchedule()
        {
            return praiseAndWorshipSchedules;
        }
        public bool AddPraiseAndWorshipSchedule(string date, string songLeader, string instrumentalist)
        {
            try
            {
                praiseAndWorshipSchedules.Add(new PraiseAndWorship
                {
                    Date = date,
                    SongLeader = songLeader,
                    Instrumentalist = instrumentalist
                });
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool RemovePraiseAndWorshipSchedule(string date)
        {
            for (int i = 0; i < praiseAndWorshipSchedules.Count; i++)
            {
                if (praiseAndWorshipSchedules[i].Date == date)
                {
                    praiseAndWorshipSchedules.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public List<SundayWorshipService> ViewSundayWorshipSched()
        {
            return sundayWorshipSchedules;
        }
        public bool AddSundayWorshipSchedule(string date, string presider, string speaker, string flowers, string ushers)
        {
            try
            {
                sundayWorshipSchedules.Add(new SundayWorshipService
                {
                    Date = date,
                    Presider = presider,
                    Speaker = speaker,
                    Flowers = flowers,
                    Ushers = ushers
                });
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool RemoveSundayWorshipSched(string date)
        {
            for (int i = 0; i < sundayWorshipSchedules.Count; i++)
            {
                if (sundayWorshipSchedules[i].Date == date)
                {
                    sundayWorshipSchedules.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
        public List<Devotion> ViewDevotionSchedule()
        {
            return devotionSchedules;
        }
        public bool AddDevotionSchedule(string date, string songLeader, string presider, string speaker)
        {
            try
            {
                devotionSchedules.Add(new Devotion
                {
                    Date = date,
                    SongLeader = songLeader,
                    Presider = presider,
                    Speaker = speaker
                });
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool RemoveDevotionSchedule(string date)
        {
            for (int i = 0; i < devotionSchedules.Count; i++)
            {
                if (devotionSchedules[i].Date == date)
                {
                    devotionSchedules.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public List<TeachersList> ViewTeachersList()
        {
            return teachersList;
        }

        public bool AddTeachers(string name, string designation)
        {
            try
            {
                teachersList.Add(new TeachersList
                {
                    TeachersName = name,
                    Assignment = designation
                });
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool RemoveTeacher(string name)
        {
            for (int i = 0; i < teachersList.Count; i++)
            {
                if (teachersList[i].TeachersName == name)
                {
                    teachersList.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public List<Lesson> ViewLessons()
        {
            return lessonsList;
        }
        public bool AddLesson(string date, string lesson, string materials)
        {
            try
            {
                lessonsList.Add(new Lesson
                {
                    Date = date,
                    Lessson = lesson,
                    Materials = materials
                });
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool RemoveLesson(string date)
        {
            for (int i = 0; i < lessonsList.Count; i++)
            {
                if (lessonsList[i].Date == date)
                {
                    lessonsList.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

    }
}
