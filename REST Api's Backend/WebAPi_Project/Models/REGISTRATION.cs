//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebAPi_Project.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class REGISTRATION
    {
        public string stud_id { get; set; }
        public string course_id { get; set; }
        public string section { get; set; }
        public string c_status { get; set; }
        public string pre_requisite { get; set; }
        public Nullable<System.DateTime> created_at { get; set; }
        public Nullable<System.DateTime> updated_at { get; set; }
    
        public virtual course course { get; set; }
        public virtual student student { get; set; }
    }
}
