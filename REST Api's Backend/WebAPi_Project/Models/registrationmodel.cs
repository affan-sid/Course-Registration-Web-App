using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPi_Project.Models
{
    public class registrationmodel
    {
        public string stud_id { get; set; }
        public string course_id { get; set; }
        public string section { get; set; }
        public string c_status { get; set; }
        public string pre_requisite { get; set; }

        public Nullable<System.DateTime> created_at { get; set; }
        public Nullable<System.DateTime> updated_at { get; set; }
    }
}