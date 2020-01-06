using System.Collections.Generic;
using gestion_de_catalogue.Models;

namespace gestion_de_catalogue.Service
{
    public interface ICategorieService
    {
        Categorie Save(Categorie p);
        IEnumerable<Categorie> FindAll();
        IEnumerable<Categorie> FindByMC(string mc);
        Categorie GetOne(int ID);
        void Update(Categorie p);
        void Delete(int ID);
    }
}