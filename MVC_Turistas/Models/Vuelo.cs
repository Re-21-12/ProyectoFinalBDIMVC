using System;
using System.Collections.Generic;

namespace MVC_Turistas.Models;

public partial class Vuelo
{
    public decimal NumeroVuelo { get; set; }

    public DateTime? Fecha { get; set; }

    public DateTime? Hora { get; set; }

    public string? Origen { get; set; }

    public string? Destino { get; set; }

    public decimal? PlazaTotales { get; set; }

    public decimal? PlazaTuristaDisponible { get; set; }

    public virtual ICollection<Turistum> Turista { get; set; } = new List<Turistum>();

    public virtual ICollection<VueloTuristum> VueloTurista { get; set; } = new List<VueloTuristum>();
}
