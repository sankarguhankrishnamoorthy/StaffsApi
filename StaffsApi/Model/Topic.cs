using System;
using System.Collections.Generic;

#nullable disable

namespace StaffsApi.Model
{
    public partial class Topic
    {
        public int TopicId { get; set; }
        public string TopicName { get; set; }
        public string TopicDesc { get; set; }
        public string MaterialPath { get; set; }
        public string VideoPath { get; set; }
        public int CourseId { get; set; }

        public virtual Course Course { get; set; }
    }
}
