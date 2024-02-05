using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSSeriesMvvm.Models;

namespace WSSeriesMvvm.ViewModels
{
    public class GererSerieViewModel : ObservableObject
    {
        private Serie serieToShow;
        public Serie SerieToShow
        {
            get { return this.serieToShow; }
            set
            {
                this.serieToShow = value;
                OnPropertyChanged("SerieToShow");
            }
        }
        public int IdSerie { get; set; }
        public IRelayCommand BtnGetSerie { get; }
        public IRelayCommand BtnPutSerie { get; }
        public IRelayCommand BtnDeleteSerie { get; }

        public GererSerieViewModel()
        {
            this.BtnGetSerie = new RelayCommand(ActionGetSerie);
            this.BtnPutSerie = new RelayCommand(ActionPutSerie);
            this.BtnDeleteSerie = new RelayCommand(ActionDeleteSerie);
        }

        public void ActionGetSerie()
        {

        }
        public void ActionPutSerie()
        {

        }
        public void ActionDeleteSerie()
        {

        }
    }
}
