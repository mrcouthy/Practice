namespace EfPractice
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RB_Report
    {
        [Key]
        public int ReportId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        public int CreatedById { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? CreatedDate { get; set; }

        public string ReportSQL { get; set; }

        public string ReportObject { get; set; }

        [StringLength(100)]
        public string ReportTableName { get; set; }

        [StringLength(50)]
        public string ReportStatus { get; set; }
    }
}
