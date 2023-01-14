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
    [Route("api/usuarios")]
    [ApiController]
    public class ConfigUsuariosController : ControllerBase
    {
        private readonly db_personalContext _context;

        public ConfigUsuariosController(db_personalContext context)
        {
            _context = context;
        }

        // GET: api/ConfigUsuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConfigUsuario>>> GetConfigUsuarios()
        {
            return await _context.ConfigUsuarios.ToListAsync();
        }

        // GET: api/ConfigUsuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ConfigUsuario>> GetConfigUsuario(int id)
        {
            var configUsuario = await _context.ConfigUsuarios.FindAsync(id);

            if (configUsuario == null)
            {
                return NotFound();
            }

            return configUsuario;
        }

        // PUT: api/ConfigUsuarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConfigUsuario(int id, ConfigUsuario configUsuario)
        {
            if (id != configUsuario.Id)
            {
                return BadRequest();
            }

            _context.Entry(configUsuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConfigUsuarioExists(id))
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

        // POST: api/ConfigUsuarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ConfigUsuario>> PostConfigUsuario(ConfigUsuario configUsuario)
        {
            configUsuario.FechaCreacion = DateTime.Now;
            _context.ConfigUsuarios.Add(configUsuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConfigUsuario", new { id = configUsuario.Id }, configUsuario);
        }


        private bool ConfigUsuarioExists(int id)
        {
            return _context.ConfigUsuarios.Any(e => e.Id == id);
        }
    }
}
