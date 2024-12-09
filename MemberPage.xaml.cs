using GymManagmentSystem.Models;

namespace GymManagmentSystem;

public partial class MemberPage : ContentPage
{
    private List<GymMember> members = new List<GymMember>();
    public MemberPage()
    {
        InitializeComponent();
    }
    private async void OnAddMemberClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddMemberPage(members));
    }

    private async void OnViewMembersClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Confirmation", "'Confirmation Message Here'", "OK");
    }
    public void RefreshMemberList()
    {
        MemberListView.ItemsSource = null; // Clear the current source
        MemberListView.ItemsSource = members; // Reassign the updated list
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        RefreshMemberList();
    }
    private async void OnDashboardClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///MainPage");
    }

}
