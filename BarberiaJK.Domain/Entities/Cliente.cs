using BarberiaJK.Domain.Core;
//

namespace BarberiaJK.Domain.Entities
    // CLIENTE
{
    public class Cliente : BaseEntity
    {
        public int IdCliente { get; set; }   
        public string Nombre { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
    }
}
