using BarberiaJK.Domain.Entities;
using BarberiaJK.Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BarberiaJK.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComisionController : ControllerBase
    {
        private readonly BarberiaContext _context;

        public ComisionController(BarberiaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comision>>> GetComisiones()
        {
            return await _context.Comisiones
                .Include(c => c.Empleado)
                .Include(c => c.Cita)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Comision>> GetComision(int id)
        {
            var comision = await _context.Comisiones
                .Include(c => c.Empleado)
                .Include(c => c.Cita)
                .FirstOrDefaultAsync(c => c.IdComision == id);

            if (comision == null)
                return NotFound();

            return comision;
        }

        [HttpPost]
        public async Task<ActionResult<Comision>> PostComision(Comision comision)
        {
            _context.Comisiones.Add(comision);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetComision), new { id = comision.IdComision }, comision);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutComision(int id, Comision comision)
        {
            if (id != comision.IdComision)
                return BadRequest();

            _context.Entry(comision).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComision(int id)
        {
            var comision = await _context.Comisiones.FirstOrDefaultAsync(c => c.IdComision == id);

            if (comision == null)
                return NotFound();

            _context.Comisiones.Remove(comision);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
