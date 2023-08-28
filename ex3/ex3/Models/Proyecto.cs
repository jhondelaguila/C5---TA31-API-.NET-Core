using System;
using System.Collections.Generic;

namespace ex3.Models;

public partial class Proyecto
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public int? Horas { get; set; }

    public virtual ICollection<Cientifico> Cientificos { get; set; } = new List<Cientifico>();
}
