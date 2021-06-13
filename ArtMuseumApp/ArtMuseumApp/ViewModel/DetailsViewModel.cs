using ArtMuseumApp.models;
using ArtMuseumApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ArtMuseumApp.ViewModel
{
    public class DetailsViewModel:BaseViewModel
    {

        private ArtObject selectedArt;
        public ArtObject localobject
        {
            get { return selectedArt; }
            set { SetProperty(ref selectedArt , value); }
        }
        public ArtObjectDB artData { get; set; }
        public ICommand AddItemCommand { private set; get; }
        public ICommand ShareItemCommand { private set; get; }
        private async Task Additem()
        {
            int id = 1;
            bool op;
            artData.id=id+1;
            artData.titile = localobject.title;
            artData.imageUrl = localobject.webImage.url;
            artData.presentingDate = localobject.dating.presentingDate;
            artData.principalOrFirstMaker = localobject.principalOrFirstMaker;
            artData.longTitle = localobject.longTitle;
            op= await App.DbContext.AddItem(artData);
            if (op)
            {
                sqlViewModel vm = new sqlViewModel();
                await vm.LoadSql();
                await Application.Current.MainPage.DisplayAlert("success!", "Item added to favorites...", "OK");
          
            }
            else
                await Application.Current.MainPage.DisplayAlert("Error!", "Item Was NOT added to favorites...", "OK");
        }
        private async Task loaddata(ArtObject artObject)
        {
            localobject = await ApiService.GetArtDetail(artObject.objectNumber);
        }
        private async Task Share()
        {
            string answer = await App.Current.MainPage.DisplayActionSheet("Choose...", "Cancel", null, "Via SMS", "Via Email", "Others");
            switch (answer)
            {

                case "Cancel":

                    break;

                case "Via SMS":
                    await Sms.ComposeAsync(new SmsMessage("Titile:\n"+localobject.title + "\n" + "Presented Date:\n"+localobject.dating.presentingDate+"\nowner:\n"+
                        localobject.principalOrFirstMaker +"\nimage Url\n"+ localobject.webImage.url,
                       "+420"));
                    break;
                case "Via Email":
                    await Email.ComposeAsync("Art Details", "Titile:\n" + localobject.title + "\n" + "Presented Date:\n" + localobject.dating.presentingDate + "\nowner:\n" +
                        localobject.principalOrFirstMaker + "\nimage Url\n" + localobject.webImage.url, "");
                    break;
                case "Others":
                    await Xamarin.Essentials.Share.RequestAsync(new ShareTextRequest
                    {
                        Text = "Titile:\n" + localobject.title + "\n" + "Presented Date:\n" + localobject.dating.presentingDate + "\nowner:\n" +
                        localobject.principalOrFirstMaker + "\nimage Url\n" + localobject.webImage.url,
                        Title = "Share Text"
                    });
                    break;
            }
        }
        public  DetailsViewModel(ArtObject artObject)
        {
            artData = new ArtObjectDB();
            Task.Run(async () => await loaddata(artObject));
            AddItemCommand = new Command(async () => await Additem());
            ShareItemCommand = new Command(async () => await Share());

        }
    }
}
