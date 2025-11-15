using BarberiaJK.Domain.Entities;

namespace BarberiaJK.Domain.Repository
{
    public interface IEmpleadoRepository
    {
        Task<IEnumerable<Empleado>> GetAllAsync();
        Task<Empleado?> GetByIdAsync(int id);
        Task<Empleado> AddAsync(Empleado empleado);
        Task UpdateAsync(Empleado empleado);
        Task DeleteAsync(int id);
    }
}
