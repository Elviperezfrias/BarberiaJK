using BarberiaJK.Domain.Core;

namespace BarberiaJK.Domain.Entities
{
    public class Empleado : BaseEntity
    {
        public int IdEmpleado { get; set; }  // PK real
        public string Nombre { get; set; } = string.Empty;
        public decimal PorcentajeComision { get; set; }
    }
}
