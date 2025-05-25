using System;
using sem9.Models;

namespace sem9.Repository.TesisRepository;

public interface ITesisRepository
{
    Task<IEnumerable<Tesis>> obtenerTesis();
    Task<Tesis> obtenerTesisPorId(int id);
    Task<Tesis> crearTesis(Tesis tesis);

    Task<Tesis> actualizarTesis(Tesis tesis);

    IEnumerable<Estudiante> obtenerEstudiantes();
    Task<IEnumerable<Asesor>> obtenerAsesores();

    Task<Estudiante> obtenerEstudiantePorId(int id);

    Task<Asesor> obtenerAsesorPorId(int id);

    Task<bool> tesisAsignada(int estudianteId);
    Task asignarEstudiante(AsignarEstudiante asignacion);
}
