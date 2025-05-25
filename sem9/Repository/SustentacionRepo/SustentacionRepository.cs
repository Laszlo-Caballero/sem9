using sem9.Data;
using Microsoft.EntityFrameworkCore;
using sem9.Models;

namespace sem9.Repository.SustentacionRepo
{
    public class SustentacionRepository : ISustentacionRepository
    {
        private readonly TesisContext _context;

        public SustentacionRepository(TesisContext context)
        {
            _context = context;
        }

        // Obtener todas las sustentaciones
        public async Task<IEnumerable<SustentacionFinal>> ObtenerTodas()
        {
            return await _context.SustentacionFinals
                                 .Include(s => s.IdTesisNavigation)
                                 .Include(s => s.AsignarJurados)
                                     .ThenInclude(aj => aj.IdJuradoNavigation)
                                 .ToListAsync();
        }

        // Obtener sustentación por ID
        public async Task<SustentacionFinal?> ObtenerPorId(int id)
        {
            return await _context.SustentacionFinals
                                 .FirstOrDefaultAsync(s => s.IdSustentacion == id);
        }
        // Crear nueva sustentación
        public async Task<SustentacionFinal> CrearSustentacion(SustentacionFinal sustentacion)
        {
            _context.SustentacionFinals.Add(sustentacion);
            await _context.SaveChangesAsync();
            return sustentacion;
        }

    }
}
