using GymManagmentSystem.Models;
using GymManagmentSystem.Services;

namespace GymManagmentSystem;

public partial class AddBookingPage : ContentPage
{
    public AddBookingPage()
    {
        InitializeComponent();
        LoadDataAsync();
    }

    private async void LoadDataAsync()
    {
        // Fetch members and trainers from DB
        var members = await DatabaseService.GetMembersAsync();
        var trainers = await DatabaseService.GetTrainersAsync();

        MemberPicker.ItemsSource = members.Select(m => m.Name).ToList();
        TrainerPicker.ItemsSource = trainers.Select(t => t.Name).ToList();
    }

    private async void OnAddBookingClicked(object sender, EventArgs e)
    {
        if (MemberPicker.SelectedIndex == -1 || TrainerPicker.SelectedIndex == -1)
        {
            await DisplayAlert("Error", "Please select both a member and a trainer.", "OK");
            return;
        }

        var newBooking = new Booking
        {
            // BookingID could be optional now since ID is primary key, but we can still set it:
            BookingID = 0, // or calculate if needed, but ID is the true PK now.
            MemberName = MemberPicker.SelectedItem.ToString(),
            TrainerName = TrainerPicker.SelectedItem.ToString(),
            Date = BookingDatePicker.Date
        };

        await DatabaseService.AddBookingAsync(newBooking);

        // Navigate back to BookingPage
        await Navigation.PopAsync();
    }

}