using gestion_de_catalogue.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gestion_de_catalogue.Data
{
    public class MyDbContext : DbContext
    {
        public DbSet<Produit> Produit{get;set;}
        public DbSet<Categorie> Categorie { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=localhost;Database=ef;User=root;Password=");
        }
    }
}