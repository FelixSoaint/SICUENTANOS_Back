using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dominio.Administrador;
using System.Numerics;

namespace Persistencia.FluentConfig.Administrador
{
    public class ActividadConfig

    {
        public ActividadConfig(EntityTypeBuilder<Actividad> entity)
        {
            entity.ToTable("Actividad");

            entity.HasKey(p => p.Id);

            entity
            .HasOne(p => p.Modulo)
            .WithMany(p => p.Actividades)
            .HasForeignKey(p => p.ModuloId)
            .HasConstraintName("FK_Actividad_Modulo")
            .OnDelete(DeleteBehavior.Restrict);

            entity
            .HasMany(p => p.Roles)
            .WithMany(p => p.Actividades)
            .UsingEntity<ActividadRol>(
                j => j
                    .HasOne(pt => pt.Rol)
                    .WithMany(t => t.ActividadRoles)
                    .HasForeignKey(f => f.RolId),
                j => j
                    .HasOne(pt => pt.Actividad)
                    .WithMany(t => t.ActividadRoles)
                    .HasForeignKey(f => f.ActividadId),
                j => j
                    .HasKey(pt => new {pt.RolId,pt.ActividadId})
                );

            entity.Property(p => p.VcNombre).IsRequired().HasMaxLength(50);

            entity.Property(p => p.VcDescripcion).IsRequired().HasMaxLength(200);

            entity.Property(p => p.VcRedireccion).IsRequired().HasMaxLength(80);

            entity.Property(p => p.VcIcono).IsRequired().HasMaxLength(20);

            entity.Property(p => p.BEstado).IsRequired();

            entity.Property(p => p.PadreId)
            .IsRequired(false)
            .HasMaxLength(40)
            .HasComment("Id de la actividad padre de acuerdo con la jerarquia");

            entity.Property(p => p.DtFechaCreacion).IsRequired();

            entity.Property(p => p.DtFechaActualizacion).IsRequired();

            entity
            .Property(p => p.DtFechaAnulacion)
            .IsRequired(false)
            .HasComment("Fecha anulaci??n del registro");



            //entity.HasData(
            //    new Actividad
            //    {
            //        Id = Guid.Parse("b235b97e-e79a-481a-ad19-cb314e5e8ea7"),
            //        ModuloId = 1,
            //        VcNombre = "Personas",
            //        VcDescripcion = "Gesti??n de personas",
            //        VcRedireccion = "#",
            //        VcIcono = "bi bi-person",
            //        BEstado = true,
            //        DtFechaCreacion = new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773),
            //        DtFechaActualizacion = new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773)
            //    },
            //    new Actividad
            //    {
            //        Id = Guid.Parse("9f8333eb-c849-4db5-9147-7fee695d507c"),
            //        ModuloId = 1,
            //        VcNombre = "Roles",
            //        VcDescripcion = "Gesti??n de roles",
            //        VcRedireccion = "/actividad",
            //        VcIcono = "bi bi-person-rolodex",
            //        BEstado = true,
            //        DtFechaCreacion = new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773),
            //        DtFechaActualizacion = new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773)
            //    },
            //    new Actividad
            //    {
            //        Id = Guid.Parse("651fb52a-eff0-4ba8-8639-8eb415cd177f"),
            //        ModuloId = 1,
            //        VcNombre = "Configuraci??n",
            //        VcDescripcion = "Configuraci??n General",
            //        VcRedireccion = "#",
            //        VcIcono = "bi bi-person-rolodex",
            //        BEstado = true,
            //        DtFechaCreacion = new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773),
            //        DtFechaActualizacion = new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773)
            //    },
            //    new Actividad
            //    {
            //        Id = Guid.Parse("f1de5c86-a834-44e6-96fd-d5f7eb2c1565"),
            //        ModuloId = 1,
            //        VcNombre = "Uusarios",
            //        VcDescripcion = "Gesti??n de usuarios",
            //        VcRedireccion = "/usuario",
            //        VcIcono = "",
            //        BEstado = true,
            //        DtFechaCreacion = new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773),
            //        DtFechaActualizacion = new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773),
            //        PadreId = "b235b97e-e79a-481a-ad19-cb314e5e8ea7"

            //    },
            //    new Actividad
            //    {
            //        Id = Guid.Parse("136e80b6-663e-42d3-bc36-b63463f4ed88"),
            //        ModuloId = 1,
            //        VcNombre = "Cargos",
            //        VcDescripcion = "Gesti??n de Cargos",
            //        VcRedireccion = "/cargos",
            //        VcIcono = "",
            //        BEstado = true,
            //        DtFechaCreacion = new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773),
            //        DtFechaActualizacion = new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773),
            //        PadreId = "b235b97e-e79a-481a-ad19-cb314e5e8ea7"
            //    },
            //    new Actividad
            //    {
            //        Id = Guid.Parse("7102d0db-d846-488e-b485-a6518aeb722d"),
            //        ModuloId = 1,
            //        VcNombre = "??reas",
            //        VcDescripcion = "Gesti??n de ??reas",
            //        VcRedireccion = "#",
            //        VcIcono = "",
            //        BEstado = true,
            //        DtFechaCreacion = new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773),
            //        DtFechaActualizacion = new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773),
            //        PadreId = "b235b97e-e79a-481a-ad19-cb314e5e8ea7"
            //    },
            //    new Actividad
            //    {
            //        Id = Guid.Parse("efaf2845-3c4e-44b1-9385-29781eb7247d"),
            //        ModuloId = 1,
            //        VcNombre = "Puntos de Atenci??n",
            //        VcDescripcion = "Gesti??n de Puntos de Atenci??n",
            //        VcRedireccion = "#",
            //        VcIcono = "bi bi-person",
            //        BEstado = true,
            //        DtFechaCreacion = new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773),
            //        DtFechaActualizacion = new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773),
            //        PadreId = "b235b97e-e79a-481a-ad19-cb314e5e8ea7"
            //    }
            //);

        }
    }
}