using System.Collections.Generic;
using System.Linq;
using gestion_de_catalogue.Data;
using gestion_de_catalogue.Models;

namespace gestion_de_catalogue.Service
{
    public class CategorieDaoImpl : ICategorieService
    {
        public MyDbContext DbContext { get; set; }

        public CategorieDaoImpl(MyDbContext dbContext)
        {
            this.DbContext = dbContext;
            // Save(new Categorie {NomCategorie = "cat1"});
            // Save(new Categorie {NomCategorie = "cat2"});
            // Save(new Categorie {NomCategorie = "cat3"});
            // Save(new Categorie {NomCategorie = "cat4"});
        }

        public void Delete(int ID)
        {
            Categorie cat = DbContext.Categorie.Single(c => c.CategorieID == ID);
            DbContext.Categorie.Remove(cat);
            DbContext.SaveChanges();
        }

        public IEnumerable<Categorie> FindAll()
        {
            return DbContext.Categorie.ToList();
        }

        public Categorie GetOne(int ID)
        {
            return DbContext.Categorie.Single(c => c.CategorieID == ID);
        }

        public Categorie Save(Categorie c)
        {
            DbContext.Categorie.Add(c);
            DbContext.SaveChanges();
            return c;
        }

        public void Update(Categorie c)
        {
            DbContext.Categorie.Update(c);
            DbContext.SaveChanges();
        }

        public IEnumerable<Categorie> FindByMC(string mc)
        {
            return DbContext.Categorie.ToList().Where(c => c.NomCategorie.Contains(mc));
        }
    }
}