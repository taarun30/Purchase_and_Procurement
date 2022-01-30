using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RetailStore.Models
{
    [Table("Invoice")]
    public class Invoice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int InvoiceNo { get; set; }

        public int? InvoiceAmount { get; set; }

        [StringLength(50)]
        public string InvoiceStatus { get; set; }

        [Column(TypeName = "date")]
        public DateTime? InvoiceDate { get; set; }

        //public int? OrderId { get; set; }
        //[ForeignKey("OrderId")]
        public int OrderId { get; set; }
        public virtual OrdersMaster OrdersMaster { get; set; }
    }
}