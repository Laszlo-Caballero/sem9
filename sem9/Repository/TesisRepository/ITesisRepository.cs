using System;
using sem9.Models;

namespace sem9.Repository.TesisRepository;

public interface ITesisRepository
{
    Task<IEnumerable<Tesis>> obtenerTesis();
    Task<Tesis> obtenerTesisPorId(int id);
    Task<Tesis> crearTesis(Tesis tesis);
}
