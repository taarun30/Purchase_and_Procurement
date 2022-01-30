using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RetailStore.Models
{
    
    public class Retailer
    {
        
        public Retailer()
        {
            Feedbacks = new HashSet<Feedback>();
            OrdersMasters = new HashSet<OrdersMaster>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RetailerId { get; set; }

        [StringLength(30)]
        public string Firstname { get; set; }

        [StringLength(30)]
        public string LastName { get; set; }

        [StringLength(30)]
        public string email { get; set; }

        [StringLength(15)]
        public string Contactnumber { get; set; }

        [StringLength(50)]
        public string Address { get; set; }
        public string Status { get; set; }

       
        public virtual ICollection<Feedback> Feedbacks { get; set; }

        
        public virtual ICollection<OrdersMaster> OrdersMasters { get; set; }

    } 
}