using BarberiaJK.Domain.Entities;
using BarberiaJK.Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BarberiaIX.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly BarberiaContext _context;

        public EmpleadoController(BarberiaContext context)
        {
            _context = context;
        }

        // GET: api/Empleado
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Empleado>>> GetEmpleados()
        {
            return await _context.Empleados.ToListAsync();
        }

        // GET: api/Empleado/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Empleado>> GetEmpleado(int id)
        {
            var empleado = await _context.Empleados.FindAsync(id);

            if (empleado == null)
            {
                return NotFound(new { message = $"Empleado con ID {id} no encontrado" });
            }

            return empleado;
        }

        // GET: api/Empleado/5/comisiones
        [HttpGet("{id}/comisiones")]
        public async Task<ActionResult<IEnumerable<Comision>>> GetComisionesByEmpleado(int id)
        {
            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado == null)
            {
                return NotFound(new { message = $"Empleado con ID {id} no encontrado" });
            }

            var comisiones = await _context.Comisiones
                .Include(c => c.Cita!)
                .ThenInclude(cita => cita.Servicio!)
                .Where(c => c.IdEmpleado == id)
                .ToListAsync();

            return comisiones;
        }

        // POST: api/Empleado
        [HttpPost]
        public async Task<ActionResult<Empleado>> PostEmpleado(Empleado empleado)
        {
            if (empleado.PorcentajeComision < 0 || empleado.PorcentajeComision > 100)
            {
                return BadRequest(new { message = "El porcentaje de comisión debe estar entre 0 y 100" });
            }

            _context.Empleados.Add(empleado);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEmpleado), new { id = empleado.IdEmpleado }, empleado);
        }

        // PUT: api/Empleado/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpleado(int id, Empleado empleado)
        {
            if (id != empleado.IdEmpleado)
            {
                return BadRequest(new { message = "El ID no coincide" });
            }

            if (empleado.PorcentajeComision < 0 || empleado.PorcentajeComision > 100)
            {
                return BadRequest(new { message = "El porcentaje de comisión debe estar entre 0 y 100" });
            }

            _context.Entry(empleado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpleadoExists(id))
                {
                    return NotFound(new { message = $"Empleado con ID {id} no encontrado" });
                }
                throw;
            }

            return NoContent();
        }

        // DELETE: api/Empleado/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpleado(int id)
        {
            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado == null)
            {
                return NotFound(new { message = $"Empleado con ID {id} no encontrado" });
            }

            _context.Empleados.Remove(empleado);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmpleadoExists(int id)
        {
            return _context.Empleados.Any(e => e.IdEmpleado == id);
        }
    }
}