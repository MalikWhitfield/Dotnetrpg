using System.Threading.Tasks;
using Dotnetrpg.Data;
using Dotnetrpg.DTOs.Character;
using Dotnetrpg.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dotnetrpg.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepo;

        public AuthController(IAuthRepository authRepo)
        {
            _authRepo = authRepo;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDTO request)
        {
            ServiceResponse<int> response = await _authRepo.Register(
                new Models.User { Username = request.Username }, request.Password
            );
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDTO request)
        {
            ServiceResponse<string> response = await _authRepo.Login(
                 request.Username, request.Password
            );
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }


    }
}