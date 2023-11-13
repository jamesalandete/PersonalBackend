using Business.Abstraction;
using Data.Entities;
using Data.Request;
using Data.Response;
using Microsoft.AspNetCore.Mvc;

namespace Business.Services
{
    internal class UserService : IUserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext uow)
        {
            _context = uow;
        }
        public ActionResult<SuccessResponse<UserResponse>> FindByUser(Login login)
        {
            try
            {
                var user = _context.AuthUsers.FirstOrDefault(u => u.Usuario == login.Usuario);
                    
                if(user == null)
                {
                    throw new Exception("Usuario no registrado");
                }

                if (user.Pass != login.Pass)
                {
                    throw new Exception("Usuario y contraseñas erroneas");
                }

                var token = JwtHelper.GenerateJwtToken(user);

                var response = new List<UserResponse> { 
                    new UserResponse { Id = user.Id, Usuario = user.Usuario, Token = token } 
                };

                return new SuccessResponse<UserResponse> { Status = 200, Message = "Se ejecuto con exito", Result = response };
            }
            catch (Exception error)
            {
                return new BadRequestObjectResult( new ErrorResponse { Status = 400, Message = error.Message});
            }
        }

        public ActionResult<SuccessResponse<UserResponse>> RegisterUser(AuthUser newUser)
        {
            try
            {
                var user = _context.AuthUsers.Add(newUser).Entity;
                _context.SaveChanges();

                var response = new List<UserResponse> { 
                    new UserResponse { Id = user.Id, Usuario = user.Usuario } 
                };
                return new SuccessResponse<UserResponse> { Status = 200, Message = "Se ejecuto con exito", Result = response };
            }
            catch (Exception error)
            {
                return new BadRequestObjectResult(new ErrorResponse { Status = 400, Message = error.Message });
            }
        }
    }
}
