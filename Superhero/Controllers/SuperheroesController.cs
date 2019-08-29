using SuperheroProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperheroProject.Controllers
{
    public class SuperheroesController : Controller
    {
        ApplicationDbContext context;
        public SuperheroesController()
        {
            context = new ApplicationDbContext();
        }
        // GET: Superheroes
        public ActionResult Index()
        {
            return View();
        }

        // GET: Superheroes/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Superheroes/Create
        public ActionResult Create()
        {
            Models.Superhero superhero = new Models.Superhero();
            return View(superhero);
        }

        // POST: Superheroes/Create
        [HttpPost]
        public ActionResult Create(Superhero superhero)
        {
            try
            {
                // TODO: Add insert logic here
                context.Superheroes.Add(superhero);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Superheroes/Edit/5
        public ActionResult Edit(int id)
        {
            Superhero superheroToEdit = context.Superheroes.Find(id);
            superheroToEdit.name = NewName;
            superheroToEdit.alterEgo = newAlterEgo;
            superheroToEdit.primarySuperheroAbility = newPrimarySuperheroAbility;
            superheroToEdit.secondarySuperheroAbility = newSecondarySuperheroAbility;
            superheroToEdit.catchphrase = newCatchPhrase;
            context.SaveChanges();
            return View(superheroToEdit);
        }

        // POST: Superheroes/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Superhero superhero) //one parameter?
        {
            try
            {
                // TODO: Add update logic here
                Superhero superheroToEdit = context.Superheroes.FirstOrDefault(s => s.Id == id);
                superheroToEdit.name = newName;
                superheroToEdit.alterEgo = newAlterEgo;
                superheroToEdit.primarySuperheroAbility = newPrimarySuperheroAbility;
                superheroToEdit.secondarySuperheroAbility = newSecondarySuperheroAbility;
                superheroToEdit.catchphrase = newCatchPhrase;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Superheroes/Delete/5
        public ActionResult Delete(int id)
        {
            Superhero superheroToDelete = context.Superheroes.Find(id);
            return View(superheroToDelete);
        }

        // POST: Superheroes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Superhero superhero) //only one parameter?
        {
            try
            {
                // TODO: Add delete logic here
                Superhero superheroToDelete = context.Superheroes.Find(id);
                context.Superheroes.Remove(superheroToDelete);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
