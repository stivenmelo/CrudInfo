using CrudInfotrack.Data;
using CrudInfotrack.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudInfotrack.Controllers
{
    public class AlumnosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AlumnosController(ApplicationDbContext context)
        {
            _context = context;
        }

        //http Get Index
        public IActionResult Index()
        {
            IEnumerable<Alumno> listAlumnos = _context.Alumno;

            return View(listAlumnos);
        }

        //http Get Create
        public IActionResult Create()
        {
            return View();

        }

        //http Post Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Alumno alumno)
        {
            if (ModelState.IsValid)
            {
                _context.Alumno.Add(alumno);
                _context.SaveChanges();

                TempData["mensaje"] = "El alumno se ha creado Correctamente";

                return RedirectToAction("Index");
            }
            return View();

        }

        //http Get Edit
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            //obtener el Alumno
            var alumno = _context.Alumno.Find(id);

            if(alumno == null)
            {
                return NotFound();
            }

            return View(alumno);

        }

        //http Post Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Alumno alumno)
        {
            if (ModelState.IsValid)
            {
                _context.Alumno.Update(alumno);
                _context.SaveChanges();

                TempData["mensaje"] = "El alumno se ha actualizado Correctamente";

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

            //obtener el Alumno
            var alumno = _context.Alumno.Find(id);

            if (alumno == null)
            {
                return NotFound();
            }

            return View(alumno);

        }

        //http Post Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteAlumno(int? id )
        {
            //Obtener el Alumno por id
            var alumno = _context.Alumno.Find(id);

            if (alumno == null)
            {
                return NotFound();
            }

            _context.Alumno.Remove(alumno);
            _context.SaveChanges();

            TempData["mensaje"] = "El alumno se ha eliminado Correctamente";
            return RedirectToAction("Index");
            

        }


    }
}
