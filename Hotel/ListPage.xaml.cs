using Hotel.Models;

namespace Hotel;

public partial class ListPage : ContentPage
{
	public ListPage()
	{
		InitializeComponent();
	}
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var slist = (ReservationList)BindingContext;
        slist.Date = DateTime.UtcNow;
        await App.Database.SaveReservationListAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (ReservationList)BindingContext;
        await App.Database.DeleteReservationListAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnChooseButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RoomPage((ReservationList)
       this.BindingContext)
        {
            BindingContext = new Room()
        });

    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var shopl = (ReservationList)BindingContext;

        listView.ItemsSource = await App.Database.GetListRoomsAsync(shopl.ID);
    }

}