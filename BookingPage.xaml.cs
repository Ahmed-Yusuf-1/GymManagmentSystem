using GymManagmentSystem.Models;

namespace GymManagmentSystem;

public partial class BookingPage : ContentPage
{
    private List<Booking> bookings = new List<Booking>();

    public BookingPage()
    {
        InitializeComponent();
    }

    private async void OnAddBookingClicked(object sender, EventArgs e)
    {
        // Navigate to AddBookingPage and pass the booking list
        await Navigation.PushAsync(new AddBookingPage(bookings));
    }

    public void RefreshBookingList()
    {
        BookingListView.ItemsSource = null; // Clear the current source
        BookingListView.ItemsSource = bookings; // Reassign the updated list
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        RefreshBookingList();
    }
}