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
    
    public partial class StudioLink
    {
        public int id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public Nullable<int> studioid { get; set; }
    
        public virtual Studio Studio { get; set; }
    }
}