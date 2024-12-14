using GymManagmentSystem.Models;
using GymManagmentSystem.Services;

namespace GymManagmentSystem;

public partial class EditBookingPage : ContentPage
{
    private Booking _bookingToEdit;

    public EditBookingPage(Booking booking)
    {
        InitializeComponent();
        _bookingToEdit = booking;
        BookingDatePicker.Date = _bookingToEdit.Date;
    }

    private async void OnSaveChangesClicked(object sender, EventArgs e)
    {
        _bookingToEdit.Date = BookingDatePicker.Date;


        await DatabaseService.UpdateBookingAsync(_bookingToEdit);

        await Navigation.PopAsync();
    }

    private async void OnCancelClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}
