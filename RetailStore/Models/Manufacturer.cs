using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RetailStore.Models
{
    [Table("Manufacturer")]
    public class Manufacturer
    {
        public Manufacturer()
        {
            PurchaseOrderMasters = new List<PurchaseOrderMaster>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ManufacturerID { get; set; }

        [StringLength(30)]
        public string CompanyName { get; set; }

        [StringLength(30)]
        public string Firstname { get; set; }

        [StringLength(30)]
        public string Lastname { get; set; }

        [StringLength(30)]
        public string Address { get; set; }

        [StringLength(30)]
        public string City { get; set; }

        [StringLength(30)]
        public string State { get; set; }

        public int? PostalCode { get; set; }

        [StringLength(30)]
        public string Country { get; set; }

        [StringLength(15)]
        public string Phone { get; set; }

        [StringLength(30)]
        public string Email { get; set; }

        
        public  ICollection<PurchaseOrderMaster> PurchaseOrderMasters { get; set; }
    }
}