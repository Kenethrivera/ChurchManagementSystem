using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSTopics
{
    public class DiscipleshipTopics
    {
        private string topic;
        private string description;
        private string materials;
        private string dateTime;

        public string Topic
        {
            get { return topic; }
            set { topic = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public string Materials
        {
            get { return materials; }
            set { materials = value; }
        }
        public string DateTime
        {
            get { return dateTime; }
            set { dateTime = value; }
        }
        public string GetDiscipleshipTopicDetails()
        {
            return ($"Date and Time: {dateTime}\nTopic: {topic}\nDescription: {description}\nMaterials: {materials}");
        }
    }
    public class PrayerMinistryTopics
    {
        private string prayerRequest;
        public string PrayerRequest
        {
            get { return prayerRequest; }
            set { prayerRequest = value; }
        }
        public string GetPrayerRequest()
        {
            return ($"Prayer Request: {prayerRequest}");
        }
    }

    public class WorshipMinistryTopics
    {
        private string repertoire;

        public string Repertoire
        {
            get { return repertoire; }
            set { repertoire = value; }
        }

        public string GetRepertoire()
        {
            return ($"Repretoire List: {repertoire}");
        }
    }

    public class ChristianEducationTopics
    {
        private string lesson;
        private string teacher;
        private string materials;

        public string Lesson
        {
            get { return lesson; }
            set { lesson = value; }
        }
        public string Teacher
        {
            get { return teacher; }
            set { teacher = value; }
        }
        public string Materials
        {
            get { return materials; }
            set { materials = value; }
        }

        public string GetLessonDetails()
        {
            return ($"Lesson: {lesson}\nTeacher: {teacher}\nMaterials: {materials}");
        }
    }
}
