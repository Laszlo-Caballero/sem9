using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using sem9.Data;
using sem9.Models;
using sem9.Repository.TesisRepository;

namespace sem9.Controllers
{
    public class TesisController : Controller
    {
        private readonly ITesisRepository tesisRepository;

        public TesisController(ITesisRepository _tesisRepository)
        {
            tesisRepository = _tesisRepository;
        }


        // GET: TesisController
        public async Task<ActionResult> Index()
        {
            var tesis = await tesisRepository.obtenerTesis();
            return View(tesis);
        }


        [HttpGet]
        public async Task<ActionResult> Create()
        {
            var estudiantes = tesisRepository.obtenerEstudiantes();
            var asesores = await tesisRepository.obtenerAsesores();

            ViewBag.Estudiantes = new SelectList(estudiantes, "IdEstudiante", "Nombre");
            ViewBag.Asesores = new SelectList(asesores, "IdAsesor", "Nombre");

            return View("Crear");
        }


        [HttpPost]
        public async Task<ActionResult> Create(Tesis tesis, int[] idEstudiante, int[] idAsesor)
        {
            foreach (var id in idEstudiante)
            {
                var tesisEstudiant = await tesisRepository.tesisAsignada(id);

                if (tesisEstudiant)
                {

                    var estudiantes = tesisRepository.obtenerEstudiantes();
                    var asesores = await tesisRepository.obtenerAsesores();

                    ViewBag.Estudiantes = new SelectList(estudiantes, "IdEstudiante", "Nombre");
                    ViewBag.Asesores = new SelectList(asesores, "IdAsesor", "Nombre");
                    ViewBag.Error = "El estudiante ya tiene una tesis activa.";


                    return View("Crear", tesis);
                }
            }

            foreach (var id in idAsesor)
            {
                var asesor = await tesisRepository.obtenerAsesorPorId(id);
                if (asesor != null)
                {
                    tesis.IdAsesorNavigation = asesor;
                }
            }

            await tesisRepository.crearTesis(tesis);


            foreach (var id in idEstudiante)
            {
                var asignacion = new AsignarEstudiante
                {
                    IdTesis = tesis.IdTesis,
                    IdEstudiante = id
                };
                await tesisRepository.asignarEstudiante(asignacion);
            }

            return RedirectToAction(nameof(Index));
        }


        [HttpPut]
        public async Task<ActionResult> UpdateState(int id)
        {
            var findTesis = await tesisRepository.obtenerTesisPorId(id);

            if (findTesis == null)
            {
                return Json(new { status = false, message = "No se encontro la tesis" });
            }

            if (findTesis.Estado == "Inactivo")
            {
                findTesis.Estado = "Activo";
            }
            else
            {
                findTesis.Estado = "Inactivo";
            }

            await tesisRepository.actualizarTesis(findTesis);

            var tesis = await tesisRepository.obtenerTesis();


            return PartialView("_table", tesis);
        }

    }
}
