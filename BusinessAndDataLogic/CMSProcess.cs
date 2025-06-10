using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMSAccounts;
using CMSDataLogic;
using CMSSchedules;

namespace BusinessAndDataLogic
{
    public class CMSProcess
    {
        private CMSDataProcess dataProcess = new CMSDataProcess();

        // about Login/sign up
        public bool RegisteringRegularAccounts(string firstName, string lastName, int age, string emailAddress, string username, string password)
        {
            var userAccounts = new UserAccounts()
            {
                FirstName = firstName,
                LastName = lastName,
                Age = age,
                EmailAddress = emailAddress,
                UserName = username,
                Password = password
            };
            return dataProcess.RegularUserAccounts(userAccounts);
        }
        public bool RegisteringAdminAccounts(string firstName, string lastName, int age, string emailAddress, string ministryName, string position, string userName, string passWord)
        {
            var adminAccounts = new UserAccounts()
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
            return dataProcess.AdminAccounts(adminAccounts);
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
            var loginAccounts = new UserAccounts()
            {
                UserName = username,
                Password = password
            };
            return dataProcess.GetUserRole(loginAccounts);
        }
        public string ValidatingAdminMinistry(string username, string password)
        {
            var loginAccounts = new UserAccounts()
            {
                UserName = username,
                Password = password
            };
            return dataProcess.GetAdminMinistry(loginAccounts);
        }


        // about the ministries schedule
        public string[] MinistryNamesList()
        {
            string[] ministryName = { "[1] Discipleship Ministry", "[2] Prayer Ministry", "[3] Worship Ministry", "[4] Christian Education", "[5] EXIT" };
            return ministryName;
        }
        
        //discipleship ministry
        public List<DiscipleshipMinistry> ViewDiscipleshipSchedule()
        {
            return dataProcess.ViewDiscipleshipSchedule();
        }
        public bool AddDiscipleshipSched(DateTime date, string speaker, string description, string note)
        {
            var discipleship = new DiscipleshipMinistry()
            {
                Date = date,
                Speaker = speaker,
                Description = description,
                Note = note
            };
            return dataProcess.AddDiscipleshipSchedule(discipleship);
        }
        public bool UpdateDiscipleshipSched(DateTime date, string speaker, string description, string note)
        {
            var update = new DiscipleshipMinistry()
            {
                Date = date,
                Speaker = speaker,
                Description = description,
                Note = note
            };
            return dataProcess.UpdateDiscipleshipSchedule(update);
        }
        public bool RemoveDiscipleSched(DateTime date)
        {
            var toDelete = new DiscipleshipMinistry()
            {
                Date = date.Date
            };
            return dataProcess.RemoveDiscipleshipSchedule(toDelete);
        }
        
        //prayer ministry
        public List<PrayerMinistry> ViewPrayerSched()
        {
            return dataProcess.ViewPrayerMeetingSchedule();
        }
        public bool AddPrayerSched(DateTime date, string songLeader, string presider, string speaker, string prayerItem)
        {
            var prayerSched = new PrayerMinistry()
            {
                Date = date,
                SongLeader = songLeader,
                Presider = presider,
                Speaker = speaker,
                PrayerItem = prayerItem
            };
            return dataProcess.AddPrayerSchedule(prayerSched);
        }
        public bool UpdatePrayerSched(DateTime date, string songLeader, string presider, string speaker, string prayerItem)
        {
            var update = new PrayerMinistry()
            {
                Date = date,
                SongLeader = songLeader,
                Presider = presider,
                Speaker = speaker,
                PrayerItem = prayerItem
            };
            return dataProcess.UpdatePrayerSchedule(update);
        }
        public bool RemovePrayerSched(DateTime date)
        {
            var toDelete = new PrayerMinistry()
            {
                Date = date.Date
            };
            return dataProcess.RemovePrayerSchedule(toDelete);
        }

        //worship ministry
        public List<PraiseAndWorship> ViewPraiseAndWorshipSched()
        {
            return dataProcess.ViewPraiseAndWorshipSchedule();
        }
        public bool AddPraiseAndWorshipSched(DateTime date, string songLeader, string instrumentalist)
        {
            var praiseAndWorshipSched = new PraiseAndWorship()
            {
                Date = date,
                SongLeader = songLeader,
                Instrumentalist = instrumentalist
            };
            return dataProcess.AddPraiseAndWorshipSchedule(praiseAndWorshipSched);
        }
        public bool UpdatePraiseAndWorshipSched(DateTime date, string songLeader)
        {
            var update = new PraiseAndWorship()
            {
                Date = date,
                SongLeader = songLeader
            };
            return dataProcess.UpdatePraiseAndWorshipSchedule(update);
        }
        public bool RemovePraiseAndWorshipSched(DateTime date)
        {
            var toDelete = new PraiseAndWorship()
            {
                Date = date.Date
            };
            return dataProcess.RemovePraiseAndWorshipSchedule(toDelete);
        }

        public List<SundayWorshipService> ViewSundayWorshipSched()
        {
            return dataProcess.ViewSundayWorshipSched();
        }
        public bool AddSundayWorshipServiceSched(DateTime date, string presider, string speaker, string flowers, string ushers)
        {
            var sundayWorshipSched = new SundayWorshipService()
            {
                Date = date,
                Presider = presider,
                Speaker = speaker,
                Flowers = flowers,
                Ushers = ushers
            };
            return dataProcess.AddSundayWorshipSchedule(sundayWorshipSched);
        }
        public bool UpdateSundayWorshipServiceSched(DateTime date, string presider, string speaker, string flowers, string ushers)
        {
            var update = new SundayWorshipService()
            {
                Date = date,
                Presider = presider,
                Speaker = speaker,
                Flowers = flowers,
                Ushers = ushers
            };
            return dataProcess.UpdateSundayWorshipSchedule(update);
        }
        public bool RemoveSundayWorshipSched(DateTime date)
        {
            var toDelete = new SundayWorshipService()
            {
                Date = date.Date
            };
            return dataProcess.RemoveSundayWorshipSched(toDelete);
        }

