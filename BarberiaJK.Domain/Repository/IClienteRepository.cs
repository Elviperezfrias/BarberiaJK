using BarberiaJK.Domain.Entities;

namespace BarberiaJK.Domain.Repository
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> GetAllAsync();
        Task<Cliente?> GetByIdAsync(int id);
        Task<Cliente> AddAsync(Cliente cliente);
        Task UpdateAsync(Cliente cliente);
        Task DeleteAsync(int id);
    }
}
