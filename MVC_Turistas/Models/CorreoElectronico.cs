using System;
using System.Collections.Generic;

namespace MVC_Turistas.Models;

public partial class CorreoElectronico
{
    public string CorreoElectronico1 { get; set; } = null!;

    public decimal? CodigoTurista { get; set; }

    public virtual Turistum? CodigoTuristaNavigation { get; set; }
}
