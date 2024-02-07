using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSSeriesMvvm.Models;
using WSSeriesMvvm.Services;

namespace WSSeriesMvvm.ViewModels
{
    public class GererSerieViewModel : ObservableObject
    {
        private Serie serieToShow;
        private int idSerie;
        public Serie SerieToShow
        {
            get { return this.serieToShow; }
            set
            {
                this.serieToShow = value;
                OnPropertyChanged("SerieToShow");
            }
        }
        public int IdSerie {
            get { return this.idSerie; }
            set
            {
                this.idSerie = value;
                OnPropertyChanged("IdSerie");
            }
        }
        public IRelayCommand BtnGetSerie { get; }
        public IRelayCommand BtnPutSerie { get; }
        public IRelayCommand BtnDeleteSerie { get; }

        public GererSerieViewModel()
        {
            this.BtnGetSerie = new RelayCommand(ActionGetSerie);
            this.BtnPutSerie = new RelayCommand(ActionPutSerie);
            this.BtnDeleteSerie = new RelayCommand(ActionDeleteSerie);
        }

        public async void ActionGetSerie()
        {
            WSService service = new WSService("https://apiseriesemeric.azurewebsites.net/api/series");

            if (this.IdSerie == 0)
            {
                this.SerieToShow = null;
                MessageAsync("Entrez l'id de la série", "Erreur");
                return;
            }

            var result = await service.GetSerieAsync(this.IdSerie);

            if (result != null)
            {
                this.SerieToShow = result;
            }
            else
            {
                MessageAsync("Série inconnue", "Erreur");
            }
        }
        public async void ActionPutSerie()
        {
            WSService service = new WSService("https://apiseriesemeric.azurewebsites.net/api/series");

            if (this.IdSerie == 0)
            {
                MessageAsync("Sélectionnez une série", "Erreur");
                return;
            }

            if (String.IsNullOrWhiteSpace(this.SerieToShow.Titre))
            {
                MessageAsync("Renseignez un titre", "Erreur");
                return;
            }

            var result = await service.PutSerieAsync(this.SerieToShow.SerieId, this.SerieToShow);

            if (result)
            {
                this.SerieToShow = await service.GetSerieAsync(this.IdSerie);
                MessageAsync("Modification réussie !", "Succès");
            }
            else
            {
                MessageAsync("Echec de la modification", "Erreur");
            }
        }
        public async void ActionDeleteSerie()
        {
            WSService service = new WSService("https://apiseriesemeric.azurewebsites.net/api/series");

            if (this.IdSerie == 0)
            {
                MessageAsync("Sélectionnez une série", "Erreur");
                return;
            }

            var result = await service.DeleteSerieAsync(this.SerieToShow.SerieId);

            if (result)
            {
                this.IdSerie = 0;
                this.SerieToShow = null;
                MessageAsync("Suppression effectuée !", "Succès");
            }
            else
            {
                MessageAsync("Echec de la suppression", "Erreur");
            }
        }

        private async void MessageAsync(string message, string title)
        {
            ContentDialog dialog = new ContentDialog
            {
                Title = title,
                Content = message,
                CloseButtonText = "Ok"
            };

            dialog.XamlRoot = App.MainRoot.XamlRoot;
            ContentDialogResult result = await dialog.ShowAsync();
        }
    }
}
