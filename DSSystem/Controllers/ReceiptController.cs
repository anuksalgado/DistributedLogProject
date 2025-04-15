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
    public class ReceiptController : ControllerBase
    {
        private readonly DBManager _context;

        public ReceiptController(DBManager context)
        {
            _context = context;
        }

        // GET: api/Receipt
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReceiptStruct>>> GetreceiptStruct()
        {
            return await _context.receiptStruct.ToListAsync();
        }

        // GET: api/Receipt/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReceiptStruct>> GetReceiptStruct(string id)
        {
            var receiptStruct = await _context.receiptStruct.FindAsync(id);

            if (receiptStruct == null)
            {
                return NotFound();
            }

            return receiptStruct;
        }

        // PUT: api/Receipt/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReceiptStruct(string id, ReceiptStruct receiptStruct)
        {
            if (id != receiptStruct.ReceiptID)
            {
                return BadRequest();
            }

            _context.Entry(receiptStruct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReceiptStructExists(id))
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

        // POST: api/Receipt
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ReceiptStruct>> PostReceiptStruct(ReceiptCreateDto receiptStructDTO)
        {
            //USage of DTO means ReceiptID would not need to be passed in
            var receiptStruct = new ReceiptStruct
            {
                ReceiptID = ReceiptIDGenerator.GenerateID(),
                items = receiptStructDTO.items,
                cusName = receiptStructDTO.cusName,
                puchaseDate = DateTime.Now
            };
            //Check for duplicates and regenerate until unique. Checking on Contexts ReceiptStruct
            while (await _context.receiptStruct.AnyAsync(b => b.ReceiptID == receiptStruct.ReceiptID))
            {
                receiptStruct.ReceiptID = ReceiptIDGenerator.GenerateID();
            }
            _context.receiptStruct.Add(receiptStruct);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ReceiptStructExists(receiptStruct.ReceiptID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetReceiptStruct", new { id = receiptStruct.ReceiptID }, receiptStruct);
        }

        // DELETE: api/Receipt/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReceiptStruct(string id)
        {
            var receiptStruct = await _context.receiptStruct.FindAsync(id);
            if (receiptStruct == null)
            {
                return NotFound();
            }

            _context.receiptStruct.Remove(receiptStruct);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReceiptStructExists(string id)
        {
            return _context.receiptStruct.Any(e => e.ReceiptID == id);
        }

        public class ReceiptCreateDto
        {
            public List<itemStruct> items { get; set; } = new List<itemStruct>();
            public string cusName { get; set; }
        }
    }
}
