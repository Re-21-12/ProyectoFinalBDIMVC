using System;
using System.Collections.Generic;

namespace MVC_Turistas.Models;

public partial class HotelTuristum
{
    public decimal CodigoHotelTurista { get; set; }

    public decimal? CodigoHotel { get; set; }

    public decimal? CodigoTurista { get; set; }

    public string? Regimen { get; set; }

    public DateTime? FechaLlegada { get; set; }

    public DateTime? FechaPartida { get; set; }

    public virtual Hotel? CodigoHotelNavigation { get; set; }

    public virtual Turistum? CodigoTuristaNavigation { get; set; }
}
