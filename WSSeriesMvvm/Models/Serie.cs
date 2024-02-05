using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSSeriesMvvm.Models
{
    public class Serie
    {
        private int serieId;
        private string titre;
        private string? resume;
        private int? nbSaisons;
        private int? nbEpisodes;
        private int? anneeCreation;
        private string? network;

        public int SerieId
        {
            get
            {
                return serieId;
            }

            set
            {
                serieId = value;
            }
        }
        public string Titre
        {
            get
            {
                return titre;
            }

            set
            {
                titre = value;
            }
        }
        public string Resume
        {
            get
            {
                return resume;
            }

            set
            {
                resume = value;
            }
        }
        public int? NbSaisons
        {
            get
            {
                return nbSaisons;
            }

            set
            {
                nbSaisons = value;
            }
        }
        public int? NbEpisodes
        {
            get
            {
                return nbEpisodes;
            }

            set
            {
                nbEpisodes = value;
            }
        }
        public int? AnneeCreation
        {
            get
            {
                return anneeCreation;
            }

            set
            {
                anneeCreation = value;
            }
        }
        public string Network
        {
            get
            {
                return this.network;
            }

            set
            {
                this.network = value;
            }
        }


        public Serie() { }
        public Serie(int serieid, string titre)
        {
            this.SerieId = serieid;
            this.Titre = titre;
        }
        public Serie(int serieid, string titre, string? resume, int? nbsaisons, int? nbepisodes, int? anneecreation, string? network) : this(serieid, titre)
        {
            this.Resume = resume;
            this.NbSaisons = nbsaisons;
            this.NbEpisodes = nbepisodes;
            this.AnneeCreation = anneecreation;
            this.Network = network;
        }

        public override bool Equals(object? obj)
        {
            return obj is Serie serie &&
                   this.SerieId == serie.SerieId &&
                   this.Titre == serie.Titre &&
                   this.Resume == serie.Resume &&
                   this.NbSaisons == serie.NbSaisons &&
                   this.NbEpisodes == serie.NbEpisodes &&
                   this.AnneeCreation == serie.AnneeCreation &&
                   this.Network == serie.Network;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(this.SerieId, this.Titre, this.Resume, this.NbSaisons, this.NbEpisodes, this.AnneeCreation, this.Network);
        }
    }
}
