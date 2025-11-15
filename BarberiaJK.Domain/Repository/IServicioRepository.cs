using BarberiaJK.Domain.Entities;

namespace BarberiaJK.Domain.Repository
{
    public interface IServicioRepository
    {
        Task<IEnumerable<Servicio>> GetAllAsync();
        Task<Servicio?> GetByIdAsync(int id);
        Task<Servicio> AddAsync(Servicio servicio);
        Task UpdateAsync(Servicio servicio);
        Task DeleteAsync(int id);
    }
}
