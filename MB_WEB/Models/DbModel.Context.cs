﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class sri123_mbdbEntities1 : DbContext
    {
        public sri123_mbdbEntities1()
            : base("name=sri123_mbdbEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Tbl_Student> Tbl_Student { get; set; }
        public virtual DbSet<admin_tbl> admin_tbl { get; set; }
        public virtual DbSet<customer_tbl> customer_tbl { get; set; }
        public virtual DbSet<DISTRICT_MASTER> DISTRICT_MASTER { get; set; }
        public virtual DbSet<DISTRICT_TBL> DISTRICT_TBL { get; set; }
        public virtual DbSet<document_tbl> document_tbl { get; set; }
        public virtual DbSet<INSURANCE> INSURANCEs { get; set; }
        public virtual DbSet<STATE_MASTER> STATE_MASTER { get; set; }
        public virtual DbSet<STATE_TBL> STATE_TBL { get; set; }
        public virtual DbSet<user_collections_tbl> user_collections_tbl { get; set; }
        public virtual DbSet<user_tbl> user_tbl { get; set; }
        public virtual DbSet<customer_tbl_TMP> customer_tbl_TMP { get; set; }
        public virtual DbSet<tbl_Practicevideoupload> tbl_Practicevideoupload { get; set; }
        public virtual DbSet<user_tbl_TMP> user_tbl_TMP { get; set; }
    }
}
