using System;
using System.Collections.Generic;

#nullable disable

namespace StaffsApi.Model
{
    public partial class Course
    {
        public Course()
        {
            Classes = new HashSet<Class>();
            CourseEnrolls = new HashSet<CourseEnroll>();
            Topics = new HashSet<Topic>();
        }

        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public DateTime UpdateTime { get; set; }
        public decimal Amount { get; set; }

        public virtual ICollection<Class> Classes { get; set; }
        public virtual ICollection<CourseEnroll> CourseEnrolls { get; set; }
        public virtual ICollection<Topic> Topics { get; set; }
    }
}
