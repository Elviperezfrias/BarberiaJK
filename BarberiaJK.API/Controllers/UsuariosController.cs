using BarberiaJK.Domain.Entities;
using BarberiaJK.Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BarberiaJK.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly BarberiaContext _context;

        public UsuarioController(BarberiaContext context)
        {
            _context = context;
        }

        // POST: api/usuario/registrar
        [HttpPost("registrar")]
        public async Task<IActionResult> Registrar([FromBody] Usuario usuario)
        {
            if (usuario == null || string.IsNullOrEmpty(usuario.Email) || string.IsNullOrEmpty(usuario.PasswordHash))
                return BadRequest(new { message = "Email y contraseña son obligatorios" });

           
            var existente = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == usuario.Email);
            if (existente != null)
                return Conflict(new { message = "Ya existe un usuario con este email" });

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                usuario.Id,
                usuario.Nombre,
                usuario.Email,
                usuario.Rol
            });
        }

        // POST: api/usuario/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Usuario login)
        {
            if (login == null || string.IsNullOrEmpty(login.Email) || string.IsNullOrEmpty(login.PasswordHash))
                return BadRequest(new { message = "Email y contraseña son obligatorios" });

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Email == login.Email && u.PasswordHash == login.PasswordHash);

            if (usuario == null)
                return Unauthorized(new { message = "Email o contraseña incorrectos" });

            return Ok(new
            {
                usuario.Id,
                usuario.Nombre,
                usuario.Email,
                usuario.Rol
            });
        }
    }
}

