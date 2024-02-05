namespace WSSeries.Models.EntityFramework
{
    public partial class Serie
    {
        public Serie() { }
        public Serie(int serieid, string titre)
        {
            this.Serieid = serieid;
            this.Titre = titre;
        }

        public Serie(int serieid, string titre, string? resume, int? nbsaisons, int? nbepisodes, int? anneecreation, string? network) : this(serieid, titre)
        {
            this.Resume = resume;
            this.Nbsaisons = nbsaisons;
            this.Nbepisodes = nbepisodes;
            this.Anneecreation = anneecreation;
            this.Network = network;
        }


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
}
