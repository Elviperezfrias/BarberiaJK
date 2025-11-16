using BarberiaJK.Domain.Entities;

namespace BarberiaJK.Infrastructure.Interfaces
{
    // ID EMPLEADO REPOSITORY
    public interface IEmpleadoRepository
    {
        Task<IEnumerable<Empleado>> GetAllAsync();
        Task<Empleado?> GetByIdAsync(int id);
        Task<Empleado> AddAsync(Empleado empleado);
        Task UpdateAsync(Empleado empleado);
        Task DeleteAsync(int id);
    }
}
