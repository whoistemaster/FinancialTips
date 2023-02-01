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
    public class FinancialPlanningsController : ControllerBase
    {
        //Refactored
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //public FinancialPlanningsController(ApplicationDbContext context)
        public FinancialPlanningsController(IUnitOfWork unitOfWork)
        {
            //Refractored
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/FinancialPlannings
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<FinancialPlanning>>> GetFinancialPlannings()]
        public async Task<IActionResult> GetFinancialPlannings()
        {
            //Refactored
            //return await _context.FinancialPlannings.ToListAsync();
            var financialplannings = await _unitOfWork.FinancialPlannings.GetAll();
            return Ok(financialplannings);
        }

        // GET: api/FinancialPlannings/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<FinancialPlanning>> GetFinancialPlanning(int id)
        public async Task<IActionResult> GetFinancialPlanning(int id)

        {
            //var financialplanning = await _context.FinancialPlannings.FindAsync(id);
            var financialplanning = await _unitOfWork.FinancialPlannings.Get(q => q.Id == id);

            if (financialplanning == null)
            {
                return NotFound();
            }

            return Ok(financialplanning);
        }

        // PUT: api/FinancialPlannings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFinancialPlanning(int id, FinancialPlanning financialplanning)
        {
            if (id != financialplanning.Id)
            {
                return BadRequest();
            }

            //_context.Entry(financialplanning).State = EntityState.Modified;
            _unitOfWork.FinancialPlannings.Update(financialplanning);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!FinancialPlanningExists(id))
                if (!await FinancialPlanningExists(id))
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

        // POST: api/FinancialPlannings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FinancialPlanning>> PostFinancialPlanning(FinancialPlanning financialplanning)
        {
            //_context.FinancialPlannings.Add(financialplanning);
            //await _context.SaveChangesAsync();
            await _unitOfWork.FinancialPlannings.Insert(financialplanning);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetFinancialPlanning", new { id = financialplanning.Id }, financialplanning);
        }

        // DELETE: api/FinancialPlannings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFinancialPlanning(int id)
        {
            //var financialplanning = await _context.FinancialPlannings.FindAsync(id);
            var financialplanning = await _unitOfWork.FinancialPlannings.Get(q => q.Id == id);
            if (financialplanning == null)
            {
                return NotFound();
            }

            //_context.FinancialPlannings.Remove(financialplanning);
            //await _context.SaveChangesAsync();
            await _unitOfWork.FinancialPlannings.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //private bool FinancialPlanningExists(int id)
        private async Task<bool> FinancialPlanningExists(int id)
        {
            //return _context.FinancialPlannings.Any(e => e.Id == id);
            var financialplanning = await _unitOfWork.FinancialPlannings.Get(q => q.Id == id);
            return financialplanning != null;
        }
    }
}
