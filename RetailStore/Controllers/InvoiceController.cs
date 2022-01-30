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
    public class InvoiceController : ApiController
    {
        RetailStoreContext ctx = new RetailStoreContext();
        [HttpGet]
        [Route("Invoice/Id")]
        public IEnumerable<OrdersMaster> Get()
        {
            var or = ctx.OrdersMasters.Include("OrderDetails").ToList();
            return or.Select(x => new OrdersMaster()
            {
                OrderID = x.OrderID,
                OrderDate = x.OrderDate,
                OrderStatus = x.OrderStatus,
                PaymentMode = x.PaymentMode,
                RetailerId = x.RetailerId,
                TotalAmount = x.TotalAmount,
                OrderDetails = (x.OrderDetails.Select(item => new OrderDetail()
                {
                    slno = item.slno,
                    OrderId = item.OrderId,
                    InventoryId = item.InventoryId,
                    Quantity = item.Quantity,
                    PaymentMode = item.PaymentMode
                }).ToList() as ICollection<OrderDetail>)
            }).ToList();
        }






        [HttpGet]

        [Route("Invoice")]

        public HttpResponseMessage GetInvoice()
        {
            using (RetailStoreContext x = new RetailStoreContext())
            {
            }

            string query = @"SELECT * FROM Inventory 
                RIGHT JOIN OrderDetail ON Inventory.InventoryId = OrderDetail.InventoryID
                RIGHT JOIN OrdersMaster ON OrderDetail.OrderId = OrdersMaster.OrderID;";


            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.
                ConnectionStrings["RetailStoreContext"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }






    }
}
