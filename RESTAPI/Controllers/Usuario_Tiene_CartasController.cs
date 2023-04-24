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
    public class Usuario_Tiene_CartasController : ControllerBase
    {
        private readonly ToDoDbContext _context;

        public Usuario_Tiene_CartasController(ToDoDbContext context)
        {
            _context = context;
        }

        // GET: api/Usuario_Tiene_Cartas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario_Tiene_Carta>>> GetUsuario_Tiene_Carta()
        {
          if (_context.Usuario_Tiene_Carta == null)
          {
              return NotFound();
          }
            return await _context.Usuario_Tiene_Carta.ToListAsync();
        }

        // GET: api/Usuario_Tiene_Cartas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario_Tiene_Carta>> GetUsuario_Tiene_Carta(string id)
        {
          if (_context.Usuario_Tiene_Carta == null)
          {
              return NotFound();
          }
            var usuario_Tiene_Carta = await _context.Usuario_Tiene_Carta.FindAsync(id);

            if (usuario_Tiene_Carta == null)
            {
                return NotFound();
            }

            return usuario_Tiene_Carta;
        }

        // PUT: api/Usuario_Tiene_Cartas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario_Tiene_Carta(string id, Usuario_Tiene_Carta usuario_Tiene_Carta)
        {
            if (id != usuario_Tiene_Carta.id_usuario)
            {
                return BadRequest();
            }

            _context.Entry(usuario_Tiene_Carta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Usuario_Tiene_CartaExists(id))
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

        // POST: api/Usuario_Tiene_Cartas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Usuario_Tiene_Carta>> PostUsuario_Tiene_Carta(Usuario_Tiene_Carta usuario_Tiene_Carta)
        {
          if (_context.Usuario_Tiene_Carta == null)
          {
              return Problem("Entity set 'ToDoDbContext.Usuario_Tiene_Carta'  is null.");
          }
            _context.Usuario_Tiene_Carta.Add(usuario_Tiene_Carta);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (Usuario_Tiene_CartaExists(usuario_Tiene_Carta.id_usuario))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUsuario_Tiene_Carta", new { id = usuario_Tiene_Carta.id_usuario }, usuario_Tiene_Carta);
        }

        // DELETE: api/Usuario_Tiene_Cartas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario_Tiene_Carta(string id)
        {
            if (_context.Usuario_Tiene_Carta == null)
            {
                return NotFound();
            }
            var usuario_Tiene_Carta = await _context.Usuario_Tiene_Carta.FindAsync(id);
            if (usuario_Tiene_Carta == null)
            {
                return NotFound();
            }

            _context.Usuario_Tiene_Carta.Remove(usuario_Tiene_Carta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Usuario_Tiene_CartaExists(string id)
        {
            return (_context.Usuario_Tiene_Carta?.Any(e => e.id_usuario == id)).GetValueOrDefault();
        }
    }
}
