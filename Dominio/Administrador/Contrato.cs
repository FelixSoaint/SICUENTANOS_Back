﻿using System.Numerics;

namespace Dominio.Administrador
{
    public class Contrato
    {
        public BigInteger Id { get; set; }

        public BigInteger UsuarioId { get; set; }

        public int INumero { get; set; }

        public int IAño { get; set; }

        public DateTime DtFechaInicio { get; set; }

        public DateTime DtFechaFin { get; set; }

        public DateTime? DtFechaProrroga { get; set; }

        public DateTime? DtFechaTerminacion { get; set; }

        public Boolean BEstado { get; set; }

        public DateTime DtFechaCreacion { get; set; }

        public DateTime? DtFechaActualizacion { get; set; }

        public DateTime? DtFechaAnulacion { get; set; }

        public Usuario? Usuario { get; set; }

    }
}