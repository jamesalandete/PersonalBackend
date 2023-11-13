using Data.Entities;
using Data.Request;
using Data.Response;
using Microsoft.AspNetCore.Mvc;

namespace Business.Abstraction
{
    public interface IUserService
    {
        ActionResult<SuccessResponse<UserResponse>> FindByUser(Login login);
        ActionResult<SuccessResponse<UserResponse>> RegisterUser(AuthUser AuthUsers);
    }
}
