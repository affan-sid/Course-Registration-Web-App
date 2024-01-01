using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Project2.Models
{
    public class registration
    {
        [DisplayName("Student ID")]
        public string stud_id { get; set; }
        [DisplayName("Course ID")]
        public string course_id { get; set; }
        [DisplayName("Section")]
        public string section { get; set; }
        [DisplayName("Status")]
        public string c_status { get; set; }
        [DisplayName("Pre Requisite")]
        public string pre_requisite { get; set; }
        public Nullable<System.DateTime> created_at { get; set; }
        public Nullable<System.DateTime> updated_at { get; set; }

        public virtual course course { get; set; }
        public virtual student student { get; set; }
    }
}