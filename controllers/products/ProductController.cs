using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YourProjectName.Data;
using YourProjectName.Models;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using rf;

namespace YourProjectName.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
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

        [HttpGet("getOne")]
        public async Task<ActionResult<object>> GetActionResultAsync([FromBody] object props)
        {
            Console.Write(props);
            var context = await _context.db_products
            .Join(
                _context.db_category,
                p => p.categoryId,
                c => c.id,
                (product, category) => new { category = new { category.image, category.name, product } }
            )
            .ToListAsync(); // Convert to list

            if (context == null)
            {
                return NoContent();
            }
            return Ok(context);
        }

        [HttpPost]
        public async Task<ActionResult<object>> PostCSharpCornerArticle([FromBody] db_products article)
        {
            _context.db_products.Add(article);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCSharpCornerArticles", new { id = article.id }, article);
        }

        [HttpPut("update")]
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

        [HttpDelete("delete")]
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