using BarberiaJK.Domain.Entities;
using BarberiaJK.Infrastructure.Context;
using BarberiaJK.Infrastructure.Core;
using BarberiaJK.Infrastructure.Interfaces;

namespace BarberiaJK.Infrastructure.Repositories
{
    public class ComisionRepository : BaseRepository<Comision>, IComisionRepository
    {
        public ComisionRepository(BarberiaContext context) : base(context)
        {
        }
    }
}
