using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestion_de_catalogue.Models
{
    [Table("CATEGORIES")]
    public class Categorie
    {
        [Key] public int CategorieID { get; set; }

        [Required, MinLength(3)]
        [StringLength(35)]
        public string NomCategorie { get; set; }

        public virtual ICollection<Produit> Produits { get; set; }
    }
}