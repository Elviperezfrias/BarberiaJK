using BarberiaJK.Domain.Entities;
using BarberiaJK.Domain.Repository; 
using BarberiaJK.Infrastructure.Context;
using BarberiaJK.Infrastructure.Core;

namespace BarberiaJK.Infrastructure.Repositories
{
    public class EmpleadoRepository : BaseRepository<Empleado>, IEmpleadoRepository
    {
        public EmpleadoRepository(BarberiaContext context) : base(context)
        {
        }
    }
}
