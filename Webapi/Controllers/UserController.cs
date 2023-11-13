using Microsoft.AspNetCore.Mvc;
using Business.Abstraction;
using Data.Entities;
using Data.Request;
using Data.Response;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers
{
    [Route("auth")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/user
        [AllowAnonymous]
        [HttpPost("login")]
        public ActionResult<SuccessResponse<UserResponse>> Login([FromBody] Login login)
        {
            return _userService.FindByUser(login);
        }

        [Authorize]
        [HttpPost("register")]
        public ActionResult<SuccessResponse<UserResponse>> Register([FromBody] Login input)
        {
            var authUser = new AuthUser
            {
                Usuario = input.Usuario,
                Pass = input.Pass
            };
            return _userService.RegisterUser(authUser);
        }


    }
}
