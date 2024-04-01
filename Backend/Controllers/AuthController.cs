using Backend.Helpers;
using Backend.Models.DB;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly ITSenseContext _authContext;
        private readonly IPasswordHasher _passwordHasher;
        public AuthController(ITSenseContext iTSenseContext, IPasswordHasher passwordHasher)    
        {
            _authContext = iTSenseContext;
            _passwordHasher = passwordHasher;

        }

        [HttpPost("authentication")]
        public async Task<IActionResult> Authenticate([FromBody] Usuario objUser)
        {
            if (objUser == null)
            {
                return BadRequest();
            }

            var user = await _authContext.Usuarios.FirstOrDefaultAsync(x => x.Email == objUser.Email);

            if (user == null)
            {
                return NotFound(new {Message = "User not found"});
            }

            var result =  _passwordHasher.Verify(user.Password, objUser.Password);

            if (!result) 
            {
                return NotFound(new { message = "Email or password is not correct" });
            }

            return Ok(new { message = "Login success" });
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] Usuario objUser)
        {
            if (objUser != null)
            {
                if (await CheckEmailExistAsync(objUser.Email))
                {
                    return BadRequest(new { Message = "Email Already Exist" });
                }
                var passwordHash = _passwordHasher.Hash(objUser.Password);
                var user = new Usuario
                {
                    Nombre = objUser.Nombre,
                    Email = objUser.Email,
                    Password = passwordHash,
                    Activo = true
                };

                await _authContext.Usuarios.AddAsync(user);
                await _authContext.SaveChangesAsync();

            } else
            {
                return BadRequest();
            }

            return Ok(new
            {
                Message= "User Registered!!"
            });
        }

        private Task<bool> CheckEmailExistAsync(string email)
            => _authContext.Usuarios.AnyAsync(x=>x.Email == email);
    }
}
