using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace RetailStore.Models
{
    [Table("PurchaseOrderDetail")]
    public class PurchaseOrderDetail
    {
        [Key]
        public int slno { get; set; }
        public int PurchaseOrderID { get; set; }
        public virtual PurchaseOrderMaster PurchaseOrderMaster { get; set; }
        public int InventoryId { get; set; }
        public virtual Inventory Inventory { get; set; }
        public int Quantity { get; set; }
        public float Amount { get; set; }

    }
}