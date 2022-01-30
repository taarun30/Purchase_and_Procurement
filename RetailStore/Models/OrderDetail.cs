using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RetailStore.Models
{
    [Table("OrderDetail")]
    public class OrderDetail
    {
        [Key]
        public int slno { get; set; }
        public int OrderId { get; set; }
        public virtual OrdersMaster OrdersMaster { get; set; }
        public int InventoryId { get; set; }
        public virtual Inventory Inventory { get; set; }
        public int Quantity { get; set; }
        public string PaymentMode { get; set; }
    }
}