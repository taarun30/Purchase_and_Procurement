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
    public class OrderController : ApiController
    {
        RetailStoreContext ctx = new RetailStoreContext();

        [HttpGet]
        [Route("api/Orders")]
        public IQueryable<Inventory> Get()
        {
            try
            {
                return ctx.Inventories;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public string Post(Inventory inv, OrderDetail det, OrdersMaster mas, Retailer ret)
        {
            try
            {
                string query = @"insert into dbo.OrderDetail values
                ('" + inv.InventoryId + mas.OrderID+  @"')"+@"insert into db.OrdersMaster values
                ('"+ret.RetailerId+@"')";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["RetailStoreContext"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Added Successful";
            }
            catch (Exception)
            {
                return "Failed to Add";
            }
        }


    }
}

