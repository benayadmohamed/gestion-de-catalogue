using gestion_de_catalogue.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gestion_de_catalogue.Service
{
    public interface IProduitService
    {
        public void Delete(int ID);
        public IEnumerable<Produit> FindAll();
        public IEnumerable<Produit> FindByDesignation(string mc);
        public Produit GetOne(int ID);
        public Produit Save(Produit p);
        public void Update(Produit p);
    }
}
