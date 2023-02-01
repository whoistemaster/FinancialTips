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
    public class InsightsController : ControllerBase
    {
        //Refactored
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //public InsightsController(ApplicationDbContext context)
        public InsightsController(IUnitOfWork unitOfWork)
        {
            //Refractored
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Insights
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Insight>>> GetInsights()]
        public async Task<IActionResult> GetInsights()
        {
            //Refactored
            //return await _context.Insights.ToListAsync();
            var insights = await _unitOfWork.Insights.GetAll();
            return Ok(insights);
        }

        // GET: api/Insights/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<Insight>> GetInsight(int id)
        public async Task<IActionResult> GetInsight(int id)

        {
            //var insight = await _context.Insights.FindAsync(id);
            var insight = await _unitOfWork.Insights.Get(q => q.Id == id);

            if (insight == null)
            {
                return NotFound();
            }

            return Ok(insight);
        }

        // PUT: api/Insights/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInsight(int id, Insight insight)
        {
            if (id != insight.Id)
            {
                return BadRequest();
            }

            //_context.Entry(insight).State = EntityState.Modified;
            _unitOfWork.Insights.Update(insight);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!InsightExists(id))
                if (!await InsightExists(id))
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

        // POST: api/Insights
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Insight>> PostInsight(Insight insight)
        {
            //_context.Insights.Add(insight);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Insights.Insert(insight);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetInsight", new { id = insight.Id }, insight);
        }

        // DELETE: api/Insights/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInsight(int id)
        {
            //var insight = await _context.Insights.FindAsync(id);
            var insight = await _unitOfWork.Insights.Get(q => q.Id == id);
            if (insight == null)
            {
                return NotFound();
            }

            //_context.Insights.Remove(insight);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Insights.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //private bool InsightExists(int id)
        private async Task<bool> InsightExists(int id)
        {
            //return _context.Insights.Any(e => e.Id == id);
            var insight = await _unitOfWork.Insights.Get(q => q.Id == id);
            return insight != null;
        }
    }
}
