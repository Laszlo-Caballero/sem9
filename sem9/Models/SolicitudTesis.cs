using System;
using System.Collections.Generic;

namespace sem9.Models;

public partial class SolicitudTesis
{
    public int IdSolicitud { get; set; }

    public int IdPago { get; set; }

    public DateOnly? Fecha { get; set; }

    public string? Estado { get; set; }

    public virtual PagoCarpeta IdPagoNavigation { get; set; } = null!;
}
