using BarberiaJK.Domain.Entities;

namespace BarberiaJK.Infrastructure.Interfaces
{
    public interface IComisionRepository
    {
        Task<IEnumerable<Comision>> GetAllAsync();
        Task<Comision?> GetByIdAsync(int id);
        Task<Comision> AddAsync(Comision comision);
        Task UpdateAsync(Comision comision);
        Task DeleteAsync(int id);
    }
}
