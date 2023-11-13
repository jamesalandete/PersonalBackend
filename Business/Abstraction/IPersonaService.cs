using Data.Entities;
using Data.Request;
using Data.Response;
using Microsoft.AspNetCore.Mvc;

namespace Business.Abstraction
{
    public interface IPersonaService
    {
        ActionResult<SuccessResponse<GenPersona>> FindAll(int? id = null, bool? estado = null);
        ActionResult<SuccessResponse<GenPersona>> Save(PersonaRequest input);
        ActionResult<SuccessResponse<GenPersona>> Update(int id, PersonaRequest input);
    }
}
