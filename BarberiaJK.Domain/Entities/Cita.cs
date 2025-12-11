using BarberiaJK.Domain.Entities;
using System;

namespace BarberiaJK.Domain.Entities
{
    public class Cita
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
