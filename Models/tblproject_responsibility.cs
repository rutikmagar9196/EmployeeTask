//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EmployeeTask.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblproject_responsibility
    {
        public int Responsibility_Id { get; set; }
        public Nullable<int> Project_Id { get; set; }
        public string Responsibility { get; set; }
    
        public virtual tblemployee_experiance_projects tblemployee_experiance_projects { get; set; }
    }
}
