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

        public MochilaContext(DbContextOptions op): base(op) { }
    }
}
