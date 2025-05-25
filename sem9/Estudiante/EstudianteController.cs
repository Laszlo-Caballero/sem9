using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sem9.Data;
using sem9.Models;

namespace sem9.Controllers
{
    public class EstudianteController : Controller
    {
        private readonly TesisContext _context;

        public EstudianteController(TesisContext context)
        {
            _context = context;
        }

        // Mostrar lista de estudiantes
        public IActionResult Index()
        {
            var estudiantes = _context.Estudiantes.ToList();
            return View(estudiantes);
        }

        // Formulario para crear nuevo estudiante
        public IActionResult Create()
        {
            return View("EstudianteForm", new Estudiante());
        }

        // Guardar nuevo estudiante
        [HttpPost]
        public IActionResult Create(Estudiante estudiante)
        {
            if (ModelState.IsValid)
            {
                _context.Estudiantes.Add(estudiante);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View("EstudianteForm", estudiante);
        }

        // Formulario para editar estudiante
        public IActionResult Edit(int id)
        {
            var estudiante = _context.Estudiantes.Find(id);
            if (estudiante == null)
            {
                return NotFound();
            }
            return View("EstudianteForm", estudiante);
        }

        // Guardar edición
        [HttpPost]
        public IActionResult Edit(Estudiante estudiante)
        {
            if (ModelState.IsValid)
            {
                _context.Update(estudiante);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View("EstudianteForm", estudiante);
        }

        // Ver detalles de un estudiante
        public IActionResult Details(int id)
        {
            var estudiante = _context.Estudiantes.FirstOrDefault(e => e.IdEstudiante == id);
            if (estudiante == null)
            {
                return NotFound();
            }
            return View(estudiante);
        }

        // Confirmación para eliminar estudiante
        public IActionResult Delete(int id)
        {
            var estudiante = _context.Estudiantes.Find(id);
            if (estudiante == null)
            {
                return NotFound();
            }
            return View(estudiante);
        }

        // Eliminar estudiante (confirmado)
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var estudiante = _context.Estudiantes.Find(id);
            if (estudiante != null)
            {
                _context.Estudiantes.Remove(estudiante);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
