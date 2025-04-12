using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DSSystem;

namespace DSSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogMessageController : ControllerBase
    {
        private readonly DBManager _context;

        public LogMessageController(DBManager context)
        {
            _context = context;
        }

        // GET: api/LogMessage
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoginStruct>>> GetLoginStruct()
        {
            return await _context.LoginStruct.ToListAsync();
        }

        //http://localhost:5249/api/LogMessage/Burn
        // GET: api/LogMessage/5 //ID is Username as thats the ID
        [HttpGet("{id}")]
        public async Task<ActionResult<LoginStruct>> GetLoginStruct(string id)
        {
            var loginStruct = await _context.LoginStruct.FindAsync(id);

            if (loginStruct == null)
            {
                return NotFound();
            }

            return loginStruct;
        }

        // PUT: api/LogMessage/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoginStruct(string id, LoginStruct loginStruct)
        {
            if (id != loginStruct.Username)
            {
                return BadRequest();
            }

            _context.Entry(loginStruct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoginStructExists(id))
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

        // POST: api/LogMessage
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LoginStruct>> PostLoginStruct(LoginStruct loginStruct)
        {
            _context.LoginStruct.Add(loginStruct);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LoginStructExists(loginStruct.Username))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLoginStruct", new { id = loginStruct.Username }, loginStruct);
        }

        // DELETE: api/LogMessage/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoginStruct(string id)
        {
            var loginStruct = await _context.LoginStruct.FindAsync(id);
            if (loginStruct == null)
            {
                return NotFound();
            }

            _context.LoginStruct.Remove(loginStruct);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LoginStructExists(string id)
        {
            return _context.LoginStruct.Any(e => e.Username == id);
        }
    }
}
