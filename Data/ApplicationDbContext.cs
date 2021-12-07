using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Web.Models;

namespace Web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AutorModel>()
                .HasKey(f => f.Id);

            modelBuilder.Entity<LivroModel>()
                .HasKey(f => f.Id);

            modelBuilder.Entity<ReservaModel>()
                .HasKey(f => f.Id);

            modelBuilder.Entity<LivroModel>()
                .HasOne(f => f.Autor)
                .WithMany(f => f.Livros)
                .HasForeignKey(f=>f.AutorId);

            modelBuilder.Entity<ReservaModel>()
                .HasOne(f => f.Livro)
                .WithOne(f => f.Reserva)
                .HasForeignKey<ReservaModel>(f => f.LivroId);
        }

        public DbSet<Web.Models.AutorModel> AutorModel { get; set; }

        public DbSet<Web.Models.LivroModel> LivroModel { get; set; }

        public DbSet<Web.Models.ReservaModel> ReservaModel { get; set; }
    }
}
