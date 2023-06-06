namespace StudentManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FacultyCourse")]
    public partial class FacultyCourse
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string facultyID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string courseID { get; set; }

        [StringLength(10)]
        public string temp { get; set; }

        public virtual Course Course { get; set; }

        public virtual Faculty Faculty { get; set; }
    }
}
