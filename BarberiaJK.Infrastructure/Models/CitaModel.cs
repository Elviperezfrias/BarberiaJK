using System;

namespace BarberiaJK.Infrastructure.Models
{
    public class CitaModel
    {
        public int IdCliente { get; set; }
        public int IdEmpleado { get; set; }
        public int IdServicio { get; set; }
        public DateTime FechaHoraInicio { get; set; }
        public DateTime FechaHoraFin { get; set; }
    }
}
