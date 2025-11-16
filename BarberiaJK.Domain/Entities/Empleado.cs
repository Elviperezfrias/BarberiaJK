using BarberiaJK.Domain.Core;


namespace BarberiaJK.Domain.Entities
//EMPLEADO ENTITY
{
    public class Empleado : BaseEntity
    {
        public int IdEmpleado { get; set; }  
        public string Nombre { get; set; } = string.Empty;
        public decimal PorcentajeComision { get; set; }
    }
}
