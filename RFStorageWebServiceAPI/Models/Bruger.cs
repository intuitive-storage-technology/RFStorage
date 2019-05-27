namespace RFStorageWebServiceAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Bruger")]
    public partial class Bruger
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Bruger()
        {
            Ordre = new HashSet<Ordre>();
        }

        [StringLength(8)]
        public string BrugerID { get; set; }

        [Required]
        [StringLength(50)]
        public string Brugernavn { get; set; }

        [Required]
        [StringLength(30)]
        public string BrugerPassword { get; set; }

        [Required]
        [StringLength(30)]
        public string BrugerType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ordre> Ordre { get; set; }
    }
}
