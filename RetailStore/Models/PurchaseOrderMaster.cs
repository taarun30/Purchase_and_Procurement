using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RetailStore.Models
{
    [Table("PurchaseOrderMaster")]
    public class PurchaseOrderMaster
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PurchaseOrderID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? PurchaseOrderDate { get; set; }

        [StringLength(30)]
        public string PurchaseOrderStatus { get; set; }

        [StringLength(30)]
        public string PaymentMode { get; set; }

        public int? TotalAmount { get; set; }

        //public int? ManufacturerId { get; set; }

        [StringLength(30)]
        public string PaymentStatus { get; set; }
        //[ForeignKey("ManufacturerId")]
        public int ManufacturerId { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
    }
}