//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PMS.Models.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserStudio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UserStudio()
        {
            this.JobDateUsers = new HashSet<JobDateUser>();
        }
    
        public int id { get; set; }
        public Nullable<int> studioid { get; set; }
        public Nullable<int> userid { get; set; }
        public Nullable<int> studioroleid { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JobDateUser> JobDateUsers { get; set; }
        public virtual Studio Studio { get; set; }
        public virtual StudioRole StudioRole { get; set; }
        public virtual User User { get; set; }
    }
}
