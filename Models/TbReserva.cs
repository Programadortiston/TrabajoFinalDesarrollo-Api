using System;
using System.Collections.Generic;

namespace WebApiLibreria.Models;

public partial class TbReserva
{
    public int IdPrestamo { get; set; }

    public string FecPrestamo { get; set; } = null!;

    public string FecDevolucion { get; set; } = null!;

    public int IdCli { get; set; }

    public string Estado { get; set; } = null!;

    public virtual TbCliente IdCliNavigation { get; set; } = null!;

    public virtual ICollection<TbDetalleReserva> TbDetalleReservas { get; set; } = new List<TbDetalleReserva>();
}
