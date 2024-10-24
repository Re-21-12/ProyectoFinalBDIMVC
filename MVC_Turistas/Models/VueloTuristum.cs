using System;
using System.Collections.Generic;

namespace MVC_Turistas.Models;

public partial class VueloTuristum
{
    public decimal NumeroVueloTurista { get; set; }

    public string? Clase { get; set; }

    public decimal? NumeroVuelo { get; set; }

    public decimal? CodigoTurista { get; set; }

    public virtual Turistum? CodigoTuristaNavigation { get; set; }

    public virtual Vuelo? NumeroVueloNavigation { get; set; }
}
