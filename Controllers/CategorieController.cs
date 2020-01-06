using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gestion_de_catalogue.Models;
using gestion_de_catalogue.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace gestion_de_catalogue.Controllers
{
    public class CategorieController : Controller
    {
        private ICategorieService CategorieService;

        public CategorieController(ICategorieService categorieService)
        {
            CategorieService = categorieService;
        }

        // GET: Categorie
        public ActionResult Index()
        {
            IEnumerable<Categorie> categories = CategorieService.FindAll();
            return View(categories);
        }

        // GET: Categorie/Create
        public ActionResult Create()
        {
            Categorie categorie = new Categorie();
            return View(categorie);
        }

        // POST: Categorie/Create
        [HttpPost]
        // [ValidateAntiForgeryToken]
        public ActionResult Create(Categorie categorie)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Categorie p = CategorieService.Save(categorie);
                    return RedirectToAction("Index");
                }

                return View("Create", categorie);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Create", categorie);
            }
        }

        // GET: Categorie/Edit/5
        public ActionResult Edit(int id)
        {
            Categorie categorie = CategorieService.GetOne(id);
            return View(categorie);
        }

        // POST: Categorie/Edit/5
        [HttpPost]
        // [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Categorie categorie)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CategorieService.Update(categorie);
                    return RedirectToAction("Index");
                }

                return View("Edit", categorie);
            }
            catch
            {
                return View("Edit", categorie);
            }
        }

        // GET: Categorie/Delete/5
        public ActionResult Delete(int id)
        {
            CategorieService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}