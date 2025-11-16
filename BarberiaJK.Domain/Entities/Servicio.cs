using BarberiaJK.Domain.Core;

namespace BarberiaJK.Domain.Entities
{
    // SERVICIO ENTITY
    public class Servicio : BaseEntity
    {
        public int IdServicio { get; set; }  
        public string Nombre { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public int DuracionMinutos { get; set; }
    }
}
