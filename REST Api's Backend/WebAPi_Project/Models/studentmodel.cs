using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPi_Project.Models
{
    public class studentmodel
    {
        public string id { get; set; }
        public string fname { get; set; }
        public string depart { get; set; }
        public string student_batch { get; set; }
        public string current_sem { get; set; }
        public string gender { get; set; }
        public string email { get; set; }
        public string contact_number { get; set; }
        public string section { get; set; }
        public string cgpa { get; set; }

        public virtual ICollection<REGISTRATION> REGISTRATIONs { get; set; }
    }
}