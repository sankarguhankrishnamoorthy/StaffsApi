using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvcclient.Models
{
    public class Topic
    {
        public int TopicId { get; set; }
        public string TopicName { get; set; }
        public string TopicDesc { get; set; }
        public string MaterialPath { get; set; }
        public string VideoPath { get; set; }
        public int CourseId { get; set; }
    }
}
