﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace React_Service.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SurvayDatabaseEntities2 : DbContext
    {
        public SurvayDatabaseEntities2()
            : base("name=SurvayDatabaseEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Answer> Answer { get; set; }
        public virtual DbSet<Bolge> Bolge { get; set; }
        public virtual DbSet<ExamInfo> ExamInfo { get; set; }
        public virtual DbSet<Participant> Participant { get; set; }
        public virtual DbSet<QuestionType> QuestionType { get; set; }
        public virtual DbSet<QuestionTypeFiveChoseExam> QuestionTypeFiveChoseExam { get; set; }
        public virtual DbSet<QuestionTypeFiveChoseSurvey> QuestionTypeFiveChoseSurvey { get; set; }
        public virtual DbSet<QuestionTypeImage> QuestionTypeImage { get; set; }
        public virtual DbSet<QuestionTypeThree> QuestionTypeThree { get; set; }
        public virtual DbSet<QuestionTypeYesNo> QuestionTypeYesNo { get; set; }
        public virtual DbSet<SurveyInfo> SurveyInfo { get; set; }
    }
}