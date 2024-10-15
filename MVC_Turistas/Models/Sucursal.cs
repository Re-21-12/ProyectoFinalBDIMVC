using System;
using System.Collections.Generic;

namespace MVC_Turistas.Models;

public partial class Sucursal
{
    public decimal CodigoSucursal { get; set; }

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public virtual ICollection<SucursalTuristum> SucursalTurista { get; set; } = new List<SucursalTuristum>();

    public virtual ICollection<Turistum> Turista { get; set; } = new List<Turistum>();
}
