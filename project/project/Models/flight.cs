namespace project.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("flight")]
    public partial class flight
    {
        [Key]
        public int f_id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date { get; set; }

        public int? p_id { get; set; }

        public int? cat_id { get; set; }

        public int? s_id { get; set; }

        public int? fr_id { get; set; }

        public virtual catloge catloge { get; set; }

        public virtual from from { get; set; }

        public virtual passenger passenger { get; set; }

        public virtual select_dir select_dir { get; set; }
    }
}
