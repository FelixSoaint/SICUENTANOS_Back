﻿namespace Dominio.Administrador
{
    public class UsuarioArea
    {
        public Guid Id { get; set; }

        public Guid UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }

        public Guid ParametroDetalleId { get; set; }
        public ParametroDetalle? ParametroDetalle { get; set; }

        public DateTime DtFechaInicio  { get; set; }

        public DateTime DtFechaCreacion { get; set; }

        public DateTime? DtFechaAnulacion { get; set; }


    }
}
