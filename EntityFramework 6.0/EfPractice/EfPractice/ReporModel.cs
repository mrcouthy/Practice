namespace EfPractice
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ReporModel : DbContext
    {
        public ReporModel()
            : base("name=ReporModel")
        {
        }

        public virtual DbSet<RB_Report> RB_Report { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RB_Report>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<RB_Report>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<RB_Report>()
                .Property(e => e.ReportSQL)
                .IsUnicode(false);

            modelBuilder.Entity<RB_Report>()
                .Property(e => e.ReportObject)
                .IsUnicode(false);

            modelBuilder.Entity<RB_Report>()
                .Property(e => e.ReportTableName)
                .IsUnicode(false);

            modelBuilder.Entity<RB_Report>()
                .Property(e => e.ReportStatus)
                .IsUnicode(false);
        }
    }
}
