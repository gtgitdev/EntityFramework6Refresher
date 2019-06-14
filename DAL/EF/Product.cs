namespace DAL.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Store.Products")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
            ShoppingCartRecords = new HashSet<ShoppingCartRecord>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int CategoryId { get; set; }

        [Column(TypeName = "money")]
        public decimal CurrentPrice { get; set; }

        [StringLength(3800)]
        public string Description { get; set; }

        public bool IsFeatured { get; set; }

        [StringLength(50)]
        public string ModelName { get; set; }

        [StringLength(50)]
        public string ModelNumber { get; set; }

        [StringLength(150)]
        public string ProductImage { get; set; }

        [StringLength(150)]
        public string ProductImageLarge { get; set; }

        [StringLength(150)]
        public string ProductImageThumb { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] TimeStamp { get; set; }

        [Column(TypeName = "money")]
        public decimal UnitCost { get; set; }

        public int UnitsInStock { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ShoppingCartRecord> ShoppingCartRecords { get; set; }
    }
}
