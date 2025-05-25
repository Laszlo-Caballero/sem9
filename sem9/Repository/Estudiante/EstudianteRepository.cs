using System;
using Microsoft.EntityFrameworkCore;
using sem9.Data;
using sem9.Models;

namespace sem9.Repository.EstudianteRepository;

public class EstudianteRepository : IEstudianteRepository
{
    private readonly TesisContext _context;

    public EstudianteRepository(TesisContext context)
    {
        _context = context;
    }


    public async Task<IEnumerable<Estudiante>> ObtenerEstudiantes()
    {
        return await _context.Estudiantes.ToListAsync();
    }

    public async Task<Estudiante> ObtenerEstudiantePorId(int id)
    {
        return await _context.Estudiantes.FindAsync(id);
    }

    public async Task<Estudiante> CrearEstudiante(Estudiante estudiante)
    {
        _context.Estudiantes.Add(estudiante);
        await _context.SaveChangesAsync();
        return estudiante;
    }
}
