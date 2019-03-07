namespace ClientLourdWpf
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class brokers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public brokers()
        {
            appointments = new HashSet<appointments>();
        }

        [Key]
        public int idBroker { get; set; }

        [Required]
        [StringLength(50)]
        public string lastName { get; set; }

        [Required]
        [StringLength(50)]
        public string firstName { get; set; }

        [Required]
        [StringLength(100)]
        public string mail { get; set; }

        [Required]
        [StringLength(10)]
        public string phoneNumber { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<appointments> appointments { get; set; }
    }
}
