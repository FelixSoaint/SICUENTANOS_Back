namespace Dominio.Administrador
{
    public class Actividad
    {
        public Guid Id { get; set; }
        
        public Guid ModuloId { get; set; }

        public String? VcNombre { get; set; }

        public String? VcDescripcion { get; set; }

        public String? VcRedireccion { get; set; }

        public String? VcIcono { get; set; }

        public Boolean BEstado { get; set; }

        public String? PadreId { get; set; }

        public DateTime DtFechaCreacion { get; set; }

        public DateTime? DtFechaActualizacion { get; set; }

        public DateTime? DtFechaAnulacion { get; set; }

        public Modulo? Modulo { get; set; }
        public virtual ICollection<Rol>? Roles { get; set; }
        public virtual List <ActividadRol>? ActividadRoles { get; set; }
    }
}
