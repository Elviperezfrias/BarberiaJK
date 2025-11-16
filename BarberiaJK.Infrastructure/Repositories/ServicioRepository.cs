using BarberiaJK.Domain.Entities;
using BarberiaJK.Infrastructure.Context;
using BarberiaJK.Infrastructure.Core;
using BarberiaJK.Infrastructure.Interfaces;

namespace BarberiaJK.Infrastructure.Repositories
// SERVICIO REPOSITORY 
{
    public class ServicioRepository : BaseRepository<Servicio>, IServicioRepository
    {
        public ServicioRepository(BarberiaContext context) : base(context)
        {
        }
    }
}
