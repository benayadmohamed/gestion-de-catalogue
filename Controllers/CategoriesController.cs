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
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private ICategorieService CategorieService;

        public CategoriesController(ICategorieService categorieService)
        {
            CategorieService = categorieService;
        }

        // GET: api/Categories
        [HttpGet]
        public IEnumerable<Categorie> Get()
        {
            return CategorieService.FindAll();
        }

        // GET: api/Categories
        [HttpGet("Search")]
        public IEnumerable<Categorie> Search(String motCle)
        {
            if (motCle != null)
                return CategorieService.FindByMC(motCle);
            else
            {
                return CategorieService.FindAll();
            }
        }

        // GET: api/Categories/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Categories
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Categories/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}