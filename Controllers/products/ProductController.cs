using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YourProjectName.Data;
using YourProjectName.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace YourProjectName.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CSharpCornerArticlesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CSharpCornerArticlesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<db_products>>> GetCSharpCornerArticles()
        {
            var groupedProducts = await _context.db_products
           .ToListAsync();

            return groupedProducts;

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<db_products>> GetActionResultAsync(int id)
        {

            var context = await _context.db_products.Where(x => x.id == id).FirstAsync();
            return context;
        }

        [HttpPost]
        public async Task<ActionResult<db_products>> PostCSharpCornerArticle(db_products article)
        {
            _context.db_products.Add(article);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCSharpCornerArticles", new { id = article.id }, article);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCSharpCornerArticle(int id, db_products article)
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCSharpCornerArticle(int id)
        {
            var article = await _context.db_products.FindAsync(id);

            _context.db_products.Remove(article);
            await _context.SaveChangesAsync();

            return Ok("Deleted successfully");
        }

        private bool CSharpCornerArticleExists(int id)
        {
            return _context.db_products.Any(e => e.id == id);
        }
    }
}