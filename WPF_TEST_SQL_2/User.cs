//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WPF_TEST_SQL_2
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public int id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public Nullable<System.DateTime> birthdate { get; set; }
        public string image { get; set; }
        public Nullable<int> idRole { get; set; }
    
        public virtual Role Role { get; set; }
    }
}
