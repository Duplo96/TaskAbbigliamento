using System;
using System.Collections.Generic;

namespace TaskAbbigliamento.Models;

public partial class Prezzo
{
    public int PrezzoId { get; set; }

    public decimal PrezzoPieno { get; set; }

    public decimal? PrezzoScontato { get; set; }

    public DateOnly? InizioSconto { get; set; }

    public DateOnly? FineSconto { get; set; }

    public int VariazioneRif { get; set; }

    public virtual Variazione VariazioneRifNavigation { get; set; } = null!;
}
