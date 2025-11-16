using BarberiaJK.Domain.Entities;
using BarberiaJK.Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        // =======================
        //      GET ALL (DTO)
        // =======================
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
                    Cliente = c.Cliente!.Nombre,
                    Empleado = c.Empleado!.Nombre,
                    Servicio = c.Servicio!.Nombre
                })
                .ToListAsync();

            return Ok(citas);
        }

        // =======================
        //        GET BY ID
        // =======================
        [HttpGet("{id}")]
        public async Task<ActionResult<Cita>> GetCita(int id)
        {
            var cita = await _context.Citas
                .Include(c => c.Cliente)
                .Include(c => c.Empleado)
                .Include(c => c.Servicio)
                .FirstOrDefaultAsync(c => c.IdCita == id);

            if (cita == null)
                return NotFound();

            return Ok(cita);
        }

        // =======================
        //          POST
        // =======================
        [HttpPost]
        public async Task<ActionResult<Cita>> PostCita(Cita cita)
        {
            try
            {
                _context.Citas.Add(cita);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetCita), new { id = cita.IdCita }, cita);
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, "Error al guardar la cita en la base de datos.");
            }
        }

        // =======================
        //           PUT
        // =======================
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCita(int id, Cita cita)
        {
            if (id != cita.IdCita)
                return BadRequest("El ID no coincide.");

            var citaDb = await _context.Citas.FindAsync(id);

            if (citaDb == null)
                return NotFound();

            // Actualiza solo propiedades reales
            citaDb.FechaHoraInicio = cita.FechaHoraInicio;
            citaDb.FechaHoraFin = cita.FechaHoraFin;
            citaDb.IdCliente = cita.IdCliente;
            citaDb.IdEmpleado = cita.IdEmpleado;
            citaDb.IdServicio = cita.IdServicio;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, "Error al actualizar la cita.");
            }

            return NoContent();
        }

        // =======================
        //         DELETE
        // =======================
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCita(int id)
        {
            var cita = await _context.Citas.FindAsync(id);

            if (cita == null)
                return NotFound();

            _context.Citas.Remove(cita);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, "Error al eliminar la cita.");
            }

            return NoContent();
        }
    }

    // =======================
    //           DTO
    // =======================
    public class CitaDto
    {
        public int Id { get; set; }
        public DateTime FechaHoraInicio { get; set; }
        public DateTime FechaHoraFin { get; set; }
        public string Cliente { get; set; } = string.Empty;
        public string Empleado { get; set; } = string.Empty;
        public string Servicio { get; set; } = string.Empty;  
    }

}
