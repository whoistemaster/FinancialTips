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
    public class CommunitysController : ControllerBase
    {
        //Refactored
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //public CommunitysController(ApplicationDbContext context)
        public CommunitysController(IUnitOfWork unitOfWork)
        {
            //Refractored
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Communitys
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Community>>> GetCommunitys()]
        public async Task<IActionResult> GetCommunitys()
        {
            //Refactored
            //return await _context.Communitys.ToListAsync();
            var communitys = await _unitOfWork.Community.GetAll();
            return Ok(communitys);
        }

        // GET: api/Communitys/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<Community>> GetCommunity(int id)
        public async Task<IActionResult> GetCommunity(int id)

        {
            //var community = await _context.Communitys.FindAsync(id);
            var community = await _unitOfWork.Community.Get(q => q.Id == id);

            if (community == null)
            {
                return NotFound();
            }

            return Ok(community);
        }

        // PUT: api/Communitys/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCommunity(int id, Community community)
        {
            if (id != community.Id)
            {
                return BadRequest();
            }

            //_context.Entry(community).State = EntityState.Modified;
            _unitOfWork.Community.Update(community);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!CommunityExists(id))
                if (!await CommunityExists(id))
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

        // POST: api/Communitys
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Community>> PostCommunity(Community community)
        {
            //_context.Communitys.Add(community);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Community.Insert(community);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetCommunity", new { id = community.Id }, community);
        }

        // DELETE: api/Communitys/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCommunity(int id)
        {
            //var community = await _context.Communitys.FindAsync(id);
            var community = await _unitOfWork.Community.Get(q => q.Id == id);
            if (community == null)
            {
                return NotFound();
            }

            //_context.Communitys.Remove(community);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Community.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //private bool CommunityExists(int id)
        private async Task<bool> CommunityExists(int id)
        {
            //return _context.Communitys.Any(e => e.Id == id);
            var community = await _unitOfWork.Community.Get(q => q.Id == id);
            return community != null;
        }
    }
}
