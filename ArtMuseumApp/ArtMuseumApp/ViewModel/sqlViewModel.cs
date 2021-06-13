using ArtMuseumApp.models;
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
    public class sqlViewModel
    {
        public ObservableCollection<ArtObjectDB> sqlart { get; set; }
        public ICommand LoadSqlDataCommand { private set; get; }
        public ICommand DeleteItemCommand { private set; get; }
        public ICommand ShareItemCommand { private set; get; }

        public ArtObjectDB selectedArt { get; set; }
        public  async Task LoadSql()
        {
            List<ArtObjectDB> arts = await App.DbContext.GetItems<ArtObjectDB>();
            sqlart.Clear();
            foreach (ArtObjectDB art in arts)
            {
                sqlart.Add(art);
            }
        }

        private async Task Delete()
        {
            bool op;
            bool answer = await App.Current.MainPage.DisplayAlert("Confirm", "Do you Want to delete From favorites?", "Delete", "Cancel");
            if (answer)
            {
                op = await App.DbContext.DeleteItem<ArtObjectDB>(selectedArt);
                if (op)
                {
                    await LoadSql();
                    await App.Current.MainPage.DisplayAlert("success!", "Item Deleted From favorites...", "OK");
                }
                else
                    await App.Current.MainPage.DisplayAlert("Error!", "Item Was NOT Deleted From favorites...", "OK");
            }
        }
        private async Task Share()
        {
            string answer = await App.Current.MainPage.DisplayActionSheet("Choose...", "Cancel", null, "Via SMS", "Via Email", "Others");
            switch (answer)
            {

                case "Cancel":

                    break;

                case "Via SMS":
                    await Sms.ComposeAsync(new SmsMessage("Titile:\n" + selectedArt.titile + "\n" + "Presented Date:\n" + selectedArt.presentingDate + "\nowner:\n" +
                        selectedArt.principalOrFirstMaker + "\nimage Url\n" + selectedArt.imageUrl,
                       "+420"));
                    break;
                case "Via Email":
                    await Email.ComposeAsync("Art Details", "Titile:\n" + selectedArt.titile + "\n" + "Presented Date:\n" + selectedArt.presentingDate + "\nowner:\n" +
                        selectedArt.principalOrFirstMaker + "\nimage Url\n" + selectedArt.imageUrl, "");
                    break;
                case "Others":
                    await Xamarin.Essentials.Share.RequestAsync(new ShareTextRequest
                    {
                        Text = "Titile:\n" + selectedArt.titile + "\n" + "Presented Date:\n" + selectedArt.presentingDate + "\nowner:\n" +
                        selectedArt.principalOrFirstMaker + "\nimage Url\n" + selectedArt.imageUrl,
                        Title = "Share Text"
                    });
                    break;
            }
        }
        public sqlViewModel()
        {
            sqlart = new ObservableCollection<ArtObjectDB>();
            Task.Run(async () => await LoadSql());
            LoadSqlDataCommand = new Command(async () => await LoadSql());
            ShareItemCommand = new Command(async () => await Share());
            DeleteItemCommand = new Command(async () => await Delete());
        }
    }
}
