using System.Numerics;

namespace Dominio.Administrador
{
    public class ActividadRol
    {
        public BigInteger ActividadId { get; set; }

        public Actividad? Actividad { get; set; }

        public BigInteger RolId { get; set; }

        public Rol? Rol { get; set; }   

    }
}
