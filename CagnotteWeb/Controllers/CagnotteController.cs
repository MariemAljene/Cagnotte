using ApplicationCore.Domain;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace CagnotteWeb.Controllers
{
    public class CagnotteController : Controller
    {
        ICagnotteService  cagnotteService; 
        IEntrepriseService entrepriseService;
        public CagnotteController(ICagnotteService cagnotteService, IEntrepriseService entrepriseService)
        {
            this.cagnotteService = cagnotteService;
            this.entrepriseService = entrepriseService;
        }

        // GET: CagnotteController
        public ActionResult Index(string? Titre)
        {
            if (Titre == null)
                return View(cagnotteService.GetAll());
            else
                return View(cagnotteService.GetMany(f => f.Titre.Equals(Titre)));
            //return View(cagnotteService.GetAll());
        }

        // GET: CagnotteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CagnotteController/Create
        public ActionResult Create()
        {
            ViewBag.entreprise = new SelectList(entrepriseService.GetAll(), "EntrepriseId", "NomEntreprise");
            return View() ;
        }

        // POST: CagnotteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cagnotte collection, IFormFile Photo)
        {
            try
            {
                if (Photo != null)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(),

                    "wwwroot", "uploads", Photo.FileName);

                    Stream stream = new FileStream(path, FileMode.Create);
                    Photo.CopyTo(stream);
                    collection.Photo = Photo.FileName;
                }
                cagnotteService.Add(collection);
                cagnotteService.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CagnotteController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CagnotteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CagnotteController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CagnotteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
