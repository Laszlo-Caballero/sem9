using System;
using System.Collections.Generic;

namespace sem9.Models;

public partial class AsignarEstudiante
{
    public int IdAsignacion { get; set; }

    public int IdTesis { get; set; }

    public int IdEstudiante { get; set; }

    public virtual Estudiante IdEstudianteNavigation { get; set; } = null!;

    public virtual Tesis IdTesisNavigation { get; set; } = null!;
}
