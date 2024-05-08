using APDatabaseWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace APDatabaseWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorController : ControllerBase
    {
        private readonly APContext db;
        public VendorController(APContext db)
        {
            this.db = db;
        }
        [HttpGet]
        public IActionResult GetVendors(string vendorCity)
        {
            var data = db.Vendors.FromSqlRaw($"exec AP_VendorCity_Proc @City ", new SqlParameter ("@City", vendorCity)).ToList();
            return Ok(data);
        }
    }
}
