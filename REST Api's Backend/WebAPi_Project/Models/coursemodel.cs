using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPi_Project.Models
{
    public class coursemodel
    {
        public string id { get; set; }
        public string name { get; set; }
        public int credithours { get; set; }
        public string pre_requisite { get; set; }
        public virtual ICollection<REGISTRATION> REGISTRATIONs { get; set; }

    }
}