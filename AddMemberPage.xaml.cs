using GymManagmentSystem.Models;
using GymManagmentSystem.Services;

namespace GymManagmentSystem;

public partial class AddMemberPage : ContentPage
{
    public AddMemberPage()
    {
        InitializeComponent();
    }

    private async void OnAddMemberClicked(object sender, EventArgs e)
    {
        // Create a new GymMember object from the input fields.
        var newMember = new GymMember
        {
            Name = NameEntry.Text,
            MembershipPlan = PlanEntry.Text,
        };

        // Insert the new member into the database instead of a local list.
        await DatabaseService.AddMemberAsync(newMember);

        // After adding the member to the database, navigate back to the previous page.
        await Navigation.PopAsync();
    }

    private async void OnDashboardClicked(object sender, EventArgs e)
    {
        // Navigate back to the main page or dashboard.
        await Shell.Current.GoToAsync("///MainPage");
    }
}
