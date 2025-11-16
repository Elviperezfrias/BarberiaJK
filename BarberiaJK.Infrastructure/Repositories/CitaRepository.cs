using BarberiaJK.Domain.Entities;
using BarberiaJK.Infrastructure.Context;
using BarberiaJK.Infrastructure.Core;
using BarberiaJK.Infrastructure.Interfaces;

namespace BarberiaJK.Infrastructure.Repositories
{//
    public class CitaRepository : BaseRepository<Cita>, ICitaRepository
    {
        public CitaRepository(BarberiaContext context) : base(context)
        {
        }
    }
}
