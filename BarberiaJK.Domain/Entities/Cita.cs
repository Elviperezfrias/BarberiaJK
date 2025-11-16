using BarberiaJK.Domain.Core;

namespace BarberiaJK.Domain.Entities
    // CITA 
{
    public class Cita : BaseEntity
    {
        public int IdCita { get; set; }  

        public int IdCliente { get; set; }
        public Cliente? Cliente { get; set; }

        public int IdEmpleado { get; set; }
        public Empleado? Empleado { get; set; }

        public int IdServicio { get; set; }
        public Servicio Servicio { get; set; } = null!;


        public DateTime FechaHoraInicio { get; set; }
        public DateTime FechaHoraFin { get; set; }
    }
}
