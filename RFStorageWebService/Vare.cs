namespace RFStorageWebService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Vare")]
    public partial class Vare
    {
        [Key]
        [StringLength(50)]
        public string VareNavn { get; set; }

        public int? VareID { get; set; }

        [Required]
        [StringLength(50)]
        public string VareType { get; set; }

        public int Antal { get; set; }
    }
}
