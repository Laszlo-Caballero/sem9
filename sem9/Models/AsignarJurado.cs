using System;
using System.Collections.Generic;

namespace sem9.Models;

public partial class AsignarJurado
{
    public int IdAsignacion { get; set; }

    public int IdSustentacion { get; set; }

    public int IdJurado { get; set; }

    public virtual Jurado IdJuradoNavigation { get; set; } = null!;

    public virtual SustentacionFinal IdSustentacionNavigation { get; set; } = null!;
}
