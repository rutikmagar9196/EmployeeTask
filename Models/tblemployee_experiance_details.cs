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
    
    public partial class tblemployee_experiance_details
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblemployee_experiance_details()
        {
            this.tblemployee_experiance_projects = new HashSet<tblemployee_experiance_projects>();
        }
    
        public int Experiance_Id { get; set; }
        public Nullable<int> Emp_Id { get; set; }
        public string Company_Name { get; set; }
        public string Form_Date { get; set; }
        public string To_Date { get; set; }
        public Nullable<int> Designation_Id { get; set; }
    
        public virtual tbldesignation tbldesignation { get; set; }
        public virtual tblemployee tblemployee { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblemployee_experiance_projects> tblemployee_experiance_projects { get; set; }
    }
}
