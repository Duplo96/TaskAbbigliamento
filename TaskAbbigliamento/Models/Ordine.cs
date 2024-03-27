using System;
using System.Collections.Generic;

namespace TaskAbbigliamento.Models;

public partial class Ordine
{
    public int OrdineId { get; set; }

    public int NOrdine { get; set; }

    public DateOnly DataEmissione { get; set; }

    public bool IsArrivato { get; set; }

    public int UtenteRif { get; set; }

    public virtual Utente UtenteRifNavigation { get; set; } = null!;

    public virtual ICollection<Variazione> VariazioneRifs { get; set; } = new List<Variazione>();
}
