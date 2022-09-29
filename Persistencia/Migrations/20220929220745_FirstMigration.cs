using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistencia.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Configuracion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDiasLimiteRespuesta = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    BSabadoLaboral = table.Column<bool>(type: "bit", maxLength: 50, nullable: false),
                    BDomingoLaboral = table.Column<bool>(type: "bit", maxLength: 50, nullable: false),
                    BEstado = table.Column<bool>(type: "bit", nullable: false),
                    DtFechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtFechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtFechaAnulacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configuracion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Modulo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VcNombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    VcDescripcion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    VcRedireccion = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    VcIcono = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BEstado = table.Column<bool>(type: "bit", nullable: false),
                    DtFechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtFechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtFechaAnulacion = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Fecha Eliminacion del registro")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modulo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parametro",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VcNombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    VcCodigoInterno = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    BEstado = table.Column<bool>(type: "bit", nullable: false),
                    DtFechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtFechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtFechaAnulacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parametro", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipoDocumento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VcDocumento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VcPrimerNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VcPrimerApellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VcSegundoNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VcSegundoApellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VcCorreo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VcTelefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VcDireccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VcIdAzure = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BEstado = table.Column<bool>(type: "bit", nullable: false),
                    DtFechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtFechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DtFechaAnulacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Actividad",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModuloId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VcNombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    VcDescripcion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    VcRedireccion = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    VcIcono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    BEstado = table.Column<bool>(type: "bit", nullable: false),
                    PadreId = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true, comment: "Id de la actividad padre de acuerdo con la jerarquia"),
                    DtFechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtFechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtFechaAnulacion = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Fecha anulación del registro")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actividad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Actividad_Modulo",
                        column: x => x.ModuloId,
                        principalTable: "Modulo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModuloId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VcNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BEstado = table.Column<bool>(type: "bit", nullable: false),
                    VcCodigoInterno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DtFechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtFechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DtFechaAnulacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rol_Modulo_ModuloId",
                        column: x => x.ModuloId,
                        principalTable: "Modulo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParametroDetalle",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParametroId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VcNombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TxDescripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VcCodigoInterno = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DCodigoIterno = table.Column<decimal>(type: "decimal(17,3)", precision: 17, scale: 3, nullable: true),
                    BEstado = table.Column<bool>(type: "bit", nullable: false),
                    RangoDesde = table.Column<int>(type: "int", nullable: true),
                    RangoHasta = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParametroDetalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParametroDetalle_Parametro_ParametroId",
                        column: x => x.ParametroId,
                        principalTable: "Parametro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contrato",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    INumero = table.Column<int>(type: "int", nullable: false),
                    IAño = table.Column<int>(type: "int", nullable: false),
                    DtFechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtFechaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtFechaProrroga = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DtFechaTerminacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BEstado = table.Column<bool>(type: "bit", nullable: false),
                    DtFechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtFechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DtFechaAnulacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contrato", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contrato_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActividadRol",
                columns: table => new
                {
                    ActividadId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RolId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActividadRol", x => new { x.RolId, x.ActividadId });
                    table.ForeignKey(
                        name: "FK_ActividadRol_Actividad_ActividadId",
                        column: x => x.ActividadId,
                        principalTable: "Actividad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActividadRol_Rol_RolId",
                        column: x => x.RolId,
                        principalTable: "Rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioArea",
                columns: table => new
                {
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParametroDetalleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DtFechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtFechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtFechaAnulacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioArea", x => new { x.UsuarioId, x.ParametroDetalleId });
                    table.ForeignKey(
                        name: "FK_UsuarioArea_ParametroDetalle_ParametroDetalleId",
                        column: x => x.ParametroDetalleId,
                        principalTable: "ParametroDetalle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioArea_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioCargo",
                columns: table => new
                {
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParametroDetalleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DtFechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtFechaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtFechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtFechaAnulacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioCargo", x => new { x.UsuarioId, x.ParametroDetalleId });
                    table.ForeignKey(
                        name: "FK_UsuarioCargo_ParametroDetalle_ParametroDetalleId",
                        column: x => x.ParametroDetalleId,
                        principalTable: "ParametroDetalle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioCargo_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioPuntoAtencion",
                columns: table => new
                {
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParametroDetalleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DtFechaIncio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtFechaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtFechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtFechaAnulacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioPuntoAtencion", x => new { x.UsuarioId, x.ParametroDetalleId });
                    table.ForeignKey(
                        name: "FK_UsuarioPuntoAtencion_ParametroDetalle_ParametroDetalleId",
                        column: x => x.ParametroDetalleId,
                        principalTable: "ParametroDetalle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioPuntoAtencion_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Actividad_ModuloId",
                table: "Actividad",
                column: "ModuloId");

            migrationBuilder.CreateIndex(
                name: "IX_ActividadRol_ActividadId",
                table: "ActividadRol",
                column: "ActividadId");

            migrationBuilder.CreateIndex(
                name: "IX_Contrato_UsuarioId",
                table: "Contrato",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ParametroDetalle_ParametroId",
                table: "ParametroDetalle",
                column: "ParametroId");

            migrationBuilder.CreateIndex(
                name: "IX_Rol_ModuloId",
                table: "Rol",
                column: "ModuloId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioArea_ParametroDetalleId",
                table: "UsuarioArea",
                column: "ParametroDetalleId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioCargo_ParametroDetalleId",
                table: "UsuarioCargo",
                column: "ParametroDetalleId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioPuntoAtencion_ParametroDetalleId",
                table: "UsuarioPuntoAtencion",
                column: "ParametroDetalleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActividadRol");

            migrationBuilder.DropTable(
                name: "Configuracion");

            migrationBuilder.DropTable(
                name: "Contrato");

            migrationBuilder.DropTable(
                name: "UsuarioArea");

            migrationBuilder.DropTable(
                name: "UsuarioCargo");

            migrationBuilder.DropTable(
                name: "UsuarioPuntoAtencion");

            migrationBuilder.DropTable(
                name: "Actividad");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropTable(
                name: "ParametroDetalle");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Modulo");

            migrationBuilder.DropTable(
                name: "Parametro");
        }
    }
}
