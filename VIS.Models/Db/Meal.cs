//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VIS.Models.Db
{
    using System;
    using System.Collections.Generic;
    
    public partial class Meal
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Meal()
        {
            this.Dailyrecords = new HashSet<Dailyrecords>();
        }
    
        public int Meal_id { get; set; }
        public string Nazev { get; set; }
        public Nullable<double> Kalorie { get; set; }
        public Nullable<double> Bilkoviny { get; set; }
        public Nullable<double> Tuky { get; set; }
        public Nullable<double> Cukry { get; set; }
        public Nullable<double> Vlaknina { get; set; }
        public Nullable<bool> Verejne { get; set; }
        public int User_ID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dailyrecords> Dailyrecords { get; set; }
        public virtual User User { get; set; }
    }
}
