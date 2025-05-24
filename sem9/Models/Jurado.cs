using System;
using System.Collections.Generic;

namespace sem9.Models;

public partial class Jurado
{
    public int IdJurado { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Telefono { get; set; }

    public string? Email { get; set; }

    public string? Carrera { get; set; }

    public virtual ICollection<AsignarJurado> AsignarJurados { get; set; } = new List<AsignarJurado>();
}
