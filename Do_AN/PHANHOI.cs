//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Do_AN
{
    using System;
    using System.Collections.Generic;
    
    public partial class PHANHOI
    {
        public string SOPH { get; set; }
        public string MANV { get; set; }
        public Nullable<System.DateTime> NGPH { get; set; }
        public string LOIPH { get; set; }
    
        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
