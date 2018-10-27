using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using OperasWebSites.Models;


namespace OperasWebSites.Controllers
{
    public class OperaController : Controller
    {
        private OperasDB context = new OperasDB();

        // GET: Opera
        public ActionResult Index()
        {
            return View("Index", context.Operas.ToList());
        }

        //GET: An Opera
        public ActionResult Details(int id)
        {

            Opera opera = context.Operas.Find(id);
            if (opera == null)
            {
                return HttpNotFound();
            }

            return View("Details", opera);
        }

        //GET
        public ActionResult Create()
        {
            Opera newOpera = new Opera();
            ViewBag.TitleCreate = "Crear una nueva opera.";
            return View("Create", newOpera);
        }

        [HttpPost]
        public ActionResult Create(Opera newOpera)
        {
            if (ModelState.IsValid)
            {
                context.Operas.Add(newOpera);

                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("Create", newOpera);
            }            
        }

        public ActionResult Delete(int id)
        {
            Opera operaToDelete = context.Operas.Find(id);

            if(operaToDelete == null)
            {
                return HttpNotFound();
            }

            context.Operas.Remove(operaToDelete);

            context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}