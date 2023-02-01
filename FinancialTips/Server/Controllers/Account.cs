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
    public class AccountsController : ControllerBase
    {
        //Refactored
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //public AccountsController(ApplicationDbContext context)
        public AccountsController(IUnitOfWork unitOfWork)
        {
            //Refractored
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Accounts
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Account>>> GetAccounts()]
        public async Task<IActionResult> GetAccounts()
        {
            //Refactored
            //return await _context.Accounts.ToListAsync();
            var accounts = await _unitOfWork.Accounts.GetAll();
            return Ok(accounts);
        }

        // GET: api/Accounts/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<Account>> GetAccount(int id)
        public async Task<IActionResult> GetAccount(int id)

        {
            //var account = await _context.Accounts.FindAsync(id);
            var account = await _unitOfWork.Accounts.Get(q => q.Id == id);

            if (account == null)
            {
                return NotFound();
            }

            return Ok(account);
        }

        // PUT: api/Accounts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccount(int id, Account account)
        {
            if (id != account.Id)
            {
                return BadRequest();
            }

            //_context.Entry(account).State = EntityState.Modified;
            _unitOfWork.Accounts.Update(account);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!AccountExists(id))
                if (!await AccountExists(id))
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

        // POST: api/Accounts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Account>> PostAccount(Account account)
        {
            //_context.Accounts.Add(account);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Accounts.Insert(account);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetAccount", new { id = account.Id }, account);
        }

        // DELETE: api/Accounts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            //var account = await _context.Accounts.FindAsync(id);
            var account = await _unitOfWork.Accounts.Get(q => q.Id == id);
            if (account == null)
            {
                return NotFound();
            }

            //_context.Accounts.Remove(account);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Accounts.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //private bool AccountExists(int id)
        private async Task<bool> AccountExists(int id)
        {
            //return _context.Accounts.Any(e => e.Id == id);
            var account = await _unitOfWork.Accounts.Get(q => q.Id == id);
            return account != null;
        }
    }
}
