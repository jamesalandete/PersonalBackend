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
    [Route("api/tiposIdentificacion")]
    [ApiController]
    public class GenTipoIdentificacionController : ControllerBase
    {
        private readonly db_personalContext _context;

        public GenTipoIdentificacionController(db_personalContext context)
        {
            _context = context;
        }

        // GET: api/GenTipoIdentificacions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GenTipoIdentificacion>>> GetGenTipoIdentificaciones()
        {
            return await _context.GenTipoIdentificaciones.ToListAsync();
        }

        // GET: api/GenTipoIdentificacions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GenTipoIdentificacion>> GetGenTipoIdentificacion(int id)
        {
            var genTipoIdentificacion = await _context.GenTipoIdentificaciones.FindAsync(id);

            if (genTipoIdentificacion == null)
            {
                return NotFound();
            }

            return genTipoIdentificacion;
        }

        // PUT: api/GenTipoIdentificacions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGenTipoIdentificacion(int id, GenTipoIdentificacion genTipoIdentificacion)
        {
            if (id != genTipoIdentificacion.Id)
            {
                return BadRequest();
            }

            _context.Entry(genTipoIdentificacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GenTipoIdentificacionExists(id))
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

        // POST: api/GenTipoIdentificacions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GenTipoIdentificacion>> PostGenTipoIdentificacion(GenTipoIdentificacion genTipoIdentificacion)
        {
            _context.GenTipoIdentificaciones.Add(genTipoIdentificacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGenTipoIdentificacion", new { id = genTipoIdentificacion.Id }, genTipoIdentificacion);
        }     

        private bool GenTipoIdentificacionExists(int id)
        {
            return _context.GenTipoIdentificaciones.Any(e => e.Id == id);
        }
    }
}
