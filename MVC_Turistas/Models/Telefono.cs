using System;
using System.Collections.Generic;

namespace MVC_Turistas.Models;

public partial class Telefono
{
    public string NumeroTelefono { get; set; } = null!;

    public decimal? CodigoTurista { get; set; }

    public virtual Turistum? CodigoTuristaNavigation { get; set; }
}
