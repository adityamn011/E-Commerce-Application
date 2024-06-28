using fliplart2._1.context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using fliplart2._1.models;
 
namespace fliplart2._1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
 
    {
        private readonly AppDbContext _flipContext;
        public ProductController(AppDbContext appDbContext)
        {
            _flipContext = appDbContext;
        }
 
        [HttpGet("getAllProduct")]
 
        public IActionResult GetProducts()
        {
            return Ok(_flipContext.Products.ToList());
        }
 
 
        [HttpPost("insertProduct")]
        public async Task<IActionResult> ProductPost([FromBody] Product ProObj)
        {
            if (ProObj == null)
                return BadRequest();
            await _flipContext.Products.AddAsync(ProObj);
            await _flipContext.SaveChangesAsync();
            return Ok(new
            {
                Message = "Product Created!"
            });
 
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult Update([FromBody] Product blogUpdate, [FromRoute] int id)
        {
            var updateBlog = _flipContext.Products.FirstOrDefault(x => x.PId == id);
            if (blogUpdate == null)
            {
                return NotFound();
            }
            updateBlog.product_name = blogUpdate.product_name;
            updateBlog.product_description = blogUpdate.product_description;
            updateBlog.price = blogUpdate.price;

            _flipContext.SaveChanges();

            return Ok(updateBlog);
        }

      
        [HttpDelete]
        [Route("{id:int}")]

        public IActionResult Delete([FromRoute] int id)
        {
            var blog = _flipContext.Products.FirstOrDefault(x => x.PId == id);
            if (blog == null)
            {
                return NotFound();
            }

            _flipContext.Products.Remove(blog);
            _flipContext.SaveChanges();
            return Ok();

        }


    }
}



