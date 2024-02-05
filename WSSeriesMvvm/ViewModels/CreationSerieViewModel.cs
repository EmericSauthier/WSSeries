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
    public class CreationSerieViewModel : ObservableObject
    {
        private Serie serieToAdd;
        public Serie SerieToAdd {
            get { return this.serieToAdd; }
            set
            {
                this.serieToAdd = value;
                OnPropertyChanged("SerieToAdd");
            }
        }
        public IRelayCommand BtnPostSerie { get; }

        public CreationSerieViewModel()
        {
            this.SerieToAdd = new Serie();

            this.BtnPostSerie = new RelayCommand(ActionPostSerie);
        }

        public async void ActionPostSerie()
        {
            WSService service = new WSService("https://apiseriesemeric.azurewebsites.net/api/series");

            if (String.IsNullOrWhiteSpace(this.SerieToAdd.Titre))
            {
                MessageAsync("Renseignez un titre", "Erreur");
                return;
            }

            var result = await service.PostSerieAsync(this.SerieToAdd);

            if (result)
            {
                this.SerieToAdd = new Serie();
                MessageAsync("Ajout réussi !", "Succès");
            }
            else
            {
                MessageAsync("Echec de l'ajout", "Erreur");
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
