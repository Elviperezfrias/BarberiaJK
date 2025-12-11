using BarberiaJK.Application.DTOs;
using BarberiaJK.Domain.Entities;
using BarberiaJK.Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace BarberiaJK.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitaController : ControllerBase
    {
        private readonly BarberiaContext _context;

        public CitaController(BarberiaContext context)
        {
            _context = context;
        }

        // ============================
        // GET ALL
        // ============================
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CitaDto>>> GetCitas()
        {
            var citas = await _context.Citas
                .Include(c => c.Cliente)
                .Include(c => c.Empleado)
                .Include(c => c.Servicio)
                .Select(c => new CitaDto
                {
                    Id = c.IdCita,
                    FechaHoraInicio = c.FechaHoraInicio,
                    FechaHoraFin = c.FechaHoraFin,
                    IdCliente = c.IdCliente,
                    IdEmpleado = c.IdEmpleado,
                    IdServicio = c.IdServicio,
                    Cliente = c.Cliente!.Nombre,
                    Empleado = c.Empleado!.Nombre,
                    Servicio = c.Servicio!.Nombre
                })
                .ToListAsync();

            return Ok(citas);
        }

        // ============================
        // GET BY ID
        // ============================
        [HttpGet("{id}")]
        public async Task<ActionResult<Cita>> GetCita(int id)
        {
            var cita = await _context.Citas.FindAsync(id);
            if (cita == null) return NotFound();
            return Ok(cita);
        }

        // ============================
        // POST
        // ============================
        [HttpPost]
        [HttpPost]
        public async Task<ActionResult<CitaDto>> PostCita([FromBody] CitaCreateDto dto)
        {
            var cliente = await _context.Clientes.FindAsync(dto.IdCliente);
            var empleado = await _context.Empleados.FindAsync(dto.IdEmpleado);
            var servicio = await _context.Servicios.FindAsync(dto.IdServicio);

            if (cliente == null) return BadRequest("Cliente no encontrado");
            if (empleado == null) return BadRequest("Empleado no encontrado");
            if (servicio == null) return BadRequest("Servicio no encontrado");

            
            var cita = new Cita
            {
                IdCliente = dto.IdCliente,
                IdEmpleado = dto.IdEmpleado,
                IdServicio = dto.IdServicio,
                FechaHoraInicio = dto.FechaHoraInicio,
                FechaHoraFin = dto.FechaHoraFin
            };

            _context.Citas.Add(cita);
            await _context.SaveChangesAsync();

           
            var citaDto = new CitaDto
            {
                Id = cita.IdCita,
                IdCliente = dto.IdCliente,
                IdEmpleado = dto.IdEmpleado,
                IdServicio = dto.IdServicio,
                FechaHoraInicio = dto.FechaHoraInicio,
                FechaHoraFin = dto.FechaHoraFin,
                Cliente = cliente.Nombre,
                Empleado = empleado.Nombre,
                Servicio = servicio.Nombre
            };

            return Ok(citaDto);
        }




        // ============================
        // PUT (CORREGIDO)
        // ============================
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCita(int id, [FromBody] CitaUpdateDto dto)
        {
            var cita = await _context.Citas.FindAsync(id);
            if (cita == null)
                return NotFound("No existe la cita");

         
            var cliente = await _context.Clientes.FindAsync(dto.IdCliente);
            var empleado = await _context.Empleados.FindAsync(dto.IdEmpleado);
            var servicio = await _context.Servicios.FindAsync(dto.IdServicio);

            if (cliente == null) return BadRequest("Cliente no encontrado");
            if (empleado == null) return BadRequest("Empleado no encontrado");
            if (servicio == null) return BadRequest("Servicio no encontrado");

           
            cita.IdCliente = dto.IdCliente;
            cita.IdEmpleado = dto.IdEmpleado;
            cita.IdServicio = dto.IdServicio;
            cita.FechaHoraInicio = dto.FechaHoraInicio;
            cita.FechaHoraFin = dto.FechaHoraFin;

            try
            {
                await _context.SaveChangesAsync();
                return Ok("Cita actualizada correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest($"ERROR PUT: {ex.Message}");
            }
        }


        // ============================
        // DELETE
        // ============================
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCita(int id)
        {
            var cita = await _context.Citas.FindAsync(id);
            if (cita == null) return NotFound();

            _context.Citas.Remove(cita);
            await _context.SaveChangesAsync();

            return Ok("Cita eliminada");
        }
    }

    // ============================
    // DTO
    // ============================
    public class CitaDto
    {
        public int Id { get; set; }
        public DateTime FechaHoraInicio { get; set; }
        public DateTime FechaHoraFin { get; set; }
        public int IdCliente { get; set; }
        public int IdEmpleado { get; set; }
        public int IdServicio { get; set; }
        public string Cliente { get; set; } = string.Empty;
        public string Empleado { get; set; } = string.Empty;
        public string Servicio { get; set; } = string.Empty;
    }
}
