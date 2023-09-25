using EmployeeTekosol.Repository.Models;
using EmployeeTekosol.Service.Abstraction;
using EmployeeTekosol.Service.Implementation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeTekosol.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost, Route(nameof(Login))]
        public IActionResult Login(User user)
        {
            if (user.UserName == "user" && user.Password == "password")
            {
                var stringToken = _authService.CreateToken(user);
                return Ok(stringToken);
            }
            return Unauthorized();
        }
    }
}
