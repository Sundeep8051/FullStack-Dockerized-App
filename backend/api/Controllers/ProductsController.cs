using System.Data;
using api.models;
using Dapper;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/controller")]
    public class ProductsController : ControllerBase
    {
        // private static List<Product> products = [];

        private readonly IDbConnection _db;

        public ProductsController(IDbConnection db)
        {
            _db = db;
        }
        
        [HttpGet]
        [Route("GetProducts")]
        public async Task<IActionResult> GetProducts()
        {
            var sql = "SELECT Id, Name, Category, Price, Quantity from Product";
            return Ok(await _db.QueryAsync<Product>(sql));
        }

        [HttpGet]
        [Route("GetProductById")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var sql = "SELECT Id, Name, Category, Price, Quantity from Product where Id = @Id";
            return Ok(await _db.QueryFirstOrDefaultAsync<Product>(sql, new {Id = id}));
        }

        [HttpPost]
        [Route("AddProduct")]
        public async Task<IActionResult> AddProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                var sql = """
                INSERT INTO Product (Name, Category, Price, Quantity)
                values (@Name, @Category, @Price, @Quantity)
                """;
                await _db.ExecuteAsync(sql, product);
                return Created();
            }
            
            return BadRequest("Invalid request");
        }

        [HttpDelete]
        [Route("RemoveProduct")]
        public async Task<IActionResult> RemoveProduct(int id)
        {
            var sql = """
                DELETE from Product Where Id = @Id
            """;
            
            await _db.ExecuteAsync(sql, new {Id = id});
            return Ok();
        }
    }
}