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
        return await _context.Tesis.ToListAsync();
    }

    public async Task<Tesis> obtenerTesisPorId(int id)
    {
        return await _context.Tesis.FindAsync(id);
    }

    public async Task<Tesis> crearTesis(Tesis tesis)
    {
        _context.Tesis.Add(tesis);
        await _context.SaveChangesAsync();
        return tesis;
    }
}
