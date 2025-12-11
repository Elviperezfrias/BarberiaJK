using BarberiaJK.Domain.Entities;
using BarberiaJK.Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BarberiaJK.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly BarberiaContext _context;

        public ClienteController(BarberiaContext context)
        {
            _context = context;
        }

        // ============================================
        // GET: api/cliente
        // ============================================
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            return await _context.Clientes.ToListAsync();
        }

        // ============================================
        // GET: api/cliente/5
        // ============================================
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            var cliente = await _context.Clientes
                .FirstOrDefaultAsync(c => c.IdCliente == id);

            if (cliente == null)
                return NotFound();

            return cliente;
        }

        // ============================================
        // POST: api/cliente
        // ============================================
        [HttpPost]
        public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCliente),
                new { id = cliente.IdCliente }, cliente);
        }

        // ============================================
        // PUT: api/cliente/5
        // ============================================
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, Cliente cliente)
        {
            if (id != cliente.IdCliente)
                return BadRequest();

            _context.Entry(cliente).State = EntityState.Modified;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // ============================================
        // PUT: api/cliente/5/activar
        // ============================================
        [HttpPut("{id}/activar")]
        public async Task<IActionResult> ActivarCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null)
                return NotFound();

            cliente.Activo = true;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // ============================================
        // DELETE (DESACTIVAR): api/cliente/5
        // ============================================
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.IdCliente == id);

            if (cliente == null)
                return NotFound();

            
            cliente.Activo = false;
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}