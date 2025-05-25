using System;
using System.Collections.Generic;

namespace sem9.Models;

public partial class Estudiante
{
    public int IdEstudiante { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Telefono { get; set; }

    public string? Email { get; set; }

    public string? Direccion { get; set; }

    public string? Carrera { get; set; }

    public virtual ICollection<AsignarEstudiante> AsignarEstudiantes { get; set; } = new List<AsignarEstudiante>();

    public virtual ICollection<PagoCarpeta> PagoCarpeta { get; set; } = new List<PagoCarpeta>();

}
