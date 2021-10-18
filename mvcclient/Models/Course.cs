using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvcclient.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public DateTime UpdateTime { get; set; }
        public decimal Amount { get; set; }
    }
}
