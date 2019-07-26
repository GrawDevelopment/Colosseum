using System;
using System.Collections.Generic;
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
	public partial class BookTicketPage : ContentPage
    {
        private string _selectedTime = "";
		public BookTicketPage ()
		{
			InitializeComponent ();
		}

        public BookTicketPage(NowPlayingMovie movie)
        {
            InitializeComponent();
            MovieImage.Source = movie.CoverImage;
            Time1Label.Text = movie.ShowTime1.ToShortTimeString();
            Time2Label.Text = movie.ShowTime2.ToShortTimeString();
            Time3Label.Text = movie.ShowTime3.ToShortTimeString();
            UnitPrice.Text = movie.TicketPrice;
            MovieNameLabel.Text = movie.MovieName;
            Picker.SelectedIndex = 0;
            Quantity.Text = Picker.SelectedItem.ToString();

            ButtonBook.Clicked += async (sender, args) =>
            {
                var ticket = new BookTicket();
                ticket.MovieName = MovieNameLabel.Text;
                ticket.Email = EmailEntry.Text;
                ticket.CustomerName = NameEntry.Text;
                ticket.Phone = PhoneEntry.Text;
                ticket.Qty = Quantity.Text;
                ticket.BookingDate = _selectedTime;
                ticket.TotalPayment = TotalPrice.Text;
                var api = new ApiServices();
                var result = await api.PostOrder(ticket);
                if (result)
                {
                    await DisplayAlert("Message", "Your ticket was reserved...", "OK");
                }
                else
                {
                    await DisplayAlert("Error", "Something went wrong....", "OK");
                }

                await Navigation.PopAsync(true);
            };

            Picker.SelectedIndexChanged += (sender, args) =>
            {
                var quantity = int.Parse(Picker.SelectedItem.ToString());
                var unitPrice = int.Parse(UnitPrice.Text);
                var total = quantity * unitPrice;
                Quantity.Text = quantity.ToString();
                TotalPrice.Text = total.ToString();
            };
        }

        private void Tab1_OnTapped(object sender, EventArgs e)
        {
            Frame1.BackgroundColor = Color.LightGray;
            Frame2.BackgroundColor = Color.FromHex("#FF5722");
            Frame3.BackgroundColor = Color.FromHex("#FF5722");
            _selectedTime = Time1Label.Text;
        }

        private void Tab2_OnTapped(object sender, EventArgs e)
        {
            Frame2.BackgroundColor = Color.LightGray;
            Frame1.BackgroundColor = Color.FromHex("#FF5722");
            Frame3.BackgroundColor = Color.FromHex("#FF5722");
            _selectedTime = Time2Label.Text;
        }

        private void Tab3_OnTapped(object sender, EventArgs e)
        {
            Frame3.BackgroundColor = Color.LightGray;
            Frame2.BackgroundColor = Color.FromHex("#FF5722");
            Frame1.BackgroundColor = Color.FromHex("#FF5722");
            _selectedTime = Time3Label.Text;
        }
    }
}