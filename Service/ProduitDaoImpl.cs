using gestion_de_catalogue.Data;
using gestion_de_catalogue.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace gestion_de_catalogue.Service
{
    public class ProduitDaoImpl : IProduitService
    {
        public MyDbContext DbContext { get; set; }

        public ProduitDaoImpl(MyDbContext dbContext)
        {
            this.DbContext = dbContext;
            // Save(new Produit {Designation = "HP650", Prix = 870});
            // Save(new Produit {Designation = "XXXX", Prix = 54});
        }

        public void Delete(int ID)
        {
            Produit produit = DbContext.Produit.FirstOrDefault(p => p.ProduitId == ID);
            DbContext.Produit.Remove(produit);
            DbContext.SaveChanges();
        }

        public IEnumerable<Produit> FindAll()
        {
            return DbContext.Produit.Include(p => p.Categorie);
        }

        public IEnumerable<Produit> FindByDesignation(string mc)
        {
            return DbContext.Produit.Include(p => p.Categorie)
                .Where(p =>
                    p.Designation.Contains(mc));
        }

        public Produit GetOne(int ID)
        {
            return DbContext.Produit.FirstOrDefault(p => p.ProduitId == ID);
        }

        public Produit Save(Produit p)
        {
            DbContext.Produit.Add(p);
            DbContext.SaveChanges();
            return p;
        }

        public void Update(Produit p)
        {
            DbContext.Produit.Update(p);
            DbContext.SaveChanges();
        }
    }
}