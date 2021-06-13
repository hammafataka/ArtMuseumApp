using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Drawing;
using System.Linq;

using ArtMuseumApp.models;
using ArtMuseumApp.Services;
using ArtMuseumApp.View;

using Xamarin.Forms;
using System.Threading.Tasks;


namespace ArtMuseumApp.ViewModel
{
    public class ListViewModel:BaseViewModel
    {
        public ObservableCollection<ArtObject> arts { get; }
        private List<ArtObject> artList;
        private string artname;
        public string ArtName
        {
            get { return artname; }
            set {SetProperty(ref artname , value); }
        }
        private ArtObject selectedArt;

        public ArtObject SelectedArt
        {
            get { return selectedArt; }
            set { SetProperty(ref selectedArt , value); }
        }

        public ICommand LoadDataCommand { private set; get; }
        public ICommand GoToDetailsCommand { private set; get; }
        public async void LoadData()
        {
            IsBusy = true;
            arts.Clear();
            artList = await ApiService.GetArts(artname);
            foreach (ArtObject art in artList.Take(5))
            {
                arts.Add(art);
            }
            IsBusy = false;
        }
        
        private async Task GoToDetail()
        {
            if (SelectedArt != null)
            {
                
                DetailsViewModel viewModel = new DetailsViewModel(SelectedArt);
                ArtDetailsView view = new ArtDetailsView
                {
                    BindingContext = viewModel
                };
                await App.Current.MainPage.Navigation.PushAsync(view);
            }
        }


        public ListViewModel()
        {
            artList = new List<ArtObject>();
            arts = new ObservableCollection<ArtObject>();
            LoadDataCommand = new Command(LoadData);
            GoToDetailsCommand = new Command(async () => await GoToDetail());

        }


    }
}
