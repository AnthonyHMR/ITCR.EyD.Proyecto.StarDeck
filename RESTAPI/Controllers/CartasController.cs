using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RESTAPI.Models;
using RESTAPI.Services;

namespace RESTAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartasController : ControllerBase
    {
        private readonly ToDoDbContext _context;

        public CartasController(ToDoDbContext context)
        {
            _context = context;
        }

        // GET: api/Cartas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Carta>>> GetCarta()
        {
          if (_context.Carta == null)
          {
              return NotFound();
          }
            return await _context.Carta.ToListAsync();
        }

        // GET: api/Cartas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Carta>> GetCarta(string id)
        {
          if (_context.Carta == null)
          {
              return NotFound();
          }
            var carta = await _context.Carta.FindAsync(id);

            if (carta == null)
            {
                return NotFound();
            }

            return carta;
        }

        // PUT: api/Cartas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarta(string id, Carta carta)
        {
            if (id != carta.id_carta)
            {
                return BadRequest();
            }

            _context.Entry(carta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartaExists(id))
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

        // POST: api/Cartas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Carta>> PostCarta(Carta carta)
        {
          if (_context.Carta == null)
          {
              return Problem("Entity set 'ToDoDbContext.Carta'  is null.");
          }
            _context.Carta.Add(carta);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CartaExists(carta.id_carta))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCarta", new { id = carta.id_carta }, carta);
        }

        // DELETE: api/Cartas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarta(string id)
        {
            if (_context.Carta == null)
            {
                return NotFound();
            }
            var carta = await _context.Carta.FindAsync(id);
            if (carta == null)
            {
                return NotFound();
            }

            _context.Carta.Remove(carta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CartaExists(string id)
        {
            return (_context.Carta?.Any(e => e.id_carta == id)).GetValueOrDefault();
        }
    }
}
