using BarberiaJK.Domain.Core;

namespace BarberiaJK.Domain.Entities

    // COMICION
{
    public class Comision : BaseEntity
    {
        public int IdComision { get; set; }

        public int IdEmpleado { get; set; }
        public Empleado? Empleado { get; set; }

        public int IdCita { get; set; }
        public Cita? Cita { get; set; }

        public decimal MontoComision { get; set; }
    }
}
