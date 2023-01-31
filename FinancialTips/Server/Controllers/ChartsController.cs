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
    public class ChartsController : ControllerBase
    {
        //Refactored
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //public ChartsController(ApplicationDbContext context)
        public ChartsController(IUnitOfWork unitOfWork)
        {
            //Refractored
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Charts
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Chart>>> GetCharts()]
        public async Task<IActionResult> GetCharts()
        {
            //Refactored
            //return await _context.Charts.ToListAsync();
            var charts = await _unitOfWork.Charts.GetAll();
            return Ok(charts);
        }

        // GET: api/Charts/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<Chart>> GetChart(int id)
        public async Task<IActionResult> GetChart(int id)

        {
            //var chart = await _context.Charts.FindAsync(id);
            var chart = await _unitOfWork.Charts.Get(q => q.Id == id);

            if (chart == null)
            {
                return NotFound();
            }

            return Ok(chart);
        }

        // PUT: api/Charts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChart(int id, Chart chart)
        {
            if (id != chart.Id)
            {
                return BadRequest();
            }

            //_context.Entry(chart).State = EntityState.Modified;
            _unitOfWork.Charts.Update(chart);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!ChartExists(id))
                if (!await ChartExists(id))
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

        // POST: api/Charts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Chart>> PostChart(Chart chart)
        {
            //_context.Charts.Add(chart);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Charts.Insert(chart);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetChart", new { id = chart.Id }, chart);
        }

        // DELETE: api/Charts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChart(int id)
        {
            //var chart = await _context.Charts.FindAsync(id);
            var chart = await _unitOfWork.Charts.Get(q => q.Id == id);
            if (chart == null)
            {
                return NotFound();
            }

            //_context.Charts.Remove(chart);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Charts.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //private bool ChartExists(int id)
        private async Task<bool> ChartExists(int id)
        {
            //return _context.Charts.Any(e => e.Id == id);
            var chart = await _unitOfWork.Charts.Get(q => q.Id == id);
            return chart != null;
        }
    }
}
