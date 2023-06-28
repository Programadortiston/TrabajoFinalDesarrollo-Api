using System;
using System.Collections.Generic;

namespace WebApiLibreria.Models;

public partial class TbDetalleReserva
{
    public int IdDetalle { get; set; }

    public int IdLibro { get; set; }

    public int IdPrestamo { get; set; }

    public string FecPrestamo { get; set; } = null!;

    public string FecDevolucion { get; set; } = null!;

    public int Cantidad { get; set; }

    public virtual TbLibro IdLibroNavigation { get; set; } = null!;

    public virtual TbReserva IdPrestamoNavigation { get; set; } = null!;
}
