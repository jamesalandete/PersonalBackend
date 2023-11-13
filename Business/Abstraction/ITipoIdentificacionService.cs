using Data.Entities;
using Data.Request;
using Data.Response;
using Microsoft.AspNetCore.Mvc;

namespace Business.Abstraction
{
    public interface ITipoIdentificacionService
    {
        ActionResult<SuccessResponse<TipoIdentificacion>> FindAll();
        ActionResult<SuccessResponse<TipoIdentificacion>> FindById(int id);
        ActionResult<SuccessResponse<TipoIdentificacion>> Save(TipoIdentificacion input);
        ActionResult<SuccessResponse<TipoIdentificacion>> Update(int id, TipoIdentificacion input);
    }
}
