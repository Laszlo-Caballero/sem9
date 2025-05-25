using System;
using sem9.Models;

namespace sem9.Repository.EstudianteRepository;

public interface IEstudianteRepository
{
    Task<IEnumerable<Estudiante>> ObtenerEstudiantes();

    Task<Estudiante> ObtenerEstudiantePorId(int id);

    Task<Estudiante> CrearEstudiante(Estudiante estudiante);
}
