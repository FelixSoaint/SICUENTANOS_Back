namespace Dominio.Administrador
{
    public class ActividadRol
    {
        public Guid ActividadId { get; set; }

        public Actividad? Actividad { get; set; }

        public Guid RolId { get; set; }

        public Rol? Rol { get; set; }   

    }
}
