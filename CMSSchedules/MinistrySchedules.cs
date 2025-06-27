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
        private DateTime date;
        private string speaker;
        private string description;
        private string note;
        private string status = "Pending";

        public DateTime Date
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
        public string Status
        {
            get { return status; }
            set
            {
                if (value == "Pending" || value == "Confirmed" || value == "Request to be Changed")
                {
                    status = value;
                } else
                {
                    throw new ArgumentException("Invalid Request");
                }
            }
        }

    }
    public class PrayerMinistry
    {
        private DateTime date;
        private string songLeader;
        private string songLeaderStatus = "Pending";
        private string presider;
        private string presiderStatus = "Pending";
        private string speaker;
        private string speakerStatus = "Pending";
        private string prayerItem;

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
        public string SongLeader
        {
            get { return songLeader; }
            set { songLeader = value; }
        }
        public string SongLeaderStatus
        {
            get { return songLeaderStatus; }
            set
            {
                if (value == "Pending" || value == "Confirmed" || value == "Request to be Changed")
                {
                    songLeaderStatus = value;
                }
                else
                {
                    throw new ArgumentException("Invalid Request");
                }
            }
        }
        public string Presider
        {
            get { return presider; }
            set { presider = value; }
        }
        public string PresiderStatus
        {
            get { return presiderStatus; }
            set
            {
                if (value == "Pending" || value == "Confirmed" || value == "Request to be Changed")
                {
                    presiderStatus = value;
                }
                else
                {
                    throw new ArgumentException("Invalid Request");
                }
            }
        }
        public string Speaker
        {
            get { return speaker; }
            set { speaker = value; }
        }
        public string SpeakerStatus
        {
            get { return speakerStatus; }
            set
            {
                if (value == "Pending" || value == "Confirmed" || value == "Request to be Changed")
                {
                    speakerStatus = value;
                }
                else
                {
                    throw new ArgumentException("Invalid Request");
                }
            }
        }
        public string PrayerItem
        {
            get { return prayerItem; }
            set { prayerItem = value; }
        }

    }
    public class PraiseAndWorship
    {
        private DateTime date;
        private string songLeader;
        private string songLeaderStatus = "Pending";
        private string instrumentalist;
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
        public string SongLeader
        {
            get { return songLeader; }
            set { songLeader = value; }
        }
        public string SongLeaderStatus
        {
            get { return songLeaderStatus; }
            set
            {
                if (value == "Pending" || value == "Confirmed" || value == "Request to be Changed")
                {
                    songLeaderStatus = value;
                }
                else
                {
                    throw new ArgumentException("Invalid Request");
                }
            }
        }
        public string Instrumentalist
        {
            get { return instrumentalist; }
            set { instrumentalist = value; }
        }


    }
    public class SundayWorshipService
    {
        private DateTime date;
        private string presider;
        private string presiderStatus = "Pending";
        private string speaker;
        private string speakerStatus = "Pending";
        private string flowers;
        private string flowersStatus = "Pending";
        private string ushers;
        private string ushersStatus = "Pending";

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
        public string Presider
        {
            get { return presider; }
            set { presider = value; }
        }
        public string PresiderStatus
        {
            get { return presiderStatus; }
            set
            {
                if (value == "Pending" || value == "Confirmed" || value == "Request to be Changed")
                {
                    presiderStatus = value;
                }
                else
                {
                    throw new ArgumentException("Invalid Request");
                }
            }
        }
        public string Speaker
        {
            get { return speaker; }
            set { speaker = value; }
        }
        public string SpeakerStatus
        {
            get { return speakerStatus ; }
            set
            {
                if (value == "Pending" || value == "Confirmed" || value == "Request to be Changed")
                {
                    speakerStatus = value;
                }
                else
                {
                    throw new ArgumentException("Invalid Request");
                }
            }
        }
        public string Flowers
        {
            get { return flowers; }
            set { flowers = value; }
        }
        public string FlowersStatus
        {
            get { return flowersStatus; }
            set
            {
                if (value == "Pending" || value == "Confirmed" || value == "Request to be Changed")
                {
                    flowersStatus = value;
                }
                else
                {
                    throw new ArgumentException("Invalid Request");
                }
            }
        }
        public string Ushers
        {
            get { return ushers; }
            set { ushers = value; }
        }
        public string UshersStatus
        {
            get { return ushersStatus; }
            set
            {
                if (value == "Pending" || value == "Confirmed" || value == "Request to be Changed")
                {
                    ushersStatus = value;
                }
                else
                {
                    throw new ArgumentException("Invalid Request");
                }
            }
        }
    }
    public class Devotion
    {
        private string presider;
        private string presiderStatus = "Pending";
        private string speaker;
        private string speakerStatus = "Pending";
        private DateTime date;
        private string songLeader;
        private string songLeaderStatus = "Pending";

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
        public string SongLeader
        {
            get { return songLeader; }
            set { songLeader = value; }
        }
        public string SongLeaderStatus
        {
            get { return songLeaderStatus; }
            set
            {
                if (value == "Pending" || value == "Confirmed" || value == "Request to be Changed")
                {
                    songLeaderStatus = value;
                }
                else
                {
                    throw new ArgumentException("Invalid Request");
                }
            }
        }
        public string Presider
        {
            get { return presider; }
            set { presider = value; }
        }
        public string PresiderStatus
        {
            get { return presiderStatus; }
            set
            {
                if (value == "Pending" || value == "Confirmed" || value == "Request to be Changed")
                {
                    presiderStatus = value;
                }
                else
                {
                    throw new ArgumentException("Invalid Request");
                }
            }
        }
        public string Speaker
        {
            get { return speaker; }
            set { speaker = value; }
        }
        public string SpeakerStatus
        {
            get { return speakerStatus; }
            set
            {
                if (value == "Pending" || value == "Confirmed" || value == "Request to be Changed")
                {
                    speakerStatus = value;
                }
                else
                {
                    throw new ArgumentException("Invalid Request");
                }
            }
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
        private DateTime date;
        private string lesson;
        private string materials;

        public DateTime Date
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
