using System;
using System.Collections.Generic;

namespace MVC_Turistas.Models;

public partial class Turistum
{
    public decimal CodigoTurista { get; set; }

    public string? NombreUno { get; set; }

    public string? NombreDos { get; set; }

    public string? NombreTres { get; set; }

    public string? ApellidoUno { get; set; }

    public string? ApellidoDos { get; set; }

    public string? Direccion { get; set; }

    public string? PaisResidencia { get; set; }

    public decimal? NumeroVuelo { get; set; }

    public decimal? CodigoSucursal { get; set; }

    public virtual Sucursal? CodigoSucursalNavigation { get; set; }

    public virtual ICollection<CorreoElectronico> CorreoElectronicos { get; set; } = new List<CorreoElectronico>();

    public virtual ICollection<HotelTuristum> HotelTurista { get; set; } = new List<HotelTuristum>();

    public virtual Vuelo? NumeroVueloNavigation { get; set; }

    public virtual ICollection<SucursalTuristum> SucursalTurista { get; set; } = new List<SucursalTuristum>();

    public virtual ICollection<Telefono> Telefonos { get; set; } = new List<Telefono>();

    public virtual ICollection<VueloTuristum> VueloTurista { get; set; } = new List<VueloTuristum>();
}
