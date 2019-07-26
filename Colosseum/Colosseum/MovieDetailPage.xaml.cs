using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Colosseum.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Colosseum
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MovieDetailPage : ContentPage
    {

        NowPlayingMovie _nowPlayingMoview;

        public MovieDetailPage(NowPlayingMovie nowPlayingMovie)
        {
            InitializeComponent();
            _nowPlayingMoview = nowPlayingMovie;
            LabelMovie.Text = _nowPlayingMoview.MovieName;
            LabelDuration.Text = _nowPlayingMoview.Duration;
            LabelDate.Text = _nowPlayingMoview.PlayingDate.ToLongDateString();
            LabelLanguage.Text = _nowPlayingMoview.Language;
            LabelPg.Text = _nowPlayingMoview.RatedLevel;
            LabelDescription.Text = _nowPlayingMoview.Description;
            LabelGenre.Text = _nowPlayingMoview.Genre;
            LabelStar.Text = _nowPlayingMoview.Cast;
            ImageCover.Source = _nowPlayingMoview.CoverImage;
            BookTicketButton.Clicked += async (sender, args) =>
            {
                await Navigation.PushAsync(new BookTicketPage(_nowPlayingMoview));
            };
        }

        public MovieDetailPage()
        {
            InitializeComponent();
            _nowPlayingMoview = new NowPlayingMovie();
        }

        private async void PlayVideo_OnTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VideoPage(_nowPlayingMoview.MovieTrailor));
        }
    }
}