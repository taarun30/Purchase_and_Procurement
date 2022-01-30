using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RetailStore.Models
{
    [Table("Feedback")]
    public class Feedback
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FeedbackId { get; set; }

        //public int? RetailerId { get; set; }

        //public int? OrderId { get; set; }

        [StringLength(100)]
        public string FeedbackScore { get; set; }
        //[ForeignKey("OrderId")]
        public int OrderId { get; set; }
        public virtual OrdersMaster OrdersMaster { get; set; }
        //[ForeignKey("RetailerId")]
        public int RetailerId { get; set; }
        public virtual Retailer Retailer { get; set; }
    }
}