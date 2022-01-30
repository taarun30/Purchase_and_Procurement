using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RetailStore.Models;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace RetailStore.Controllers
{
    public class RatingController : ApiController
    {
        RetailStoreContext ctx = new RetailStoreContext();
        [HttpPut]
        [Route("EditInventory")]
        public IHttpActionResult EditManufacturer(Inventory man)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                Inventory obj = new Inventory();
                obj = ctx.Inventories.Find(man.InventoryId);
                if (obj != null)
                {
                    obj.InventoryId = man.InventoryId;
                    obj.Productname = man.Productname;
                    obj.Rating = (man.Rating+obj.Rating)/2;
                   
                   
                }
                int i = this.ctx.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(man);
        }
    }
}
