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
    public class FinancialTipsController : ControllerBase
    {
        //Refactored
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //public FinancialTipsController(ApplicationDbContext context)
        public FinancialTipsController(IUnitOfWork unitOfWork)
        {
            //Refractored
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/FinancialTips
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<FinancialTip>>> GetFinancialTips()]
        public async Task<IActionResult> GetFinancialTips()
        {
            //Refactored
            //return await _context.FinancialTips.ToListAsync();
            var financialtips = await _unitOfWork.FinancialTip.GetAll();
            return Ok(financialtips);
        }

        // GET: api/FinancialTips/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<FinancialTip>> GetFinancialTip(int id)
        public async Task<IActionResult> GetFinancialTip(int id)

        {
            //var financialtip = await _context.FinancialTips.FindAsync(id);
            var financialtip = await _unitOfWork.FinancialTip.Get(q => q.Id == id);

            if (financialtip == null)
            {
                return NotFound();
            }

            return Ok(financialtip);
        }

        // PUT: api/FinancialTips/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFinancialTip(int id, FinancialTip financialtip)
        {
            if (id != financialtip.Id)
            {
                return BadRequest();
            }

            //_context.Entry(financialtip).State = EntityState.Modified;
            _unitOfWork.FinancialTip.Update(financialtip);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!FinancialTipExists(id))
                if (!await FinancialTipExists(id))
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

        // POST: api/FinancialTips
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FinancialTip>> PostFinancialTip(FinancialTip financialtip)
        {
            //_context.FinancialTips.Add(financialtip);
            //await _context.SaveChangesAsync();
            await _unitOfWork.FinancialTip.Insert(financialtip);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetFinancialTip", new { id = financialtip.Id }, financialtip);
        }

        // DELETE: api/FinancialTips/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFinancialTip(int id)
        {
            //var financialtip = await _context.FinancialTips.FindAsync(id);
            var financialtip = await _unitOfWork.FinancialTip.Get(q => q.Id == id);
            if (financialtip == null)
            {
                return NotFound();
            }

            //_context.FinancialTips.Remove(financialtip);
            //await _context.SaveChangesAsync();
            await _unitOfWork.FinancialTip.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //private bool FinancialTipExists(int id)
        private async Task<bool> FinancialTipExists(int id)
        {
            //return _context.FinancialTips.Any(e => e.Id == id);
            var financialtip = await _unitOfWork.FinancialTip.Get(q => q.Id == id);
            return financialtip != null;
        }
    }
}
