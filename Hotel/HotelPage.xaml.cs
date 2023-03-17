using Hotel.Models;
using Plugin.LocalNotification;

namespace Hotel;

public partial class HotelPage : ContentPage
{
	public HotelPage()
	{
		InitializeComponent();
	}

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var hotel = (Hotell)BindingContext;
        await App.Database.SaveHotelAsync(hotel);
        await Navigation.PopAsync();
    }

    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var hotel = (Hotell)BindingContext;
        await App.Database.DeleteHotelAsync(hotel);
        await Navigation.PopAsync();
    }

}
