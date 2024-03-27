using System;
using System.Collections.Generic;

namespace TaskAbbigliamento.Models;

public partial class Variazione
{
    public int VariazioneId { get; set; }

    public string Colore { get; set; } = null!;

    public string Taglia { get; set; } = null!;

    public int Quantita { get; set; }

    public int ProdottoRif { get; set; }

    public virtual ICollection<Prezzo> Prezzos { get; set; } = new List<Prezzo>();

    public virtual Prodotto ProdottoRifNavigation { get; set; } = null!;

    public virtual ICollection<Ordine> OrdineRifs { get; set; } = new List<Ordine>();
}
