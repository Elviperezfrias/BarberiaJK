using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberiaJK.Application.DTOs
{
    public class CitaCreateDto
    {
        public int IdCliente { get; set; }
        public int IdEmpleado { get; set; }
        public int IdServicio { get; set; }
        public DateTime FechaHoraInicio { get; set; }
        public DateTime FechaHoraFin { get; set; }
    }

}
