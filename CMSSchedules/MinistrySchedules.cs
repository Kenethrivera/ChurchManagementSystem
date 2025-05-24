using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSSchedules
{
    public class DiscipleshipMinistry
    {
        private string date;
        private string speaker;
        private string description;
        private string note;

        public string Date
        {
            get { return date; }
            set { date = value; }
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
        public string Note
        {
            get { return note; }
            set { note = value; }
        }

    }
    public class PrayerMinistry
    {
        private string date;
        private string songLeader;
        private string presider;
        private string speaker;
        private string description;
        private string prayerItem;

        public string Date
        {
            get { return date; }
            set { date = value; }
        }
        public string SongLeader
        {
            get { return songLeader; }
            set { songLeader = value; }
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
        public string PrayerItem
        {
            get { return prayerItem; }
            set { prayerItem = value; }
        }

    }
    public class PraiseAndWorship
    {
        private string date;
        private string songLeader;
        private string instrumentalist;
        public string Date
        {
            get { return date; }
            set { date = value; }
        }
        public string SongLeader
        {
            get { return songLeader; }
            set { songLeader = value; }
        }
        public string Instrumentalist
        {
            get { return instrumentalist; }
            set { instrumentalist = value; }
        }


    }
    public class SundayWorshipService
    {
        private string date;
        private string presider;
        private string speaker;
        private string flowers;
        private string ushers;

        public string Date
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
        public string Flowers
        {
            get { return flowers; }
            set { flowers = value; }
        }
        public string Ushers
        {
            get { return ushers; }
            set { ushers = value; }
        }
    }
    public class Devotion
    {
        string presider;
        string speaker;
        string date;
        string songLeader;

        public string Date
        {
            get { return date; }
            set { date = value; }
        }
        public string SongLeader
        {
            get { return songLeader; }
            set { songLeader = value; }
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

    }
    public class TeachersList
    {
        private string teachersName;
        private string assignment;

        public string TeachersName
        {
            get { return teachersName; }
            set { teachersName = value; }
        }
        public string Assignment
        {
            get { return assignment; }
            set { assignment = value; }
        }
    }
    public class Lesson
    {
        private string date;
        private string lesson;
        private string materials;

        public string Date
        {
            get { return date; }
            set { date = value; }
        }
        public string Lessson
        {
            get { return lesson; }
            set { lesson = value; }
        }
        public string Materials
        {
            get { return materials; }
            set { materials = value; }
        }
    }
}
