using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RetailStore.Models
{
    [Table("OrdersMaster")]
    public class OrdersMaster
    {
        
        public OrdersMaster()
        {
            Feedbacks = new HashSet<Feedback>();
            Invoices = new HashSet<Invoice>();
            OrderDetails = new HashSet<OrderDetail>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrderID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? OrderDate { get; set; }

        [StringLength(50)]
        public string OrderStatus { get; set; }

        [StringLength(50)]
        public string PaymentMode { get; set; }

        public int? TotalAmount { get; set; }

        public int? RetailerId { get; set; }

       
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<OrderDetail>OrderDetails{ get;set; }

        
        public virtual ICollection<Invoice> Invoices { get; set; }
        [ForeignKey("RetailerId")]
        //public int RetailerId { get; set; }
        public virtual Retailer Retailer { get; set; }
    }
}