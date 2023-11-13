using Business.Abstraction;
using Data.Entities;
using Data.Request;
using Data.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Business.Services
{
    internal class PersonaService : IPersonaService
    {
        private readonly AppDbContext _context;

        public PersonaService(AppDbContext uow)
        {
            _context = uow;
        }
        public ActionResult<SuccessResponse<GenPersona>> FindAll(int? id = null, bool? estado = null )
        {
            try
            {

                // Ejecutar un procedimiento almacenado con parámetros utilizando FromSqlInterpolated
                var personas = _context.GenPersonas.FromSqlInterpolated($"EXEC sp_listar_personas @id = {id}, @estado = {estado}").ToList();

                return new SuccessResponse<GenPersona> { Status = 200, Message = "Se ejecuto con exito", Result = personas };
            }
            catch (Exception error)
            {
                return new BadRequestObjectResult( new ErrorResponse { Status = 400, Message = error.Message});
            }
        }

        public ActionResult<SuccessResponse<GenPersona>> Save(PersonaRequest input)
        {
            try
            {
                var tipoIdenti = _context.TipoIdentificaciones.Where(sel => sel.Id == input.TipoIdentificacionId).FirstOrDefault();

                if (tipoIdenti == null) throw new Exception("Tipo identidicacion no existe");

               
                var newPersona = new GenPersona {};
                _context.Entry(newPersona).CurrentValues.SetValues(input);

                newPersona.NombreCompleto = input.Nombres + " " + input.Apellidos;
                newPersona.Identificacion = tipoIdenti.Sigla + " " + input.NumeroIdentificacion;

                var addedTipoIdentificacion = _context.GenPersonas.Add(newPersona).Entity;
                _context.SaveChanges();

                var response = new SuccessResponse<GenPersona>
                {
                    Status = 200,
                    Message = "Se ejecutó con éxito",
                    Result = new List<GenPersona> { addedTipoIdentificacion }
                };

                return response;
            }
            catch (Exception error)
            {
                return new BadRequestObjectResult(new ErrorResponse { Status = 400, Message = error.Message });
            }
        }

        public ActionResult<SuccessResponse<GenPersona>> Update(int id, PersonaRequest input)
        {
            try
            {

                var tipoIdenti = _context.TipoIdentificaciones.Where(sel => sel.Id == input.TipoIdentificacionId).FirstOrDefault();

                if (tipoIdenti == null) throw new Exception("Tipo identidicacion no existe");

                var find = _context.GenPersonas.Where(sel => sel.Id == id).FirstOrDefault();

                if (find == null) throw new Exception("No se encontro coincidencia");

                _context.Entry(find).CurrentValues.SetValues(input);
                _context.GenPersonas.Update(find);
                _context.SaveChanges();

                var response = new SuccessResponse<GenPersona>
                {
                    Status = 200,
                    Message = "Se ejecutó con éxito",
                    Result = new List<GenPersona> { find }
                };

                return response;
            }
            catch (Exception error)
            {
                return new BadRequestObjectResult(new ErrorResponse { Status = 400, Message = error.Message });
            }
        }

    }
}
