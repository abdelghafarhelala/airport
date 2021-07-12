namespace project.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("passenger")]
    public partial class passenger
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public passenger()
        {
            flights = new HashSet<flight>();
        }

        public int id { get; set; }

        [StringLength(50)]
        [MinLength(3)]
        [Required(ErrorMessage = "*")]
        public string name { get; set; }

        [Range(20, 60, ErrorMessage = "age must between 20 and 60")]
        public int? age { get; set; }

        [StringLength(50)]
        public string country { get; set; }

        public int? phone { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "*")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$", ErrorMessage = "invalid E-mail")]
        public string email { get; set; }

        [StringLength(50)]
        [MinLength(5)]
        [Required(ErrorMessage = "*")]
        public string password { get; set; }

        [StringLength(50)]
        [NotMapped]
        [MinLength(5)]
        [Required(ErrorMessage = "confirm password is reqired!")]
        [Compare("password")]
        [DisplayName("Confirm  password")]
        public string confpassword { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BD { get; set; }

        [StringLength(10)]
        public string gender { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<flight> flights { get; set; }
    }
}
