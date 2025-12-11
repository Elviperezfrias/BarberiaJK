using BarberiaJK.Application.DTOs;
using BarberiaJK.Domain.Entities;
using BarberiaJK.Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BarberiaJK.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly BarberiaContext _context;

        public AuthController(BarberiaContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto login)
        {
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Email == login.Email && u.PasswordHash == login.Password);

            if (usuario == null)
                return Unauthorized(new { message = "Email o contraseña incorrectos" });

            return Ok(new
            {
                usuario.Id,
                usuario.Nombre,
                usuario.Rol
            });
        }
    }
}
