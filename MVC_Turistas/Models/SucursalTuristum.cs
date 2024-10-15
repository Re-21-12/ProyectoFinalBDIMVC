using System;
using System.Collections.Generic;

namespace MVC_Turistas.Models;

public partial class SucursalTuristum
{
    public decimal CodigoSucursalTurista { get; set; }

    public decimal? CodigoSucursal { get; set; }

    public decimal? CodigoTurista { get; set; }

    public virtual Sucursal? CodigoSucursalNavigation { get; set; }

    public virtual Turistum? CodigoTuristaNavigation { get; set; }
}
