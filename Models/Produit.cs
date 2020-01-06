using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace gestion_de_catalogue.Models
{
    [Table("PRODUITS")]
    public class Produit
    {
        [Key] [Display(Name = "Produit ID")] public int ProduitId { get; set; }


        [Required, MinLength(6), MaxLength(25)]
        public string Designation { get; set; }

        [Required, Range(100, 1000000)] public double Prix { get; set; }

        public int CategorieID { get; set; }
        [ForeignKey("CategorieID")] public virtual Categorie Categorie { get; set; }
    }
}