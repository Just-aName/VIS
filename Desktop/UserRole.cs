//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Desktop
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserRole
    {
        public int User_ID { get; set; }
        public int Role_ID { get; set; }
        public Nullable<bool> Active { get; set; }
    
        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
    }
}
