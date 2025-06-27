using BusinessAndDataLogic;
using CMSAccounts;
using CMSSchedules;
using Microsoft.AspNetCore.Mvc;

namespace CMSAPI.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class MinistriesController : Controller
    {
        CMSProcess cmsProcess = new CMSProcess();
        UserAccounts userAccounts = new UserAccounts();

        [HttpGet("DiscipleshipSchedules")]
        public IEnumerable<DiscipleshipMinistry> GetDiscipleshipSchedules()
        {
            var discipleshipSchedules = cmsProcess.ViewDiscipleshipSchedule();
            return discipleshipSchedules;
        }
        [HttpGet("PrayerSchedules")]
        public IEnumerable<PrayerMinistry> GetPrayerSchedules()
        {
            var prayerSchedules = cmsProcess.ViewPrayerSched();
            return prayerSchedules;
        }
        [HttpGet("PraiseAndWorshipSchedules")]
        public IEnumerable<PraiseAndWorship> GetPraiseAndWorshipsSchedules()
        {
            var praiseAndWorshipsSchedules = cmsProcess.ViewPraiseAndWorshipSched();
            return praiseAndWorshipsSchedules;
        }
        [HttpGet("SundayWorshipServiceSchedules")]
        public IEnumerable<SundayWorshipService> GetSundayWorshipServiceSchedules()
        {
            var sundayWorshipSchedules = cmsProcess.ViewSundayWorshipSched();
            return sundayWorshipSchedules;
        }
        [HttpGet("DevotionSchedules")]
        public IEnumerable<Devotion> GetDevotionSchedules()
        {
            var devotionSchedules = cmsProcess.ViewDevotionSched();
            return devotionSchedules;
        }
        [HttpGet("TeachersList")]
        public IEnumerable<TeachersList> GetTeachers()
        {
            var teachers = cmsProcess.GetTeachers();
            return teachers;
        }
        [HttpGet("LessonsList")]
        public IEnumerable<Lesson> GetLessons()
        {
            var lessons = cmsProcess.GetLessons();
            return lessons;
        }
        [HttpPost("AddAdminAccounts")]
        public bool AddAdminAccounts(UserAccounts userAccounts)
        {           
            return cmsProcess.RegisteringAdminAccounts(userAccounts.FirstName, userAccounts.LastName, userAccounts.Age, userAccounts.EmailAddress, userAccounts.MinistryName, userAccounts.Position, userAccounts.UserName, userAccounts.Password);
        }
        [HttpPost("AddUserAccounts")]
        public bool AddUserAccounts(UserAccounts userAccounts)
        {
            return cmsProcess.RegisteringRegularAccounts(userAccounts.FirstName, userAccounts.LastName, userAccounts.Age, userAccounts.EmailAddress, userAccounts.MinistryName, userAccounts.Position, userAccounts.UserName, userAccounts.Password);
        }
        [HttpPost("AddDiscipleshipSchedule")]
        public bool AddDiscipleshipSchedule(DiscipleshipMinistry addSched)
        {
            if (!cmsProcess.ValidateSundayDate(addSched.Date)){
                return false;
            }
            if (!cmsProcess.DateIsPast(addSched.Date))
            {
                return false;
            }
            if (cmsProcess.DiscipleshipScheduleExist(addSched.Date))
            {
                return false;
            }
            addSched.Status = "Pending";
            return cmsProcess.AddDiscipleshipSched(addSched.Date, addSched.Speaker, addSched.Description, addSched.Note);
        }
        [HttpPost("AddPrayerSchedule")]
        public bool AddPrayerSchedules(PrayerMinistry addSched)
        {
            if (!cmsProcess.ValidateThursdayDate(addSched.Date))
            {
                return false;
            }
            if (!cmsProcess.DateIsPast(addSched.Date))
            {
                return false;
            }
            if (cmsProcess.PrayerScheduleExist(addSched.Date))
            {
                return false;
            }
            addSched.SongLeaderStatus = "Pending";
            addSched.PresiderStatus = "Pending";
            addSched.SpeakerStatus = "Pending";
            return cmsProcess.AddPrayerSched(addSched.Date, addSched.SongLeader, addSched.Presider, addSched.Speaker, addSched.PrayerItem);
        }
        [HttpPost("AddPraiseAndWorshipSchedule")]
        public bool AddPraiseAndWorshipSchedules(PraiseAndWorship addSched)
        {
            if (!cmsProcess.ValidateSundayDate(addSched.Date))
            {
                return false;
            }
            if (!cmsProcess.DateIsPast(addSched.Date))
            {
                return false;
            }
            if (cmsProcess.PraiseAndWorshipScheduleExist(addSched.Date))
            {
                return false;
            }
            addSched.SongLeaderStatus = "Pending";
            return cmsProcess.AddPraiseAndWorshipSched(addSched.Date.Date, addSched.SongLeader, addSched.Instrumentalist);
        }
        [HttpPost("AddSundayWorshipSchedule")]
        public bool AddSundayWorshipSchedules(SundayWorshipService addSched)
        {
            if (!cmsProcess.ValidateSundayDate(addSched.Date))
            {
                return false;
            }
            if (!cmsProcess.DateIsPast(addSched.Date))
            {
                return false;
            }
            if (cmsProcess.SundayWorshipScheduleExist(addSched.Date))
            {
                return false;
            }
            addSched.PresiderStatus = "Pending";
            addSched.SpeakerStatus = "Pending";
            addSched.FlowersStatus = "Pending";
            addSched.UshersStatus = "Pending";
            return cmsProcess.AddSundayWorshipServiceSched(addSched.Date.Date, addSched.Presider, addSched.Speaker, addSched.Flowers, addSched.Ushers);
        }
        [HttpPost("AddDevotionSchedule")]
        public bool AddDevotionSchedules(Devotion addSched)
        {
            if (!cmsProcess.ValidateFridayDate(addSched.Date))
            {
                return false;
            }
            if (!cmsProcess.DateIsPast(addSched.Date))
            {
                return false;
            }
            if (cmsProcess.DevotionScheduleExist(addSched.Date))
            {
                return false;
            }
            return cmsProcess.AddDevotionSched(addSched.Date.Date, addSched.SongLeader, addSched.Presider, addSched.Speaker);
        }
        [HttpPost("AddTeacher")]
        public bool AddTeacher(TeachersList addTeacher)
        {
             return cmsProcess.AddTeachers(addTeacher.TeachersName, addTeacher.Assignment);
        }
        [HttpPost("AddLesson")]
        public bool AddLesson(Lesson addLesson)
        {
            if (!cmsProcess.ValidateSundayDate(addLesson.Date))
            {
                return false;
            }
            if (!cmsProcess.DateIsPast(addLesson.Date))
            {
                return false;
            }
            if (cmsProcess.DevotionScheduleExist(addLesson.Date))
            {
                return false;
            }
            return cmsProcess.AddLesson(addLesson.Date, addLesson.Lessson, addLesson.Materials);
        }
        [HttpPut("UpdateDiscipleshipSchedule")]
        public bool UpdateDiscipleshipSchedule(DiscipleshipMinistry updateSched)
        {

            if (!cmsProcess.DiscipleshipScheduleExist(updateSched.Date))
            {
                return false;
            }
            return cmsProcess.UpdateDiscipleshipSched(updateSched.Date, updateSched.Speaker, updateSched.Status, updateSched.Description, updateSched.Note);
        }
        [HttpPut("UpdatePrayerSchedule")]
        public bool UpdatePrayerSchedule(PrayerMinistry updateSched)
        {

            if (!cmsProcess.PrayerScheduleExist(updateSched.Date))
            {
                return false;
            }
            return cmsProcess.UpdatePrayerSched(updateSched.Date, updateSched.SongLeader, updateSched.SongLeaderStatus, updateSched.Presider, updateSched.PresiderStatus, updateSched.Speaker, updateSched.SpeakerStatus, updateSched.PrayerItem);
        }
        [HttpPut("UpdatePraiseAndWorshipSchedule")]
        public bool UpdatePraiseAndWorshipSchedule(PraiseAndWorship updateSched)
        {

            if (!cmsProcess.PraiseAndWorshipScheduleExist(updateSched.Date))
            {
                return false;
            }
            return cmsProcess.UpdatePraiseAndWorshipSched(updateSched.Date, updateSched.SongLeader, updateSched.SongLeaderStatus);
        }
        [HttpPut("UpdateSundayWorshipSchedule")]
        public bool UpdateSundayWorshipSchedule(SundayWorshipService updateSched)
        {

            if (!cmsProcess.SundayWorshipScheduleExist(updateSched.Date))
            {
                return false;
            }
            return cmsProcess.UpdateSundayWorshipServiceSched(updateSched.Date, updateSched.Presider, updateSched.PresiderStatus, updateSched.Speaker, updateSched.SpeakerStatus, updateSched.Flowers, updateSched.FlowersStatus, updateSched.Ushers, updateSched.UshersStatus);
        }
        [HttpPut("UpdateDevotionSchedule")]
        public bool UpdateDevotionSchedule(Devotion updateSched)
        {

            if (!cmsProcess.DevotionScheduleExist(updateSched.Date))
            {
                return false;
            }
            return cmsProcess.UpdateDevotionSched(updateSched.Date, updateSched.SongLeader, updateSched.SongLeaderStatus, updateSched.Presider, updateSched.PresiderStatus, updateSched.Speaker, updateSched.SpeakerStatus);
        }
        [HttpPut("UpdateTeachers")]
        public bool UpdateTeachers(TeachersList update)
        {

            if (!cmsProcess.TeacherNameExist(update.TeachersName))
            {
                return false;
            }
            return cmsProcess.UpdateTeachers(update.TeachersName, update.Assignment);
        }
        [HttpPut("UpdateLessons")]
        public bool UpdateLessons(Lesson update)
        {

            if (!cmsProcess.LessonExist(update.Date))
            {
                return false;
            }
            return cmsProcess.UpdateLesson(update.Date, update.Lessson, update.Materials);
        }
        [HttpDelete("DeleteDiscipleshipShced")]
        public bool DeleteDiscipleshipSched(DateTime date)
        {
            return cmsProcess.RemoveDiscipleSched(date);
        }
        [HttpDelete("DeletePrayerShced")]
        public bool DeletePrayerSched(DateTime date)
        {
            return cmsProcess.RemovePrayerSched(date);
        }
        [HttpDelete("DeletePraiseAndWorshipShced")]
        public bool DeletePraiseAndWorshipSched(DateTime date)
        {
            return cmsProcess.RemovePraiseAndWorshipSched(date);
        }
        [HttpDelete("DeleteSundayWorshipShced")]
        public bool DeleteSundayWorshipSched(DateTime date)
        {
            return cmsProcess.RemoveSundayWorshipSched(date);
        }
        [HttpDelete("DeleteDevotionShced")]
        public bool DeleteDevotionSched(DateTime date)
        {
            return cmsProcess.RemoveDevotionSched(date);
        }
        [HttpDelete("DeleteTeacher")]
        public bool DeleteTeacher(string teachersName)
        {
            return cmsProcess.RemoveTeacher(teachersName);
        }
        [HttpDelete("DeleteLesson")]
        public bool DeleteLessons(DateTime date)
        {
            return cmsProcess.RemoveLesson(date);
        }
    }
}
