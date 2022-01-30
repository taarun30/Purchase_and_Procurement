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
   
    public class ManufacturerController : ApiController
    {
        RetailStoreContext ctx = new RetailStoreContext();

        [HttpGet]
        [Route("ManufacturerDetails")]
        public IQueryable<Manufacturer> Get()
        {
            try
            {
                return ctx.Manufacturers;
            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpGet]
        [Route("GetManufacturerDetailsById/{manufacturerId}")]
        public IHttpActionResult GetManufacturerById(string manufacturerId)
        {
            Manufacturer objEmp = new Manufacturer();
            int ID = Convert.ToInt32(manufacturerId);
            try
            {
                objEmp = ctx.Manufacturers.Find(ID);
                if (objEmp == null)
                {
                    return NotFound();
                }

            }
            catch (Exception)
            {
                throw;
            }

            return Ok(objEmp);
        }

        [HttpPost]
        [Route("AddManufacturer")]
        public IHttpActionResult AddRetailer(Manufacturer data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                ctx.Manufacturers.Add(data);
                ctx.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(data);
        }
        [HttpPut]
        [Route("EditManufacturer")]
        public IHttpActionResult EditManufacturer(Manufacturer man)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                Manufacturer obj = new Manufacturer();
                obj = ctx.Manufacturers.Find(man.ManufacturerID);
                if (obj != null)
                {
                    obj.ManufacturerID = man.ManufacturerID;
                    obj.CompanyName = man.CompanyName;
                    obj.Firstname = man.Firstname;
                    obj.Lastname = man.Lastname;
                    obj.Address = man.Address;
                    obj.City = man.City;
                    obj.State = man.State;
                    obj.PostalCode = man.PostalCode;
                    obj.Country = man.Country;
                    obj.Email = man.Email;
                    obj.Phone = man.Phone;
                }
                int i = this.ctx.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(man);
        }
        [HttpDelete]
        [Route("DeleteManufacturer/{id}")]
        public IHttpActionResult DeleteManufacturer(int id)
        {
            Manufacturer man = ctx.Manufacturers.Find(id);
            if (man == null)
            {
                return NotFound();
            }
            ctx.Manufacturers.Remove(man);
            ctx.SaveChanges();

            return Ok(man);
        }
    }

}
