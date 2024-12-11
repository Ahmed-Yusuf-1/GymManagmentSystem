using GymManagmentSystem.Models;
using GymManagmentSystem.Services;

namespace GymManagmentSystem;

public partial class BookingPage : ContentPage
{
    private Booking _selectedBooking;

    public BookingPage()
    {
        InitializeComponent();
    }

    private async void OnAddBookingClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddBookingPage());
    }

    public async void RefreshBookingList()
    {
        var bookingsFromDb = await DatabaseService.GetBookingsAsync();
        BookingListView.ItemsSource = null;
        BookingListView.ItemsSource = bookingsFromDb;

        _selectedBooking = null;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        RefreshBookingList();
    }

    private async void OnDashboardClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///MainPage");
    }

    // Handle booking selection
    private void OnBookingTapped(object sender, ItemTappedEventArgs e)
    {
        if (e.Item is Booking tappedBooking)
        {
            _selectedBooking = tappedBooking;
        }
    }

    private async void OnEditBookingClicked(object sender, EventArgs e)
    {
        if (_selectedBooking != null)
        {
            await Navigation.PushAsync(new EditBookingPage(_selectedBooking));
        }
        else
        {
            await DisplayAlert("Error", "Please select a booking to edit.", "OK");
        }
    }

    // Cancel Booking Button handler
    private async void OnCancelBookingClicked(object sender, EventArgs e)
    {
        if (_selectedBooking != null)
        {
            bool confirm = await DisplayAlert("Confirmation", "Are you sure you want to cancel this booking?", "Yes", "No");
            if (confirm)
            {
                await DatabaseService.RemoveBookingAsync(_selectedBooking);
                RefreshBookingList();
            }
        }
        else
        {
            await DisplayAlert("Error", "Please select a booking to cancel.", "OK");
        }
    }

}