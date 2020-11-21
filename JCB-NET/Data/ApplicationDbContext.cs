using System;
using System.Collections.Generic;
using System.Text;
using JCB_NET.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JCB_NET.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TecnicoxTarea>().HasKey(txt => new { txt.Id_Tecnico, txt.Id_Tarea });
            modelBuilder.Entity<SuministroxTarea>().HasKey(txt => new { txt.Id_Suministro, txt.Id_Tarea });
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<TipoDocumento> TipoDocumento { get; set; }
        public DbSet<PlanMantenimientoPreventivo> PlanMantenimientoPreventivo { get; set; }
        public DbSet<EstadoPlan> EstadoPlan { get; set; }
        public DbSet<Tarea> Tarea { get; set; }
        public DbSet<Periodicidad> Periodicidad { get; set; }
        public DbSet<Maquina> Maquina { get; set; }
        public DbSet<Tecnico> Tecnico { get; set; }
        public DbSet<TecnicoxTarea> TecnicoxTarea { get; set; }
        public DbSet<Bodega> Bodega { get; set; }
        public DbSet<Suministro> Suministro { get; set; }
        public DbSet<SuministroxTarea> SuministroxTarea { get; set; }
        public DbSet<OrdenServicio> OrdenServicio { get; set; }
        public DbSet<EstadoOrdenServicio> EstadoOrdenServicio { get; set; }


    }
}
