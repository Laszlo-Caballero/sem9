using System;
using System.Collections.Generic;

namespace sem9.Models;

public partial class SustentacionFinal
{
    public int IdSustentacion { get; set; }

    public int IdTesis { get; set; }

    public DateOnly? Fecha { get; set; }

    public string? Modalidad { get; set; }

    public string? Calificacion { get; set; }

    public string? Estado { get; set; }

    public virtual ICollection<AsignarJurado> AsignarJurados { get; set; } = new List<AsignarJurado>();

    public virtual Tesis IdTesisNavigation { get; set; } = null!;
}
