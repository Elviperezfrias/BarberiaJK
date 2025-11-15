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

        // GET ALL
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cita>>> GetCitas()
        {
            return await _context.Citas
                .Include(c => c.Cliente)
                .Include(c => c.Empleado)
                .Include(c => c.Servicio)
                .ToListAsync();
        }

        // GET BY ID
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

            return cita;
        }

        // POST
        [HttpPost]
        public async Task<ActionResult<Cita>> PostCita(Cita cita)
        {
            _context.Citas.Add(cita);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCita), new { id = cita.IdCita }, cita);
        }

        // PUT
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCita(int id, Cita cita)
        {
            if (id != cita.IdCita)
                return BadRequest();

            _context.Entry(cita).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCita(int id)
        {
            var cita = await _context.Citas.FirstOrDefaultAsync(c => c.IdCita == id);

            if (cita == null)
                return NotFound();

            _context.Citas.Remove(cita);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
