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
    public class TipoIdentificacionController : ControllerBase
    {
        private readonly ITipoIdentificacionService _tipoIdentificacionService;

        public TipoIdentificacionController(ITipoIdentificacionService tipoIdentificacionService)
        {
            _tipoIdentificacionService = tipoIdentificacionService;
        }
        // GET: api/<TipoIdentificacion>
        [HttpGet]
        public ActionResult<SuccessResponse<TipoIdentificacion>> Get()
        {
            return _tipoIdentificacionService.FindAll();
        }

        // GET api/<TipoIdentificacion>/5
        [HttpGet("{id}")]
        public ActionResult<SuccessResponse<TipoIdentificacion>> FindById(int id)
        {
            return _tipoIdentificacionService.FindById(id);
        }

        // POST api/<TipoIdentificacion>
        [HttpPost]
        public ActionResult<SuccessResponse<TipoIdentificacion>> Post([FromBody] TipoIdentificacion input)
        {
            return _tipoIdentificacionService.Save(input);
        }

        // PUT api/<TipoIdentificacion>/5
        [HttpPut("{id}")]
        public ActionResult<SuccessResponse<TipoIdentificacion>> Put(int id, [FromBody] TipoIdentificacion input)
        {
            return _tipoIdentificacionService.Update(id, input);
        }
    }
}
