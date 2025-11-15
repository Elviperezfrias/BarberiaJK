using BarberiaJK.Domain.Entities;

namespace BarberiaJK.Domain.Repository
{
    public interface ICitaRepository
    {
        Task<IEnumerable<Cita>> GetAllAsync();
        Task<Cita?> GetByIdAsync(int id);
        Task<Cita> AddAsync(Cita cita);
        Task UpdateAsync(Cita cita);
        Task DeleteAsync(int id);
    }
}
