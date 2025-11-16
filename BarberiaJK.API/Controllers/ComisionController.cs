using BarberiaJK.Domain.Entities;
using BarberiaJK.Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BarberiaJK.API.Controllers



{//     [HttpDelete("{id}")]
    [Route("api/[controller]")]
    [ApiController]
    public class ComisionController : ControllerBase
    {
        private readonly BarberiaContext _context;

        public ComisionController(BarberiaContext context)
        {
            _context = context;
        }
        //GET: api/Comision
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comision>>> GetComisiones()
        {
            return await _context.Comisiones
                .Include(c => c.Empleado)
                .Include(c => c.Cita)
                .ToListAsync();
        }
        //GET: api/Comision/5
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
        //GET: api/Comision/Empleado/5
        [HttpPost]
        public async Task<ActionResult<Comision>> PostComision(Comision comision)
        {
            _context.Comisiones.Add(comision);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetComision), new { id = comision.IdComision }, comision);
        }
        //GET: api/Comision/Empleado/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComision(int id, Comision comision)
        {
            if (id != comision.IdComision)
                return BadRequest();


            _context.Entry(comision).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }
        //GET: api/Comision/5
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
