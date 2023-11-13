using Business.Abstraction;
using Data.Entities;
using Data.Request;
using Data.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly IPersonaService _personaService;

        public PersonaController(IPersonaService personaService)
        {
            _personaService = personaService;
        }

        // GET: api/<Personas>
        [HttpGet]
        public ActionResult<SuccessResponse<GenPersona>> Get()
        {
            return _personaService.FindAll();
        }

        // GET api/<Personas>/5
        [HttpGet("FindById/{id}")]
        public ActionResult<SuccessResponse<GenPersona>> FindById(int id)
        {
            return _personaService.FindAll(id);
        }

        // GET api/<Personas>/true
        [HttpGet("FindByEstado/{estado}")]
        public ActionResult<SuccessResponse<GenPersona>> FindByEstado(bool estado)
        {
            return _personaService.FindAll(null, estado);
        }

        // POST api/<Personas>
        [HttpPost]
        public ActionResult<SuccessResponse<GenPersona>> Post([FromBody] PersonaRequest input)
        {
            return _personaService.Save(input);
        }

        // PUT api/<Personas>/5
        [HttpPut("{id}")]
        public ActionResult<SuccessResponse<GenPersona>> Put(int id, [FromBody] PersonaRequest input)
        {
            return _personaService.Update(id, input);
        }
    }
}
