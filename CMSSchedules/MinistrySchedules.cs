using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSSchedules
{
    public class DiscipleshipMinistry
    {
        private int date;
        private string presider;
        private string speaker;
        private string description;

        public int Date
        {
            get { return date; }
            set { date = value; }
        }
        public string Presider
        {
            get { return presider; }
            set { presider = value; }
        }
        public string Speaker
        {
            get { return speaker; }
            set { speaker = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string GetDiscipleshipScheduleDetails()
        {
            return ($"Date: {date}\nSpeaker: {speaker}\nPresider: {presider}\nDescription: {description} ");
            
        }
        

    }
    public class PrayerMinistry
    {
        private int date;
        private string presider;
        private string speaker;
        private string description;

        public int Date
        {
            get { return date; }
            set { date = value; }
        }
        public string Presider
        {
            get { return presider; }
            set { presider = value; }
        }
        public string Speaker
        {
            get { return speaker; }
            set { speaker = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string GetPrayerScheduleDetails()
        {
            return ($"Date: {date}\nSpeaker: {speaker}\nPresider: {presider}\nDescription: {description} ");

        }
    }
    public class WorshipMinistry
    {
        //for option 1
        //the sunday worship service
        private int date;
        private string presider;
        private string speaker;
        private string description;
        public int Date
        {
            get { return date; }
            set { date = value; }
        }
        public string Presider
        {
            get { return presider; }
            set { presider = value; }
        }
        public string Speaker
        {
            get { return speaker; }
            set { speaker = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        //for option 2
        //weekly p&w practices

        private string songLeader;
        private string firstRehearsalDate;
        private string finalRehearsalDate;
        private string firstRehearsalTime;
        private string finalRehearsalTime;
        
        public string SongLeader
        {
            get { return songLeader; }
            set { songLeader = value; }
        }
        public string FirstRehearsalDate
        {
            get { return firstRehearsalDate; }
            set { firstRehearsalDate = value; }
        }
        public string FinalRehearsalDate
        {
            get { return finalRehearsalDate; }
            set { finalRehearsalDate = value; }
        }
        public string FirstRehearsalTime
        {
            get { return firstRehearsalTime; }
            set { firstRehearsalTime = value; }
        }
        public string FinalRehearsalTime
        {
            get { return finalRehearsalTime; }
            set { finalRehearsalTime = value; }
        }

        //for option 3
        //weekly devotion schedule
        private string devotionSpeaker;
        private string devotionPresider;
        private string devotionDate;
        private string devotionTime;

        public string DevotionSpeaker
        {
            get { return devotionSpeaker; }
            set { devotionSpeaker = value; }
        }
        public string DevotionPresider
        {
            get { return devotionPresider; }
            set { devotionPresider = value; }
        }
        public string DevotionDate
        {
            get { return devotionDate; }
            set { devotionDate = value; }
        }
        public string DevotionTime
        {
            get { return devotionTime; }
            set { devotionTime = value; }
        }

        public string GetSundayWorshipServiceDetails()
        {
            return ($"Date: {date}\nSpeaker: {speaker}\nPresider: {presider}\nDescription: {description} ");

        }
        public string GetPraiseAndWorshipDetails()
        {
            return ($"SongLeader: {songLeader}\nFirstRehearsalDate: {finalRehearsalDate}\nFinalRehearsalDate: {finalRehearsalDate}\nFistRehearsalTime: {firstRehearsalTime}\nFinalRehearsalTime: {FinalRehearsalTime} ");
        }
        public string GetDevotionDetails()
        {
            return ($"Speaker: {devotionSpeaker}\nPresider: {devotionPresider}\nDevotion Date: {devotionDate}\nDevotion Time: {devotionTime}");
        }
    }

    public class ChristianEducation
    {
        private string teachersName;

        public string TeachersName
        {
            get { return teachersName; }
            set { teachersName = value; }
        }

        public string GetTeachersList()
        {
            return ($"Teacher's List: {teachersName}");
        }
    }
}
