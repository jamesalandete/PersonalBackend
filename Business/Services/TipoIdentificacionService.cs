using Business.Abstraction;
using Data.Entities;
using Data.Request;
using Data.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Business.Services
{
    internal class TipoIdentificacionService : ITipoIdentificacionService
    {
        private readonly AppDbContext _context;

        public TipoIdentificacionService(AppDbContext uow)
        {
            _context = uow;
        }
        public ActionResult<SuccessResponse<TipoIdentificacion>> FindAll()
        {
            try
            {
                var tipos = _context.TipoIdentificaciones.ToList();

                return new SuccessResponse<TipoIdentificacion> { Status = 200, Message = "Se ejecuto con exito", Result = tipos };
            }
            catch (Exception error)
            {
                return new BadRequestObjectResult( new ErrorResponse { Status = 400, Message = error.Message});
            }
        }
        public ActionResult<SuccessResponse<TipoIdentificacion>> FindById(int id)
        {
            try
            {
                var tipos = _context.TipoIdentificaciones.Where(sel => sel.Id == id).FirstOrDefault();

                if (tipos == null) throw new Exception("No se encontro resultados");

                var response = new List<TipoIdentificacion> { tipos };
                return new SuccessResponse<TipoIdentificacion> { Status = 200, Message = "Se ejecuto con exito", Result = response };
            }
            catch (Exception error)
            {
                return new BadRequestObjectResult(new ErrorResponse { Status = 400, Message = error.Message });
            }
        }

        public ActionResult<SuccessResponse<TipoIdentificacion>> Save(TipoIdentificacion input)
        {
            try
            {
                var addedTipoIdentificacion = _context.TipoIdentificaciones.Add(input).Entity;
                _context.SaveChanges();

                var response = new SuccessResponse<TipoIdentificacion>
                {
                    Status = 200,
                    Message = "Se ejecutó con éxito",
                    Result = new List<TipoIdentificacion> { addedTipoIdentificacion }
                };

                return response;
            }
            catch (Exception error)
            {
                return new BadRequestObjectResult(new ErrorResponse { Status = 400, Message = error.Message });
            }
        }

        public ActionResult<SuccessResponse<TipoIdentificacion>> Update(int id, TipoIdentificacion input)
        {
            try
            {
                var find = _context.TipoIdentificaciones.Where(sel => sel.Id == id).FirstOrDefault();

                if (find == null) throw new Exception("No se encontro coincidencia");

                _context.Entry(find).CurrentValues.SetValues(input);
                _context.TipoIdentificaciones.Update(find);
                _context.SaveChanges();

                var response = new SuccessResponse<TipoIdentificacion>
                {
                    Status = 200,
                    Message = "Se ejecutó con éxito",
                    Result = new List<TipoIdentificacion> { input }
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