        public List<Devotion> ViewDevotionSched()
        {
            return dataProcess.ViewDevotionSchedule();
        }     
        public bool AddDevotionSched(DateTime date, string songLeader, string presider, string speaker)
        {
            var devotionSched = new Devotion()
            {
                Date = date,
                SongLeader = songLeader, 
                Presider = presider,
                Speaker = speaker
            };
            return dataProcess.AddDevotionSchedule(devotionSched);
        }
        public bool UpdateDevotionSched(DateTime date, string songLeader, string presider, string speaker)
        {
            var update = new Devotion()
            {
                Date = date,
                SongLeader = songLeader,
                Presider = presider,
                Speaker = speaker
            };
            return dataProcess.UpdateDevotionSchedule(update);
        }
        public bool RemoveDevotionSched(DateTime date)
        {
            var toDelete = new Devotion()
            {
                Date = date.Date
            };

            return dataProcess.RemoveDevotionSchedule(toDelete);
        }

        public List<TeachersList> GetTeachers()
        {
            return dataProcess.ViewTeachersList();
        }
        public bool AddTeachers(string name, string designation)
        {
            var teachersList = new TeachersList()
            {
                TeachersName = name,
                Assignment = designation
            };
            return dataProcess.AddTeachers(teachersList);
        }
        public bool UpdateTeachers(string name, string designation)
        {
            var update = new TeachersList()
            {
                TeachersName = name,
                Assignment = designation
            };
            return dataProcess.UpdateTeachers(update);
        }
        public bool RemoveTeacher(string name)
        {
            var toDelete = new TeachersList()
            {
                TeachersName = name
            };
            return dataProcess.RemoveTeacher(toDelete);
        }

        public List<Lesson> GetLessons()
        {
            return dataProcess.ViewLessons();
        }
        public bool AddLesson(DateTime date, string lesson, string materials)
        {
            var lessonsLists = new Lesson()
            {
                Date = date,
                Lessson = lesson,
                Materials = materials
            };
            return dataProcess.AddLesson(lessonsLists);
        }
        public bool UpdateLesson(DateTime date, string lesson, string materials)
        {
            var update = new Lesson()
            {
                Date = date,
                Lessson = lesson,
                Materials = materials
            };
            return dataProcess.UpdateLesson(update);
        }
        public bool RemoveLesson(DateTime date)
        {
            var toDelete = new Lesson()
            {
                Date = date.Date
            };
            return dataProcess.RemoveLesson(toDelete);
        }

        public bool ValidateSundayDate(DateTime date)
        {
            if (date.DayOfWeek != DayOfWeek.Sunday)
            {
                return false;
            }
            return true;
        }
        public bool ValidateFridayDate(DateTime date)
        {
            if (date.DayOfWeek != DayOfWeek.Friday)
            {
                return false;
            }
            return true;
        }
        public bool ValidateThursdayDate(DateTime date)
        {
            if (date.DayOfWeek != DayOfWeek.Thursday)
            {
                return false;
            }
            return true;
        }
        public bool DateIsPast(DateTime date)
        {
            if(date.Date < DateTime.Today)
            {
                return false;
            }
            return true;
        }

        //checking if date exist
        public bool DiscipleshipScheduleExist(DateTime date)
        {
            foreach (DiscipleshipMinistry sched in dataProcess.ViewDiscipleshipSchedule())
            {
                if (sched.Date.Date == date.Date)
                {
                    return true;
                }
            }
            return false;
        }
        public bool PrayerScheduleExist(DateTime date)
        {
            foreach (PrayerMinistry sched in dataProcess.ViewPrayerMeetingSchedule())
            {
                if (sched.Date.Date == date.Date)
                {
                    return true;
                }
            }
            return false;
        }
        public bool PraiseAndWorshipScheduleExist(DateTime date)
        {
            foreach (PraiseAndWorship sched in dataProcess.ViewPraiseAndWorshipSchedule())
            {
                if (sched.Date.Date == date.Date)
                {
                    return true;
                }
            }
            return false;
        }
        public bool SundayWorshipScheduleExist(DateTime date)
        {
            foreach (SundayWorshipService sched in dataProcess.ViewSundayWorshipSched())
            {
                if (sched.Date.Date == date.Date)
                {
                    return true;
                }
            }
            return false;
        }
        public bool DevotionScheduleExist(DateTime date)
        {
            foreach (Devotion sched in dataProcess.ViewDevotionSchedule())
            {
                if (sched.Date.Date == date.Date)
                {
                    return true;
                }
            }
            return false;
        }
        public bool TeacherNameExist(string name)
        {
            foreach (TeachersList sched in dataProcess.ViewTeachersList())
            {
                if (sched.TeachersName == name)
                {
                    return true;
                }
            }
            return false;
        }
        public bool LessonExist(DateTime date)
        {
            foreach (Lesson sched in dataProcess.ViewLessons())
            {
                if (sched.Date.Date == date.Date)
                {
                    return true;
                }
            }
            return false;
        }

    }
}