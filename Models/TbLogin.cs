using System;
using System.Collections.Generic;

namespace WebApiLibreria.Models;

public partial class TbLogin
{
    public string Usuario { get; set; } = null!;

    public string Contra { get; set; } = null!;
}
