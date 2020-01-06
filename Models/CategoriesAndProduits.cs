using System.Collections.Generic;

namespace gestion_de_catalogue.Models
{
    public class CategoriesAndProduits
    {
        public IEnumerable<Produit> Produits { get; set; }
        public IEnumerable<Categorie> Categories { get; set; }
    }
}