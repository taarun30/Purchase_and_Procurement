using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RetailStore.Models
{
    [Table("Inventory")]
    public class Inventory
    {

        public Inventory()
       {
          OrderDetails = new List<OrderDetail>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int InventoryId { get; set; }

        [StringLength(30)]
        public string Productname { get; set; }

        public int? ProductPrice { get; set; }

        [StringLength(600)]
        public string ProductDescription { get; set; }

        public int? QuantityInHand { get; set; }

        public int? ReorderLevel { get; set; }

        public int? Rating { get; set; }


        public  ICollection<OrderDetail> OrderDetails { get; set; }
    }
}