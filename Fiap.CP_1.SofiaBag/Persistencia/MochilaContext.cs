using Fiap.CP_1.SofiaBag.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.CP_1.SofiaBag.Persistencia
{
    public class MochilaContext : DbContext
    {
        public DbSet<Objetos> Objetos { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public  DbSet<Lembrete> Lembretes { get; set; }

        public DbSet<Categoria> Categorias { get; set; }

        public MochilaContext(DbContextOptions op): base(op) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ObjetoCategoria>().HasKey(c => new { c.CategoriaId, c.CodigoId });

            modelBuilder.Entity<ObjetoCategoria>()
                .HasOne(o => o.Objeto)
                .WithMany(o => o.ObjetosCateg)
                .HasForeignKey(o => o.CodigoId);

            modelBuilder.Entity<ObjetoCategoria>()
                .HasOne(o => o.Categoria)
                .WithMany(c => c.ObjetosCateg)
                .HasForeignKey(c => c.CategoriaId);

            base.OnModelCreating(modelBuilder);
        }

    }
    
}
