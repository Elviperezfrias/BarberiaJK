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

        // GET: api/Empleado (todos)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Empleado>>> GetEmpleados()
        {
            return await _context.Empleados
                .ToListAsync(); // elimina el filtro Activo
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
     

        // POST: api/Empleado
        [HttpPost]
        public async Task<ActionResult<Empleado>> PostEmpleado(Empleado empleado)
        {
            if (empleado.PorcentajeComision < 0 || empleado.PorcentajeComision > 100)
            {
                return BadRequest(new { message = "El porcentaje de comisión debe estar entre 0 y 100" });
            }

            empleado.Activo = true;

            _context.Empleados.Add(empleado);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEmpleado), new { id = empleado.IdEmpleado }, empleado);
        }

        // PUT: api/Empleado/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpleado(int id, Empleado empleado)
        {
            if (id != empleado.IdEmpleado)
                return BadRequest("El ID no coincide.");

            _context.Entry(empleado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Empleados.Any(e => e.IdEmpleado == id))
                    return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/Empleado/5 (Soft Delete)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpleado(int id)
        {
            var empleado = await _context.Empleados
                .FirstOrDefaultAsync(e => e.IdEmpleado == id);

            if (empleado == null)
                return NotFound(new { message = $"Empleado con ID {id} no encontrado" });

            // Soft Delete
            empleado.Activo = false;
            await _context.SaveChangesAsync();

            return Ok(new { message = $"Empleado {id} desactivado correctamente" });
        }


        // PUT: api/Empleado/activar/5
        [HttpPut("{id}/activar")]
        public async Task<IActionResult> ActivarEmpleado(int id)
        {
            var empleado = await _context.Empleados.FindAsync(id);

            if (empleado == null)
                return NotFound();

            empleado.Activo = true;
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
