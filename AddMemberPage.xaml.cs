using GymManagmentSystem.Models;

namespace GymManagmentSystem;

public partial class AddMemberPage : ContentPage
{
    private List<GymMember> members;
    public AddMemberPage(List<GymMember> memberlist)
    {
        InitializeComponent();
        members = memberlist;
    }
    private async void OnAddMemberClicked(object sender, EventArgs e)
    {
        var newMember = new GymMember
        {
            Name = NameEntry.Text,
            MembershipPlan = PlanEntry.Text,
            JoinDate = DateTime.Now
        };

        members.Add(newMember);

        await Navigation.PopAsync();
    }
    private async void OnDashboardClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("///MainPage");
    }
}
