using System;
using System.Collections.Generic;

namespace TaskAbbigliamento.Models;

public partial class Categorium
{
    public int CategoriaId { get; set; }

    public string? NomeCategoria { get; set; }

    public virtual ICollection<Prodotto> Prodottos { get; set; } = new List<Prodotto>();
}
