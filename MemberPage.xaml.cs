using GymManagmentSystem.Models;
using GymManagmentSystem.Services;  // For DatabaseService

namespace GymManagmentSystem;

public partial class MemberPage : ContentPage
{
    private GymMember _selectedMember;

    public MemberPage()
    {
        InitializeComponent();
    }

    private async void OnAddMemberClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddMemberPage());
    }


    private void OnMemberTapped(object sender, ItemTappedEventArgs e)
    {
        if (e.Item is GymMember tappedMember)
        {
            _selectedMember = tappedMember;
        }
    }

    private async void OnEditMemberClicked(object sender, EventArgs e)
    {
        try
        {
            if (_selectedMember != null)
            {
                // Navigate to EditMemberPage, passing the selected member
                await Navigation.PushAsync(new EditMemberPage(_selectedMember));
            }
            else
            {
                await DisplayAlert("Error", "Please select a member to edit", "OK");
            }
        }
        catch (Exception ex)
        {
            // Display the caught exception message in a friendly alert
            await DisplayAlert("Unexpected Error", $"An error occurred: {ex.Message}", "OK");
        }
    }



    private async void OnClearMembersClicked(object sender, EventArgs e)
{
    bool confirm = await DisplayAlert("Confirmation", "Are you sure you want to clear all members?", "Yes", "No");
    if (confirm)
    {
        // Call the database method to clear all members
        await DatabaseService.ClearAllMembersAsync();

        // Refresh the list to show that it's now empty
        RefreshMemberList();
    }
}


    public async void RefreshMemberList()
    {
        var membersFromDb = await DatabaseService.GetMembersAsync();
        MemberListView.ItemsSource = null;
        MemberListView.ItemsSource = membersFromDb;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        RefreshMemberList();
    }

    private async void OnDashboardClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }
}
