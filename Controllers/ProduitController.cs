using System.Collections.Generic;
using System.Linq;
using gestion_de_catalogue.Models;
using gestion_de_catalogue.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace gestion_de_catalogue.Controllers
{
    public class ProduitController : Controller
    {
        public IProduitService ProduitService { get; set; }

        public ICategorieService CategorieService { get; set; }
        // public ILogger<ProduitController> logger { get; set; }

        public ProduitController(IProduitService produitService, ICategorieService categorieService)
        {
            ProduitService = produitService;
            CategorieService = categorieService;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            IEnumerable<Produit> produits = ProduitService.FindAll();
            ViewBag.listcategories = CategorieService.FindAll();
            return View("list", produits);
        }

        public IActionResult SelectCat(string motCle, int categorieID)
        {
            IEnumerable<Produit> allProds;
            ViewBag.listcategories = CategorieService.FindAll();
            ViewBag.motCle = motCle;
            if (motCle == null)
            {
                allProds = ProduitService.FindAll()
                    .Where(produit => produit.CategorieID == categorieID);
                ViewBag.categorieID = categorieID;
                return View("list", allProds);
            }

            allProds = ProduitService.FindByDesignation(motCle)
                .Where(produit => produit.CategorieID == categorieID);
            ViewBag.categorieID = categorieID;

            return View("list", allProds);
        }

        public IActionResult Chercher(string motCle)
        {
            if (motCle == null)
            {
                ModelState.AddModelError("motCle", "ne doit pas être nul");
            }

            ViewBag.listcategories = CategorieService.FindAll();

            if (ModelState.IsValid)
            {
                IEnumerable<Produit> prods = ProduitService.FindByDesignation(motCle);
                ViewBag.motCle = motCle;
                return View("list", prods);
            }

            IEnumerable<Produit> allProds = ProduitService.FindAll();
            return View("list", allProds);
        }

        public IActionResult FormProduit()
        {
            IEnumerable<Categorie> categories = CategorieService.FindAll();
            ViewBag.listcategories = categories;
            Produit produit = new Produit();
            return View(produit);
        }

        public IActionResult Save(Produit produit)
        {
            if (ModelState.IsValid)
            {
                Produit p = ProduitService.Save(produit);
                return RedirectToAction("Index");
            }

            ViewBag.listcategories = CategorieService.FindAll();
            return View("FormProduit", produit);
        }

        public IActionResult Edit(int Id)
        {
            IEnumerable<Categorie> categories = CategorieService.FindAll();
            ViewBag.listcategories = categories;
            Produit p = ProduitService.GetOne(Id);
            return View(p);
        }

        // public IActionResult Update(Produit produit)
        // {
        //     if (ModelState.IsValid)
        //     {
        //         ProduitService.Update(produit);
        //         return RedirectToAction("Index");
        //     }
        //
        //     ViewBag.listcategories = CategorieService.FindAll();
        //     return View("Edit", produit);
        // }

        public IActionResult Delete(int id)
        {
            ProduitService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}