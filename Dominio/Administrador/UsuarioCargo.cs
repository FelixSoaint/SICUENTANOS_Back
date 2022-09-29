﻿using System.Numerics;

namespace Dominio.Administrador
{
    public class UsuarioCargo
    {
        public BigInteger Id { get; set; }

        public BigInteger UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }

        public BigInteger ParametroDetalleId { get; set; }
        public ParametroDetalle? ParametroDetalle { get; set; }

        public DateTime DtFechaInicio { get; set; }

        public DateTime DtFechaFin { get; set; }

        public DateTime DtFechaCreacion { get; set; }

        public DateTime? DtFechaAnulacion { get; set; }

    }
}
