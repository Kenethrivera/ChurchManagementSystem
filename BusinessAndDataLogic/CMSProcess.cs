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
            private readonly EmailService _emailService;
        
        public CMSProcess(EmailService emailService)
        {
            dataProcess = new CMSDataProcess();
            _emailService = emailService;
        }

        // about Login/sign up
        public bool RegisteringRegularAccounts(string firstName, string lastName, int age, string emailAddress, string ministryName, string position, string username, string password)
            {
                var userAccounts = new UserAccounts()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Age = age,
                    EmailAddress = emailAddress,
                    MinistryName = ministryName,
                    Position = position,
                    UserName = username,
                    Password = password
                };
                _emailService.SendWelcomeEmail(emailAddress, firstName, ministryName);
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
            _emailService.SendWelcomeEmail(emailAddress, firstName, ministryName);
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
        public UserAccounts ValidatingUserRole(bool isAdmin, string username, string password)
        {
            var loginAccounts = new UserAccounts()
            {
                UserName = username,
                Password = password
            };
            return dataProcess.GetUserRole(loginAccounts, isAdmin);
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
        public bool UpdateDiscipleshipSched(DateTime date, string speaker, string speakerStatus, string description, string note)
        {
            var update = new DiscipleshipMinistry()
            {
                Date = date,
                Speaker = speaker,
                Status = speakerStatus,
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
        public bool UpdatePrayerSched(DateTime date, string songLeader, string songLeaderStatus, string presider, string presiderStataus, string speaker, string speakerStatus, string prayerItem)
        {
            var update = new PrayerMinistry()
            {
                Date = date,
                SongLeader = songLeader,
                SongLeaderStatus = songLeaderStatus,
                Presider = presider,
                PresiderStatus = presiderStataus,
                Speaker = speaker,
                SpeakerStatus = speakerStatus,
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

        // worship ministry
        // praise and worship
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
        public bool UpdatePraiseAndWorshipSched(DateTime date, string songLeader, string songLeaderStatus)
        {
            var update = new PraiseAndWorship()
            {
                Date = date,
                SongLeader = songLeader,
                SongLeaderStatus = songLeaderStatus
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
        // Sunday worship service
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
        public bool UpdateSundayWorshipServiceSched(DateTime date, string presider, string presiderStatus, string speaker, string speakerStatus, string flowers, string flowersStatus, string ushers, string ushersStatus)
        {
            var update = new SundayWorshipService()
            {
                Date = date,
                Presider = presider,
                PresiderStatus = presiderStatus,
                Speaker = speaker,
                SpeakerStatus = speakerStatus,
                Flowers = flowers,
                FlowersStatus = flowersStatus,
                Ushers = ushers,
                UshersStatus = ushersStatus
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
        // devotion
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
        public bool UpdateDevotionSched(DateTime date, string songLeader, string songLeaderStatus, string presider, string presiderStatus, string speaker, string speakerStatus)
        {
            var update = new Devotion()
            {
                Date = date,
                SongLeader = songLeader,
                SongLeaderStatus = songLeaderStatus,
                Presider = presider,
                PresiderStatus = presiderStatus,
                Speaker = speaker,
                SpeakerStatus = speakerStatus
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
        // teachers
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
        // lessons
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

        // validate date
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

        // checking if date exist
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
        
        //get all users
        public List<string> GetAllUsersPerMinistry(string ministryName)
        {
            var allAccounts = dataProcess.GetAllAccounts();

            List<string> names = new List<string>();
            foreach(var account in allAccounts)
            {
                if (account.MinistryName.Equals(ministryName, StringComparison.OrdinalIgnoreCase))
                {
                    names.Add(account.FirstName + " " + account.LastName);
                }
            }
            return names;
        }

        //processing users response
        public bool ProcessUserResponseDiscipleship(DateTime date, string newStatus)
        {
            var userResponse = new DiscipleshipMinistry()
            {
                Date = date,
                Status = newStatus
            };
            return dataProcess.ProcessUserResponseDiscipleship(userResponse);
        }
        public bool ProcessUserResponsePrayer(DateTime date, string presiderStatus, string  speakerStatus, string songLeaderStatus)
        {
            var statusUpdate = new PrayerMinistry()
            {
                Date = date,
                PresiderStatus = presiderStatus,
                SongLeaderStatus = songLeaderStatus,
                SpeakerStatus = speakerStatus
            };
            return dataProcess.ProcessUserResponsePrayer(statusUpdate);
        }

        // for windows form, since i can't revise and think of differnt approach or logic anymore :(
        public bool ProcessUserResponsePrayer(DateTime date, string role, string newStatus)
        {
            var prayer = new PrayerMinistry { 
                Date = date 
            };

            if (role == "Presider")
                prayer.PresiderStatus = newStatus;
            else if (role == "Speaker")
                prayer.SpeakerStatus = newStatus;
            else if (role == "Song Leader")
                prayer.SongLeaderStatus = newStatus;

            return dataProcess.ProcessUserResponsePrayer(prayer);
        }

        public bool ProcessUserResponseDevotion(DateTime date, string role, string newStatus)
        {
            var devotion = new Devotion { 
                Date = date 
            };

            if (role == "Presider")
                devotion.PresiderStatus = newStatus;
            else if (role == "Speaker")
                devotion.SpeakerStatus = newStatus;
            else if (role == "Song Leader")
                devotion.SongLeaderStatus = newStatus;

            return dataProcess.ProcessUserResponseDevotion(devotion);
        }
        public bool ProcessUserResponsePraiseAndWorship(DateTime date, string role, string newStatus)
        {
            var pw = new PraiseAndWorship { 
                Date = date 
            };

            if (role == "Song Leader")
                pw.SongLeaderStatus = newStatus;

            return dataProcess.ProcessUserResponsePW(pw);
        }

        public bool ProcessUserResponseSundayWorship(DateTime date, string role, string newStatus)
        {
            var sunday = new SundayWorshipService {
                Date = date 
            };

            if (role == "Presider")
                sunday.PresiderStatus = newStatus;
            else if (role == "Speaker")
                sunday.SpeakerStatus = newStatus;
            else if (role == "Flowers")
                sunday.FlowersStatus = newStatus;
            else if (role == "Ushers")
                sunday.UshersStatus = newStatus;

            return dataProcess.ProcessUserResponseSundayWorship(sunday);
        }



        public bool ProcessUserResponsePW(DateTime date, string songLeaderStatus)
        {
            var statusUpdate = new PraiseAndWorship()
            {
                Date = date,
                SongLeaderStatus = songLeaderStatus
            };
            return dataProcess.ProcessUserResponsePW(statusUpdate);
        }
        public bool ProcessUserResponseSundayWorship(DateTime date, string presiderStatus, string speakerStatus, string flowersStatus, string ushersStatus)
        {
            var statusUpdate = new SundayWorshipService()
            {
                Date = date,
                PresiderStatus = presiderStatus,
                SpeakerStatus = speakerStatus,
                FlowersStatus = flowersStatus,
                UshersStatus = ushersStatus
            };
            return dataProcess.ProcessUserResponseSundayWorship(statusUpdate);
        }
        public bool ProcessUserResponseDevotion(DateTime date, string presiderStatus, string speakerStatus, string songLeaderStatus)
        {
            var statusUpdate = new Devotion()
            {
                Date = date,
                PresiderStatus = presiderStatus,
                SpeakerStatus = speakerStatus,
                SongLeaderStatus = songLeaderStatus
            };
            return dataProcess.ProcessUserResponseDevotion(statusUpdate);
        }
        


        public string GetUserConfirmation(int choice)
        {

            if (choice == 1)
            {
                return "Confirmed";
            }
            else if (choice == 2)
            {
                return "Request to be Changed";
            }
            else
            {
                return "invalid";
            }
        }
        public bool CheckIfStatusIsPending(string fullName, string assignedName, string status)
        {
            return assignedName.Equals(fullName, StringComparison.OrdinalIgnoreCase) && !status.Equals("Confirmed", StringComparison.OrdinalIgnoreCase);
        }

    }
}