using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WSSeries.Models.EntityFramework;

[Table("serie")]
public partial class Serie
{
    [Key]
    [Column("serieid")]
    public int Serieid { get; set; }

    [Column("titre")]
    [StringLength(100)]
    public string Titre { get; set; } = null!;

    [Column("resume")]
    public string? Resume { get; set; }

    [Column("nbsaisons")]
    public int? Nbsaisons { get; set; }

    [Column("nbepisodes")]
    public int? Nbepisodes { get; set; }

    [Column("anneecreation")]
    public int? Anneecreation { get; set; }

    [Column("network")]
    [StringLength(50)]
    public string? Network { get; set; }

    public override bool Equals(object? obj)
    {
        return obj is Serie serie &&
               this.Serieid == serie.Serieid &&
               this.Titre == serie.Titre &&
               this.Resume == serie.Resume &&
               this.Nbsaisons == serie.Nbsaisons &&
               this.Nbepisodes == serie.Nbepisodes &&
               this.Anneecreation == serie.Anneecreation &&
               this.Network == serie.Network;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(this.Serieid, this.Titre, this.Resume, this.Nbsaisons, this.Nbepisodes, this.Anneecreation, this.Network);
    }
}
