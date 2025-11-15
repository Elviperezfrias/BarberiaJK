using BarberiaJK.Domain.Core;

namespace BarberiaJK.Domain.Entities
{
    public class Servicio : BaseEntity
    {
        public int IdServicio { get; set; }  // PK real
        public string Nombre { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public int DuracionMinutos { get; set; }
    }
}
