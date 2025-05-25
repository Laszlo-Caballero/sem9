using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using sem9.Data;
using sem9.Models;
using sem9.Repository.SustentacionRepo;

namespace sem9.Controllers
{
    public class SustentacionController : Controller
    {
        private readonly ISustentacionRepository _sustentacionRepository;
        private readonly TesisContext _context; 

        public SustentacionController(ISustentacionRepository sustentacionRepository, TesisContext context)
        {
            _sustentacionRepository = sustentacionRepository;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var sustentaciones = await _sustentacionRepository.ObtenerTodas();
            return View(sustentaciones);
        }
        public IActionResult Create()
        {
            ViewBag.TesisId = new SelectList(_context.Tesis, "IdTesis", "Titulo");
            ViewBag.Jurados = new SelectList(_context.Jurados, "IdJurado", "Nombre");
            return View();
        }
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SustentacionFinal sustentacion)
        {
          
                // Añadimos los jurados seleccionados a la colección AsignarJurados
                foreach (var juradoId in sustentacion.SelectedJurados)
                {
                    sustentacion.AsignarJurados.Add(new AsignarJurado
                    {
                        IdJurado = juradoId,
                    });
                }

                await _sustentacionRepository.CrearSustentacion(sustentacion);
                TempData["SuccessMessage"] = "Sustentación creada exitosamente.";
                return RedirectToAction(nameof(Index));
        }

    }
}