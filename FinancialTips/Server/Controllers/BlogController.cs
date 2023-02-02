using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinancialTips.Server.Data;
using FinancialTips.Shared.Domain;
using FinancialTips.Server.IRepository;

namespace FinancialTips.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        //Refactored
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //public BlogsController(ApplicationDbContext context)
        public BlogsController(IUnitOfWork unitOfWork)
        {
            //Refractored
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Blogs
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Blog>>> GetBlogs()]
        public async Task<IActionResult> GetBlogs()
        {
            //Refactored
            //return await _context.Blogs.ToListAsync();
            var blogs = await _unitOfWork.Blogs.GetAll();
            return Ok(blogs);
        }

        // GET: api/Blogs/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<Blog>> GetBlog(int id)
        public async Task<IActionResult> GetBlog(int id)

        {
            //var blog = await _context.Blogs.FindAsync(id);
            var blog = await _unitOfWork.Blogs.Get(q => q.Id == id);

            if (blog == null)
            {
                return NotFound();
            }

            return Ok(blog);
        }

        // PUT: api/Blogs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBlog(int id, Blog blog)
        {
            if (id != blog.Id)
            {
                return BadRequest();
            }

            //_context.Entry(blog).State = EntityState.Modified;
            _unitOfWork.Blogs.Update(blog);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!BlogExists(id))
                if (!await BlogExists(id))
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

        // POST: api/Blogs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Blog>> PostBlog(Blog blog)
        {
            //_context.Blogs.Add(blog);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Blogs.Insert(blog);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetBlog", new { id = blog.Id }, blog);
        }

        // DELETE: api/Blogs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            //var blog = await _context.Blogs.FindAsync(id);
            var blog = await _unitOfWork.Blogs.Get(q => q.Id == id);
            if (blog == null)
            {
                return NotFound();
            }

            //_context.Blogs.Remove(blog);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Blogs.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //private bool BlogExists(int id)
        private async Task<bool> BlogExists(int id)
        {
            //return _context.Blogs.Any(e => e.Id == id);
            var blog = await _unitOfWork.Blogs.Get(q => q.Id == id);
            return blog != null;
        }
    }
}
