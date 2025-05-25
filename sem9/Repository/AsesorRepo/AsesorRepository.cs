using Microsoft.EntityFrameworkCore;
using sem9.Data;
using sem9.Models;

namespace sem9.Repository.AsesorRepo
{
    public class AsesorRepository : IAsesorRepository
    {
        private readonly TesisContext _context;

        public AsesorRepository(TesisContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Asesor>> ObtenerAsesor()
        {
            return await _context.Asesors.ToListAsync();
        }

        public async Task<Asesor> ObtenerAsesorPorId(int id)
        {
            return await _context.Asesors.FindAsync(id);
        }

        public async Task<Asesor> CrearAsesor(Asesor asesor)
        {
            _context.Asesors.Add(asesor);
            await _context.SaveChangesAsync();
            return asesor;
        }
    }
}
