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
        public Serie SerieToAdd { get; set; }
        public IRelayCommand BtnPostSerie { get; }

        public CreationSerieViewModel()
        {
            this.SerieToAdd = new Serie();
            this.SerieToAdd.NbSaisons = 0;
            this.SerieToAdd.NbEpisodes = 0;
            this.SerieToAdd.AnneeCreation = 0;

            this.BtnPostSerie = new RelayCommand(ActionPostSerie);
        }

        public void ActionPostSerie()
        {
            WSService service = new WSService("https://apiseriesemeric.azurewebsites.net/api/");


            if (String.IsNullOrWhiteSpace(this.SerieToAdd.Titre))
            {
                MessageAsync("Renseignez un titre", "Erreur");
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
