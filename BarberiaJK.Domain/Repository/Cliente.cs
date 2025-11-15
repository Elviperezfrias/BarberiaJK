using BarberiaJK.Domain.Core;

namespace BarberiaJK.Domain.Repository
{
    public class Cliente : BaseEntity
        {
            public int IdCliente { get; set; }   // PK real de la BD
            public string Nombre { get; set; } = string.Empty;
            public string Telefono { get; set; } = string.Empty;
        


    }
}