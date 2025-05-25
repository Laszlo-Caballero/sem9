using sem9.Models;
using System.Threading.Tasks;

namespace sem9.Repository.AsesorRepo

{
    public interface IAsesorRepository
    {
        Task<IEnumerable<Asesor>> ObtenerAsesor();
        Task<Asesor> ObtenerAsesorPorId(int id);

        Task<Asesor> CrearAsesor(Asesor asesor);

    }
}
