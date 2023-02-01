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
    public class TipsController : ControllerBase
    {
        //Refactored
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //public TipsController(ApplicationDbContext context)
        public TipsController(IUnitOfWork unitOfWork)
        {
            //Refractored
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Tips
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Tip>>> GetTips()]
        public async Task<IActionResult> GetTips()
        {
            //Refactored
            //return await _context.Tips.ToListAsync();
            var tips = await _unitOfWork.Tips.GetAll();
            return Ok(tips);
        }

        // GET: api/Tips/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<Tip>> GetTip(int id)
        public async Task<IActionResult> GetTip(int id)

        {
            //var tip = await _context.Tips.FindAsync(id);
            var tip = await _unitOfWork.Tips.Get(q => q.Id == id);

            if (tip == null)
            {
                return NotFound();
            }

            return Ok(tip);
        }

        // PUT: api/Tips/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTip(int id, Tip tip)
        {
            if (id != tip.Id)
            {
                return BadRequest();
            }

            //_context.Entry(tip).State = EntityState.Modified;
            _unitOfWork.Tips.Update(tip);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!TipExists(id))
                if (!await TipExists(id))
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

        // POST: api/Tips
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tip>> PostTip(Tip tip)
        {
            //_context.Tips.Add(tip);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Tips.Insert(tip);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetTip", new { id = tip.Id }, tip);
        }

        // DELETE: api/Tips/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTip(int id)
        {
            //var tip = await _context.Tips.FindAsync(id);
            var tip = await _unitOfWork.Tips.Get(q => q.Id == id);
            if (tip == null)
            {
                return NotFound();
            }

            //_context.Tips.Remove(tip);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Tips.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //private bool TipExists(int id)
        private async Task<bool> TipExists(int id)
        {
            //return _context.Tips.Any(e => e.Id == id);
            var tip = await _unitOfWork.Tips.Get(q => q.Id == id);
            return tip != null;
        }
    }
}
