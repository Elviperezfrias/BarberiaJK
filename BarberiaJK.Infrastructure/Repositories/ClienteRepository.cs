using BarberiaJK.Domain.Entities;
using BarberiaJK.Infrastructure.Context;
using BarberiaJK.Infrastructure.Core;
using BarberiaJK.Infrastructure.Interfaces;

namespace BarberiaJK.Infrastructure.Repositories
{// REPOSITORIO DE CLIENTE 
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(BarberiaContext context) : base(context)
        {
        }
    }
}
