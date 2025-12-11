namespace BarberiaJK.Domain.Entities
{
    public class Empleado
    {
        public int IdEmpleado { get; set; }

        public string Nombre { get; set; } = null!;

        public bool Activo { get; set; } = true;


        public string? Telefono { get; set; }   
        public string? Cargo { get; set; }      

        public decimal PorcentajeComision { get; set; }
        public ICollection<Cita> Citas { get; set; } = new List<Cita>();
        public ICollection<Comision> Comisiones { get; set; } = new List<Comision>();

    }
}
