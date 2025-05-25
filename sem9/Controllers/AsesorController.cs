using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using sem9.Data;
using sem9.Models;
using sem9.Repository.AsesorRepo;
using sem9.Repository.TesisRepository;

namespace sem9.Controllers
{
    public class AsesorController : Controller
    {
        private readonly IAsesorRepository _repository;
        private readonly ITesisRepository _tesisRepository;

        public AsesorController(IAsesorRepository repository, ITesisRepository tesisRepository)
        {
            _repository = repository;
            _tesisRepository = tesisRepository;
        }

        public async Task<IActionResult> Index()
        {
            var asesores = await _repository.ObtenerAsesor();
            return View(asesores);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var tesis = await _tesisRepository.obtenerTesis();
            ViewBag.Tesis = new SelectList(tesis as IEnumerable<Tesis>, "idTesis", "titulo");
            return View("Create");
        }

        public async Task<IActionResult> Create(Asesor asesor, int[] tesisID)
        {
            foreach (var tesisid in tesisID )
            {
                var tesis = await _tesisRepository.obtenerTesisPorId(tesisid);

                if (tesis != null)
                {
                    asesor.Tesis.Add(tesis);
                }
            }

            _repository.CrearAsesor(asesor);

            return RedirectToAction(nameof(Index));
        }

    }
}
