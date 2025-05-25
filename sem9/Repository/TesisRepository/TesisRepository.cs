using System;
using Microsoft.EntityFrameworkCore;
using sem9.Data;
using sem9.Models;

namespace sem9.Repository.TesisRepository;

public class TesisRepository : ITesisRepository
{
    private readonly TesisContext _context;

    public TesisRepository(TesisContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Tesis>> obtenerTesis()
    {
        return await _context.Tesis.Include(t => t.AsignarEstudiantes).ThenInclude(a => a.IdEstudianteNavigation).ToListAsync();
    }

    public async Task<Tesis> obtenerTesisPorId(int id)
    {
        return await _context.Tesis.Include(t => t.AsignarEstudiantes).ThenInclude(a => a.IdEstudianteNavigation).FirstOrDefaultAsync(t => t.IdTesis == id);
    }

    public async Task<Tesis> crearTesis(Tesis tesis)
    {
        _context.Tesis.Add(tesis);
        await _context.SaveChangesAsync();
        return tesis;
    }

    public async Task<Tesis> actualizarTesis(Tesis tesis)
    {
        _context.Tesis.Update(tesis);
        await _context.SaveChangesAsync();
        return tesis;
    }

    public IEnumerable<Estudiante> obtenerEstudiantes()
    {
        var estudiantes = _context.Estudiantes;

        return estudiantes;
    }

    public async Task<IEnumerable<Asesor>> obtenerAsesores()
    {
        return await _context.Asesors.ToListAsync();
    }

    public async Task<Estudiante> obtenerEstudiantePorId(int id)
    {
        return await _context.Estudiantes.FindAsync(id);
    }

    public async Task<Asesor> obtenerAsesorPorId(int id)
    {
        return await _context.Asesors.FindAsync(id);
    }


    public async Task<bool> tesisAsignada(int estudianteId)
    {
        var tesis = await _context.AsignarEstudiantes
            .FirstOrDefaultAsync(ae => ae.IdEstudiante == estudianteId && ae.IdTesisNavigation.Estado == "Activo");


        return tesis != null;
    }

    public async Task asignarEstudiante(AsignarEstudiante asignacion)
    {
        _context.AsignarEstudiantes.Add(asignacion);
        await _context.SaveChangesAsync();
    }
}
