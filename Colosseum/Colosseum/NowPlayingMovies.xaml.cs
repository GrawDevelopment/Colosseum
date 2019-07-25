using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Colosseum.Model;
using Colosseum.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Colosseum
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NowPlayingMovies : ContentPage
    {
        public ObservableCollection<NowPlayingMovie> NowPlayingMoviesCollection;
        private static bool _first = true;
        public NowPlayingMovies()
        {
            InitializeComponent();
            NowPlayingMoviesCollection = new ObservableCollection<NowPlayingMovie>();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if(!_first)
                return;
            var service = new ApiServices();
            var result = await service.GetNowPlayingMovies();
            foreach (var item in result)
            {
                NowPlayingMoviesCollection.Add(item);
            }
            
            ListNowPlaying.ItemsSource = NowPlayingMoviesCollection;
            _first = false;
        }

        private void ListNowPlaying_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as NowPlayingMovie;
            Navigation.PushAsync(new MovieDetailPage(item));
        }
    }
}