using System;
using System.Collections.Generic;

#nullable disable

namespace StaffsApi.Model
{
    public partial class Class
    {
        public int ClassId { get; set; }
        public int CourseId { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Link { get; set; }

        public virtual Course Course { get; set; }
    }
}
