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
            var receiptStruct = await _context.receiptStruct.Include(r => r.items).FirstOrDefaultAsync(r => r.ReceiptID == id);

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
                cusName = receiptStructDTO.cusName,
                puchaseDate = DateTime.Now
            };
            //Check for duplicates and regenerate until unique. Checking on Contexts ReceiptStruct
            while (await _context.receiptStruct.AnyAsync(b => b.ReceiptID == receiptStruct.ReceiptID))
            {
                receiptStruct.ReceiptID = ReceiptIDGenerator.GenerateID();
            }
            
            foreach (var itemDto in receiptStructDTO.items)
            {
                var item = new itemStruct
                {
                    itemName = itemDto.itemName,
                    price = itemDto.price,
                    quantity = itemDto.quantity,
                    MFD = itemDto.MFD,
                    ReceiptStructReceiptID = receiptStruct.ReceiptID
                };

                receiptStruct.items.Add(item);
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
                    return BadRequest("ReceiptID exists and couldnt be assigned a unique value");
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

        //DTO for the posting of a receipt
        public class ReceiptCreateDto
        {
            public List<ItemCreateDto> items { get; set; } = new List<ItemCreateDto>(); //this uses the DTO below when creating Items so we wont get any issues with receiptStructReceiptID FK
            public string cusName { get; set; }
        }

        public class ItemCreateDto
        {
            public string itemName { get; set; } = default!;
            public int price { get; set; }
            public int quantity { get; set; }
            public DateTime MFD { get; set; }
        }
    }
}
