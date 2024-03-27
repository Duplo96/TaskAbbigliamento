using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TaskAbbigliamento.Models;

public partial class TaskAbbigliamentoContext : DbContext
{
    public TaskAbbigliamentoContext()
    {
    }

    public TaskAbbigliamentoContext(DbContextOptions<TaskAbbigliamentoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categorium> Categoria { get; set; }

    public virtual DbSet<Ordine> Ordines { get; set; }

    public virtual DbSet<Prezzo> Prezzos { get; set; }

    public virtual DbSet<Prodotto> Prodottos { get; set; }

    public virtual DbSet<Utente> Utentes { get; set; }

    public virtual DbSet<Variazione> Variaziones { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-701IT76\\SQLEXPRESS01;Database=TaskAbbigliamento;User Id=Academy;Password=Academy!;MultipleActiveResultSets=true;Encrypt=false;TrustServerCertificate=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categorium>(entity =>
        {
            entity.HasKey(e => e.CategoriaId).HasName("PK__Categori__6378C0209E4FF9CF");

            entity.Property(e => e.CategoriaId).HasColumnName("categoriaID");
            entity.Property(e => e.NomeCategoria)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("nome_categoria");
        });

        modelBuilder.Entity<Ordine>(entity =>
        {
            entity.HasKey(e => e.OrdineId).HasName("PK__Ordine__8F87D0E56708634C");

            entity.ToTable("Ordine");

            entity.HasIndex(e => e.NOrdine, "UQ__Ordine__25A4B5DE5DCB9346").IsUnique();

            entity.Property(e => e.OrdineId).HasColumnName("ordineID");
            entity.Property(e => e.DataEmissione).HasColumnName("data_emissione");
            entity.Property(e => e.IsArrivato).HasColumnName("isArrivato");
            entity.Property(e => e.NOrdine).HasColumnName("n_ordine");
            entity.Property(e => e.UtenteRif).HasColumnName("utenteRIF");

            entity.HasOne(d => d.UtenteRifNavigation).WithMany(p => p.Ordines)
                .HasForeignKey(d => d.UtenteRif)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Ordine__utenteRI__2739D489");

            entity.HasMany(d => d.VariazioneRifs).WithMany(p => p.OrdineRifs)
                .UsingEntity<Dictionary<string, object>>(
                    "VariazioneOrdine",
                    r => r.HasOne<Variazione>().WithMany()
                        .HasForeignKey("VariazioneRif")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Variazion__varia__2A164134"),
                    l => l.HasOne<Ordine>().WithMany()
                        .HasForeignKey("OrdineRif")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Variazion__ordin__2B0A656D"),
                    j =>
                    {
                        j.HasKey("OrdineRif", "VariazioneRif").HasName("PK__Variazio__FC46B00F9CEC76DA");
                        j.ToTable("Variazione_Ordine");
                        j.IndexerProperty<int>("OrdineRif").HasColumnName("ordineRIF");
                        j.IndexerProperty<int>("VariazioneRif").HasColumnName("variazioneRIF");
                    });
        });

        modelBuilder.Entity<Prezzo>(entity =>
        {
            entity.HasKey(e => e.PrezzoId).HasName("PK__Prezzo__B096F6D7E225F16E");

            entity.ToTable("Prezzo");

            entity.Property(e => e.PrezzoId).HasColumnName("prezzoID");
            entity.Property(e => e.FineSconto).HasColumnName("fine_sconto");
            entity.Property(e => e.InizioSconto).HasColumnName("inizio_sconto");
            entity.Property(e => e.PrezzoPieno)
                .HasColumnType("decimal(6, 2)")
                .HasColumnName("prezzo_pieno");
            entity.Property(e => e.PrezzoScontato)
                .HasColumnType("decimal(6, 2)")
                .HasColumnName("prezzo_scontato");
            entity.Property(e => e.VariazioneRif).HasColumnName("variazioneRIF");

            entity.HasOne(d => d.VariazioneRifNavigation).WithMany(p => p.Prezzos)
                .HasForeignKey(d => d.VariazioneRif)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Prezzo__variazio__1EA48E88");
        });

        modelBuilder.Entity<Prodotto>(entity =>
        {
            entity.HasKey(e => e.ProdottoId).HasName("PK__Prodotto__3AB659750BFCD7C7");

            entity.ToTable("Prodotto");

            entity.Property(e => e.ProdottoId).HasColumnName("prodottoID");
            entity.Property(e => e.CategoriaRif).HasColumnName("categoriaRIF");
            entity.Property(e => e.ImgDue)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("imgDue");
            entity.Property(e => e.ImgUno)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("imgUno");
            entity.Property(e => e.Marca)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("marca");
            entity.Property(e => e.Modello)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("modello");

            entity.HasOne(d => d.CategoriaRifNavigation).WithMany(p => p.Prodottos)
                .HasForeignKey(d => d.CategoriaRif)
                .HasConstraintName("FK__Prodotto__catego__18EBB532");
        });

        modelBuilder.Entity<Utente>(entity =>
        {
            entity.HasKey(e => e.UtenteId).HasName("PK__Utente__CA5C2253769E1F8C");

            entity.ToTable("Utente");

            entity.HasIndex(e => e.NomeUtente, "UQ__Utente__1C52E263E3997BE7").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Utente__AB6E616446327968").IsUnique();

            entity.Property(e => e.UtenteId).HasColumnName("utenteID");
            entity.Property(e => e.Cognome)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("cognome");
            entity.Property(e => e.Email)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Nome)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("nome");
            entity.Property(e => e.NomeUtente)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("nome_utente");
            entity.Property(e => e.Telefono)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Variazione>(entity =>
        {
            entity.HasKey(e => e.VariazioneId).HasName("PK__Variazio__54F6EA5AE0EFB512");

            entity.ToTable("Variazione");

            entity.Property(e => e.VariazioneId).HasColumnName("variazioneID");
            entity.Property(e => e.Colore)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("colore");
            entity.Property(e => e.ProdottoRif).HasColumnName("prodottoRIF");
            entity.Property(e => e.Quantita).HasColumnName("quantita");
            entity.Property(e => e.Taglia)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("taglia");

            entity.HasOne(d => d.ProdottoRifNavigation).WithMany(p => p.Variaziones)
                .HasForeignKey(d => d.ProdottoRif)
                .HasConstraintName("FK__Variazion__prodo__1BC821DD");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
