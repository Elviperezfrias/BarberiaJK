using BarberiaJK.Domain.Entities;
using BarberiaJK.Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BarberiaJK.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicioController : ControllerBase
    {
        private readonly BarberiaContext _context;

        public ServicioController(BarberiaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Servicio>>> GetServicios()
        {
            return await _context.Servicios.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Servicio>> GetServicio(int id)
        {
            var servicio = await _context.Servicios.FirstOrDefaultAsync(s => s.IdServicio == id);

            if (servicio == null)
                return NotFound();

            return servicio;
        }

        [HttpPost]
        public async Task<ActionResult<Servicio>> PostServicio(Servicio servicio)
        {
            _context.Servicios.Add(servicio);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetServicio), new { id = servicio.IdServicio }, servicio);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutServicio(int id, Servicio servicio)
        {
            if (id != servicio.IdServicio)
                return BadRequest();

            _context.Entry(servicio).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServicio(int id)
        {
            var servicio = await _context.Servicios.FirstOrDefaultAsync(s => s.IdServicio == id);

            if (servicio == null)
                return NotFound();

            _context.Servicios.Remove(servicio);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
