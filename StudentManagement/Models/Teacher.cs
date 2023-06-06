namespace StudentManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Teacher")]
    public partial class Teacher
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Teacher()
        {
            Classes = new HashSet<Class>();
        }

        [StringLength(10)]
        public string teacherID { get; set; }

        [StringLength(50)]
        public string fullName { get; set; }

        [StringLength(100)]
        public string address { get; set; }

        [StringLength(10)]
        public string facultyID { get; set; }

        [StringLength(20)]
        public string phoneNumber { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Class> Classes { get; set; }

        public virtual Faculty Faculty { get; set; }
    }
}
