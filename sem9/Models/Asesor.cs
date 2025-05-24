using System;
using System.Collections.Generic;

namespace sem9.Models;

public partial class Asesor
{
    public int IdAsesor { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Telefono { get; set; }

    public string? Email { get; set; }

    public string? Carrera { get; set; }

    public virtual ICollection<AsignarAsesor> AsignarAsesors { get; set; } = new List<AsignarAsesor>();
}
