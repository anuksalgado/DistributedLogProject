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
    public class itemController : ControllerBase
    {
        private readonly DBManager _context;

        public itemController(DBManager context)
        {
            _context = context;
        }

        // GET: api/item
        [HttpGet]
        public async Task<ActionResult<IEnumerable<itemStruct>>> GetitemStruct()
        {
            return await _context.itemStruct.ToListAsync();
        }

        // GET: api/item/5
        [HttpGet("{id}")]
        public async Task<ActionResult<itemStruct>> GetitemStruct(int id)
        {
            var itemStruct = await _context.itemStruct.FindAsync(id);

            if (itemStruct == null)
            {
                return NotFound();
            }

            return itemStruct;
        }

        // PUT: api/item/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutitemStruct(int id, itemStruct itemStruct)
        {
            if (id != itemStruct.Id)
            {
                return BadRequest();
            }

            _context.Entry(itemStruct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!itemStructExists(id))
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

        //expects JSON
        // POST: api/item
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<itemStruct>> PostitemStruct(itemStruct itemStruct)
        {
            int maxId = await _context.itemStruct.MaxAsync(i => (int?)i.Id) ?? 0;
            itemStruct.Id = maxId + 1;
            _context.itemStruct.Add(itemStruct);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetitemStruct", new { id = itemStruct.Id }, itemStruct);
        }
        /*
        {
            "itemName": "Test",
            "price": 2344,
            "quantity": 3,
            "receiptStructReceiptID": "R005"
        }
        */

        // DELETE: api/item/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteitemStruct(int id)
        {
            var itemStruct = await _context.itemStruct.FindAsync(id);
            if (itemStruct == null)
            {
                return NotFound();
            }

            _context.itemStruct.Remove(itemStruct);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool itemStructExists(int id)
        {
            return _context.itemStruct.Any(e => e.Id == id);
        }
    }
}
