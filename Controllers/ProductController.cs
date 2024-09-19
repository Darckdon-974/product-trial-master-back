using back.Data;
using back.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;

namespace back.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public ProductController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _context.Products.ToList();

            return Ok(products);
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] Products createProduct)
        {
            var productToAdd = createProduct;
            _context.Products.Add(productToAdd);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetProductById), new { id = productToAdd.Id }, productToAdd);
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById([FromRoute] int id)
        {
            var product  = _context.Products.Find(id);

            if(product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPatch]
        [Route("{id}")]
        public IActionResult PatchProduct(int id, [FromBody] JsonPatchDocument<Products> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest();
            }
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            patchDoc.ApplyTo(product, ModelState);
            if (!TryValidateModel(product))
            {
                return BadRequest(ModelState);
            }
            _context.Update(product);
            _context.SaveChanges();
            return Ok(product);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteProduct([FromRoute] int id)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);

            _context.SaveChanges();

            return NoContent();
        }
    }
}