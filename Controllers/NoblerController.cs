using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NobleApi.Models;

namespace NobleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoblerController : ControllerBase
    {
        private readonly NoblerContext _context;

        public NoblerController(NoblerContext context)
        {
            _context = context;
        }

        // GET: api/Nobler
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Nobler>>> GetNoblers()
        {
            return await _context.Noblers.ToListAsync();
        }

        // GET: api/Nobler/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Nobler>> GetNobler(long id)
        {
            var nobler = await _context.Noblers.FindAsync(id);

            if (nobler == null)
            {
                return NotFound();
            }

            return nobler;
        }

        // PUT: api/Nobler/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNobler(long id, Nobler nobler)
        {
            if (id != nobler.ID)
            {
                return BadRequest();
            }

            _context.Entry(nobler).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NoblerExists(id))
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

        // POST: api/Nobler
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Nobler>> PostNobler(Nobler nobler)
        {
            _context.Noblers.Add(nobler);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetNobler", new { id = nobler.ID }, nobler);
            return CreatedAtAction(nameof(GetNobler), new {id = nobler.ID}, nobler);
        }

        // DELETE: api/Nobler/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Nobler>> DeleteNobler(long id)
        {
            var nobler = await _context.Noblers.FindAsync(id);
            if (nobler == null)
            {
                return NotFound();
            }

            _context.Noblers.Remove(nobler);
            await _context.SaveChangesAsync();

            return nobler;
        }

        private bool NoblerExists(long id)
        {
            return _context.Noblers.Any(e => e.ID == id);
        }
    }
}
