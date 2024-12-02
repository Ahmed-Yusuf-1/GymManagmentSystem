using GymManagmentSystem.Models;

namespace GymManagmentSystem;

public partial class AddBookingPage : ContentPage
{
    private List<Booking> bookings;
    private List<GymMember> members;
    private List<Trainer> trainers;

    public AddBookingPage(List<Booking> bookings)
    {
        this.bookings = bookings;
    }

    public AddBookingPage(List<Booking> bookingList, List<GymMember> memberList, List<Trainer> trainerList)
    {
        InitializeComponent();
        bookings = bookingList;
        members = memberList;
        trainers = trainerList;

        
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
            BookingID = bookings.Count + 1,
            MemberName = MemberPicker.SelectedItem.ToString(),
            TrainerName = TrainerPicker.SelectedItem.ToString(),
            Date = BookingDatePicker.Date
        };

        bookings.Add(newBooking);

        
        await Navigation.PopAsync();
    }
}