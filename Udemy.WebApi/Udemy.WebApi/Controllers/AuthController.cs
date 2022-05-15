using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Udemy.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        public IActionResult Login()
        {
            // giriş işlemleri
            JwtTokenGenerator jwtTokenGenerator = new JwtTokenGenerator();
            return Created("", jwtTokenGenerator.GenerateToken());
        }
    }
}
