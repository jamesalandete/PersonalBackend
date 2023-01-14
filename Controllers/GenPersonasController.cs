using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using crud.Models;

namespace crud.Controllers
{
    [Route("api/personal")]
    [ApiController]
    public class GenPersonasController : ControllerBase
    {
        private readonly db_personalContext _context;

        public GenPersonasController(db_personalContext context)
        {
            _context = context;
        }

        // GET: api/GenPersonas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GenPersonasView>>> GetGenPersonas()
        {
            var genPersonas = await (from p in _context.GenPersonas
            join t in _context.GenTipoIdentificaciones
            on p.TipoIdentificacionId equals t.Id
            select new GenPersonasView
            {
                Id = p.Id,
                Nombres = p.Nombres,
                Apellidos = p.Apellidos,
                TipoIdentificacionId = p.TipoIdentificacionId,
                NumeroIdentificacion = p.NumeroIdentificacion,
                Email = p.Email,
                NombreCompleto = p.NombreCompleto,
                CodigoIndentificacion = p.CodigoIndentificacion,
                Estado = p.Estado,
                FechaCreacion = p.FechaCreacion,
                TipoIdentificacionNombre = t.Nombre
            }).ToListAsync();

            return genPersonas;
                //await _context.GenPersonas.ToListAsync();
        }

        // GET: api/GenPersonas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GenPersonas>> GetGenPersonas(int id)
        {
            var genPersonas = await _context.GenPersonas.FindAsync(id);

            if (genPersonas == null)
            {
                return NotFound();
            }

            return genPersonas;
        }

        // PUT: api/GenPersonas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGenPersonas(int id, GenPersonas genPersonas)
        {
            if (id != genPersonas.Id)
            {
                return BadRequest();
            }

            _context.Entry(genPersonas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GenPersonasExists(id))
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

        // POST: api/GenPersonas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GenPersonas>> PostGenPersonas(GenPersonas genPersonas)
        {
            genPersonas.FechaCreacion = DateTime.Now;
            _context.GenPersonas.Add(genPersonas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGenPersonas", new { id = genPersonas.Id }, genPersonas);
        }

     

        private bool GenPersonasExists(int id)
        {
            return _context.GenPersonas.Any(e => e.Id == id);
        }
    }
}
