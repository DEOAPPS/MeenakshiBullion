//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MB_WEB.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class document_tbl
    {
        public int DOCUMENT_ID { get; set; }
        public string DOCUMENT_NAME { get; set; }
        public string DOCUMENT_URL { get; set; }
        public string STATUS { get; set; }
        public Nullable<int> CUSTOMER_ID { get; set; }
    
        public virtual customer_tbl customer_tbl { get; set; }
    }
}