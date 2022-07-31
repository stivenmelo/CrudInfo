using CrudInfotrack.Data;
using CrudInfotrack.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudInfotrack.Controllers
{
    public class MateriasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MateriasController(ApplicationDbContext context)
        {
            _context = context;
        }

        //http Get Index
        public IActionResult Index()
        {
            IEnumerable<Materia> listMaterias = _context.Materia;
            return View(listMaterias);
        }


        //http Get Create
        public IActionResult Create()
        {
            return View();
        }


        //http Post Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Materia materia)
        {
            if (ModelState.IsValid)
            {
                _context.Materia.Add(materia);
                _context.SaveChanges();

                TempData["mensaje"] = "La materia se ha creado correctamente";

                return RedirectToAction("Index");

            }
            return View();
        }

        //http Get Edit
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //Obtener la materia
            var materia = _context.Materia.Find(id);

            if (materia == null)
            {
                return NotFound();
            }


            return View(materia);
        }

        //http Post Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Materia materia)
        {
            if (ModelState.IsValid)
            {
                _context.Materia.Update(materia);
                _context.SaveChanges();

                TempData["mensaje"] = "La materia se ha actualizado correctamente";

                return RedirectToAction("Index");

            }
            return View();
        }


        //http Get Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //Obtener la materia
            var materia = _context.Materia.Find(id);

            if (materia == null)
            {
                return NotFound();
            }


            return View(materia);
        }

        //http Post Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteMateria(int? id)
        {
            //Odtener Materia por Id
            var materia = _context.Materia.Find(id);

            if (materia == null )
            {
                return NotFound();
            }
     
            _context.Materia.Remove(materia);
            _context.SaveChanges();

            TempData["mensaje"] = "La materia se ha eliminado correctamente";

            return RedirectToAction("Index");
     
        }

    } 
}
