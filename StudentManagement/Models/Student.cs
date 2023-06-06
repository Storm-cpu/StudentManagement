namespace StudentManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Student")]
    public partial class Student
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Student()
        {
            StudentMarks = new HashSet<StudentMark>();
        }

        [StringLength(10)]
        public string studentID { get; set; }

        [StringLength(50)]
        public string fullName { get; set; }

        [StringLength(10)]
        public string gender { get; set; }

        [Column(TypeName = "date")]
        public DateTime? birthday { get; set; }

        [StringLength(100)]
        public string homeTown { get; set; }

        [Column(TypeName = "image")]
        public byte[] image { get; set; }

        [StringLength(10)]
        public string classID { get; set; }

        [StringLength(10)]
        public string facultyID { get; set; }

        public double? avgScore { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        public virtual Class Class { get; set; }

        public virtual Faculty Faculty { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentMark> StudentMarks { get; set; }
    }
}
