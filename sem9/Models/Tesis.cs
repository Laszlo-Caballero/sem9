using System;
using System.Collections.Generic;

namespace sem9.Models;

public partial class Tesis
{
    public int IdTesis { get; set; }

    public int IdEstudiante { get; set; }

    public int IdAsesor { get; set; }
    public string? Titulo { get; set; }
    public string? TipoTesis { get; set; }

    public string? LineaInvestigacion { get; set; }

    public string? Objetivo { get; set; }

    public DateOnly? FechaInicio { get; set; }

    public string? Estado { get; set; }

    public virtual ICollection<AsignarEstudiante> AsignarEstudiantes { get; set; } = new List<AsignarEstudiante>();

    public virtual Asesor IdAsesorNavigation { get; set; } = null!;

    public virtual Estudiante IdEstudianteNavigation { get; set; } = null!;

    public virtual ICollection<SustentacionFinal> SustentacionFinals { get; set; } = new List<SustentacionFinal>();
}
