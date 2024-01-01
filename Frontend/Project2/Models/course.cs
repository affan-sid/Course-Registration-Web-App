using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project2.Models
{
    public class course
    {
        public course()
        {
            this.REGISTRATIONs = new HashSet<registration>();
        }
        [DisplayName("Course Id")]
        public string id { get; set; }

        [DisplayName("Course Name")]
        public string name { get; set; }

        [DisplayName("Credit Hours")]
        public Nullable<int> credithours { get; set; }

        [DisplayName("Pre Requisite")]
        public string pre_requisite { get; set; }
        public Nullable<System.DateTime> created_at { get; set; }
        public Nullable<System.DateTime> updated_at { get; set; }

        public virtual ICollection<registration> REGISTRATIONs { get; set; }
    }
}