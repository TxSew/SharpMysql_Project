using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rf;
using YourProjectName.Data;

namespace CategoryController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<db_category>>> GetCSharpCornerArticles()
        {
            var groupedProducts = await _context.db_category
           .ToListAsync();
            return groupedProducts;
        }

        [HttpGet("filterOne")]
        public async Task<ActionResult<object>> GetActionResultAsync()
        {
            try
            {
                var context = await _context.db_category
               .Join(
                   _context.db_products,
                   p => p.id,
                   c => c.categoryId,
                   (product, category) => new { category = new { category.image, product } }
               )
               .ToListAsync();

                if (context == null)
                {
                    return NoContent();
                }
                return Ok(context);

            }
            catch (Exception error)
            {
                Console.WriteLine($"An error occurred: {error.Message}");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpPost]
        public async Task<ActionResult<object>> PostCSharpCornerArticle([FromBody] db_category article)
        {
            _context.db_category.Add(article);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCSharpCornerArticles", new { id = article.id }, article);
        }

        [HttpPut("update")]
        public async Task<IActionResult> PutCSharpCornerArticle(int id, db_category article)
        {

            _context.Entry(article).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CSharpCornerArticleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteCSharpCornerArticle(int id)
        {
            var article = await _context.db_category.FindAsync(id);

            _context.db_category.Remove(article);
            await _context.SaveChangesAsync();

            return Ok("Deleted successfully");
        }

        private bool CSharpCornerArticleExists(int id)
        {
            return _context.db_category.Any(e => e.id == id);
        }
    }
}