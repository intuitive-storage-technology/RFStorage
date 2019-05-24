namespace RFStorageWebService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ordre")]
    public partial class Ordre
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrdreID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrganisationID { get; set; }

        public DateTime OrdreDateTime { get; set; }

        [StringLength(50)]
        public string Note { get; set; }

        [Required]
        [StringLength(8)]
        public string Udleverer { get; set; }

        public virtual Bruger Bruger { get; set; }
    }
}
