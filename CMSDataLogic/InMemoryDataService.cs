using CMSAccounts;
using CMSSchedules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        public bool RegularUserAccounts(UserAccounts userAccounts)
        {
            try
            {
                UserAccounts regular = new UserAccounts();
                regular.FirstName = userAccounts.FirstName;
                regular.LastName = userAccounts.LastName;
                regular.Age = userAccounts.Age;
                regular.EmailAddress = userAccounts.EmailAddress;
                regular.UserName = userAccounts.UserName;
                regular.Password = userAccounts.Password;
                regular.MinistryName = "N/A";
                regular.Position = "Regular User";
                regularAccounts.Add(regular);
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
                UserAccounts adminAccount = new UserAccounts();
                adminAccount.FirstName = admin.FirstName;
                adminAccount.LastName = admin.LastName;
                adminAccount.Age = admin.Age;
                adminAccount.MinistryName = admin.MinistryName;
                adminAccount.Position = admin.Position;
                adminAccount.UserName = admin.UserName;
                adminAccount.Password = admin.Password;
                adminAccounts.Add(adminAccount);
                return true;
            }
            catch 
            {
                return false;
            }
            
        }
        public string GetUserRole(UserAccounts loginAccounts)
        { 
            foreach (UserAccounts admin in adminAccounts)
            {
                if (admin.UserName == loginAccounts.UserName && admin.Password == loginAccounts.Password)
                {
                    return "Admin";
                }
            }

            foreach (UserAccounts user in regularAccounts)
            {
                if (user.UserName == loginAccounts.UserName && user.Password == loginAccounts.Password)
                {
                    return "User";
                }
            }

            return "No Account Match";
        }
        public string GetAdminMinistry(UserAccounts loginAccounts)
        {

            foreach (UserAccounts admin in adminAccounts)
            {
                if (admin.UserName == loginAccounts.UserName && admin.Password == loginAccounts.Password)
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
        public bool AddDiscipleshipSchedule(DiscipleshipMinistry discipleshipSched)
        {
            try
            {
                discipleshipSchedules.Add(new DiscipleshipMinistry
                {
                    Date = discipleshipSched.Date,
                    Speaker = discipleshipSched.Speaker,
                    Description = discipleshipSched.Description,
                    Note = discipleshipSched.Note
                });
                return true;
            }
            catch
            {
                return false;
            }

        }
        public bool UpdateDiscipleshipSchedule(DiscipleshipMinistry update)
        {
            for(int i = 0; i <discipleshipSchedules.Count; i++)
            {
                if (discipleshipSchedules[i].Date.Date == update.Date.Date)
                {
                    discipleshipSchedules[i].Speaker = update.Speaker;
                    discipleshipSchedules[i].Description = update.Description;
                    discipleshipSchedules[i].Note = update.Note;
                    return true;
                }
            }
            return false;
        }
        public bool RemoveDiscipleshipSchedule(DiscipleshipMinistry toDelete)
        {
            for (int i = 0; i < discipleshipSchedules.Count; i++)
            {
                if (discipleshipSchedules[i].Date.Date == toDelete.Date.Date)
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
        public bool AddPrayerSchedule(PrayerMinistry prayerSched)
        {
            try
            {
                prayerSchedules.Add(new PrayerMinistry
                {
                    Date = prayerSched.Date,
                    SongLeader = prayerSched.SongLeader,
                    Presider = prayerSched.Presider,
                    Speaker = prayerSched.Speaker,
                    PrayerItem = prayerSched.PrayerItem
                });
                return true;
            }
            catch
            {
                return false;
            }

        }
        public bool UpdatePrayerSchedule(PrayerMinistry update)
        {
            for (int i = 0; i < prayerSchedules.Count; i++)
            {
                if (prayerSchedules[i].Date.Date == update.Date.Date)
                {
                    prayerSchedules[i].SongLeader = update.SongLeader;
                    prayerSchedules[i].Presider = update.Presider;
                    prayerSchedules[i].Speaker = update.Speaker;
                    prayerSchedules[i].PrayerItem = update.PrayerItem;
                    return true;
                }
            }
            return false;
        }
        public bool RemovePrayerSchedule(PrayerMinistry toDelete)
        {
            for (int i = 0; i < prayerSchedules.Count; i++)
            {
                if (prayerSchedules[i].Date.Date == toDelete.Date.Date)
                {
                    prayerSchedules.RemoveAt(i);
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
        public bool AddPraiseAndWorshipSchedule(PraiseAndWorship praiseAndWorshipSched)
        {
            try
            {
                praiseAndWorshipSchedules.Add(new PraiseAndWorship
                {
                    Date = praiseAndWorshipSched.Date,
                    SongLeader = praiseAndWorshipSched.SongLeader,
                    Instrumentalist = praiseAndWorshipSched.Instrumentalist
                });
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool UpdatePraiseAndWorshipSchedule(PraiseAndWorship update)
        {
            for (int i = 0; i < praiseAndWorshipSchedules.Count; i++)
            {
                if (praiseAndWorshipSchedules[i].Date.Date == update.Date.Date)
                {
                    praiseAndWorshipSchedules[i].SongLeader = update.SongLeader;
                    return true;
                }
            }
            return false;
        }
        public bool RemovePraiseAndWorshipSchedule(PraiseAndWorship toDelete)
        {
            for (int i = 0; i < praiseAndWorshipSchedules.Count; i++)
            {
                if (praiseAndWorshipSchedules[i].Date.Date == toDelete.Date.Date)
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
        public bool AddSundayWorshipSchedule(SundayWorshipService sundayWorshipSched)
        {
            try
            {
                sundayWorshipSchedules.Add(new SundayWorshipService
                {
                    Date = sundayWorshipSched.Date,
                    Presider = sundayWorshipSched.Presider,
                    Speaker = sundayWorshipSched.Speaker,
                    Flowers = sundayWorshipSched.Flowers,
                    Ushers = sundayWorshipSched.Ushers
                });
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool UpdateSundayWorshipSchedule(SundayWorshipService update)
        {
            for (int i = 0; i < sundayWorshipSchedules.Count; i++)
            {
                if (sundayWorshipSchedules[i].Date.Date == update.Date.Date)
                {
                    sundayWorshipSchedules[i].Presider = update.Presider;
                    sundayWorshipSchedules[i].Speaker = update.Speaker;
                    sundayWorshipSchedules[i].Flowers = update.Flowers;
                    sundayWorshipSchedules[i].Ushers = update.Ushers;
                    return true;
                }
            }
            return false;
        }
        public bool RemoveSundayWorshipSched(SundayWorshipService toDelete)
        {
            for (int i = 0; i < sundayWorshipSchedules.Count; i++)
            {
                if (sundayWorshipSchedules[i].Date.Date == toDelete.Date)
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
        public bool AddDevotionSchedule(Devotion devotionSched)
        {
            try
            {
                devotionSchedules.Add(new Devotion
                {
                    Date = devotionSched.Date,
                    SongLeader = devotionSched.SongLeader,
                    Presider = devotionSched.Presider,
                    Speaker = devotionSched.Speaker
                });
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool UpdateDevotionSchedule(Devotion update)
        {
            for (int i = 0; i < devotionSchedules.Count; i++)
            {
                if (devotionSchedules[i].Date.Date == update.Date.Date)
                {
                    devotionSchedules[i].SongLeader = update.SongLeader;
                    devotionSchedules[i].Presider = update.Presider;
                    devotionSchedules[i].Speaker = update.Speaker;
                    return true;
                }
            }
            return false;
        }
        public bool RemoveDevotionSchedule(Devotion toDelete)
        {
            for (int i = 0; i < devotionSchedules.Count; i++)
            {
                if (devotionSchedules[i].Date.Date == toDelete.Date.Date)
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
        public bool AddTeachers(TeachersList teachersLists)
        {
            try
            {
                teachersList.Add(new TeachersList
                {
                    TeachersName = teachersLists.TeachersName,
                    Assignment = teachersLists.Assignment
                });
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool UpdateTeachers(TeachersList update)
        {
            for (int i = 0; i < teachersList.Count; i++)
            {
                if (teachersList[i].TeachersName == update.TeachersName)
                {
                    teachersList[i].Assignment = update.Assignment;
                    return true;
                }
            }
            return false;
        }
        public bool RemoveTeacher(TeachersList toDelete)
        {
            for (int i = 0; i < teachersList.Count; i++)
            {
                if (teachersList[i].TeachersName == toDelete.TeachersName)
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
        public bool AddLesson(Lesson lessonsLists)
        {
            try
            {
                lessonsList.Add(new Lesson
                {
                    Date = lessonsLists.Date,
                    Lessson = lessonsLists.Lessson,
                    Materials = lessonsLists.Materials
                });
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool UpdateLesson(Lesson update)
        {
            for (int i = 0; i < lessonsList.Count; i++)
            {
                if (lessonsList[i].Date.Date == update.Date.Date)
                {
                    lessonsList[i].Lessson = update.Lessson;
                    lessonsList[i].Materials = update.Materials;
                    return true;
                }
            }
            return false;
        }
        public bool RemoveLesson(Lesson toDelete)
        {
            for (int i = 0; i < lessonsList.Count; i++)
            {
                if (lessonsList[i].Date.Date == toDelete.Date.Date)
                {
                    lessonsList.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        
    }
}
