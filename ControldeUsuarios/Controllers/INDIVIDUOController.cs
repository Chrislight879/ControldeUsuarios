using ControldeUsuarios.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Prueba.Controllers
{
    public class INDIVIDUO3Controller : Controller
    {

        private INDIVIDUO3Entities context = new INDIVIDUO3Entities();
        // GET: INDIVIDUO3
        [Route("")]
        [Route("INDIVIDUO3/Index")]
        public ActionResult Index()
        {
            return View(context.INDIVIDUO3.ToList());
        }

        // GET: INDIVIDUO3/IndexFiltered?searchTerm=term&searchType=type
        [Route("INDIVIDUO3/IndexFiltered")]
        public JsonResult IndexFiltered(string searchTerm, string searchType)
        {
            var individuos = context.INDIVIDUO3.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                switch (searchType)
                {
                    case "Nombre":
                        individuos = individuos.Where(i => i.Nombre.Contains(searchTerm));
                        break;
                    case "Apellido":
                        individuos = individuos.Where(i => i.Apellido.Contains(searchTerm));
                        break;
                    case "Edad":
                        if (int.TryParse(searchTerm, out int edad))
                        {
                            individuos = individuos.Where(i => i.Edad == edad);
                        }
                        break;
                    case "Correo":
                        individuos = individuos.Where(i => i.Correo.Contains(searchTerm));
                        break;
                    default:
                        break;
                }
            }

            // Convertimos a lista y a JSON
            var result = individuos.ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // GET: INDIVIDUO3/Details/5
        public ActionResult Details(int id)
        {
            var individuo = context.INDIVIDUO3.Find(id);
            if (individuo == null)
            {
                return HttpNotFound();
            }
            return View(individuo);
        }

        // GET: INDIVIDUO3/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: INDIVIDUO3/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(INDIVIDUO3 model)
        {
            if (ModelState.IsValid)
            {
                context.INDIVIDUO3.Add(model);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: INDIVIDUO3/Edit/5
        public ActionResult Edit(int id)
        {
            var individuo = context.INDIVIDUO3.Find(id);
            if (individuo == null)
            {
                return HttpNotFound();
            }
            return View(individuo);
        }

        // POST: INDIVIDUO3/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, INDIVIDUO3 model)
        {
            if (ModelState.IsValid)
            {
                var existingIndividuo = context.INDIVIDUO3.Find(id);
                if (existingIndividuo == null)
                {
                    return HttpNotFound();
                }

                // Actualizar los valores
                existingIndividuo = model;
                // Actualizar otras propiedades si es necesario

                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: INDIVIDUO3/Delete/5
        public ActionResult Delete(int id)
        {
            var individuo = context.INDIVIDUO3.Find(id);
            if (individuo == null)
            {
                return HttpNotFound();
            }
            return View(individuo);
        }

        // POST: INDIVIDUO3/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var individuo = context.INDIVIDUO3.Find(id);
            if (individuo == null)
            {
                return HttpNotFound();
            }

            context.INDIVIDUO3.Remove(individuo);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
