namespace TataGamedom.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Supplier
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Supplier()
        {
            StockInSheets = new HashSet<StockInSheet>();
        }

        public int Id { get; set; }

        [Display(Name="�t��")]
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(15)]
        [Display(Name = "�q��")]
        public string Phone { get; set; }

        [StringLength(30)]
        [Display(Name = "�H�c")]
        public string Email { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StockInSheet> StockInSheets { get; set; }
    }
}
