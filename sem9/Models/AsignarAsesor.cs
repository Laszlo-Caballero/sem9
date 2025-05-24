using System;
using System.Collections.Generic;

namespace sem9.Models;

public partial class AsignarAsesor
{
    public int IdAsignar { get; set; }

    public int IdTesis { get; set; }

    public int IdAsesor { get; set; }

    public virtual Asesor IdAsesorNavigation { get; set; } = null!;

    public virtual Tesis IdTesisNavigation { get; set; } = null!;
}
