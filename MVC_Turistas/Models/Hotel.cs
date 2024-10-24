using System;
using System.Collections.Generic;

namespace MVC_Turistas.Models;

public partial class Hotel
{
    public decimal CodigoHotel { get; set; }

    public string? Nombre { get; set; }

    public string? Direccion { get; set; }

    public string? Ciudad { get; set; }

    public string? Telefono { get; set; }

    public decimal? NumeroPlazasDisponibles { get; set; }

    public virtual ICollection<HotelTuristum> HotelTurista { get; set; } = new List<HotelTuristum>();
}
