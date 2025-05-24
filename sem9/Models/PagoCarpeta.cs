using System;
using System.Collections.Generic;

namespace sem9.Models;

public partial class PagoCarpeta
{
    public int IdPago { get; set; }

    public int IdEstudiante { get; set; }

    public string? MetodoPago { get; set; }

    public DateOnly? Fecha { get; set; }

    public string? Estado { get; set; }

    public virtual Estudiante IdEstudianteNavigation { get; set; } = null!;

    public virtual ICollection<SolicitudTesis> SolicitudTesis { get; set; } = new List<SolicitudTesis>();
}
