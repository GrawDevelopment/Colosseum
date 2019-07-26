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
    public partial class UpComingMoviePage : ContentPage
    {
        private ObservableCollection<UpComingMovie> _upComingMovies;
        public UpComingMoviePage()
        {
            InitializeComponent();

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            _upComingMovies = new ObservableCollection<UpComingMovie>();
            var apiService = new ApiServices();
            var list =  await apiService.GetUpComingMovies();
            foreach (var item in list)
            {
                _upComingMovies.Add(item);
            }

            sfList.ItemsSource = _upComingMovies;
        }
    }
}