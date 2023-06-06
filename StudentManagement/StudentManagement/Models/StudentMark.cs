namespace StudentManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StudentMark")]
    public partial class StudentMark
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string studentID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string courseID { get; set; }

        public double? score { get; set; }

        public virtual Course Course { get; set; }

        public virtual Student Student { get; set; }
    }
}
