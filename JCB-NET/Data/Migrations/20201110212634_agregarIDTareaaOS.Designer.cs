﻿// <auto-generated />
using System;
using JCB_NET.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace JCB_NET.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20201110212634_agregarIDTareaaOS")]
    partial class agregarIDTareaaOS
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("JCB_NET.Models.Bodega", b =>
                {
                    b.Property<short>("Id_Bodega")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint");

                    b.Property<string>("Descripcion")
                        .HasColumnType("varchar(150)");

                    b.Property<string>("NombreBodega")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id_Bodega");

                    b.ToTable("T_Bodega");
                });

            modelBuilder.Entity("JCB_NET.Models.EstadoOrdenServicio", b =>
                {
                    b.Property<byte>("Id_EstadoOS")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint");

                    b.Property<string>("NombreEstado")
                        .IsRequired()
                        .HasColumnType("varchar(22)");

                    b.HasKey("Id_EstadoOS");

                    b.ToTable("T_Estado_OS");
                });

            modelBuilder.Entity("JCB_NET.Models.EstadoPlan", b =>
                {
                    b.Property<byte>("Id_EstadoPlan")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint");

                    b.Property<string>("NombreEstado")
                        .IsRequired()
                        .HasColumnType("varchar(22)");

                    b.HasKey("Id_EstadoPlan");

                    b.ToTable("T_Estado_Plan");
                });

            modelBuilder.Entity("JCB_NET.Models.Maquina", b =>
                {
                    b.Property<int>("Id_Maquina")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("varchar(18)");

                    b.Property<string>("Nombre")
                        .HasColumnType("varchar(25)");

                    b.Property<string>("Peso")
                        .HasColumnType("varchar(25)");

                    b.Property<string>("Tamano")
                        .HasColumnType("varchar(40)");

                    b.Property<string>("Ubicacion")
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id_Maquina");

                    b.ToTable("T_Maquina");
                });

            modelBuilder.Entity("JCB_NET.Models.OrdenServicio", b =>
                {
                    b.Property<int>("Id_Orden_Servicio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CodigoOS")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<DateTime>("FechaAtencion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<byte>("Id_EstadoOS")
                        .HasColumnType("tinyint");

                    b.Property<int>("Id_Tarea")
                        .HasColumnType("int");

                    b.Property<string>("ResultadoAtencion")
                        .HasColumnType("varchar(20)");

                    b.Property<string>("TipoMantenimiento")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id_Orden_Servicio");

                    b.HasIndex("Id_EstadoOS");

                    b.HasIndex("Id_Tarea");

                    b.HasIndex("UserId");

                    b.ToTable("T_Orden_Servicio");
                });

            modelBuilder.Entity("JCB_NET.Models.Periodicidad", b =>
                {
                    b.Property<byte>("Id_Periodicidad")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint");

                    b.Property<string>("Valor")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id_Periodicidad");

                    b.ToTable("T_Periodicidad");
                });

            modelBuilder.Entity("JCB_NET.Models.PlanMantenimientoPreventivo", b =>
                {
                    b.Property<int>("Id_PlanMantenimientoPreventivo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("EnEjecucion")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaFin")
                        .HasColumnType("datetime2");

                    b.Property<byte>("Id_EstadoPlan")
                        .HasColumnType("tinyint");

                    b.Property<string>("NombrePlan")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<bool>("isCorrectivo")
                        .HasColumnType("bit");

                    b.HasKey("Id_PlanMantenimientoPreventivo");

                    b.HasIndex("Id_EstadoPlan");

                    b.ToTable("T_Plan_Mantenimiento_Preventivo");
                });

            modelBuilder.Entity("JCB_NET.Models.Suministro", b =>
                {
                    b.Property<int>("Id_Suministro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<short>("Id_Bodega")
                        .HasColumnType("smallint");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Proveedor")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("StockMinimo")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Unidades")
                        .HasColumnType("varchar(15)");

                    b.HasKey("Id_Suministro");

                    b.HasIndex("Id_Bodega");

                    b.ToTable("T_Suministro");
                });

            modelBuilder.Entity("JCB_NET.Models.SuministroxTarea", b =>
                {
                    b.Property<int>("Id_Suministro")
                        .HasColumnType("int");

                    b.Property<int>("Id_Tarea")
                        .HasColumnType("int");

                    b.HasKey("Id_Suministro", "Id_Tarea");

                    b.HasIndex("Id_Tarea");

                    b.ToTable("T_Suministro_x_Tarea");
                });

            modelBuilder.Entity("JCB_NET.Models.Tarea", b =>
                {
                    b.Property<int>("Id_Tarea")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Clasificacion")
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Descripcion")
                        .HasColumnType("varchar(250)");

                    b.Property<int>("DuracionEstimada")
                        .HasColumnType("int");

                    b.Property<string>("Falla")
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("FechaFin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("datetime2");

                    b.Property<int>("Id_Maquina")
                        .HasColumnType("int");

                    b.Property<byte>("Id_Periodicidad")
                        .HasColumnType("tinyint");

                    b.Property<int>("Id_PlanMantenimientoPreventivo")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Prioridad")
                        .IsRequired()
                        .HasColumnType("varchar(25)");

                    b.Property<int>("TiempoPara")
                        .HasColumnType("int");

                    b.HasKey("Id_Tarea");

                    b.HasIndex("Id_Maquina");

                    b.HasIndex("Id_Periodicidad");

                    b.HasIndex("Id_PlanMantenimientoPreventivo");

                    b.ToTable("T_Tarea");
                });

            modelBuilder.Entity("JCB_NET.Models.Tecnico", b =>
                {
                    b.Property<int>("Id_Tecnico")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApeMaterno")
                        .HasColumnType("varchar(25)");

                    b.Property<string>("ApePaterno")
                        .IsRequired()
                        .HasColumnType("varchar(25)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("varchar(25)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("varchar(18)");

                    b.Property<string>("NroDocumento")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.HasKey("Id_Tecnico");

                    b.ToTable("T_Tecnico");
                });

            modelBuilder.Entity("JCB_NET.Models.TecnicoxTarea", b =>
                {
                    b.Property<int>("Id_Tecnico")
                        .HasColumnType("int");

                    b.Property<int>("Id_Tarea")
                        .HasColumnType("int");

                    b.HasKey("Id_Tecnico", "Id_Tarea");

                    b.HasIndex("Id_Tarea");

                    b.ToTable("T_Tecnico_x_Tarea");
                });

            modelBuilder.Entity("JCB_NET.Models.TipoDocumento", b =>
                {
                    b.Property<byte>("Id_TipoDocumento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint");

                    b.Property<string>("Valor")
                        .HasColumnType("varchar(15)");

                    b.HasKey("Id_TipoDocumento");

                    b.ToTable("T_Tipo_Documento");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("JCB_NET.Models.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("ApeMaterno")
                        .HasColumnType("varchar(15)");

                    b.Property<string>("ApePaterno")
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Direccion")
                        .HasColumnType("varchar(80)");

                    b.Property<byte[]>("Foto")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte>("Id_TipoDocumento")
                        .HasColumnType("tinyint");

                    b.Property<string>("Nombres")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("NroDocumento")
                        .HasColumnType("varchar(30)");

                    b.HasIndex("Id_TipoDocumento");

                    b.HasDiscriminator().HasValue("ApplicationUser");
                });

            modelBuilder.Entity("JCB_NET.Models.OrdenServicio", b =>
                {
                    b.HasOne("JCB_NET.Models.EstadoOrdenServicio", "EstadoOrdenServicio")
                        .WithMany()
                        .HasForeignKey("Id_EstadoOS")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JCB_NET.Models.Tarea", "Tarea")
                        .WithMany()
                        .HasForeignKey("Id_Tarea")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JCB_NET.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("JCB_NET.Models.PlanMantenimientoPreventivo", b =>
                {
                    b.HasOne("JCB_NET.Models.EstadoPlan", "EstadoPlan")
                        .WithMany()
                        .HasForeignKey("Id_EstadoPlan")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("JCB_NET.Models.Suministro", b =>
                {
                    b.HasOne("JCB_NET.Models.Bodega", "Bodega")
                        .WithMany()
                        .HasForeignKey("Id_Bodega")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("JCB_NET.Models.SuministroxTarea", b =>
                {
                    b.HasOne("JCB_NET.Models.Suministro", "Suministro")
                        .WithMany("SuministroxTareas")
                        .HasForeignKey("Id_Suministro")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JCB_NET.Models.Tarea", "Tarea")
                        .WithMany("SuministroxTareas")
                        .HasForeignKey("Id_Tarea")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("JCB_NET.Models.Tarea", b =>
                {
                    b.HasOne("JCB_NET.Models.Maquina", "Maquina")
                        .WithMany()
                        .HasForeignKey("Id_Maquina")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JCB_NET.Models.Periodicidad", "Periodicidad")
                        .WithMany()
                        .HasForeignKey("Id_Periodicidad")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JCB_NET.Models.PlanMantenimientoPreventivo", "PlanMantenimientoPreventivo")
                        .WithMany()
                        .HasForeignKey("Id_PlanMantenimientoPreventivo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("JCB_NET.Models.TecnicoxTarea", b =>
                {
                    b.HasOne("JCB_NET.Models.Tarea", "Tarea")
                        .WithMany("TecnicoxTareas")
                        .HasForeignKey("Id_Tarea")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JCB_NET.Models.Tecnico", "Tecnico")
                        .WithMany("TecnicoxTareas")
                        .HasForeignKey("Id_Tecnico")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("JCB_NET.Models.ApplicationUser", b =>
                {
                    b.HasOne("JCB_NET.Models.TipoDocumento", "TipoDocumento")
                        .WithMany()
                        .HasForeignKey("Id_TipoDocumento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
