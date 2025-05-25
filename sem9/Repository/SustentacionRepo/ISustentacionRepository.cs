using sem9.Models;

namespace sem9.Repository.SustentacionRepo
{
    public interface ISustentacionRepository
    {
        // Obtener todas las sustentaciones
        Task<IEnumerable<SustentacionFinal>> ObtenerTodas();

        // Obtener sustentación por ID
        Task<SustentacionFinal?> ObtenerPorId(int id);

        // Crear nueva sustentación
        Task<SustentacionFinal> CrearSustentacion(SustentacionFinal sustentacion);
    }
}
