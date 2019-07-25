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
		public MovieDetailPage (NowPlayingMovie nowPlayingMovie)
		{
			InitializeComponent ();
		}
	}
}