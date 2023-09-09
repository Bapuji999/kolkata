using customer_Product_Back_end.DataLyers;
using customer_Product_Back_end.Functions;
using customer_Product_Back_end.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;

namespace customer_Product_Back_end.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerProductController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly string? _conn;
        public CustomerProductController(IConfiguration configuration)
        {
            _configuration = configuration;
            this._conn = _configuration.GetConnectionString("DefaultConnection");
        }
        [HttpGet]
        [Route("GetAllProductsCustomerByCustomerID/{CustomerId}")]
        public IActionResult GetAllProducts(int CustomerId)
        {
            DataSet ds = new DataSet();
            ProductCustomerDataLayer dl = new ProductCustomerDataLayer();
            try
            {
                ds = dl.GetAllCustomerProduct(_conn, CustomerId);
                
              return Ok(JsonConvert.SerializeObject(ds.Tables[0]));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        [Route("SaveProduct")]
        public IActionResult SaveProductCustmer([FromBody] ProductCustomer ProductCustomer)
        {
            ProductCustomerDataLayer dl = new ProductCustomerDataLayer();
            string message = string.Empty;
            try
            {
                message = dl.SaveProductCustomer(_conn, ProductCustomer);
                return Ok(JsonConvert.SerializeObject(message));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("SaveSaleDate/{CustomerId}/{SaleDate}")]
        public IActionResult SaveSaleDate(int CustomerId, string SaleDate)
        {
            string message = string.Empty;
            ProductCustomerDataLayer dl = new ProductCustomerDataLayer();
            try
            {
                message = dl.SaveSaleDate(_conn, CustomerId, SaleDate);
                return Ok(JsonConvert.SerializeObject(message));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
