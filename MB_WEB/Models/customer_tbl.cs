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
    
    public partial class customer_tbl
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public customer_tbl()
        {
            this.INSURANCEs = new HashSet<INSURANCE>();
            this.user_tbl = new HashSet<user_tbl>();
            this.document_tbl1 = new HashSet<document_tbl>();
        }
    
        public int CUSTOMER_ID { get; set; }
        public string NAME { get; set; }
        public string COMPANY_NAME { get; set; }
        public string FATHERS_NAME { get; set; }
        public string MOTHERS_NAME { get; set; }
        public string PADDR_ADDRESS { get; set; }
        public string PADDR_DISTRICT { get; set; }
        public string PADDR_STATE { get; set; }
        public string PADDR_COUNTRY { get; set; }
        public string PADDR_PIN_CODE { get; set; }
        public string SADDR_ADDRESS { get; set; }
        public string SADDR_DISTRICT { get; set; }
        public string SADDR_STATE { get; set; }
        public string SADDR_COUNTRY { get; set; }
        public string SADDR_PIN_CODE { get; set; }
        public string GST_NO { get; set; }
        public string SALES_TAX_NO { get; set; }
        public string CENTRAL_TAX_NO { get; set; }
        public string MOBILE_NO { get; set; }
        public string ALTERNATE_NO { get; set; }
        public string EMAIL_ID { get; set; }
        public string REMARKS { get; set; }
        public Nullable<int> USER_ID { get; set; }
        public System.DateTime CREATED_DATE { get; set; }
        public Nullable<System.DateTime> UPDATED_DATE { get; set; }
        public string PHOTO { get; set; }
        public Nullable<decimal> AMOUNT { get; set; }
        public string Description { get; set; }
        public short IS_INSPECTION { get; set; }
        public string STATE { get; set; }
        public string DISTRICT { get; set; }
        public Nullable<int> STATE_ID { get; set; }
        public Nullable<int> DISTRICT_ID { get; set; }
        public Nullable<int> InspectionId { get; set; }
        public string CUSTOMER_TYPE { get; set; }
        public string CUSTOMER_GUID { get; set; }
        public Nullable<int> INSURANCE_ID { get; set; }
        public Nullable<int> DOCUMENT_ID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INSURANCE> INSURANCEs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<user_tbl> user_tbl { get; set; }
        public virtual user_tbl user_tbl1 { get; set; }
        public virtual document_tbl document_tbl { get; set; }
        public virtual INSURANCE INSURANCE { get; set; }
        public virtual DISTRICT_MASTER DISTRICT_MASTER { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<document_tbl> document_tbl1 { get; set; }
        public virtual STATE_MASTER STATE_MASTER { get; set; }
    }
}
